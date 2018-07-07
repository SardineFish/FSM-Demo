using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class State
{
    public virtual bool OnEnter(State previousState) => true;

    public virtual bool OnExit(State nextState) => true;

    public virtual void OnUpdate() { }
}