using System.Collections.Generic;

namespace Betsolutions.Casino.SDK.Internal.DTO.Rake
{
    internal class GetRakeResponse
    {
        public IEnumerable<RakeItem> RakeData { get; set; }
    }
}