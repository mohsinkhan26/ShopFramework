/* 
 * Author : Mohsin Khan
 * LinkedIn : http://pk.linkedin.com/in/mohsinkhan26/
 * Github : https://github.com/mohsinkhan26/
 * BitBucket : https://bitbucket.org/mohsinkhan26/ 
*/

using System.IO;
using UnityEditor;
using UnityEngine;

namespace MK.Common.Utilities
{
    [CustomPropertyDrawer(typeof(FolderReference))]
    public class FolderReferencePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty guid = property.FindPropertyRelative("GUID");
            var obj = AssetDatabase.LoadAssetAtPath<Object>(AssetDatabase.GUIDToAssetPath(guid.stringValue));

            GUIContent guiContent = EditorGUIUtility.ObjectContent(obj, typeof(DefaultAsset));

            if (property.depth == 1)
            {
                label.text = "Path";
            }

            Rect r = EditorGUI.PrefixLabel(position, label);

            Rect textFieldRect = r;
            textFieldRect.width -= 19f;

            GUIStyle textFieldStyle = new GUIStyle("TextField")
            {
                imagePosition = obj ? ImagePosition.ImageLeft : ImagePosition.TextOnly
            };

            if (GUI.Button(textFieldRect, guiContent, textFieldStyle))
            {
                if (obj != null)
                {
                    EditorGUIUtility.PingObject(obj);
                }
                else
                {
                    ShowFolderBrowser(guid, ref obj);
                }
            }

            if (textFieldRect.Contains(Event.current.mousePosition))
            {
                if (Event.current.type == EventType.DragUpdated)
                {
                    Object reference = DragAndDrop.objectReferences[0];
                    string path = AssetDatabase.GetAssetPath(reference);
                    DragAndDrop.visualMode = Directory.Exists(path) ? DragAndDropVisualMode.Copy : DragAndDropVisualMode.Rejected;
                    Event.current.Use();
                }
                else if (Event.current.type == EventType.DragPerform)
                {
                    Object reference = DragAndDrop.objectReferences[0];
                    string path = AssetDatabase.GetAssetPath(reference);
                    if (Directory.Exists(path))
                    {
                        obj = reference;
                        guid.stringValue = AssetDatabase.AssetPathToGUID(path);
                    }
                    Event.current.Use();
                }
            }

            Rect objectFieldRect = r;
            objectFieldRect.x = textFieldRect.xMax + 1f;
            objectFieldRect.width = 19f;

            if (GUI.Button(objectFieldRect, "", GUI.skin.GetStyle("IN ObjectField")))
            {
                ShowFolderBrowser(guid, ref obj);
            }
        }

        private void ShowFolderBrowser(SerializedProperty property, ref Object obj)
        {
            string path = EditorUtility.OpenFolderPanel("Select a folder", "Assets", "");
            if (path.Contains(Application.dataPath))
            {
                path = "Assets" + path.Substring(Application.dataPath.Length);
                obj = AssetDatabase.LoadAssetAtPath(path, typeof(DefaultAsset));
                property.stringValue = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(obj));
            }
        }
    }
}