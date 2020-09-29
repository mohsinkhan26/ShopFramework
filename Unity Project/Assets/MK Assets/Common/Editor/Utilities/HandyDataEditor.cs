/* 
 * Author : Mohsin Khan
 * LinkedIn : http://pk.linkedin.com/in/mohsinkhan26/
 * Github : https://github.com/mohsinkhan26/
 * BitBucket : https://bitbucket.org/mohsinkhan26/ 
*/

using UnityEditor;
using UnityEngine;
using MK.Common.Helpers;
using MK.ShopFramework.Data;

namespace MK.Common.Utilities
{
    public static class HandyDataEditor
    {
        #region Module Specific
        static ShopData shopData;
        [MenuItem("Tools/Game/Shop Data", false, 20)]
        public static void ShopDataFile()
        {
            shopData = AssetDataHelper.GetShopData();
            LoadData(ref shopData, AssetDataHelper.DATABASE_PATH_SHOP_DATA);
        }
        
        static ShopDesign shopDesign;
        [MenuItem("Tools/Game/Shop Design", false, 20)]
        public static void ShopDesignFile()
        {
            shopDesign = AssetDataHelper.GetShopDesign();
            LoadData(ref shopDesign, AssetDataHelper.DATABASE_PATH_SHOP_DESIGN);
        }
        #endregion Module Specific

        #region General
        static void LoadData<T>(ref T _object, string _assetPath) where T : ScriptableObject
        {
            Selection.activeObject = AssetDatabase.LoadMainAssetAtPath(_assetPath);

            if (_object == null)
                CreateData(ref _object, _assetPath);

            // select the .asset fiile
            EditorGUIUtility.PingObject(_object);
            // focus the project window
            EditorUtility.FocusProjectWindow();
        }

        static void CreateData<T>(ref T _object, string _assetPath) where T : ScriptableObject
        {
            _object = ScriptableObject.CreateInstance<T>();
            AssetDatabase.CreateAsset(_object, _assetPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
        #endregion General
    }
}
