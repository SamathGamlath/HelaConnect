﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelaConnectApp.Data.Models
{
    public class Favorite
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        // Navigation properties
        public Post Post { get; set; }
        public User User { get; set; }
    }
}