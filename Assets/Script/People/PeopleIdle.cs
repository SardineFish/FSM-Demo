using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class PeopleIdle : PeopleState
{
    float startTime = 0;
    public const float IdleTime = 10;
    public PeopleIdle(GameObject obj) : base(obj)
    {
    }

    public override bool OnEnter(State previousState)
    {
        People.GetComponent<NavMeshAgent>().isStopped = true;
        startTime = Time.time;
        People.GetComponent<Animator>().SetTrigger("Idle");
        return base.OnEnter(previousState);
    }

    public override void OnUpdate()
    {
        if(Time.time - startTime > IdleTime)
        {
            People.ChangeState(new PeopleWander(gameObject));
        }
    }
}