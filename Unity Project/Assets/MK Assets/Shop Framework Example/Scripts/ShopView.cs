using UnityEngine;
using UnityEngine.UI;
using MK.ShopFramework.Data;

namespace MK.ShopFramework.Example
{
    public class ShopView : MonoBehaviour
    {
        [SerializeField] ShopData shopData;
        [SerializeField] ShopDesign shopDesign;

        [SerializeField] Text itemName;
        [SerializeField] Text itemDescription;
        [SerializeField] Text itemPrice;
        [SerializeField] Image backgroundImage;
        [SerializeField] Image itemImage;

        public void SetShopView(int _shopItemId)
        {
            ShopDetail shopDetail = shopData.GetItem(_shopItemId);

            itemName.text = shopDetail.itemName;
            itemDescription.text = shopDetail.itemDescription;
            itemPrice.text = "$" + shopDetail.itemPrice.ToString();
            backgroundImage.sprite = shopDetail.bigSprite;
            itemImage.sprite = shopDetail.smallSprite;
        }

        public void CloseClicked()
        {
        }
    }
}
