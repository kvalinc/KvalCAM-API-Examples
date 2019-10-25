using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvalCAMAPIClient
{
    public static class JsonObjectFactory
    {
        public static JObject CreateFeatureGroupLocation(string lLocation, string tLocation, string wLocation)
        {
            return new JObject
            {
                ["LLocation"] = lLocation,
                ["TLocation"] = tLocation,
                ["WLocation"] = wLocation
            };
        }

        public static JObject CreateDoorData(string length, string width, string thickness)
        {
            return new JObject
            {
                ["Length"] = length,
                ["Width"] = width,
                ["Thickness"] = thickness
            };
        }

        public static JObject CreateCircle(string name, string doorSide, string lLocation, string wLocation, string tLocation, string diameter, string depth)
        {
            return new JObject
            {
                ["Type"] = "Circle",
                ["Name"] = name,
                ["DoorSide"] = doorSide,
                ["LLocation"] = lLocation,
                ["TLocation"] = tLocation,
                ["WLocation"] = wLocation,
                ["Diameter"] = diameter,
                ["Depth"] = depth,
                ["Bevel"] = "0",
                ["DiameterMinimum"] = "Diameter",
                ["DiameterMaximum"] = "Diameter",
                ["DepthMinimum"] = "Depth",
                ["DepthMaximum"] = "Depth"
            };
        }
    }
}
