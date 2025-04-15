﻿using System.Net;

namespace EmailService.Utillity
{
    public class LocalInfo
    {
        public static string GetLocalIP()
        {
            string hostName = Dns.GetHostName();

            string IP = Dns.GetHostByName(hostName).AddressList[1].ToString();

            return IP;
        }
    }
}
