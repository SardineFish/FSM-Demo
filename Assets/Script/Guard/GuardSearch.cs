using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GuardSearch : GuardState
{
    public Vector3 Position;
    public GuardSearch(GameObject obj) : base(obj)
    {
    }
    public GuardSearch(GameObject obj, Vector3 position) : this(obj)
    {
        Position = position;
    }

    public override bool OnEnter(State previousState)
    {
        gameObject.GetComponent<Animator>().SetTrigger("Search");
        return base.OnEnter(previousState);
    }
}