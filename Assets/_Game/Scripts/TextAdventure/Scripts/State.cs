using ggj.Assets._Game.Scripts.Stats;
using UnityEngine;
[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [TextArea(10,14)][SerializeField] string storyText;
    [TextArea(3, 2)][SerializeField] string[] nextTitles;
    [SerializeField] TextSpeaker nextSpeaker;
    [SerializeField] AudioClip[] nextClips;
    [SerializeField] State[] nextStates;


    public string[] GetNextTitles()
    {
        return nextTitles;
    }
    public string GetStateStory()
    {
        return storyText;
    }
    public AudioClip GetVoiceClip(int index)
    {
        if (index >= 0 && index < nextClips.Length && nextClips[index] != null)
        {
            return nextClips[index];
        }
        return null;
    }

    public State[] GetNextStates()
    {
        return nextStates;
    }

    public string GetSpeakerColor()
    {
        switch (nextSpeaker)
        {
            case TextSpeaker.man:
                return "#f0eded";
            case TextSpeaker.voice1:
                return "#eef0ed";
            case TextSpeaker.voice2:
                return "#edeef0";
            case TextSpeaker.drugdealer1:
                return "#7d7d7d";
            case TextSpeaker.drugdealer2:
                return "#0aff3b";
            case TextSpeaker.nobody:
                return "#0aff3b";
        }
        return Color.red.ToString();
    }

}
