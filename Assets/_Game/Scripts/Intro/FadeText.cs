using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ggj.Assets._Game.Scripts.Intro
{
    public class FadeText : MonoBehaviour
    {
        bool hasFadedIn = false;
        Text text;

        float timeWait = 2f;
        float time = 0f;
        float increase = 0.2f;
        // Use this for initialization
        [SerializeField] GameObject objToShow;


        void Start()
        {
            text = GetComponent<Text>();
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0);

            if (objToShow)
            {
                objToShow.SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (!hasFadedIn)
            {
                FadeIn();
            }

            if (hasFadedIn && time < timeWait)
            {
                time += Time.deltaTime;
            }

            if (hasFadedIn && time >= timeWait)
            {
                FadeOut();
            }
        }

        private void FadeIn()
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + increase * Time.deltaTime);
            if (text.color.a >= 1)
            {
                hasFadedIn = true;
            }
        }

        private void FadeOut()
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - increase * Time.deltaTime);
            if (text.color.a <= 0)
            {
                this.gameObject.SetActive(false);
                if (objToShow)
                {
                    objToShow.SetActive(true);
                }
            }
        }
    }
}