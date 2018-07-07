using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CautiousMessage:Message
{
    public Vector3 Position;

    public CautiousMessage(Vector3 position)
    {
        Position = position;
    }
}