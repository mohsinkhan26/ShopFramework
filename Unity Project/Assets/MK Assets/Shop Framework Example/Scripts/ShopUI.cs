using UnityEngine;
using MK.ShopFramework.Data;

namespace MK.ShopFramework.Example
{
    public class ShopUI : MonoBehaviour
    {
        [SerializeField] ShopData shopData;

        [SerializeField] Transform container;
        [SerializeField] GameObject shopItemPrefab;

        [Header("Item Details")]
        [SerializeField] GameObject shopViewGO;
        [SerializeField] ShopView shopView;

        // Start is called before the first frame update
        void Start()
        {
            PopulateShop();
        }

        void PopulateShop()
        {
            // TODO: better to use pooling over here for a proper game
            int containerChildCount = container.childCount;
            for (int i = containerChildCount - 1; i >= 0; --i)
            { // delete all the children
                Destroy(transform.GetChild(i).gameObject);
            }

            int shopItemsCount = shopData.TotalShopProducts;
            for (int i = 0; i < shopItemsCount; ++i)
            {
                GameObject go = GameObject.Instantiate(shopItemPrefab, container, false);
                go.transform.SetParent(container, false);
                go.GetComponent<ShopEntry>().SetShopItem(this, shopData.AllShopProducts[i].itemID);
            }
        }

        public void LoadShopItems()
        {
            PopulateShop();
        }

        public void ShowShopView(int itemID)
        {
            shopViewGO.SetActive(true);
            shopView.SetShopView(itemID);
        }
    }
}
