using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class GuardIdleGun : GuardState
{
    float enterTime = 0;
    public const float WaitTime = 5;
    public GuardIdleGun(GameObject obj) : base(obj)
    {
    }

    public override bool OnEnter(State previousState)
    {
        gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        gameObject.GetComponent<Animator>().SetTrigger("IdleGun");
        enterTime = Time.time;
        return base.OnEnter(previousState);

    }

    public override void OnUpdate()
    {
        if (Time.time - enterTime > WaitTime)
            Guard.ChangeState(new GuardIdle(gameObject));
    }


    public void OnMessage(CautiousMessage msg)
    {
        Guard.ChangeState(new GuardSearch(gameObject, msg.Position));
    }
}