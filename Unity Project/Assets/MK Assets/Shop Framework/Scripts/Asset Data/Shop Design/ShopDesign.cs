/* 
 * Author : Mohsin Khan
 * LinkedIn : http://pk.linkedin.com/in/mohsinkhan26/
 * Github : https://github.com/mohsinkhan26/
 * BitBucket : https://bitbucket.org/mohsinkhan26/ 
*/

using UnityEditor.Presets;
using UnityEngine;

namespace MK.ShopFramework.Data
{
    [CreateAssetMenu(fileName = "Shop Design", menuName = "Data/Shop Design", order = 1)]
    public sealed class ShopDesign : ScriptableObject
    {
        [Header("Product")] [SerializeField] DefaultPreset productText;
        [SerializeField] DefaultPreset productBackgroundImage;
        [SerializeField] DefaultPreset productImage;

        [Header("Bundle")] [SerializeField] DefaultPreset bundleText;
        [SerializeField] DefaultPreset bundleBackgroundImage;
        [SerializeField] DefaultPreset bundleImage;

        #region Getters // for artists

        /// <summary>
        /// Get preset for the text
        /// </summary>
        /// <param name="isBundle"></param>
        /// <returns></returns>
        public DefaultPreset GetTextPreset(bool isBundle)
        {
            return isBundle ? bundleText : productText;
        }

        /// <summary>
        /// Get preset for the background of item sprite
        /// </summary>
        /// <param name="isBundle"></param>
        /// <returns></returns>
        public DefaultPreset GetBackgroundImagePreset(bool isBundle)
        {
            return isBundle ? bundleImage : productImage;
        }

        /// <summary>
        /// Get preset for the item sprite image
        /// </summary>
        /// <param name="isBundle"></param>
        /// <returns></returns>
        public DefaultPreset GetImagePreset(bool isBundle)
        {
            return isBundle ? bundleBackgroundImage : productBackgroundImage;
        }

        #endregion Getters // for artists

#if UNITY_EDITOR
        // [ContextMenu("Load Data File As Text")]
        // void LoadDataFileAsText()
        // {
        //     this.Log("LoadDataFileAsText-Folder: " + assetFolder.name);
        // }
#endif
    }
}