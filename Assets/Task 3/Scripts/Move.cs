using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _moveX;
    private float _moveZ;
    private float _speed;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _speed = 5;
    }

    private void Update()
    {
        _moveX = Input.GetAxis("Horizontal");
        _moveZ = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_moveX, 0, _moveZ) * _speed;
    }
}
