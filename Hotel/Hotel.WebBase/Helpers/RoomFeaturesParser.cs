using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.WebBase.Helpers
{
    public class RoomFeaturesParser
    {
        public static List<string> Parse(string featuresJson)
        {
            var features = new List<string>();
            if (!string.IsNullOrEmpty(featuresJson))
            {
                try
                {
                    features = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(featuresJson);
                }
                catch { }
            }
            return features;
        }
    }
}
