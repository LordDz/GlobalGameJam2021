using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ggj.Assets._Game.Scripts.Intro
{
    public class FadeImageOutAndChangeLevel : MonoBehaviour
    {
        bool hasFadedOut = false;
        Image image;
        float increase = 0.5f;
        string sceneToChangeTo;

        // Use this for initialization
        void Start()
        {
            Init();
        }

        private void Init()
        {
            image = GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
            this.gameObject.SetActive(false);
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
            if (image == null)
            {
                Init();
            }

            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + increase * Time.deltaTime);
            
            if (image.color.a >= 1)
            {
                hasFadedOut = true;
                this.enabled = false;
                if (sceneToChangeTo != null)
                {
                    SceneManager.LoadScene(sceneToChangeTo);
                }
            }
        }

        public void StartSceneChange(string scene)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
            sceneToChangeTo = scene;
            this.gameObject.SetActive(true);
        }
    }
}