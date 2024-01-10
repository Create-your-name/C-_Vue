using Microsoft.AspNetCore.Mvc;

namespace webapi.Bean.Rep
{
    public class FabLot
    {
        public record StageWipDate(

             string? Process,
             string? Product

         );

        public record DateTimeInfo(

           string? activityBeginTime,
           string? activityEndTime
          );

    }
}
