using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Message
{
    public Message()
    {
    }

    public virtual void Dispatch(IMessageReceiver receiver)
    {
        receiver.OnMessage(this);
    }
}
public interface IMessageReceiver
{
    //void OnMessage(Message msg);
}
public static class MessageExtension
{
    public static void OnMessage(this IMessageReceiver messageReceiver, Message msg)
    {
        messageReceiver.GetType()
            .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
            .Where(method => method.Name == "OnMessage")
            .Where(method => method.GetParameters().Length > 0 && method.GetParameters()[0].ParameterType == msg.GetType())
            .FirstOrDefault()?.Invoke(messageReceiver, new object[] { msg });
    }
}
