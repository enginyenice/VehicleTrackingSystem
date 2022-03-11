/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarPaths.Dtos
{
    public class CarPathDto
    {
        #region Properties

        public DateTime DateTime { get; set; }
        public string Id { get; set; }
        public decimal Latitute { get; set; }

        public decimal Longitude { get; set; }

        public int NumberPlate { get; set; }

        #endregion Properties
    }
}