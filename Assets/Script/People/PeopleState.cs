using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PeopleState : State
{
    public People People;

    public PeopleState(GameObject obj) : base(obj)
    {
    }
}