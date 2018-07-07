using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class PeopleRun:PeopleState
{
    public GameObject Target;
    public PeopleRun(GameObject obj, GameObject target) : base(obj)
    {
        Target = target;
    }

    public override bool OnEnter(State previousState)
    {
        People.GetComponent<Animator>().SetTrigger("Run");
        People.GetComponent<NavMeshAgent>().isStopped = false;
        return base.OnEnter(previousState);
    }

    public override void OnUpdate()
    {
        People.GetComponent<NavMeshAgent>().speed = 5.689f;
        People.GetComponent<NavMeshAgent>().destination = People.transform.position + (People.transform.position - Target.transform.position).normalized * 3;

    }
}