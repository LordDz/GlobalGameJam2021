using System.Collections;
using UnityEngine;

namespace ggj.Assets._Game.Scripts.TextAdventure.Scripts
{
    public class TalkToCharacter : MonoBehaviour
    {
        State currentState;
        [SerializeField] State startingState;
        [SerializeField] GameObject outline;

        ChoiceContainer choiceContainer;
        DialogueUI dialogueUI;

        bool playerIsNearby = false;
        bool hasStartedTalking = false;

        // Use this for initialization
        void Start()
        {
            choiceContainer = FindObjectOfType<ChoiceContainer>();
            dialogueUI = FindObjectOfType<DialogueUI>();
            currentState = startingState;
            outline.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (playerIsNearby && !hasStartedTalking && Input.GetButton("Interact"))
            {
                TalkToPlayer();
            }
        }

        private void TalkToPlayer()
        {
            hasStartedTalking = true;
            outline.SetActive(false);
            dialogueUI.ShowUI();
            choiceContainer.SetTalk(currentState);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            playerIsNearby = true;

            if (!hasStartedTalking)
            {
                outline.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            playerIsNearby = false;

            if (!hasStartedTalking)
            {
                outline.SetActive(false);
            }
        }
    }
}