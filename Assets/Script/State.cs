using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class State: IMessageReceiver
{
    public GameObject gameObject;
    public virtual bool OnEnter(State previousState) => true;

    public virtual bool OnExit(State nextState) => true;

    public virtual void OnUpdate() { }

    public State(GameObject obj)
    {
        gameObject = obj;
    }
}