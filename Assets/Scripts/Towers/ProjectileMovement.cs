using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private Collider2D _target;
    public float _speed;
    public float _damage;

    public void Update()
    {
        transform.position += (_target.transform.position - transform.position).normalized * _speed;
    }

    public void SetTarget(Collider2D target)
    {
        _target = target;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (_target != collision)
            return;
        Destroy(gameObject);
    } 
}