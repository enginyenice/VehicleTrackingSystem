using Core.Persistence.MongoDb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MongoEntities
{
    public class CarPath : MongoEntity
    {
        public DateTime DateTime { get; set; }

        public decimal Latitute { get; set; }

        public decimal Longitude { get; set; }

        public int NumberPlate { get; set; }
    }
}