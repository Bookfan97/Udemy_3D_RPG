using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace RPG.Dialog.Editor
{
    public class DialogEditor : EditorWindow
    {
        [MenuItem("Window/Dialogue Editor")]
        public static void ShowEditorWindow()
        {
            GetWindow(typeof(DialogEditor), false, "Dialogue Editor");
        }

        [OnOpenAssetAttribute(1)]
        public static bool OnOpenAsset(int instanceID, int line)
        {
            Dialog dialog = EditorUtility.InstanceIDToObject(instanceID) as Dialog;
            if (dialog != null)
            {
                //Debug.Log("Opening " + dialog);
                ShowEditorWindow();
                return true;
            }
            return false;
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField("Hello World");
            EditorGUILayout.LabelField("The quick brown fox");
            EditorGUILayout.LabelField("jumps over the lazy dog");
        }
    }
}