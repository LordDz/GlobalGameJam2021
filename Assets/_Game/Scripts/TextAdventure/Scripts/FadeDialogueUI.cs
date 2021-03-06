﻿using ggj.Assets._Game.Scripts.TextAdventure.Scripts;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ggj.Assets._Game.Scripts.Intro
{
    public class FadeDialogueUI : MonoBehaviour
    {
        bool hasFadedIn = false;
        [SerializeField] Image imageBg;
        [SerializeField] Image imageBorder;
        [SerializeField] Text text;

        [SerializeField] ChoiceContainer choiceContainer;

        State changeState;


        float increase = 0.5f;

        void Start()
        {
            choiceContainer.gameObject.SetActive(false);

            imageBg.color = new Color(imageBg.color.r, imageBg.color.g, imageBg.color.b, 0);
            imageBorder.color = new Color(imageBorder.color.r, imageBorder.color.g, imageBorder.color.b, 0);
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        }

        public void StartFadeIn(State newState = null)
        {
            imageBg.color = new Color(imageBg.color.r, imageBg.color.g, imageBg.color.b, 0);
            imageBorder.color = new Color(imageBorder.color.r, imageBorder.color.g, imageBorder.color.b, 0);
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0);

            hasFadedIn = false;
            this.enabled = true;

            changeState = newState;
        }

        // Update is called once per frame
        void Update()
        {
            if (!hasFadedIn)
            {
                FadeIn();
            }
        }

        private void FadeIn()
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + increase * Time.deltaTime);
            imageBg.color = new Color(imageBg.color.r, imageBg.color.g, imageBg.color.b, imageBg.color.a + increase * Time.deltaTime);
            imageBorder.color = new Color(imageBorder.color.r, imageBorder.color.g, imageBorder.color.b, imageBorder.color.a + increase * Time.deltaTime);
            
            if (text.color.a >= 1)
            {
                hasFadedIn = true;
                this.enabled = false;
                choiceContainer.gameObject.SetActive(true);
                if (changeState)
                {
                    choiceContainer.SetTalk(changeState);
                }
                choiceContainer.NextState(0);
            }
        }
    }
}