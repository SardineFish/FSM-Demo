using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class GuardSearch : GuardState
{
    public Vector3 Position;
    public const float ArriveThreshold = 0.2f;
    public GuardSearch(GameObject obj) : base(obj)
    {
    }
    public GuardSearch(GameObject obj, Vector3 position) : this(obj)
    {
        Position = position;
    }

    public override bool OnEnter(State previousState)
    {
        gameObject.GetComponent<NavMeshAgent>().isStopped = false;
        gameObject.GetComponent<Animator>().SetTrigger("Search");
        return base.OnEnter(previousState);
    }

    public override void OnUpdate()
    {
        var agent = gameObject.GetComponent<NavMeshAgent>().destination = Position;
        if ((Position - gameObject.transform.position).magnitude < ArriveThreshold)
        {
            Guard.ChangeState(new GuardIdleGun(gameObject));
        }
        if (Guard.Visual() && Guard.Visual().GetComponent<People>().HP>0)
        {
            Guard.ChangeState(new GuardAttack(gameObject, Guard.Visual()));
        }
    }
}