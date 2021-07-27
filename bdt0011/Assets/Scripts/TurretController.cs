using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurretController : MonoBehaviour
{
    private float _leftHandBoundary;
    private float _rightHandBoundary;
    private float _horizontalInput;

    [SerializeField]
    private float _rotationSpeed;
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private GameObject _bulletPosition;
    [SerializeField]
    private GameObject _rotatingPart;

    public void RotateRequest(InputAction.CallbackContext context)
    {
        _horizontalInput = context.ReadValue<float>();
    }

    public void FireBullet(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            float bulletYRotation = _rotatingPart.transform.rotation.eulerAngles.y - 90;
            Instantiate(_bulletPrefab, _bulletPosition.transform.position, Quaternion.AngleAxis(bulletYRotation, Vector3.up));
        }
    }

    private void Start()
    {
        _leftHandBoundary = 5f;
        _rightHandBoundary = 175f;
        _horizontalInput = 0.0f;
    }

    private void Update()
    {
        RotateTurret();
    }

    private void RotateTurret()
    {
        float yRotation = _rotatingPart.transform.rotation.eulerAngles.y;
        bool canTurnLeft = yRotation > _leftHandBoundary + 1;
        bool canTurnRight = yRotation < _rightHandBoundary - 1;

        if (Math.Sign(_horizontalInput) == -1 && canTurnLeft)
        {
            _rotatingPart.transform.Rotate(Vector3.up, -_rotationSpeed * Time.deltaTime);
        }
        else if (Math.Sign(_horizontalInput) == 1 && canTurnRight)
        {
            _rotatingPart.transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
        }
    }
}