﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sneakers.DTO.HelperModels.Jwt
{
    public class JwtCustomClaims
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
    }
}