using ggj.Assets._Game.Scripts.Intro;
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
        FadeDialogueUI fadeDialogueUI;
        FadeDialogueUIOut fadeDialogueUIOut;

        void Start()
        {
            inputController = FindObjectOfType<InputController>();
            fadeDialogueUI = GetComponent<FadeDialogueUI>();
            fadeDialogueUIOut = GetComponent<FadeDialogueUIOut>();
            HideUI();
        }

        public void ShowUI(State newState = null)
        {
            this.gameObject.SetActive(true);
            fadeDialogueUI.StartFadeIn(newState);
            if (inputController)
            {
                inputController.SetAllowMovement(false);
            }
        }

        public void HideUI()
        {
            this.gameObject.SetActive(false);
            fadeDialogueUIOut.StartFadeOut();

            if (inputController)
            {
                inputController.SetAllowMovement(true);
            }
        }
    }
}