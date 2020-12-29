using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MePostWebApp.Models
{
    public static class Misc
    { 
        public static readonly AramexWS.WebService1 WsAramexUZ;

        static Misc()
        {
            const int timeout = 1000 * 60 * 10;
            WsAramexUZ = new AramexWS.WebService1();
            WsAramexUZ.UseDefaultCredentials = true;
            WsAramexUZ.Timeout = timeout;
        }
    }
}