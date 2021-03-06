﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GuardIdle : GuardState
{
    public GuardIdle(GameObject obj) : base(obj)
    {
    }

    public override bool OnEnter(State previousState)
    {
        gameObject.GetComponent<Animator>().SetTrigger("Idle");
        return true;
    }

    public void OnMessage(CautiousMessage msg)
    {
        gameObject.GetComponent<Guard>().ChangeState(new GuardCautious(gameObject, msg.Position));
    }

    public override void OnUpdate()
    {
        if (Guard.Visual() && Guard.Visual().GetComponent<People>().HP > 0)
        {
            Guard.ChangeState(new GuardAttack(gameObject, Guard.Visual()));
        }
    }
}