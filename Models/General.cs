using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 以GeoJSON格式顯示路線的點位
    /// </summary>
    public class Geometry
    {
        public float[][] coordinates { get; set; }
        public string type { get; set; }
    }

    /// <summary>
    /// 路徑的基本屬性
    /// </summary>
    public abstract class RouteBase
    {
        /// <summary>
        /// 路程長度，單位為公尺
        /// </summary>
        public float distance { get; set; }

        /// <summary>
        /// The calculated weight of the route.
        /// </summary>
        public double weight { get; set; }

        /// <summary>
        /// 預估旅行時間，單位為秒
        /// </summary>
        public float duration { get; set; }
    }

}
