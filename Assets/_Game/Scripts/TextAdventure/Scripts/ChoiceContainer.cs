using ggj.Assets._Game.Scripts.Intro;
using UnityEngine;
using UnityEngine.UI;

namespace ggj.Assets._Game.Scripts.TextAdventure.Scripts
{
    public class ChoiceContainer : MonoBehaviour
    {
        [SerializeField] ChoiceButton[] listBtns;
        [SerializeField] Text textBox;
        [SerializeField] State startingState;

        State state;
        [SerializeField] AudioSource audioSpeaker;
        [SerializeField] FadeDialogueUIOut fadeDialogueUIOut;

        [SerializeField] FadeImageOutAndChangeLevel fadeImageOutAndChangeLevel;

        bool hasInit = false;


        private void Init()
        {
            state = startingState;

            int nr = 0;
            foreach (var btn in listBtns)
            {
                btn.Init(this, nr);
                nr++;
            }
            hasInit = true;
        }

        public void ClearText()
        {
            textBox.text = "";
        }

        public void SetTalk(State talkState)
        {
            
            state = talkState;
            FixBtns();
        }

        public void NextState(int nr)
        {
            if (!hasInit)
            {
                Init();
            }

            PlayVoiceClip(nr);
            var titles = state.GetNextTitles();
            var descriptions = state.titleDescriptions();
            var title = titles.Length > nr && titles[nr] != null ? titles[nr] : "...";
            var desc = descriptions.Length > nr && descriptions[nr] != null ? descriptions[nr] : "...";
            var textDescription = titles.Length > nr && titles[nr] != null ? titles[nr] : "...";
            var textColor = state.GetSpeakerColor();
            SetChosenDialogue(textColor, desc);
            var nextStates = state.GetNextStates();
            if (nextStates != null && nextStates.Length > 0 && nextStates.Length > nr)
            {
                state = nextStates[nr];
                if (state != null)
                {
                    FixBtns();
                }
                else
                {
                    fadeDialogueUIOut.enabled = true;
                    HideBtns();
                }
            }
            else
            {
                fadeDialogueUIOut.enabled = true;
                HideBtns();

                //We assume that the next scene dialogue choice will always be the first
                if (nr != 0) return;
                var fadeoutScene = state.GetNextScene();

                if (fadeoutScene != null && fadeoutScene.Length > 0)
                {
                    Debug.Log("I want to go to next scene: " + fadeoutScene);
                 
                    fadeImageOutAndChangeLevel.gameObject.SetActive(true);
                    fadeImageOutAndChangeLevel.StartSceneChange(fadeoutScene);
                }
            }
        }

        private void SetChosenDialogue(string textColor, string text)
        {
            var textColored = "<color=" + textColor + ">" + text + "</color>";
            textBox.text = text.Length > 0 ? "\n\n" + textColored + "" : "\n\n";
            FixBtns();
        }

        private void PlayVoiceClip(int nr)
        {
            audioSpeaker.Stop();
            if (state == null) return;
            AudioClip clip = state.GetVoiceClip(nr);
            if (clip != null)
            {
                audioSpeaker.clip = clip;
                audioSpeaker.Play();
            }
        }

        private void FixBtns()
        {
            //textComponent.text = state.GetStateStory();
            var titles = state.GetNextTitles();
            var textColor = state.GetSpeakerColor();
            int nrOfStates = titles.Length;

            for (var i = 0; i < listBtns.Length; i++)
            {
                if (i <= nrOfStates && i < titles.Length && titles[i] != null)
                {
                    listBtns[i].enabled = true;
                    listBtns[i].GetComponent<Button>().enabled = true;
                    listBtns[i].GetComponent<Image>().enabled = true;
                    listBtns[i].GetComponentInChildren<Text>().enabled = true;
                    listBtns[i].SetText(textColor, titles[i]);
                }
                else
                {
                    listBtns[i].enabled = false;
                    listBtns[i].GetComponent<Button>().enabled = false;
                    listBtns[i].GetComponent<Image>().enabled = false;
                    listBtns[i].GetComponentInChildren<Text>().enabled = false;
                }
            }
        }

        private void HideBtns()
        {
            for (var i = 0; i < listBtns.Length; i++)
            {
                listBtns[i].enabled = false;
                listBtns[i].GetComponent<Button>().enabled = false;
                listBtns[i].GetComponent<Image>().enabled = false;
                listBtns[i].GetComponentInChildren<Text>().enabled = false;
            }
        }
    }
}