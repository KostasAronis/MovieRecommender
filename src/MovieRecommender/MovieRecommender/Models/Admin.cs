﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommender.Models
{
    public class Admin : BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
