using UnityEngine.Events;

public struct GameData
{
    public int _numberOfAliensToSpawn;
    public float _waitTime;
    public float _spawnIntervall;
    public int _maximumAliensAtDoor;
    public int _targetKillCount;
}

public class GameOverEvent : UnityEvent<bool> { }
public class AliensAtDoorUpdatedEvent : UnityEvent<int, int> { }
public class KillCountUpdatedEvent : UnityEvent<int, int> { }
public class InititalizeGameEvent : UnityEvent<GameData> { }

public class MessageBroker
{
    private UnityEvent _alienReachedDoor;
    private UnityEvent _alienDied;
    private GameOverEvent _gameOver;
    private AliensAtDoorUpdatedEvent _aliensAtDoorUpdated;
    private KillCountUpdatedEvent _killCountUpdated;
    private InititalizeGameEvent _gameInitialize;

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

    public InititalizeGameEvent GameInitialize
    {
        get => _gameInitialize;
    }

    public MessageBroker()
    {
        _alienDied = new UnityEvent();
        _alienReachedDoor = new UnityEvent();
        _gameOver = new GameOverEvent();
        _aliensAtDoorUpdated = new AliensAtDoorUpdatedEvent();
        _killCountUpdated = new KillCountUpdatedEvent();
        _gameInitialize = new InititalizeGameEvent();
    }
}