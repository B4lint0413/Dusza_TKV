using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuszaTKVGameLib.DTOs.BetDTOs
{
    public class CreateBetDto
    {
        public int UserId { get; set; }
        public int GameId { get; set; }
        public string Subject { get; set; } = string.Empty;
        public int EventId { get; set; }
        public string Result { get; set; } = string.Empty;
        public int Stake { get; set; }
    }
}
