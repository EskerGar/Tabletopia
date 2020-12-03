using System;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    public event Action<Color> OnBump;
    
    private Rigidbody _rigidbody;
    private bool _isDowned;
    private const float Speed = 10f;
    private Vector3 _position;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }


    public void ActivateCube(Action<Color> func)
    {
        OnBump += func;
    }

    public void SetPosition(Vector3 position)
    {
        _position = position;
    }

    public void DeactivateCube(Action<Color> func)
    {
        OnBump -= func;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _position.normalized * Speed;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        var cube = other.gameObject.GetComponent<MoveComponent>();
        if (cube != null)
        {
            OnBump?.Invoke(cube.GetComponent<MeshRenderer>().material.color);
        }
    }
}