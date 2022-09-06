using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doggo
{
    public static class SD
    {
        public static string ItemAPIBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
