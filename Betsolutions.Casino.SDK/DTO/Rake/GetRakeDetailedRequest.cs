using System;

namespace Betsolutions.Casino.SDK.DTO.Rake
{
    public class GetRakeDetailedRequest
    {
        public string UserId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? GameId { get; set; }
    }
}
