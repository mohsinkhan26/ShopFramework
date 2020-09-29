using MK.ShopFramework.Core;

namespace MK.ShopFramework.Example
{
    public class ShopEntry : ShopItem
    {
        ShopUI shopUI;

        public void SetShopItem(ShopUI _shopUI, int _shopItemId)
        {
            shopUI = _shopUI;
            SetShopItem(_shopItemId);
        }

        public void ShopItemClicked()
        {
            shopUI.ShowShopView(shopDetail.itemID);
        }
    }
}
