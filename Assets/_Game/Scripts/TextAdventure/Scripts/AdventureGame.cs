using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;

    State state;
    State lastState;

    void Start ()
    {
        state = startingState;
        textComponent.text = state.GetStateStory();
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        ManageState();
    }

    private void ManageState()
    {
        var nextStates = state.GetNextStates();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            state = nextStates[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            state = nextStates[1];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            state = nextStates[2];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            state = nextStates[3];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            state = nextStates[4];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            state = nextStates[5];
        }
        textComponent.text = state.GetStateStory();
    }
}
