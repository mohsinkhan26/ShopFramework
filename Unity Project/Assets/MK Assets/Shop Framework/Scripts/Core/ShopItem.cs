/* 
 * Author : Mohsin Khan
 * LinkedIn : http://pk.linkedin.com/in/mohsinkhan26/
 * Github : https://github.com/mohsinkhan26/
 * BitBucket : https://bitbucket.org/mohsinkhan26/ 
*/

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Presets;
#endif
using UnityEngine.UI;
using MK.Common;
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

#if UNITY_EDITOR
        [ContextMenu("Set Product Preset")]
        public void SetProductPreset()
        {
            string filePath = shopDesign.PresetFolderReference + "/";
            if (shopDesign.GetTextPreset(false).CanBeAppliedTo(itemName))
            { // somewhow to Apply preset in Editor mode, Preset need to be loaded from the path
                Preset preset = AssetDatabase.LoadAssetAtPath<Preset>(filePath + shopDesign.GetTextPreset(false).name);
                this.Log("SetProductPreset-Text-Success: " + preset.ApplyTo(itemName));
            }
            if (shopDesign.GetImagePreset(false).CanBeAppliedTo(itemImage))
            {
                Preset preset = AssetDatabase.LoadAssetAtPath<Preset>(filePath + shopDesign.GetImagePreset(false).name);
                this.Log("SetProductPreset-Image-Success: " + preset.ApplyTo(itemImage));
            }
            if (shopDesign.GetBackgroundImagePreset(false).CanBeAppliedTo(backgroundImage))
            {
                Preset preset = AssetDatabase.LoadAssetAtPath<Preset>(filePath + shopDesign.GetBackgroundImagePreset(false).name);
                this.Log("SetProductPreset-BackgroundImage-Success: " + preset.ApplyTo(backgroundImage));
            }
        }

        [ContextMenu("Set Bundle Preset")]
        public void SetBundlePreset()
        {
            string filePath = shopDesign.PresetFolderReference + "/";
            if (shopDesign.GetTextPreset(true).CanBeAppliedTo(itemName))
            { // somewhow to Apply preset in Editor mode, Preset need to be loaded from the path
                Preset preset = AssetDatabase.LoadAssetAtPath<Preset>(filePath + shopDesign.GetTextPreset(true).name);
                this.Log("SetBundlePreset-Text-Success: " + preset.ApplyTo(itemName));
            }
            if (shopDesign.GetImagePreset(true).CanBeAppliedTo(itemImage))
            {
                Preset preset = AssetDatabase.LoadAssetAtPath<Preset>(filePath + shopDesign.GetImagePreset(true).name);
                this.Log("SetBundlePreset-Image-Success: " + preset.ApplyTo(itemImage));
            }
            if (shopDesign.GetBackgroundImagePreset(true).CanBeAppliedTo(backgroundImage))
            {
                Preset preset = AssetDatabase.LoadAssetAtPath<Preset>(filePath + shopDesign.GetBackgroundImagePreset(true).name);
                this.Log("SetBundlePreset-BackgroundImage-Success: " + preset.ApplyTo(backgroundImage));
            }
        }
#endif
    }
}