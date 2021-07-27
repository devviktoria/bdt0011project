using UnityEngine.Events;

public class GameOverEvent : UnityEvent<bool> { }
public class AliensAtDoorUpdatedEvent : UnityEvent<int, int> { }
public class KillCountUpdatedEvent : UnityEvent<int, int> { }

public class MessageBroker
{
    private UnityEvent _alienReachedDoor;
    private UnityEvent _alienDied;
    private GameOverEvent _gameOver;
    private AliensAtDoorUpdatedEvent _aliensAtDoorUpdated;
    private KillCountUpdatedEvent _killCountUpdated;

    public UnityEvent AlienReachedDoor
    {
        get => _alienReachedDoor;
    }

    public UnityEvent AlienDied
    {
        get => _alienDied;
    }

    public GameOverEvent GameOver
    {
        get => _gameOver;
    }

    public AliensAtDoorUpdatedEvent AliensAtDoorUpdated
    {
        get => _aliensAtDoorUpdated;
    }

    public KillCountUpdatedEvent KillCountUpdated
    {
        get => _killCountUpdated;
    }

    public MessageBroker()
    {
        _alienDied = new UnityEvent();
        _alienReachedDoor = new UnityEvent();
        _gameOver = new GameOverEvent();
        _aliensAtDoorUpdated = new AliensAtDoorUpdatedEvent();
        _killCountUpdated = new KillCountUpdatedEvent();
    }
}