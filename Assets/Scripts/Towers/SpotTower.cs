using System;
using System.Collections.Generic;
using Monnaie;
using ScriptableObjects.Variables;
using UnityEngine;

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

        [Header("Prefabs")] 
        [SerializeField] private List<GameObject> _towerPrefabs;
        
        private bool _interfaceOn;

        private void Start()
        {
            InitInterface();
            InitPreviews();
        }

        private void InitPreviews()
        {
            if (!_towerPrefabs[0].TryGetComponent(out Tower tower1)) throw new Exception("GameObject Tower does not have Tower Script!!!!");
            _preview1.ChangePreview(tower1.GoldCost, (int)tower1.BulletPower, (int)tower1.TimeBetweenShoot, (int)tower1.Range, tower1.TowerSprite);
            
            if (!_towerPrefabs[1].TryGetComponent(out Tower tower2)) throw new Exception("GameObject Tower does not have Tower Script!!!!");
            _preview2.ChangePreview(tower2.GoldCost, (int)tower2.BulletPower, (int)tower2.TimeBetweenShoot, (int)tower2.Range, tower2.TowerSprite);
            
            if (!_towerPrefabs[2].TryGetComponent(out Tower tower3)) throw new Exception("GameObject Tower does not have Tower Script!!!!");
            _preview3.ChangePreview(tower3.GoldCost, (int)tower3.BulletPower, (int)tower3.TimeBetweenShoot, (int)tower3.Range, tower3.TowerSprite);
        }

        private void InitInterface()
        {
            _interface.SetActive(false);
            _interfaceOn = false;
            _arrows.SetActive(_towerPrefabs.Count > 3);
        }

        public void ToggleInterface()
        {
            _interfaceOn = !_interfaceOn;
            _interface.SetActive(_interfaceOn);
        }

        public void InstantiateTower(GameObject prefab)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
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
            if (!_towerPrefabs[index].TryGetComponent(out Tower tower)) return;

            if (PayTower(tower.GoldCost))
                InstantiateTower(tower.gameObject);
            else
                ToggleInterface();
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