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

        public IEnumerable<DialogNode> GetAllNodes()
        {
            return nodes;
        }

        public DialogNode GetRootNode()
        {
            return nodes[0];
        }
    }
}