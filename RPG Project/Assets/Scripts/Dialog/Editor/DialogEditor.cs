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
        private GUIStyle nodeStyle = null;

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
            nodeStyle = new GUIStyle();
            nodeStyle.normal.background = EditorGUIUtility.Load("node0") as Texture2D;
            nodeStyle.normal.textColor = Color.white;
            nodeStyle.padding = new RectOffset(20, 20, 20, 20);
            nodeStyle.border = new RectOffset(12, 12, 12, 12);
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
                    OnGUINode(node);
                }
            }
        }

        private void OnGUINode(DialogNode node)
        {
            GUILayout.BeginArea(node.position, nodeStyle);
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.LabelField("Node:", EditorStyles.whiteLabel);
            string newText = EditorGUILayout.TextField(node.text);
            string newUniqueID = EditorGUILayout.TextField(node.uniqueID);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(selectedDialog, "Update Dialogue Text");
                node.text = newText;
                node.uniqueID = newUniqueID;
            }
            GUILayout.EndArea();
        }
    }
}