using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class GuardAttack : GuardState
{
    public GameObject AttackTarget;
    public const float TurnSpeed = 600;
    public GuardAttack(GameObject obj, GameObject target) : base(obj)
    {
        AttackTarget = target;
    }
    public override bool OnEnter(State previousState)
    {
        gameObject.GetComponent<Animator>().SetTrigger("Attack");
        
        return base.OnEnter(previousState);
    }

    public override void OnUpdate()
    {
        if(!Guard.Visual())
        {
            Guard.ChangeState(new GuardSearch(gameObject, AttackTarget.transform.position));
            return;
        }
        if(AttackTarget.GetComponent<People>().CurrentState is PeopleDead)
        {
            Guard.ChangeState(new GuardIdleGun(gameObject));
            return;
        }
        gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        var dir = (AttackTarget.transform.position - gameObject.transform.position);
        dir.y = 0;
        var forward = gameObject.transform.localToWorldMatrix.MultiplyVector(Vector3.forward);
        var rotate = Quaternion.FromToRotation(forward, dir);
        rotate = Quaternion.Lerp(gameObject.transform.rotation, gameObject.transform.rotation * rotate, 0.1f);
        gameObject.transform.rotation = rotate;
    }
}