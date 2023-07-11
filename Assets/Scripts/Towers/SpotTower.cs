using System.Collections.Generic;
using Monnaie;
using ScriptableObjects.Variables;
using UnityEngine;

namespace Towers
{
    public class SpotTower : MonoBehaviour
    {
        [SerializeField] private IntVariable _moneySO;
        
        [Header("Interface")]
        [SerializeField] private GameObject _interface;
        [SerializeField] private GameObject _arrows;

        [Header("Prefabs")] 
        [SerializeField] private List<GameObject> _towerPrefabs;
        
        private bool _interfaceOn;

        private void Start()
        {
            InitInterface();
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

            PayTower(tower.GoldCost);
            InstantiateTower(tower.gameObject);
        }

        private void PayTower(int towerGoldCost)
        {
            if (_moneySO.value >= towerGoldCost)
                MoneySystem.AddMoney(-towerGoldCost);
            else
                ToggleInterface();
        }

        #endregion
    }
}