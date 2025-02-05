using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuszaTKVGameLib.DTOs.BetDTOs
{
    public class UpdateBetDto
    {
        public int SubjectId { get; set; }
        public string Result { get; set; } = string.Empty;
        public int Stake { get; set; }
    }
}
