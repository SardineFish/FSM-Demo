using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class GuardState : State
{
    public GuardState(GameObject obj) : base(obj)
    {
    }
}