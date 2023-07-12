using System.Collections.Generic;
using ScriptableObjects.Variables;
using UnityEngine;

namespace ScriptableObjects.Game
{
    
    [CreateAssetMenu(menuName = "ScriptableObjects/Game/TowerModStruct", fileName = "New TowerModStruct")]
    public class TowerMod : GenericVariableSO<List<TowerModStruct>>
    {
        public void AddTowerMod(TowerModStruct inTowerModStruct)
        {
            if (value == null)
                value = new List<TowerModStruct>();
            value.Add(inTowerModStruct);
        }
        
        public void AddTowerMod(List<TowerModStruct> inTowerModStruct)
        {
            foreach (TowerModStruct towerData in inTowerModStruct)
            {
                AddTowerMod(towerData);
            }
        }
        
    }
}
[System.Serializable]
public struct TowerModStruct 
{
    public string lua;
    public string towerName;
}