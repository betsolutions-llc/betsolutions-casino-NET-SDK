using System.Collections.Generic;

namespace Betsolutions.Casino.SDK.DTO.Rake
{
    public class GetRakeResponse
    {
        public IEnumerable<RakeItem> RakeData { get; set; }
    }
}