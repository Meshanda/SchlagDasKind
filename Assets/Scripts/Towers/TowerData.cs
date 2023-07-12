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

    public async Task<bool> CreateSpriteFromPath(string modPath)
    {
        Texture2D tex2D;
        string finalPath = modPath + towerVisual;

        finalPath = finalPath.Replace("//", "/");

        if (File.Exists(finalPath)){
            var fileData = await File.ReadAllBytesAsync(finalPath);
            tex2D = new Texture2D(2, 2);
            
            if (tex2D.LoadImage(fileData))
            {
                Texture2D spriteTexture = tex2D;
                _towerSprite = Sprite.Create(spriteTexture, new Rect(0, 0, spriteTexture.width, spriteTexture.height),new Vector2(0.5f,0.31f));
 
                return true;
            }
        }
        return false;
    }
}
