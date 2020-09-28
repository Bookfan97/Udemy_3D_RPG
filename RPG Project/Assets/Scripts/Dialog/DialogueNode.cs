using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace RPG.Dialogue
{
    public class DialogueNode : ScriptableObject
    {
        //public string uniqueID;
        [SerializeField]
        public string text;

        [SerializeField]
        public List<string> children = new List<string>();

        [SerializeField]
        public Rect coord = new Rect(0, 0, 200, 100);

        public Rect GetRect()
        {
            return coord;
        }

        public string GetText()
        {
            return text;
        }

        public List<string> GetChildren()
        {
            return children;
        }

#if UNITY_EDITOR

        public void SetPosition(Vector2 newPosition)
        {
            Undo.RecordObject(this, "Move Dialogue Node");
            coord.position = newPosition;
            EditorUtility.SetDirty(this);
        }

        public void SetText(string newText)
        {
            if (newText != text)
            {
                Undo.RecordObject(this, "Update Dialogue Text");
                text = newText;
            }
            EditorUtility.SetDirty(this);
        }

        public void AddChild(string childID)
        {
            Undo.RecordObject(this, "Add Dialogue Link");
            children.Add(childID);
            EditorUtility.SetDirty(this);
        }

        public void RemoveChild(string childID)
        {
            Undo.RecordObject(this, "Remove Dialogue Link");
            children.Remove(childID);
            EditorUtility.SetDirty(this);
        }
#endif
    }
}