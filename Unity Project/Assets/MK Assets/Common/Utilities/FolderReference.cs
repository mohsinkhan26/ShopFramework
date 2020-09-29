/* 
 * Author : Mohsin Khan
 * LinkedIn : http://pk.linkedin.com/in/mohsinkhan26/
 * Github : https://github.com/mohsinkhan26/
 * BitBucket : https://bitbucket.org/mohsinkhan26/ 
*/

using System;
using UnityEditor;

namespace MK.Common.Utilities
{
    [Serializable]
    public class FolderReference
    {
        public string GUID;

        public string Path
        {
            get => AssetDatabase.GUIDToAssetPath(GUID);
            set => GUID = AssetDatabase.AssetPathToGUID(value);
        }
    }
}