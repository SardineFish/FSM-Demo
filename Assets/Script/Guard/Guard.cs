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
}