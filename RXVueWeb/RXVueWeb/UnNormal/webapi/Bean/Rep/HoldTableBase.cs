namespace webapi.Bean.Rep
{
    public class HoldTableBase
    {

        public double avg_Hold { get; set; }
        public string? Dept { get; set; }

        public double Hold__12 { get; set; }
        public double Hold__48 { get; set; }
        public int number_12 { get; set; }
        public int number_48 { get; set; }
        public double Target_0 { get; set; }

        public double Target_12 { get; set; }
        public double Target_48 { get; set; }
        public double Total_HoldNumber { get; set; }
        public double Total_HoldTime { get; set; }
    }
}