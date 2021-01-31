using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ggj.Assets._Game.Scripts.Intro
{
    public class MoveToNextScene : MonoBehaviour
    {
        public string SceneToLoad = "";

        private void OnTriggerEnter2D(Collider2D collision)
        {
            SceneManager.LoadScene(SceneToLoad);
        }
    }
}