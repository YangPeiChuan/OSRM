using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parctice.Model
{
    public class CityVM
    {
        public string RouteID { get; set; }
        public Routename RouteName { get; set; }
        public DateTime UpdateTime { get; set; }
        public int VersionID { get; set; }
        public string RouteNameZh_tw { get { return RouteName.Zh_tw; } }
        public string RouteNameEn { get { return RouteName.En; } }
    }

    public class Routename
    {
        public string Zh_tw { get; set; }
        public string En { get; set; }
    }
}
