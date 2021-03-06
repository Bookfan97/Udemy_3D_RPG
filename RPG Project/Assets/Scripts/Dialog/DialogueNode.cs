﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace RPG.Dialogue
{
    public class DialogueNode : ScriptableObject
    {
        //public string uniqueID;
        [SerializeField]
        private bool isPlayerSpeaking = false;

        [SerializeField]
        public string text;

        [SerializeField]
        public List<string> children = new List<string>();

        [SerializeField]
        public Rect coord = new Rect(0, 0, 200, 100);

        [SerializeField] 
        private string onEnterAction;
        
        [SerializeField] 
        private string onExitAction;

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

        public bool IsPlayerSpeaking()
        {
            return isPlayerSpeaking;
        }

        public string GetOnEnterAction()
        {
            return onEnterAction;
        }

        public string GetOnExitAction()
        {
            return onExitAction;
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

        public void SetPlayerIsSpeaking(bool newIsPlayerSpeaking)
        {
            Undo.RecordObject(this, "Changed Dialogue Node Speaker");
            isPlayerSpeaking = newIsPlayerSpeaking;
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