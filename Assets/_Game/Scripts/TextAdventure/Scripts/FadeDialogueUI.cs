using ggj.Assets._Game.Scripts.TextAdventure.Scripts;
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
        [SerializeField] Text textPrevious;

        [SerializeField] ChoiceContainer choiceContainer;


        DialogueUI dialogueUI;
        float increase = 0.5f;

        void Start()
        {
            dialogueUI = GetComponent<DialogueUI>();
            choiceContainer.gameObject.SetActive(false);


            imageBg.color = new Color(imageBg.color.r, imageBg.color.g, imageBg.color.b, 0);
            imageBorder.color = new Color(imageBorder.color.r, imageBorder.color.g, imageBorder.color.b, 0);
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
            textPrevious.color = new Color(textPrevious.color.r, textPrevious.color.g, textPrevious.color.b, 0);
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
            textPrevious.color = new Color(textPrevious.color.r, textPrevious.color.g, textPrevious.color.b, textPrevious.color.a + increase * Time.deltaTime);
            imageBg.color = new Color(imageBg.color.r, imageBg.color.g, imageBg.color.b, imageBg.color.a + increase * Time.deltaTime);
            imageBorder.color = new Color(imageBorder.color.r, imageBorder.color.g, imageBorder.color.b, imageBorder.color.a + increase * Time.deltaTime);
            
            if (text.color.a >= 1)
            {
                hasFadedIn = true;
                this.enabled = false;
                choiceContainer.gameObject.SetActive(true);
                choiceContainer.NextState(0);
            }
        }
    }
}