using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SocialPlatforms;
using Task = UnityEditor.VersionControl.Task;


[Serializable]
public class TowerData
{
    public int goldCost;
    public string towerVisual;
    public float timeBetweenShoot;
    public float range;
    
    public float bulletDamage;
    public float bulletSpeedPower;

    public string nameReference = "Base";

    private Sprite _towerSprite;

    public Sprite TowerSprite => _towerSprite;


    public void CreateTowerFromData(Tower toSet)
    {
        toSet.GoldCost = goldCost;
        toSet.Range = range;
        toSet.BulletPower = bulletDamage;
        toSet.SpeedPower = bulletSpeedPower;
        toSet.TimeBetweenShoot = timeBetweenShoot;
        
        toSet.TowerSprite = _towerSprite;
    }

    public async Task<bool> CreateTowerSprite(string modPath)
    {
        _towerSprite = await SpriteConverter.CreateSpriteFromPath($"{modPath}/{towerVisual}");
        return true;
    }
}
