/* 
 * Author : Mohsin Khan
 * LinkedIn : http://pk.linkedin.com/in/mohsinkhan26/
 * Github : https://github.com/mohsinkhan26/
 * BitBucket : https://bitbucket.org/mohsinkhan26/ 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using Newtonsoft.Json;
using MK.Common;
using MK.Common.Utilities;

namespace MK.ShopFramework.Data
{
    [CreateAssetMenu(fileName = "Shop Data", menuName = "Data/Shop Data", order = 1)]
    public sealed class ShopData : ScriptableObject
    {
        [SerializeField] FolderReference folderReference;

        [SerializeField]
        [TextArea(1, 5)]
        [Multiline]
        string jsonText;

        [SerializeField] List<ShopDetail> shopDetails;
        public List<ShopDetail> AllShopProducts { get { return shopDetails; } }
        public int TotalShopProducts { get { return shopDetails.Count; } }

        #region Getters // for developers

        public ShopDetail GetItem(int itemID)
        {
            if (shopDetails == null || shopDetails.Count == 0) return null;
            return shopDetails.FirstOrDefault(sD => sD.itemID == itemID);
        }

        /// <summary>
        /// Get all items, except bundles
        /// </summary>
        /// <returns></returns>
        public List<ShopDetail> GetAllItems()
        {
            if (shopDetails == null || shopDetails.Count == 0) return null;
            return shopDetails.Where(sD => !sD.IsABundle).ToList();
        }

        /// <summary>
        /// Get all bundles of items, except individual items
        /// </summary>
        /// <returns></returns>
        public List<ShopDetail> GetAllBundlesOfItems()
        {
            if (shopDetails == null || shopDetails.Count == 0) return null;
            return shopDetails.Where(sD => sD.IsABundle).ToList();
        }

        /// <summary>
        /// Get all items according to their consume type
        /// </summary>
        /// <param name="consumeType"></param>
        /// <returns></returns>
        public List<ShopDetail> GetAllItemsBy(ConsumeType consumeType)
        {
            if (shopDetails == null || shopDetails.Count == 0) return null;
            return shopDetails.Where(sD => sD.consumeType == consumeType).ToList();
        }

        /// <summary>
        /// Get items, except bundles
        /// </summary>
        /// <returns></returns>
        public List<ShopDetail> GetItemsBy(ConsumeType consumeType)
        {
            if (shopDetails == null || shopDetails.Count == 0) return null;
            return shopDetails.Where(sD => sD.consumeType == consumeType && !sD.IsABundle)
                .ToList();
        }

        /// <summary>
        /// Get all bundles of items, except individual items
        /// </summary>
        /// <returns></returns>
        public List<ShopDetail> GetBundlesOfItemsBy(ConsumeType consumeType)
        {
            if (shopDetails == null || shopDetails.Count == 0) return null;
            return shopDetails.Where(sD => sD.consumeType == consumeType && sD.IsABundle)
                .ToList();
        }

        /// <summary>
        /// Get items in your specified order
        /// </summary>
        /// <param name="consumeType"></param>
        /// <returns></returns>
        public List<ShopDetail> GetItemsOrderBy(ConsumeType consumeType1, ConsumeType consumeType2)
        {
            // as 3rd type would be at the end in result of this query
            if (shopDetails == null || shopDetails.Count == 0) return null;
            return shopDetails.Where(sD => !sD.IsABundle)
                .OrderBy(sDO1 => sDO1.consumeType == consumeType1)
                .ThenBy(sDO1 => sDO1.consumeType == consumeType2)
                .ToList();
        }

        #endregion Getters // for developers

#if UNITY_EDITOR
        [ContextMenu("Load Data File As Text")]
        void LoadDataFileAsText()
        {
            TextAsset textAsset = AssetDatabase.LoadAssetAtPath<TextAsset>(folderReference.Path + "/Data.txt");
            if (!string.IsNullOrEmpty(textAsset.text))
                jsonText = textAsset.text;
            this.Log("LoadDataFileAsText-Folder-Path: " + folderReference.Path
                + "\nGUID: " + folderReference.GUID + "\nText: " + textAsset.text);
        }

        [ContextMenu("Load Data in List")]
        void LoadDataInList()
        {
            this.Log("LoadDataInList-Path: " + folderReference.Path
                + "\nGUID: " + folderReference.GUID);
            Dictionary<string, List<ShopModel>> jsonData = JsonConvert.DeserializeObject<Dictionary<string, List<ShopModel>>>(jsonText);
            if (jsonData.ContainsKey("ShopItems"))
            {
                List<ShopModel> shopModels = new List<ShopModel>();
                shopModels = jsonData["ShopItems"];
                if (shopDetails == null)
                    shopDetails = new List<ShopDetail>();
                else shopDetails.Clear();

                for (int i = 0; i < shopModels.Count; ++i)
                {
                    shopDetails.Add(new ShopDetail(shopModels[i].ItemID, (ItemType)Enum.Parse(typeof(ItemType), shopModels[i].ItemType, true),
                        shopModels[i].ItemName, shopModels[i].Quantity, (ConsumeType)Enum.Parse(typeof(ConsumeType), shopModels[i].Consume, true),
                        shopModels[i].Price, AssetDatabase.LoadAssetAtPath<Sprite>(folderReference.Path + "/" + shopModels[i].SmallImage),
                        AssetDatabase.LoadAssetAtPath<Sprite>(folderReference.Path + "/" + shopModels[i].BigImage), shopModels[i].Description,
                        shopModels[i].Bundle));
                }
            }
        }

        [ContextMenu("Load Data From File and in List")]
        void LoadDataFromFileAndInList()
        {
            LoadDataFileAsText();
            LoadDataInList();
            this.Log("LoadDataFromFileAndInList-Path: " + folderReference.Path
                + "\nGUID: " + folderReference.GUID);
        }

        [ContextMenu("Sort Data")]
        void Sort()
        {
            try
            {
                shopDetails = shopDetails.OrderBy(sD => sD.itemID).ToList();
                this.Log("Entries Sorted. Kindly check for dublicates, manually...!");
            }
            catch (Exception _ex)
            {
                this.Log(_ex.Message + "\nTrace: " + _ex.StackTrace + "\n");
            }
        }
#endif
    }
}