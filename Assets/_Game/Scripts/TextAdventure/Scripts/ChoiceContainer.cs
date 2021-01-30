using ggj.Assets._Game.Scripts.Intro;
using ggj.Assets._Game.Scripts.Stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ggj.Assets._Game.Scripts.TextAdventure.Scripts
{
    public class ChoiceContainer : MonoBehaviour
    {
        ChoiceButton[] listBtns;
        [SerializeField] Text textBox;
        [SerializeField] State startingState;

        State state;
        AudioSource audioSpeaker;
        [SerializeField] FadeDialogueUIOut fadeDialogueUIOut;

        // Use this for initialization
        void Start()
        {
            state = startingState;
            audioSpeaker = GetComponent<AudioSource>();

            listBtns = GetComponentsInChildren<ChoiceButton>();
            int nr = 0;
            foreach (var btn in listBtns)
            {
                btn.Init(this, nr);
                nr++;
            }
        }

        public void SetTalk(State talkState)
        {
            state = talkState;
            FixBtns();
        }

        public void NextState(int nr)
        {
            PlayVoiceClip(nr);
            var titles = state.GetNextTitles();
            var title = titles.Length > nr && titles[nr] != null ? titles[nr] : "...";
            SetChosenDialogue(StatMood.happiness, title);
            var nextStates = state.GetNextStates();
            if (nextStates != null && nextStates.Length > 0 && nextStates.Length > nr)
            {
                state = nextStates[nr];
                FixBtns();
            }
            else
            {
                fadeDialogueUIOut.enabled = true;
                HideBtns();
            }
        }

        private void SetChosenDialogue(StatMood mood, string text)
        {
            Color colorText = StatsSettings.GetMoodColor(mood);
            textBox.text += text.Length > 0 ? "\n\n*" + text + "*" : "\n\n";
            FixBtns();
        }

        private void PlayVoiceClip(int nr)
        {
            audioSpeaker.Stop();
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
            int nrOfStates = titles.Length;

            for (var i = 0; i < listBtns.Length; i++)
            {
                if (i <= nrOfStates && i < titles.Length && titles[i] != null)
                {
                    listBtns[i].enabled = true;
                    listBtns[i].GetComponent<Button>().enabled = true;
                    listBtns[i].GetComponent<Image>().enabled = true;
                    listBtns[i].GetComponentInChildren<Text>().enabled = true;
                    listBtns[i].SetText(StatMood.happiness, titles[i]);
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