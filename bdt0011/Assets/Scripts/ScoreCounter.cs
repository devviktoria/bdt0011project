using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _maximumAllowedAliensAtDoor;
    private int _targetKillCount;
    private int _aliensAtDoor;
    private int _aliensKilled;

    private MessageBroker _messageBroker;

    private void Awake()
    {
        _messageBroker = GetComponent<MessageBrokerService>().MessageBroker;
        _messageBroker.AlienDied.AddListener(IncrementAlienKillCount);
        _messageBroker.AlienReachedDoor.AddListener(AlienReachedDoor);
    }

    private void Start()
    {
        _maximumAllowedAliensAtDoor = 5;
        _targetKillCount = 5;
        _aliensAtDoor = 0;
        _aliensKilled = 0;
    }

    private void OnDestroy()
    {
        _messageBroker.AlienDied.RemoveListener(IncrementAlienKillCount);
        _messageBroker.AlienReachedDoor.RemoveListener(AlienReachedDoor);
    }

    private void IncrementAlienKillCount()
    {
        _aliensKilled++;
        _messageBroker.KillCountUpdated.Invoke(_aliensKilled, _targetKillCount);
        if (_aliensKilled == _targetKillCount)
        {
            _messageBroker.GameOver.Invoke(true);
        }
    }

    private void AlienReachedDoor()
    {
        _aliensAtDoor++;
        _messageBroker.AliensAtDoorUpdated.Invoke(_aliensAtDoor, _maximumAllowedAliensAtDoor);
        if (_aliensAtDoor == _maximumAllowedAliensAtDoor)
        {
            _messageBroker.GameOver.Invoke(false);
        }
    }

}