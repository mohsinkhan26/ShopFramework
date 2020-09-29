/* 
 * Author : Mohsin Khan
 * LinkedIn : http://pk.linkedin.com/in/mohsinkhan26/
 * Github : https://github.com/mohsinkhan26/
 * BitBucket : https://bitbucket.org/mohsinkhan26/ 
*/

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using MK.ShopFramework.Data;

namespace MK.Common.Helpers
{
    public static class AssetDataHelper
    { // don't save data in this class, its just a helper class
        public const string DATABASE_PATH_SHOP_DATA = "Assets/MK Assets/Shop Framework/Scripts/Asset Data/Shop Data/Shop Data.asset";
        public const string DATABASE_PATH_SHOP_DESIGN = "Assets/MK Assets/Shop Framework/Scripts/Asset Data/Shop Design/Shop Design.asset";

#if UNITY_EDITOR
        public static ShopData GetShopData()
        {
            return GetDataFile<ShopData>(DATABASE_PATH_SHOP_DATA);
        }
        
        public static ShopDesign GetShopDesign()
        {
            return GetDataFile<ShopDesign>(DATABASE_PATH_SHOP_DESIGN);
        }

        #region General
        static T GetDataFile<T>(string _assetPath) where T : ScriptableObject
        {
            return (T)AssetDatabase.LoadAssetAtPath(_assetPath, typeof(T));
        }
        #endregion General
#endif
    }
}
