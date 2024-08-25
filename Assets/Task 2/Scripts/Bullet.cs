using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rb;

    public void Inicialize(float speed)
    {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = new Vector3(0, 0, speed);
    }
}
