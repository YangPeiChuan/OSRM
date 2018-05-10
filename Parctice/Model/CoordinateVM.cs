using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parctice.Model
{
    public class CoordinateVM
    {
        public int Index { get; set; }

        /// <summary>
        /// 經度(120~122)
        /// </summary>
        public double Longitude { get; set; }
        /// <summary>
        /// 緯度(22~25)
        /// </summary>
        public double Latitude { get; set; }
        public override string ToString()
        {
            return Longitude + "," + Latitude;
        }

        public bool? IsMatch { get; set; }

        public string JsonString { get; set; }
    }
}
