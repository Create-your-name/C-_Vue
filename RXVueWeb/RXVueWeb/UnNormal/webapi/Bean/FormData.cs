using System.Security.Cryptography.X509Certificates;

namespace webapi.Bean
{
    public class FormData
    {
        public record Data(

        string? f_Cause_Range,

        string? f_Equip_ID,

        string? f_Idea,

        string? f_LOT,

        string? f_OP_Class,

        string? f_OP_Depart,

        string? f_OP_Level,

        string? f_OP_Pheno,

        string? f_Pro,

        string? f_Pro_Kind,

        string? f_Product_name,

        string? f_ReHu,

        string? f_Res_Depart,

        string? f_Res_Depart_2,

        string? activityBeginTime2,

        string? activityEndTime2,

        string? activityBeginTime,

        string? activityEndTime,

        string? f_Yc_Odd,

        string? f_bf_NoNull,

        string? region,

        string? region2,

        string? status

            );

    }
}
