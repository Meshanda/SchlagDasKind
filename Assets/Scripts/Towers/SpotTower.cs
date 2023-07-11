using System;
using System.Collections.Generic;
using Monnaie;
using ScriptableObjects.Game;
using ScriptableObjects.Variables;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Towers
{
    public class SpotTower : MonoBehaviour
    {
        [SerializeField] private IntVariable _moneySO;

        [Header("Previews")] 
        [SerializeField] private TowerPreview _preview1;
        [SerializeField] private TowerPreview _preview2;
        [SerializeField] private TowerPreview _preview3;
        
        [Header("Interface")]
        [SerializeField] private GameObject _interface;
        [SerializeField] private GameObject _arrows;

        [SerializeField] private TowersList _towersList;

        [FormerlySerializedAs("_towerPrefabs")]
        [Header("Prefabs")] 
        [SerializeField] private List<GameObject> _baseTowerPrefabs;

        [SerializeField] private GameObject PrefabTest;
        
        private bool _interfaceOn;

        private void Start()
        {
            InitInterface();
            InitPreviews();
        }

        private void InitPreviews()
        {
            if (!_baseTowerPrefabs[0].TryGetComponent(out Tower tower1)) throw new Exception("GameObject Tower does not have Tower Script!!!!");
            _preview1.ChangePreview(tower1.GoldCost, (int)tower1.BulletPower, (int)tower1.TimeBetweenShoot, (int)tower1.Range, tower1.TowerSprite);
            
            if (!_baseTowerPrefabs[1].TryGetComponent(out Tower tower2)) throw new Exception("GameObject Tower does not have Tower Script!!!!");
            _preview2.ChangePreview(tower2.GoldCost, (int)tower2.BulletPower, (int)tower2.TimeBetweenShoot, (int)tower2.Range, tower2.TowerSprite);
            
            if (!_baseTowerPrefabs[2].TryGetComponent(out Tower tower3)) throw new Exception("GameObject Tower does not have Tower Script!!!!");
            _preview3.ChangePreview(tower3.GoldCost, (int)tower3.BulletPower, (int)tower3.TimeBetweenShoot, (int)tower3.Range, tower3.TowerSprite);
        }

        private void InitInterface()
        {
            _interface.SetActive(false);
            _interfaceOn = false;
            _arrows.SetActive(_baseTowerPrefabs.Count > 3);
        }

        public void ToggleInterface()
        {
            _interfaceOn = !_interfaceOn;
            _interface.SetActive(_interfaceOn);
        }

        public void InstantiateTower(GameObject prefab)
        {
            var go = Instantiate(prefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
        #region Buttons

        public void ClickLeftArrow()
        {
            Debug.Log("Flèche gauche");
        }

        public void ClickRightArrow()
        {
            Debug.Log("Flèche droite");
        }

        public void ClickSpot(int index)
        {
            Debug.Log($"Click Spot {index}");
            if (!_baseTowerPrefabs[index].TryGetComponent(out Tower tower)) return;

            if (PayTower(tower.GoldCost))
                InstantiateTower(tower.gameObject);
            else
                ToggleInterface();

            /*if (PayTower(_towersList.value[index].goldCost))
            {
                GameObject newTowerObject = Instantiate(PrefabTest, transform.position, Quaternion.identity);

                var towerScript = newTowerObject.GetComponent<Tower>();
                _towersList.value[index].CreateTowerFromData(towerScript);
                Destroy(gameObject);
            }*/
        }

        private bool PayTower(int towerGoldCost)
        {
            if (_moneySO.value >= towerGoldCost)
            {
                MoneySystem.AddMoney(-towerGoldCost);
                return true;
            }

            return false;
        }

        #endregion
    }
}