using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private MessageBroker _messageBroker;

    [SerializeField]
    private GameObject _alienPrefab;
    [SerializeField]
    private GameObject[] _spwanPositions;
    [SerializeField]
    private GameObject _door;

    [SerializeField]
    private float _waitTime = 1f;
    [SerializeField]
    private float _spanTime = 2f;

    void Awake()
    {
        _messageBroker = GetComponent<MessageBrokerService>().MessageBroker;
        _messageBroker.GameOver.AddListener(GameOver);
    }

    void Start()
    {
        InvokeRepeating("SpawnAlien", _waitTime, _spanTime);
    }

    void OnDestroy()
    {
        _messageBroker.GameOver.RemoveListener(GameOver);
    }

    private void GameOver(bool _)
    {
        CancelInvoke();
    }

    private void SpawnAlien()
    {
        int randomIndex = Random.Range(0, _spwanPositions.Length);
        Vector3 randomSpawnPosition = _spwanPositions[randomIndex].transform.position;
        float yPostion = _alienPrefab.transform.position.y;
        Vector3 spawnPosition = new Vector3(randomSpawnPosition.x, yPostion, randomSpawnPosition.z);
        GameObject alien = Instantiate(_alienPrefab, spawnPosition, _alienPrefab.transform.rotation);

        DoorAttackerController moveTowardsDoor = alien.GetComponent<DoorAttackerController>();
        moveTowardsDoor.Initialize(_messageBroker);

        alien.GetComponent<AlienHealthController>().Initialize(_messageBroker);

    }

}