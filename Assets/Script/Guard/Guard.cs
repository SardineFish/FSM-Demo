using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Guard : FSM<GuardState>, IMessageReceiver
{
    public float VisualHeight = 1f;
    void Start()
    {
        ChangeState(new GuardIdle(gameObject));
    }

    public void OnMessage(Message msg)
    {
        msg.Dispatch(CurrentState);
    }

    public override bool ChangeState(GuardState nextState)
    {
        if(base.ChangeState(nextState))
        {
            nextState.Guard = this;
            return true;
        }
        return false;

    }

    public GameObject Visual()
    {
        foreach (var obj in GameObject.FindGameObjectsWithTag("People"))
        {
            var ray = new Ray(transform.position + transform.up * VisualHeight, obj.transform.position - transform.position);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, 500))
            {
                if(hit.collider.gameObject == obj)
                {
                    return obj;
                }
            }
        }
        return null;
    }

    public void Fire()
    {
        if (CurrentState is GuardAttack)
        {
            var attack = CurrentState as GuardAttack;
            new AttackMessage(gameObject,10).Dispatch(attack.AttackTarget.GetComponent<People>());
            GetComponent<Weapon>().TakeFire(attack.AttackTarget.transform.position + Vector3.up);
        }
    }
}