using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class AttackMessage : Message
{
    public GameObject Attacker;
    public int Damage = 10;

    public AttackMessage(GameObject attacker, int damage)
    {
        Attacker = attacker;
        Damage = damage;
    }
}