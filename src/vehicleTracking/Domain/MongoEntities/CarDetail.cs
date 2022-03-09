using Core.Persistence.MongoDb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MongoEntities
{
    public class CarDetail : MongoEntity
    {
        public int ValueOne { get; set; }
        public string ValueTwo { get; set; }
    }
}