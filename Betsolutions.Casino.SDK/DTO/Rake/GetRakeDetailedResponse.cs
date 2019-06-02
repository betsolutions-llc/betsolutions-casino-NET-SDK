using System.Collections.Generic;

namespace Betsolutions.Casino.SDK.DTO.Rake
{
    public class GetRakeDetailedResponse
    {
        public IEnumerable<RakeDetailedItem> RakeData { get; set; }
    }
}