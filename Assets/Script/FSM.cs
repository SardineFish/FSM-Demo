using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM<T> : MonoBehaviour where T: State {

    T currentState;
    public T CurrentState
    {
        get { return currentState; }
        set { ChangeState(value); }
    }
	// Use this for initialization
	void Start () {
		
	}

    public string StateName;
	
	// Update is called once per frame
	void Update () {
        StateName = CurrentState.GetType().Name;
        CurrentState.OnUpdate();
	}

    public void ChangeState(T nextState)
    {
        if (CurrentState != null && !CurrentState.OnExit(nextState))
            return;
        if (nextState.OnEnter(CurrentState))
        {
            currentState = nextState;
        }
    }

    public void ForceChangeState(T state)
    {
        CurrentState?.OnExit(state);
        state.OnEnter(CurrentState);
        currentState = state;
    }
}
