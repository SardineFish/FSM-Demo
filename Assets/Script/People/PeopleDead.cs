using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class PeopleDead:PeopleState
{
    public PeopleDead(GameObject obj) : base(obj)
    {
    }

    public override bool OnEnter(State previousState)
    {
        People.GetComponent<NavMeshAgent>().isStopped = true;
        People.GetComponent<Animator>().SetTrigger("Dead");
        return base.OnEnter(previousState);
    }

    public override bool OnExit(State nextState)
    {
        return false;
    }

    public override void OnUpdate()
    {
        if(People.HP>0)
        {
            People.GetComponent<Animator>().SetTrigger("Live");
            People.ForceChangeState(new PeopleIdle(gameObject));
        }
    }
}