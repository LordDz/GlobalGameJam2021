using ggj.Assets._Game.Scripts.TextAdventure.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace ggj.Assets._Game.Scripts.Intro
{
    public class FadeDialogueUIOut : MonoBehaviour
    {
        bool hasFadedOut = false;
        [SerializeField] Image imageBg;
        [SerializeField] Image imageBorder;
        [SerializeField] Text text;
        [SerializeField] FadeImageIn fadeInEffect;


        DialogueUI dialogueUI;
        float increase = -0.5f;

        void Start()
        {
            dialogueUI = GetComponent<DialogueUI>();

            //imageBg.color = new Color(imageBg.color.r, imageBg.color.g, imageBg.color.b, 0);
            //imageBorder.color = new Color(imageBorder.color.r, imageBorder.color.g, imageBorder.color.b, 0);
            //text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
            this.enabled = false;
        }

        public void StartFadeOut()
        {
            hasFadedOut = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (!hasFadedOut)
            {
                FadeOut();
            }
        }

        private void FadeOut()
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + increase * Time.deltaTime);
            imageBg.color = new Color(imageBg.color.r, imageBg.color.g, imageBg.color.b, imageBg.color.a + increase * Time.deltaTime);
            imageBorder.color = new Color(imageBorder.color.r, imageBorder.color.g, imageBorder.color.b, imageBorder.color.a + increase * Time.deltaTime);

            fadeInEffect.enabled = true;

            if (text.color.a <= 0)
            {
                hasFadedOut = true;
                this.enabled = false;
                dialogueUI.HideUI();
            }
        }
    }
}