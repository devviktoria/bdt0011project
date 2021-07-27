using UnityEngine;

public class MessageBrokerService : MonoBehaviour
{
    private MessageBroker _messageBroker;

    public MessageBroker MessageBroker
    {
        get
        {
            if (_messageBroker == null)
            {
                _messageBroker = new MessageBroker();
            }

            return _messageBroker;
        }
    }
}