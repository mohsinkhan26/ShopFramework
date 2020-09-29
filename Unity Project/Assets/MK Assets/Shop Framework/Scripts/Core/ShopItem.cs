/* 
 * Author : Mohsin Khan
 * LinkedIn : http://pk.linkedin.com/in/mohsinkhan26/
 * Github : https://github.com/mohsinkhan26/
 * BitBucket : https://bitbucket.org/mohsinkhan26/ 
*/

using MK.ShopFramework.Data;
using UnityEngine;
using UnityEngine.UI;

namespace MK.ShopFramework.Core
{
    public class ShopItem : MonoBehaviour
    {
        [SerializeField] ShopData shopData;
        [SerializeField] ShopDesign shopDesign;
        ShopDetail shopDetail;

        [SerializeField] private Text itemName;
        [SerializeField] private Image backgroundImage;
        [SerializeField] private Image itemImage;

        public virtual void SetShopItem(int shopItemId)
        {
            shopDetail = shopData.GetItem(shopItemId);

            // itemImage.raycastTarget = shopDesign.GetImagePreset(shopDetail.IsABundle).preset;
        }
    }
}