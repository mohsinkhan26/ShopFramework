/* 
 * Author : Mohsin Khan
 * LinkedIn : http://pk.linkedin.com/in/mohsinkhan26/
 * Github : https://github.com/mohsinkhan26/
 * BitBucket : https://bitbucket.org/mohsinkhan26/ 
*/

using Newtonsoft.Json;

namespace MK.ShopFramework.Data
{
    public class ShopBundleModel
    {
        [JsonProperty(PropertyName = "Item1")]
        public string Item1 { get; private set; }

        [JsonProperty(PropertyName = "Item2")]
        public string Item2 { get; private set; }

        [JsonProperty(PropertyName = "Item3")]
        public string Item3 { get; private set; }
    }
}