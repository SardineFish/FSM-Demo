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
	public virtual void Update () {
        StateName = CurrentState.GetType().Name;
        CurrentState.OnUpdate();
	}

    public virtual bool ChangeState(T nextState)
    {
        if (CurrentState != null && !CurrentState.OnExit(nextState))
            return false;
        if(currentState !=null)
            if (nextState.GetType() == currentState.GetType())
                return false;
        if (nextState.OnEnter(CurrentState))
        {
            currentState = nextState;
            return true;
        }
        return false;
    }

    public virtual void ForceChangeState(T state)
    {
        if (currentState != null)
            if (state.GetType() == currentState.GetType())
                return;
        CurrentState?.OnExit(state);
        state.OnEnter(CurrentState);
        currentState = state;
    }
}
