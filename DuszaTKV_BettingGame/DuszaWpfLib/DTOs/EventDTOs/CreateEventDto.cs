using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuszaTKVGameLib.DTOs.EventDTOs
{
    public class CreateEventDto
    {
        public string GameName { get; set; } = "";
        public string Name { get; set; } = "";
        public string Subject { get; set; } = "";

    }
}
