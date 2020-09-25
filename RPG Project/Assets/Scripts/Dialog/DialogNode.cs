﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Dialog
{
    [System.Serializable]
    public class DialogNode
    {
        public string uniqueID;
        public string text;
        public string[] children;
        public Rect coord = new Rect(0, 0, 200, 100);
    }
}