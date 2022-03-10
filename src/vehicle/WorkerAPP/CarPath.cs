/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using CsvHelper.Configuration.Attributes;

namespace WorkerAPP
{
    public class CarPath
    {
        #region Properties

        [Index(0)]
        public DateTime DateTime { get; set; }

        [Index(1)]
        public decimal Latitute { get; set; }

        [Index(2)]
        public decimal Longitude { get; set; }

        [Index(3)]
        public int NumberPlate { get; set; }

        #endregion Properties
    }
}