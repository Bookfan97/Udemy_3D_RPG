using System.Collections;
using System.Collections.Generic;
using RPG.Dialogue;
using TMPro;
using UnityEngine;

namespace RPG.UI
{
    public class DialogueUI : MonoBehaviour
    {
        private PlayerConversant playerConversant;
        [SerializeField] private TextMeshProUGUI AIText;
        // Start is called before the first frame update
        void Start()
        {
            playerConversant = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConversant>();
            AIText.text = playerConversant.GetText();
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}