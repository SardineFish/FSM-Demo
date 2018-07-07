using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class GuardState : State
{
    public Guard Guard;
    public GuardState(GameObject obj) : base(obj)
    {
    }
}