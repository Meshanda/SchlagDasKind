using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public int HealthPoint;

    public static Action OnLooseHealthPoint;
    public static event Action OnBaseDestruction;

    private int _currentHealthPoint;

    private void Start()
    {
        _currentHealthPoint = HealthPoint;
    }

    private void OnEnable()
    {
        _currentHealthPoint = HealthPoint;
        OnLooseHealthPoint += LooseHealthPoint;
    }

    private void OnDisable()
    {
        OnLooseHealthPoint -= LooseHealthPoint;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Loose hp
            OnLooseHealthPoint?.Invoke();

            // Destroy the ennemy that contacted
            Destroy(collision.gameObject);
        }
    }

    private void LooseHealthPoint()
    {
        _currentHealthPoint -= 1;

        if(_currentHealthPoint <= 0)
        {
            // Destruction of the base
            Debug.Log("The base is destroyed");
            OnBaseDestruction?.Invoke();
        }
    }
}
