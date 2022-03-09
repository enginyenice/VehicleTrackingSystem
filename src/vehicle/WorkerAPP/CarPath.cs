using CsvHelper.Configuration.Attributes;

namespace WorkerAPP
{
    public class CarPath
    {
        [Index(0)]
        public DateTime DateTime { get; set; }

        [Index(1)]
        public decimal Latitute { get; set; }

        [Index(2)]
        public decimal Longitude { get; set; }

        [Index(3)]
        public int NumberPlate { get; set; }
    }
}