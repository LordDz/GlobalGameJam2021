using UnityEngine;
using UnityEngine.UI;

namespace ggj.Assets._Game.Scripts.Intro
{
    public class FadeImageIn : MonoBehaviour
    {
        bool hasFadedIn = false;
        Image image;
        float increase = -0.5f;

        [SerializeField] bool activateOnStart = false;


        // Use this for initialization
        void Start()
        {
            //text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
            //image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
            image = GetComponent<Image>();

            if (!activateOnStart)
            {
                this.enabled = false;
            }
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
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + increase * Time.deltaTime);
            
            if (image.color.a >= 1)
            {
                hasFadedIn = true;
            }
        }
    }
}