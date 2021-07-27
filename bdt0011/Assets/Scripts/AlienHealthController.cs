using UnityEngine;

public class AlienHealthController : MonoBehaviour, IDeathDataProvider
{
    private MessageBroker _messageBroker;
    [SerializeField]
    public bool _isDead;

    public bool IsDead => _isDead;

    public void Initialize(MessageBroker messageBroker)
    {
        _messageBroker = messageBroker;
        _messageBroker?.GameOver.AddListener(GameOver);
        _isDead = false;
    }

    private void OnDestroy()
    {
        _messageBroker?.GameOver.RemoveListener(GameOver);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            //Debug.Log("Collision with bullet");
            if (!_isDead)
            {
                _isDead = true;
                _messageBroker?.AlienDied.Invoke();
            }
        }
    }

    private void GameOver(bool _)
    {
        Destroy(gameObject);
    }
}