using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class People : FSM<PeopleState>, IMessageReceiver
{
    public int HP = 100;
    public float VisualHeight = 1.8f;

    private void Start()
    {
        ChangeState(new PeopleIdle(gameObject));
    }

    public override bool ChangeState(PeopleState nextState)
    {
        nextState.People = this;
        return base.ChangeState(nextState);
    }
    public override void Update()
    {
        if (HP <= 0)
            ForceChangeState(new PeopleDead(gameObject));
        if (Visual())
        {

        }
        base.Update();
    }

    public override void ForceChangeState(PeopleState state)
    {
        state.People = this;
        base.ForceChangeState(state);
    }

    public void OnMessage(AttackMessage msg)
    {
        if (HP < 50)
        {
            ChangeState(new PeopleScare(gameObject));
        }
        else
            ChangeState(new PeopleRun(gameObject, msg.Attacker));
        HP -= msg.Damage;
    }

    public GameObject Visual()
    {
        foreach (var obj in GameObject.FindGameObjectsWithTag("Guard"))
        {
            var ray = new Ray(transform.position + transform.up * VisualHeight, obj.transform.position - transform.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 500))
            {
                if (hit.collider.gameObject == obj)
                {
                    return obj;
                }
            }
        }
        return null;
    }
}