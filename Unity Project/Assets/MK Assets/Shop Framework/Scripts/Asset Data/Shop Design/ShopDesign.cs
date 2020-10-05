/* 
 * Author : Mohsin Khan
 * LinkedIn : http://pk.linkedin.com/in/mohsinkhan26/
 * Github : https://github.com/mohsinkhan26/
 * BitBucket : https://bitbucket.org/mohsinkhan26/ 
*/

using UnityEngine;
using UnityEditor.Presets;
using MK.Common.Utilities;

namespace MK.ShopFramework.Data
{ // NOTE: presets can't be set in runtime, so choose the design and set it manually
    [CreateAssetMenu(fileName = "Shop Design", menuName = "Data/Shop Design", order = 1)]
    public sealed class ShopDesign : ScriptableObject
    {
        [SerializeField] FolderReference presetFolderReference;
        public string PresetFolderPath { get { return presetFolderReference.Path; } }

        [Header("Product")]
        [SerializeField] Preset productTextPreset;
        [SerializeField] Preset productBackgroundImagePreset;
        [SerializeField] Preset productImagePreset;

        [Header("Bundle")]
        [SerializeField] Preset bundleTextPreset;
        [SerializeField] Preset bundleBackgroundImagePreset;
        [SerializeField] Preset bundleImagePreset;

        #region Getters // for artists

        /// <summary>
        /// Get preset for the text
        /// </summary>
        /// <param name="isBundle"></param>
        /// <returns></returns>
        public Preset GetTextPreset(bool isBundle)
        {
            return isBundle ? bundleTextPreset : productTextPreset;
        }

        /// <summary>
        /// Get preset for the background of item sprite
        /// </summary>
        /// <param name="isBundle"></param>
        /// <returns></returns>
        public Preset GetBackgroundImagePreset(bool isBundle)
        {
            return isBundle ? bundleImagePreset : productImagePreset;
        }

        /// <summary>
        /// Get preset for the item sprite image
        /// </summary>
        /// <param name="isBundle"></param>
        /// <returns></returns>
        public Preset GetImagePreset(bool isBundle)
        {
            return isBundle ? bundleBackgroundImagePreset : productBackgroundImagePreset;
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