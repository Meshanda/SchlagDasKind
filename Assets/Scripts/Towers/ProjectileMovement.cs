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
        Quaternion rotation = Quaternion.LookRotation
            (_target.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
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