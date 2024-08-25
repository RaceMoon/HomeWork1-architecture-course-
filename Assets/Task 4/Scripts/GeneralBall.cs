using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider), typeof(Rigidbody))]
public abstract class GeneralBall : MonoBehaviour
{
    public static Action<Transform> BallBurst;

    private Material _material;
    private MeshRenderer _renderer;
    private void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _material = SetMaterial();
        _renderer.material = _material;
    }
    protected abstract Material SetMaterial();

    protected virtual void OnMouseDown()
    {
        BallBurst(transform);
        Destroy(gameObject);
    }
}
