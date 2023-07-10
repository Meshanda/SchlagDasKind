using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MancheManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawners;
    [SerializeField] private List<Waves> _waves;

    public float TimeBeforeNextWave;
    private float _currentTimeBeforeNextWave;
    private int _currentWave;
    private bool _countStarted;

    public void Start()
    {
        _currentTimeBeforeNextWave = 0;
    }

    public void FillSpawner() 
    {
        List<GameObject> gos = new List<GameObject>();

        foreach (var enemi in _waves[_currentWave].Enemies)
        {
            for (int i = 0; i < enemi.Numbers; i++)
            {
                gos.Add(enemi.Prefab);
            }
        }

        _currentTimeBeforeNextWave = TimeBeforeNextWave;
    }

    public bool AreFilled() 
    {
        return false;
        foreach (GameObject go in _spawners) 
        {
            if (_spawners != null)
                return false;
        }
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!AreFilled())
        {
            _currentTimeBeforeNextWave -= Time.deltaTime;
            AddGold();
            _currentWave++;
        }
           

        if(_currentTimeBeforeNextWave <= 0) 
        {
            _currentTimeBeforeNextWave = TimeBeforeNextWave;
            FillSpawner();
            // Add Coins 
        }
    }

    public void AddGold() 
    {
        if (_countStarted = false)
            return;

        // ADD GOLD
        float goldToAdd = _waves[_currentWave].Gold;
        _countStarted = true;
    }
}
[Serializable]
public struct EnemiesToSpawn 
{
    public GameObject Prefab;
    public float Numbers;
}
[Serializable]
public struct Waves 
{
    public List<EnemiesToSpawn> Enemies;
    public float Gold;
}