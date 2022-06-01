using System;
// -------- Class to describe a message for the messaging system -------------//

namespace SoummySDK.Messaging
{

    public class Message
    {
        public Message() { }

        private Action messageAction;

        public void InvokeMessage() => messageAction?.Invoke();

        public void AddListener(Action listener) => messageAction += listener;

        public void RemoveListener(Action listener) => messageAction -= listener;
    }

    public class Message<T>
    {
        public Message() { }

        private Action<T> messageAction;

        public void InvokeMessage(T messageParam) => messageAction?.Invoke(messageParam);

        public void AddListener(Action<T> listener) => messageAction += listener;

        public void RemoveListner(Action<T> listener) => messageAction -= listener;
    }

    public class Message<T1, T2>
    {
        public Message() { }

        private Action<T1, T2> messageAction;

        public void InvokeMessage(T1 messageParam, T2 messageParam1) => messageAction?.Invoke(messageParam, messageParam1);

        public void AddListener(Action<T1, T2> listener) => messageAction += listener;

        public void RemoveListner(Action<T1, T2> listener) => messageAction -= listener;
    }

}


