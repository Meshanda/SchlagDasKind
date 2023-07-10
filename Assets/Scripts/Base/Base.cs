using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public int HealthPoint;

    public static Action<int> OnLooseHealthPoint;
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
            // Get Enemy damage
            int enemyDamage = 1;

            // Loose HP
            OnLooseHealthPoint?.Invoke(enemyDamage);

            // Destroy the ennemy that contacted
            Destroy(collision.gameObject);
        }
    }

    private void LooseHealthPoint(int damage)
    {
        _currentHealthPoint -= damage;

        if(_currentHealthPoint <= 0)
        {
            OnBaseDestruction?.Invoke();
        }
    }
}
