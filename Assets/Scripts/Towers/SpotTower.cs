using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Towers
{
    public class SpotTower : MonoBehaviour
    {
        [SerializeField] private GameObject _highlight;
        
        [Header("Interface")]
        [SerializeField] private GameObject _interface;

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
        }

        #endregion
    }
}