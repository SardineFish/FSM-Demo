using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour {

    State currentState;
    public State CurrentState
    {
        get { return currentState; }
        set { ChangeState(value); }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CurrentState.OnUpdate();
	}

    public void ChangeState(State nextState)
    {
        if (CurrentState != null && CurrentState.OnExit(nextState))
        {
            if (nextState.OnEnter(CurrentState))
            {
                currentState = nextState;
            }
        }
    }

    public void ForceChangeState(State state)
    {
        CurrentState?.OnExit(state);
        state.OnEnter(CurrentState);
        currentState = state;
    }
}
