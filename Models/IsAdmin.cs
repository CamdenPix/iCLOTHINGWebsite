using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iCLOTHINGWebsite.Models
{
    public class IsAdmin
    {
        public IsAdmin(bool s) 
        {
            state = s;
        }
        public bool state { get; set; }
    }
}