﻿using System;
namespace XanhNest.BackEndServer.Application.Settings
{
	public class JwtSetting
    {
		public string SecretKey {get; set;}
        public string Issuer {get; set;}
        public string Audience { get; set;}
    }
}

