/* 
 * Author : Mohsin Khan
 * LinkedIn : http://pk.linkedin.com/in/mohsinkhan26/
 * Github : https://github.com/mohsinkhan26/
 * BitBucket : https://bitbucket.org/mohsinkhan26/ 
*/

using Newtonsoft.Json;

namespace MK.ShopFramework.Data
{
    public class ShopModel
    {
        [JsonProperty(PropertyName = "ItemID")]
        public int ItemID { get; private set; }

        [JsonProperty(PropertyName = "ItemType")]
        public string ItemType { get; private set; }

        [JsonProperty(PropertyName = "ItemName")]
        public string ItemName { get; private set; }

        [JsonProperty(PropertyName = "Quantity")]
        public int Quantity { get; private set; }

        [JsonProperty(PropertyName = "Consume")]
        public string Consume { get; private set; }

        [JsonProperty(PropertyName = "Price")]
        public float Price { get; private set; }

        [JsonProperty(PropertyName = "SmallImage")]
        public string SmallImage { get; private set; }

        [JsonProperty(PropertyName = "BigImage")]
        public string BigImage { get; private set; }

        [JsonProperty(PropertyName = "Description")]
        public string Description { get; private set; }

        [JsonProperty(PropertyName = "Bundle")]
        public ShopBundleModel Bundle { get; private set; }
    }
}