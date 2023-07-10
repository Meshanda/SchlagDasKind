using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Towers
{
    public class SpotTower : MonoBehaviour
    {
        [Header("Interface")]
        [SerializeField] private GameObject _interface;

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
        }

        public void ToggleInterface()
        {
            _interfaceOn = !_interfaceOn;
            _interface.SetActive(_interfaceOn);
        }

        public void InstantiateTower(int index)
        {
            Instantiate(_towerPrefabs[index], transform.position, Quaternion.identity);
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
            InstantiateTower(index);
        }

        #endregion
    }
}