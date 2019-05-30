using System.Collections.Generic;

namespace Betsolutions.Casino.SDK.Internal.DTO
{
    internal class Product
    {
        public int ProductId { get; set; }
        public IEnumerable<Game.Game> Games { get; set; }
    }
}