using ggj.Assets._Game.Scripts.Stats;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ggj.Assets._Game.Scripts.TextAdventure.Scripts
{
    public class ChoiceButton : MonoBehaviour  // 2
     , IPointerEnterHandler
     , IPointerExitHandler
    {
        Text buttonText;
        int nr = 0;

        ChoiceContainer choiceContainer;

        public void Init(ChoiceContainer choiceContainer, int nr)
        {
            buttonText = GetComponentInChildren<Text>();
            this.nr = nr;
            this.choiceContainer = choiceContainer;
        }

        public void SetText(StatMood mood, string text)
        {
            Color colorText = StatsSettings.GetMoodColor(mood);
            buttonText.color = colorText;
            buttonText.text = text;
        }

        public void Start()
        {
            buttonText = GetComponentInChildren<Text>();
        }

        public void ButtonPress()
        {
            choiceContainer.NextState(nr);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            buttonText.fontStyle = FontStyle.BoldAndItalic;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            buttonText.fontStyle = FontStyle.Normal;
        }
    }
}