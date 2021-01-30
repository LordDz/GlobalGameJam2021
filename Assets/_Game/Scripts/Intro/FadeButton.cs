using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ggj.Assets._Game.Scripts.Intro
{
    public class FadeButton : MonoBehaviour
    {
        bool hasFadedIn = false;
        Text text;
        Image image;

        float increase = 0.2f;
        // Use this for initialization
        [SerializeField] GameObject objToShow;


        void Start()
        {
            text = GetComponentInChildren<Text>();
            image = GetComponent<Image>();
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
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
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + increase * Time.deltaTime);
            
            if (text.color.a >= 1)
            {
                hasFadedIn = true;
            }
        }
    }
}