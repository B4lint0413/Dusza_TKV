﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuszaTKVGameLib.DTOs.UserDTOs
{
    public class CreateUserDto
    {
        public string Name { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
