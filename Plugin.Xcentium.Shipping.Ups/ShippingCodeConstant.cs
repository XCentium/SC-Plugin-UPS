using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plugin.Xcentium.Shipping.Ups
{
    public static class ShippingCodeConstant
    {
        public static Dictionary<string,string> Method = new Dictionary<string, string>()
        {
            {"01","UPS Next Day Air" },
            {"02","UPS Second Day Air" },
            {"03","UPS Ground" },
            {"07","UPS Worldwide Express" },
            {"08","UPS Worldwide Expedited" },
            {"11","UPS Standard" },
            {"12","UPS Three-Day Select" },
            {"13","Next Day Air Saver" },
            {"14","UPS Next Day Air Early AM" },
            {"54","UPS Worldwide Express Plus" },
            {"59","UPS Second Day Air AM" },
            {"65","UPS Saver" },
        };
    }
}
