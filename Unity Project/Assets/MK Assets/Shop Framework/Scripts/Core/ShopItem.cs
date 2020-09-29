/* 
 * Author : Mohsin Khan
 * LinkedIn : http://pk.linkedin.com/in/mohsinkhan26/
 * Github : https://github.com/mohsinkhan26/
 * BitBucket : https://bitbucket.org/mohsinkhan26/ 
*/

using UnityEngine;
using UnityEngine.UI;
using MK.ShopFramework.Data;

namespace MK.ShopFramework.Core
{
    public class ShopItem : MonoBehaviour
    {
        [SerializeField] protected ShopData shopData;
        [SerializeField] protected ShopDesign shopDesign;
        protected ShopDetail shopDetail;

        [SerializeField] protected Text itemName;
        [SerializeField] protected Text itemPrice;
        [SerializeField] protected Image backgroundImage;
        [SerializeField] protected Image itemImage;

        protected void SetShopItem(int _shopItemId)
        {
            shopDetail = shopData.GetItem(_shopItemId);

            // TODO: perform entry styling
            // itemImage.raycastTarget = shopDesign.GetImagePreset(shopDetail.IsABundle).preset;

            // set text and images of the entry
            itemName.text = shopDetail.itemName;
            itemPrice.text = "$" + shopDetail.itemPrice.ToString();
            backgroundImage.sprite = shopDetail.bigSprite;
            itemImage.sprite = shopDetail.smallSprite;
        }
    }
}