using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class PeopleWander : PeopleState
{
    float startTime = 0;
    public const float WanderTime = 5;
    public Vector3 dst;
    public PeopleWander(GameObject obj) : base(obj)
    {
    }

    public override bool OnEnter(State previousState)
    {
        startTime = Time.time;
        People.GetComponent<NavMeshAgent>().isStopped = false;
        People.GetComponent<Animator>().SetTrigger("Wander");
        dst = (UnityEngine.Random.insideUnitCircle * 5).ToVector3XZ() + People.transform.position;
        return base.OnEnter(previousState);
    }

    public override void OnUpdate()
    {
        if(Time.time - startTime > WanderTime)
        {
            People.ChangeState(new PeopleIdle(gameObject));
        }
        People.GetComponent<NavMeshAgent>().speed = 0.8294f;
        People.GetComponent<NavMeshAgent>().destination = dst;
    }
}