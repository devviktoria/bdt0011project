using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody _bulletRigidBody;
    private float _currentAgeInSceconds;

    [SerializeField]
    private float _force = 50.0f;
    [SerializeField]
    private float _lifeSpanInSeconds = 1f;

    void Awake()
    {
        _bulletRigidBody = gameObject.GetComponent<Rigidbody>();
        _bulletRigidBody.AddForce(transform.transform.forward * _force, ForceMode.Impulse);
        _currentAgeInSceconds = 0f;
    }

    void LateUpdate()
    {
        _currentAgeInSceconds += Time.deltaTime;

        if (_currentAgeInSceconds > _lifeSpanInSeconds)
        {
            Destroy(gameObject);
        }
    }

}