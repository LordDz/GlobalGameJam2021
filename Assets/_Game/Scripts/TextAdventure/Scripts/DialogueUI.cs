using System.Collections;
using UnityEngine;

namespace ggj.Assets._Game.Scripts.TextAdventure.Scripts
{
    public class DialogueUI : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            HideUI();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ShowUI()
        {
            this.enabled = true;
        }

        public void HideUI()
        {
            this.enabled = false;
        }
    }
}