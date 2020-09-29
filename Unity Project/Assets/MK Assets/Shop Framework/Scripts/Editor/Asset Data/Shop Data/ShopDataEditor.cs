/* 
 * Author : Mohsin Khan
 * LinkedIn : http://pk.linkedin.com/in/mohsinkhan26/
 * Github : https://github.com/mohsinkhan26/
 * BitBucket : https://bitbucket.org/mohsinkhan26/ 
*/

using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace MK.ShopFramework.Data
{
    [CustomEditor(typeof(ShopData))]
    public class ShopDataEditor : Editor
    {
        private SerializedProperty m_folderReference;
        private SerializedProperty m_jsonText;
        private SerializedProperty m_shopDetailsData;
        private ReorderableList m_reorderableList;

        private void OnEnable()
        {
            // Find the variables in our ScriptableObject script.
            m_folderReference = serializedObject.FindProperty("folderReference");
            m_jsonText = serializedObject.FindProperty("jsonText");
            m_shopDetailsData = serializedObject.FindProperty("shopDetails");

            // ReorderableList initializations
            // Create an instance of our reorderable list.
            m_reorderableList = new ReorderableList(serializedObject,
                m_shopDetailsData, true, true, true, true);

            // Set up the method callback to draw our list header
            m_reorderableList.drawHeaderCallback = DrawHeaderCallback;

            // Set up the method callback to draw each element in our reorderable list
            m_reorderableList.drawElementCallback = DrawElementCallback;

            // Set the height of each element.
            m_reorderableList.elementHeightCallback += ElementHeightCallback;

            // Set up the method callback to define what should happen when we add a new object to our list.
            m_reorderableList.onAddCallback += OnAddCallback;

            // Set up the method callback to define what should happen when the entry is selected from our list
            m_reorderableList.onSelectCallback = OnSelectCallback;

            // Set up the method callback to define whether we are allowed to remove an entry from our list or not
            m_reorderableList.onCanRemoveCallback = OnCanRemoveCallback;

            // Set up the method callback to define what should happen when the entry is removed from our list
            m_reorderableList.onRemoveCallback = OnRemoveCallback;
        }

        /// <summary>
        /// Draw the Inspector Window
        /// </summary>
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            // resource folder for the shop
            DrawOtherStuff();

            // display reorderable list
            m_reorderableList.DoLayoutList();

            serializedObject.ApplyModifiedProperties();
        }

        void DrawOtherStuff()
        {
            // JSON text
            EditorGUILayout.PropertyField(m_jsonText);
            EditorGUILayout.Space(10f);

            // asset folder
            EditorGUILayout.PropertyField(m_folderReference);

            EditorGUILayout.Space(20f);
        }

        #region Reorderable list

        /// <summary>
        /// Draws the header for the reorderable list
        /// </summary>
        /// <param name="rect"></param>
        private void DrawHeaderCallback(Rect rect)
        {
            EditorGUI.LabelField(rect, "Shop Items Data");
        }

        /// <summary>
        /// This methods decides how to draw each element in the list
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="index"></param>
        /// <param name="isactive"></param>
        /// <param name="isfocused"></param>
        void DrawElementCallback(Rect rect, int index, bool isActive, bool isFocused)
        {
            //Get the element we want to draw from the list.
            SerializedProperty element = m_reorderableList.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;
            float rowWidth = rect.width / 1.01f;

            // We get the ID property of our element so we can display this in our list.
            //SerializedProperty elementName = element.FindPropertyRelative("itemID");

            //Draw the list item as a property field, just like Unity does internally.
            EditorGUI.PropertyField(position:
                new Rect(rect.x += 5, rect.y, rowWidth, EditorGUIUtility.singleLineHeight),
                element, new GUIContent(element.FindPropertyRelative("itemID").intValue.ToString()), true);

            // TODO: beautify the entry and show the selected respective sprite in the entry for the UX perspective
        }

        /// <summary>
        /// Calculates the height of a single element in the list.
        /// This is extremely useful when displaying list-items with nested data.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private float ElementHeightCallback(int index)
        {
            //Gets the height of the element. This also accounts for properties that can be expanded, like structs.
            float propertyHeight =
                EditorGUI.GetPropertyHeight(m_reorderableList.serializedProperty.GetArrayElementAtIndex(index), true);

            float spacing = EditorGUIUtility.singleLineHeight / 2;

            return propertyHeight + spacing;
        }

        /// <summary>
        /// Defines how a new list element should be created and added to our list.
        /// </summary>
        /// <param name="list"></param>
        private void OnAddCallback(ReorderableList list)
        {
            var index = list.serializedProperty.arraySize;
            list.serializedProperty.arraySize++;
            list.index = index;
            var element = list.serializedProperty.GetArrayElementAtIndex(index);
        }

        /// <summary>
        /// Defines what to do when the entry of the list selected
        /// </summary>
        /// <param name="list"></param>
        private void OnSelectCallback(ReorderableList list)
        {
            var sprite = list.serializedProperty.GetArrayElementAtIndex(list.index).FindPropertyRelative("smallSprite")
                .objectReferenceValue as Sprite;
            if (sprite)
                EditorGUIUtility.PingObject(sprite);
        }

        /// <summary>
        /// Defines what to do when a entry is removed from the list
        /// </summary>
        /// <param name="list"></param>
        private void OnRemoveCallback(ReorderableList list)
        {
            if (EditorUtility.DisplayDialog("Warning!",
                "Are you sure you want to delete this shop entry? It might be used in code.", "Yes", "No"))
            {
                ReorderableList.defaultBehaviours.DoRemoveButton(list);
            }
        }

        /// <summary>
        /// Is the selected entry allowed to be removed or not
        /// </summary>
        /// <param name="list"></param>
        private bool OnCanRemoveCallback(ReorderableList list)
        {
            return list.count > 1;
        }

        #endregion Reorderable list
    }
}