using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temp
{

    public class Rootobject
    {
        public string code { get; set; }
        public Matching[] matchings { get; set; }
        public Tracepoint[] tracepoints { get; set; }
    }

    public class Matching
    {
        public float confidence { get; set; }
        public string geometry { get; set; }
        public Leg[] legs { get; set; }
        public float distance { get; set; }
        public float duration { get; set; }
        public string weight_name { get; set; }
        public float weight { get; set; }
    }

    public class Leg
    {
        public Annotation annotation { get; set; }
        public Step[] steps { get; set; }
        public float distance { get; set; }
        public float duration { get; set; }
        public string summary { get; set; }
        public float weight { get; set; }
    }

    public class Annotation
    {
        public long[] nodes { get; set; }
        public int[] datasources { get; set; }
        public float[] speed { get; set; }
        public float[] weight { get; set; }
        public float[] duration { get; set; }
        public float[] distance { get; set; }
    }

    public class Step
    {
        public Intersection[] intersections { get; set; }
        public string geometry { get; set; }
        public string mode { get; set; }
        public float duration { get; set; }
        public Maneuver maneuver { get; set; }
        public float weight { get; set; }
        public float distance { get; set; }
        public string name { get; set; }
    }

    public class Maneuver
    {
        public int bearing_after { get; set; }
        public string type { get; set; }
        public string modifier { get; set; }
        public int bearing_before { get; set; }
        public float[] location { get; set; }
    }

    public class Intersection
    {
        public int _out { get; set; }
        public bool[] entry { get; set; }
        public int[] bearings { get; set; }
        public float[] location { get; set; }
        public int _in { get; set; }
    }

    public class Tracepoint
    {
        public int alternatives_count { get; set; }
        public int waypoint_index { get; set; }
        public float[] location { get; set; }
        public string name { get; set; }
        public string hint { get; set; }
        public int matchings_index { get; set; }
    }
}
