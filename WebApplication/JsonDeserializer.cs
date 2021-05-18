using System.Collections.Generic;

namespace WebApplication
{
    public class Wind10m
    {
        public string direction { get; set; }
        public int speed { get; set; }
    }

    public class Datasery
    {
        public int timepoint { get; set; }
        public int cloudcover { get; set; }
        public int seeing { get; set; }
        public int transparency { get; set; }
        public int lifted_index { get; set; }
        public int rh2m { get; set; }
        public Wind10m wind10m { get; set; }
        public int temp2m { get; set; }
        public string prec_type { get; set; }
    }

    public class Root
    {
        public string product { get; set; }
        public string init { get; set; }
        public List<Datasery> dataseries { get; set; }
    }
}