using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GuardSearch : GuardState
{
    public GuardSearch(GameObject obj) : base(obj)
    {
    }

    public override bool OnEnter(State previousState)
    {
        gameObject.GetComponent<Animator>().SetTrigger("Search");
        return base.OnEnter(previousState);
    }
}