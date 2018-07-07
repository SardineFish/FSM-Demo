using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GuardCautious : GuardState
{
    public const float WaitTime = 3;
    public Vector3 Position;
    float enterTime = 0;
    public GuardCautious(GameObject obj) : base(obj)
    {
    }

    public GuardCautious(GameObject obj, Vector3 position) : this(obj)
    {
        Position = position;
    }

    public override bool OnEnter(State previousState)
    {
        gameObject.GetComponent<Animator>().SetTrigger("Cautious");
        enterTime = Time.time;
        return base.OnEnter(previousState);
    }

    public override void OnUpdate()
    {
        if(Time.time - enterTime > WaitTime)
        {
            gameObject.GetComponent<Guard>().ChangeState(new GuardSearch(gameObject, Position));
        }
    }


    public void OnMessage(CautiousMessage msg)
    {
        Guard.ChangeState(new GuardSearch(gameObject, msg.Position));
    }
}