using System;
using ScriptableObjects.Variables;
using UnityEngine;

namespace Monnaie
{
    public class MoneySystem : MonoBehaviour
    {
        // int: amount to add to the money
        public static Action<int> AddMoney;
        
        // int: new total amount
        public static event Action<int> UpdateMoney;

        [SerializeField] private IntVariable _moneySO;

        private void OnEnable()
        {
            AddMoney += OnMoneyAdded;
        }

        private void OnDisable()
        {
            AddMoney -= OnMoneyAdded;
        }

        private void OnMoneyAdded(int amount)
        {
            _moneySO.value += amount;
            UpdateMoney?.Invoke(_moneySO.value);
        }
    }
}
