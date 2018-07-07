using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AttackMessage : Message
{
    public int Damage = 10;

    public AttackMessage(int damage)
    {
        Damage = damage;
    }
}