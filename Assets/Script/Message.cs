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
    public static int GetInheritDistance(Type child,Type parent)
    {
        if (!child.IsSubclassOf(parent))
        {
            return -1;
        }
        var type = child;
        for (var i = 0; i < 1024; i++)
        {
            if (type == parent)
                return i;
            type = type.BaseType;
        }
        return -1;
    }
    public static void OnMessage(this IMessageReceiver messageReceiver, Message msg)
    {
        messageReceiver.GetType()
            .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
            .Where(method => method.Name == "OnMessage")
            .Where(method=>method.GetParameters().Length>0)
            .OrderBy(method=>GetInheritDistance(msg.GetType(),method.GetParameters()[0].ParameterType))
            .FirstOrDefault()?.Invoke(messageReceiver, new object[] { msg });
    }
}