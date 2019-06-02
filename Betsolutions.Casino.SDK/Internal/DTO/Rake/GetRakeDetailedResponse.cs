using System.Collections.Generic;

namespace Betsolutions.Casino.SDK.Internal.DTO.Rake
{
    internal class GetRakeDetailedResponse
    {
        public IEnumerable<RakeDetailedItem> RakeData { get; set; }
    }
}