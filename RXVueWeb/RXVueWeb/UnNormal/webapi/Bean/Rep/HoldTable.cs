using Microsoft.AspNetCore.Mvc;

namespace webapi.Bean.Rep
{
    public class HoldTable
    {
        public HoldTable(string? dept)
        {
            this.Dept = dept;
            this.Hold__12 = "0";
            this.Hold__48 = "0";
            this.number_12 = 0;
            this.number_24 = 0;
            this.number_48 = 0;
            this.Target_0 = "0";
            this.Target_12 = "0";
            this.Target_48 = "0";
            this.Total_HoldNumber = "0";
            this.Total_HoldTime = "0";
            this.TotalNum = 0;
            this.Hold_bl = "0";
            this.avg_Hold = "0";

        }

        public HoldTable(string avg_Hold, string? dept, string hold__12, string hold__48, int number_12, int number_48, string target_0, string target_12, string target_48, string total_HoldNumber, string total_HoldTime, int TotalNum,string hold_bl) : this(avg_Hold)
        {
            this.Dept = dept;
            this.Hold__12 = hold__12;
            this.Hold__48 = hold__48;
            this.number_12 = number_12;
            this.number_48 = number_48;
            this.Target_0 = target_0;
            this.Target_12 = target_12;
            this.Target_48 = target_48;
            this.Total_HoldNumber = total_HoldNumber;
            this.Total_HoldTime = total_HoldTime;
            this.TotalNum = TotalNum;
            this.Hold_bl = hold_bl;
        }

        public string avg_Hold { get; set; }
        public string? Dept { get; set; }

        public string Hold__12 { get; set; }
        public string Hold__48 { get; set; }
        public int number_12 { get; set; }

        public int number_48 { get; set; }
        public int number_24 { get; set; }
        public int TotalNum { get; set; }
        public string Target_0 { get; set; }

        public string Target_12 { get; set; }
        public string Target_48 { get; set; }
        public string Total_HoldNumber { get; set; }
        public string Total_HoldTime { get; set; }

        public string  Hold_bl{get; set ;}
    }

}
