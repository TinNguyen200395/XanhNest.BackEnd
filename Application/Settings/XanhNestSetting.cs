using System;
namespace XanhNest.BackEndServer.Application.Settings
{
	public class XanhNestSetting
	{
        public static XanhNestSetting Instance { get; set; }
        public AuthSetting Auth { get; set; }
    }
}

