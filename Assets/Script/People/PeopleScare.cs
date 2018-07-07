using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class PeopleScare:PeopleState
{
    public PeopleScare(GameObject obj) : base(obj)
    {
    }

    public override bool OnEnter(State previousState)
    {
        People.GetComponent<Animator>().SetTrigger("Scare");
        People.GetComponent<NavMeshAgent>().isStopped = true;
        return base.OnEnter(previousState);
    }
}