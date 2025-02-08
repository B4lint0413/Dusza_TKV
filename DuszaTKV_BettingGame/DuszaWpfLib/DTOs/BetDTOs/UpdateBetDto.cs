using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuszaTKVGameLib.DTOs.BetDTOs
{
    public class UpdateBetDto
    {
        public string Subject { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;
        public int Stake { get; set; }
    }
}
