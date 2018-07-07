using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GuardCautious : GuardState
{
    public GuardCautious(GameObject obj) : base(obj)
    {
    }

    public override bool OnEnter(State previousState)
    {
        gameObject.GetComponent<Animator>().SetTrigger("Cautious");
        return base.OnEnter(previousState);
    }
}