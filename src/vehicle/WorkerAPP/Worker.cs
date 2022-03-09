using Core.MessageBroker.RabbitMQ;
using CsvHelper;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Globalization;
using System.Text;
using System.Text.Json;

namespace WorkerAPP
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private IRabbitMQPublisher<CarPath> _rabbitMQPublisher;
        private List<CarPath> carPaths;

        public Worker(ILogger<Worker> logger, IRabbitMQPublisher<CarPath> rabbitMQPublisher)
        {
            _logger = logger;
            _rabbitMQPublisher = rabbitMQPublisher;

            using (var reader = new StreamReader(@".\vehicleData.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                carPaths = csv.GetRecords<CarPath>().ToList();
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var senderCarPaths = carPaths.Where(p => p.DateTime > DateTime.Now.AddMinutes(-360) && p.DateTime < DateTime.Now).ToList();
                senderCarPaths.ForEach(p => _rabbitMQPublisher.Publish(p));
                _logger.LogInformation($"{senderCarPaths.Count} car path sended.");
                await Task.Delay((1000 * 60), stoppingToken);
            }
        }
    }
}