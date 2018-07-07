using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GuardAttack : GuardState
{
    public GuardAttack(GameObject obj) : base(obj)
    {
    }
    public override bool OnEnter(State previousState)
    {
        gameObject.GetComponent<Animator>().SetTrigger("Attack");
        return base.OnEnter(previousState);
    }
}