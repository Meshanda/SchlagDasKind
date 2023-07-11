﻿using System.Collections.Generic;
using ScriptableObjects.Variables;
using UnityEngine;

namespace ScriptableObjects.Game
{
    
    [CreateAssetMenu(menuName = "ScriptableObjects/Game/Towers", fileName = "New Towers List")]
    public class TowersList : GenericVariableSO<List<TowerData>>
    {
        public void AddTowerData(TowerData inTowerData)
        {
            if (value == null)
                value = new List<TowerData>();

            if (inTowerData.nameReference.Equals(""))
                inTowerData.nameReference = "Base";

            inTowerData.CreateSpriteFromPath();
            value.Add(inTowerData);
        }
        
        public void AddTowerData(List<TowerData> inTowersData)
        {
            foreach (TowerData towerData in inTowersData)
            {
                AddTowerData(towerData);
            }
        }
        
        /*public void ReadValues()
        {
            foreach (TowerData towerData in value)
            {
                Debug.Log($"gold : {towerData.goldCost}\nvisual : {towerData.towerVisual}\ntimeBetweenShoot : {towerData.timeBetweenShoot}\name reference : {towerData.nameReference}");
            }
        }*/
    }
}