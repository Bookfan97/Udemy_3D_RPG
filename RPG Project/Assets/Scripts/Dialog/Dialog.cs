using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Dialog
{
    [CreateAssetMenu(fileName = "New Dialog", menuName = "Dialog", order = 0)]
    public class Dialog : ScriptableObject
    {
        [SerializeField] private DialogNode[] nodes;
    }
}