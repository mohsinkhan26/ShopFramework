/* 
 * Author : Mohsin Khan
 * LinkedIn : http://pk.linkedin.com/in/mohsinkhan26/
 * Github : https://github.com/mohsinkhan26/
 * BitBucket : https://bitbucket.org/mohsinkhan26/ 
*/

using UnityEditor;
using MK.Common.Helpers;
using MK.ShopFramework.Data;

/// <summary>
/// Only create editor/shortcut in project settings which are only one
/// </summary>
namespace MK.Common.Utilities
{
    [CustomEditor(typeof(ShopData))]
    public class ShopEditorSettings : Editor
    {
        [SettingsProvider]
        internal static SettingsProvider CreateShopDataProvider()
        {
            var assetPath = AssetDatabase.GetAssetPath(AssetDataHelper.GetShopData());
            var keywords = SettingsProvider.GetSearchKeywordsFromPath(assetPath);
            return AssetSettingsProvider.CreateProviderFromAssetPath("Project/App-ShopData", assetPath, keywords);
        }
        
        [SettingsProvider]
        internal static SettingsProvider CreateShopDesignProvider()
        {
            var assetPath = AssetDatabase.GetAssetPath(AssetDataHelper.GetShopDesign());
            var keywords = SettingsProvider.GetSearchKeywordsFromPath(assetPath);
            return AssetSettingsProvider.CreateProviderFromAssetPath("Project/App-ShopDesign", assetPath, keywords);
        }
    }
}
