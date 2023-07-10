using System;
using System.Collections;
using System.Collections.Generic;
using PathCreation.Examples;
using UnityEngine;

public enum EnemyGradeDamage
{
    Weak = 1,
    Normal = 3,
    Strong = 8,
    Boss = 50,
    Snail = 99999
}


public class Enemy : MonoBehaviour
{
    
    public static Action onEnemyDeath;
    
    public float lifePoint = 20.0f;
    public float walkSpeed = 2.0f;
    public EnemyGradeDamage enemyGradeDamage = EnemyGradeDamage.Weak;
    public float enemyDamageOverride = 0.0f;
    public Sprite sprite;

    private float _enemyDamage;
    public float EnemyDamage => _enemyDamage;
    
    [SerializeField] private PathFollower _pathFollower;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _pathFollower.speed = walkSpeed;

        _spriteRenderer.sprite = sprite;

        _enemyDamage = enemyDamageOverride > 0.0f ? enemyDamageOverride : (int) enemyGradeDamage;
        Debug.Log(_enemyDamage);
    }

    public void DamageEnemy(float damage)
    {
        lifePoint -= damage;

        if (lifePoint > 0.0f) return;
        
        onEnemyDeath.Invoke();
        Destroy(gameObject);
    }
}
