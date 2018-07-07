using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GuardIdleGun : GuardState
{
    public GuardIdleGun(GameObject obj) : base(obj)
    {
    }

    public override bool OnEnter(State previousState)
    {
        gameObject.GetComponent<Animator>().SetTrigger("IdleGun");
        return base.OnEnter(previousState);
    }
}