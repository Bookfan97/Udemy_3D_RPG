using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace RPG.Inventories.Editor
{
    public class InventoryItemEditor : EditorWindow
    {
        [NonSerialized] InventoryItem selected = null;

        [MenuItem("Window/InventoryItem Editor")]
        public static void ShowEditorWindow()
        {
            GetWindow(typeof(InventoryItemEditor), false, "InventoryItem");
        }
        public static void ShowEditorWindow(InventoryItem candidate) { 
            InventoryItemEditor window = GetWindow(typeof(InventoryItemEditor), false, "Dialogue Editor") as InventoryItemEditor;
            if (candidate)
            {
                window.OnSelectionChange();
            }
        }

        [OnOpenAsset(1)]
           public static bool OnOpenAsset(int instanceID, int line)
           {
               InventoryItem candidate = EditorUtility.InstanceIDToObject(instanceID) as InventoryItem;
               if (candidate != null)
               {
                   ShowEditorWindow(candidate);
                   return true;
               }

               return false;
           }

           void OnSelectionChange()
        {
            var candidate = EditorUtility.InstanceIDToObject(Selection.activeInstanceID) as InventoryItem;
            if(candidate == null) return;
            selected = candidate;
            Repaint();
        }
        void OnGUI()
        {
            if (!selected)
            {
                EditorGUILayout.HelpBox("No Dialogue Selected", MessageType.Error);
                return;
            }
            EditorGUILayout.HelpBox($"{selected.name}/{selected.GetDisplayName()}", MessageType.Info);
            selected.SetItemID(EditorGUILayout.TextField("ItemID (clear to reset", selected.GetItemID()));
            selected.SetDisplayName(EditorGUILayout.TextField("Display name", selected.GetDisplayName()));
            selected.SetDescription(EditorGUILayout.TextField("Description", selected.GetDescription()));
            selected.SetIcon((Sprite)EditorGUILayout.ObjectField("Icon", selected.GetIcon(), typeof(Sprite), false));
            selected.SetPickup((Pickup)EditorGUILayout.ObjectField("Pickup", selected.GetPickup(), typeof(Pickup), false));
            selected.SetStackable(EditorGUILayout.Toggle("Stackable", selected.IsStackable()));

        }
    }
}
