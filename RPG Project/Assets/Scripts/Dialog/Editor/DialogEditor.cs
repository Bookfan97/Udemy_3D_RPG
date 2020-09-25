using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace RPG.Dialog.Editor
{
    public class DialogEditor : EditorWindow
    {
        private Dialog selectedDialog = null;

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
                ShowEditorWindow();
                return true;
            }
            return false;
        }

        private void OnEnable()
        {
            Selection.selectionChanged += OnSelectionChanged;
        }

        private void OnSelectionChanged()
        {
            Dialog newDialog = Selection.activeObject as Dialog;
            if (newDialog != null)
            {
                selectedDialog = newDialog;
                Repaint();
            }
        }

        private void OnGUI()
        {
            if (selectedDialog == null)
            {
                EditorGUILayout.LabelField("No dialogue selected");
            }
            else
            {
                foreach (DialogNode node in selectedDialog.GetAllNodes())
                {
                    string newText = EditorGUILayout.TextField(node.text);
                    if (newText != node.text)
                    {
                        EditorUtility.SetDirty(selectedDialog);
                    }
                }
            }
        }
    }
}