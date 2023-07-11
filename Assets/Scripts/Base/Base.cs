using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public float HealthPoint;

    public static Action<float> OnLooseHealthPoint;
    public static event Action OnBaseDestruction;

    private float _currentHealthPoint;

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
            Enemy enemy = collision.GetComponent<Enemy>();
            if (!enemy)
                return;

            float enemyDamage = enemy.EnemyDamage;

            // Loose HP
            OnLooseHealthPoint?.Invoke(enemyDamage);

            // Destroy the ennemy that contacted
            Destroy(collision.gameObject);
        }
    }

    private void LooseHealthPoint(float damage)
    {
        _currentHealthPoint -= damage;

        if(_currentHealthPoint <= 0)
        {
            OnBaseDestruction?.Invoke();
        }
    }
}
