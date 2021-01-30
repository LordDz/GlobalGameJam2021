using System.Collections;
using UnityEngine;

namespace ggj.Assets._Game.Scripts.TextAdventure.Scripts
{
    public class CollisionTalk : MonoBehaviour
    {
        State currentState;
        [SerializeField] State startingState;

        ChoiceContainer choiceContainer;
        DialogueUI dialogueUI;

        bool hasStartedTalking = false;

        // Use this for initialization
        void Start()
        {
            choiceContainer = FindObjectOfType<ChoiceContainer>();
            dialogueUI = FindObjectOfType<DialogueUI>();
            currentState = startingState;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!hasStartedTalking)
            {
                TalkToPlayer();
            }
        }

        private void TalkToPlayer()
        {
            hasStartedTalking = true;
            dialogueUI.ShowUI();
            choiceContainer.SetTalk(currentState);
            this.gameObject.SetActive(false);
        }
    }
}