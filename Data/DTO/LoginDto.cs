﻿using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class LoginDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        [JsonIgnore]
        public RoleEnum? Role { get; set; }
    }
}
