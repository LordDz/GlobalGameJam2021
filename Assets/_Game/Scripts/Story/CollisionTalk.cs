﻿using System.Collections;
using UnityEngine;

namespace ggj.Assets._Game.Scripts.TextAdventure.Scripts
{
    public class CollisionTalk : MonoBehaviour
    {
        State currentState;
        [SerializeField] State startingState;

        [SerializeField] ChoiceContainer choiceContainer;
        [SerializeField] DialogueUI dialogueUI;

        bool hasStartedTalking = false;

        // Use this for initialization
        void Start()
        {
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
            choiceContainer.ClearText();
            dialogueUI.ShowUI(currentState);
            this.gameObject.SetActive(false);

        }
    }
}