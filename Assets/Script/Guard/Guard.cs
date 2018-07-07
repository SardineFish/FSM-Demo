using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Guard : FSM<GuardState>, IMessageReceiver
{
    void Start()
    {
        ChangeState(new GuardIdle(gameObject));
    }

    public void OnMessage(Message msg)
    {
        msg.Dispatch(CurrentState);
    }

    public override bool ChangeState(GuardState nextState)
    {
        if(base.ChangeState(nextState))
        {
            nextState.Guard = this;
            return true;
        }
        return false;

    }
}