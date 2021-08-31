using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private MessageBroker _messageBroker;
    private int _aliensToSpawn;

    [SerializeField]
    private GameObject _alienPrefab;
    [SerializeField]
    private GameObject[] _spwanPositions;

    [SerializeField]
    private float _waitTime = 1f;
    [SerializeField]
    private float _spanTime = 2f;

    void Awake()
    {
        _messageBroker = GetComponent<MessageBrokerService>().MessageBroker;
        _messageBroker.GameOver.AddListener(GameOver);
        _messageBroker.GameInitialize.AddListener(Initialize);
    }

    void OnDestroy()
    {
        _messageBroker.GameOver.RemoveListener(GameOver);
        _messageBroker.GameInitialize.RemoveListener(Initialize);
    }

    private void GameOver(bool _)
    {
        CancelInvoke();
    }

    private void Initialize(GameData gameData)
    {
        _waitTime = gameData._waitTime;
        _spanTime = gameData._spawnIntervall;
        _aliensToSpawn = gameData._numberOfAliensToSpawn;
        InvokeRepeating("SpawnAlien", _waitTime, _spanTime);
    }

    private void SpawnAlien()
    {
        if (_aliensToSpawn > 0)
        {
            int randomIndex = Random.Range(0, _spwanPositions.Length);
            Vector3 randomSpawnPosition = _spwanPositions[randomIndex].transform.position;
            float yPostion = _alienPrefab.transform.position.y;
            Vector3 spawnPosition = new Vector3(randomSpawnPosition.x, yPostion, randomSpawnPosition.z);
            GameObject alien = Instantiate(_alienPrefab, spawnPosition, _alienPrefab.transform.rotation);

            DoorAttackerController moveTowardsDoor = alien.GetComponent<DoorAttackerController>();
            moveTowardsDoor.Initialize(_messageBroker);

            alien.GetComponent<AlienHealthController>().Initialize(_messageBroker);

            _aliensToSpawn--;
        }

        if (_aliensToSpawn <= 0)
        {
            CancelInvoke();
        }
    }

}