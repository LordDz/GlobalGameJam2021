using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [TextArea(10,14)][SerializeField] string storyText;
    [SerializeField] string[] nextTitles;
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
 
}
