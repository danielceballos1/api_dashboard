﻿using System;
namespace dashboard_api.Models
{
	public class Server
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOnline { get; set; }
    }
}
