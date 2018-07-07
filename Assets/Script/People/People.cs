using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class People : FSM<PeopleState>, IMessageReceiver
{
    public int HP = 100;
    public override bool ChangeState(PeopleState nextState)
    {
        if (base.ChangeState(nextState))
        {
            nextState.People = this;
            return true;
        }
        return false;
    }
    void Update()
    {
        
    }

    public void OnMessage(AttackMessage msg)
    {
        HP -= msg.Damage;
    }
}