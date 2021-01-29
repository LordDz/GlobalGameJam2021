using RPGM.Gameplay;
using RPGM.UI;
using System.Collections;
using UnityEngine;

namespace ggj.Assets._Game.Scripts.TextAdventure.Scripts
{
    public class DialogueUI : MonoBehaviour
    {
        // Use this for initialization
        InputController inputController;

        void Start()
        {
            inputController = FindObjectOfType<InputController>();
            HideUI();
        }

        public void ShowUI()
        {
            this.gameObject.SetActive(true);
            inputController.SetAllowMovement(false);
        }

        public void HideUI()
        {
            this.gameObject.SetActive(false);
            inputController.SetAllowMovement(true);
        }
    }
}