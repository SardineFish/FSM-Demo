using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class Utility
{
    public static Vector3 ToVector3XZ(this Vector2 v,float z = 0)
    {
        return new Vector3(v.x, z, v.y);
    }
}