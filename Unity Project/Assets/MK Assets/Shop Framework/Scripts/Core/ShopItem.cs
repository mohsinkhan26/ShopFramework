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

        [SerializeField] protected Sprite[] background;
        [SerializeField] protected Text itemName;
        [SerializeField] protected Text itemPrice;
        [SerializeField] protected Image backgroundImage;
        [SerializeField] protected Image itemImage;

        protected void SetShopItem(int _shopItemId)
        {
            shopDetail = shopData.GetItem(_shopItemId);

            // TODO: perform entry styling
#if UNITY_EDITOR
            if (shopDetail.IsABundle) SetBundlePreset();
            else SetProductPreset();
#endif

            // set text and images of the entry
            itemName.text = shopDetail.itemName;
            itemPrice.text = "$" + shopDetail.itemPrice.ToString();
            //backgroundImage.sprite = shopDetail.bigSprite; // TODO: should set background image
            backgroundImage.sprite = background[shopDetail.IsABundle ? 0 : 1];
            itemImage.sprite = shopDetail.smallSprite;
        }

#if UNITY_EDITOR
        [ContextMenu("Set Product Preset")]
        public void SetProductPreset()
        {
            string filePath = shopDesign.PresetFolderPath + "/";
            if (shopDesign.GetTextPreset(false).CanBeAppliedTo(itemName))
            { // somewhow to Apply preset in Editor mode, Preset need to be loaded from the path
                Preset preset = AssetDatabase.LoadAssetAtPath<Preset>(filePath + shopDesign.GetTextPreset(false).name + ".preset");
                this.Log("SetProductPreset-Text-Success: " + preset.ApplyTo(itemName));
            }
            if (shopDesign.GetTextPreset(false).CanBeAppliedTo(itemPrice))
            {
                Preset preset = AssetDatabase.LoadAssetAtPath<Preset>(filePath + shopDesign.GetTextPreset(false).name + ".preset");
                this.Log("SetProductPreset-TextPrice-Success: " + preset.ApplyTo(itemPrice));
            }
            if (shopDesign.GetImagePreset(false).CanBeAppliedTo(itemImage))
            {
                Preset preset = AssetDatabase.LoadAssetAtPath<Preset>(filePath + shopDesign.GetImagePreset(false).name + ".preset");
                this.Log("SetProductPreset-Image-Success: " + preset.ApplyTo(itemImage));
            }
            if (shopDesign.GetBackgroundImagePreset(false).CanBeAppliedTo(backgroundImage))
            {
                Preset preset = AssetDatabase.LoadAssetAtPath<Preset>(filePath + shopDesign.GetBackgroundImagePreset(false).name + ".preset");
                this.Log("SetProductPreset-BackgroundImage-Success: " + preset.ApplyTo(backgroundImage));
            }
        }

        [ContextMenu("Set Bundle Preset")]
        public void SetBundlePreset()
        {
            string filePath = shopDesign.PresetFolderPath + "/";
            if (shopDesign.GetTextPreset(true).CanBeAppliedTo(itemName))
            { // somewhow to Apply preset in Editor mode, Preset need to be loaded from the path
                Preset preset = AssetDatabase.LoadAssetAtPath<Preset>(filePath + shopDesign.GetTextPreset(true).name + ".preset");
                this.Log("SetBundlePreset-Text-Success: " + preset.ApplyTo(itemName));
            }
            if (shopDesign.GetTextPreset(true).CanBeAppliedTo(itemPrice))
            {
                Preset preset = AssetDatabase.LoadAssetAtPath<Preset>(filePath + shopDesign.GetTextPreset(true).name + ".preset");
                this.Log("SetBundlePreset-TextPrice-Success: " + preset.ApplyTo(itemPrice));
            }
            if (shopDesign.GetImagePreset(true).CanBeAppliedTo(itemImage))
            {
                Preset preset = AssetDatabase.LoadAssetAtPath<Preset>(filePath + shopDesign.GetImagePreset(true).name + ".preset");
                this.Log("SetBundlePreset-Image-Success: " + preset.ApplyTo(itemImage));
            }
            if (shopDesign.GetBackgroundImagePreset(true).CanBeAppliedTo(backgroundImage))
            {
                Preset preset = AssetDatabase.LoadAssetAtPath<Preset>(filePath + shopDesign.GetBackgroundImagePreset(true).name + ".preset");
                this.Log("SetBundlePreset-BackgroundImage-Success: " + preset.ApplyTo(backgroundImage));
            }
        }
#endif
    }
}