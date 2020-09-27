using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RPG.Dialog
{
    [CreateAssetMenu(fileName = "New Dialog", menuName = "Dialog", order = 0)]
    public class Dialog : ScriptableObject
    {
        [SerializeField]
        private List<DialogNode> nodes = new List<DialogNode>();
        private Dictionary<string, DialogNode> nodeLookup = new Dictionary<string, DialogNode>();

#if UNITY_EDITOR

        private void Awake()
        {
            //Debug.Log("Hey you, you're finally awake");
            if (nodes.Count == 0)
            {
                nodes.Add(new DialogNode());
            }
        }
#endif

        private void OnValidate()
        {
            nodeLookup.Clear();
            foreach (DialogNode node in GetAllNodes())
            {
                nodeLookup[node.uniqueID] = node;
            }
        }

        public IEnumerable<DialogNode> GetAllNodes()
        {
            return nodes;
        }

        public DialogNode GetRootNode()
        {
            return nodes[0];
        }

        public IEnumerable<DialogNode> GetAllChildren(DialogNode ParentNode)
        {
            foreach (string childID in ParentNode.children)
            {
                if (nodeLookup.ContainsKey(childID))
                {
                    yield return nodeLookup[childID];
                }
            }
        }
    }
}