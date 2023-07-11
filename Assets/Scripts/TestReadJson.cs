using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ScriptableObjects.Game;
using UnityEngine;

namespace DefaultNamespace
{
    public class TestReadJson : MonoBehaviour
    {
        public TowersList towersList;
        
        private void Start()
        {
            string path = "C:\\UnityGlobal\\UnityProject\\modding\\Assets\\SuperTower.json";

            string JsonAsString = File.ReadAllText(path);
            
            if(towersList.value != null)
                towersList.value.Clear();

            List<TowerData> towerData = Utils.JsonConverter.GenericParseJson<List<TowerData>>(JsonAsString);
            
            towersList.AddTowerData(towerData);
            
            //towersList.ReadValues();
            
        }
    }
}