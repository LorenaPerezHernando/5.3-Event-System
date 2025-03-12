using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Inventorys
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private Button _sellButton;
        [SerializeField] private Button _useButton;
        [SerializeField] private Transform _inventoryPanel;
        [SerializeField] private ItemButtons _prefabButton;

        private ItemButtons _currentItemSelected;

        public ItemButtons PrefabButton => _prefabButton;
        public Transform InventoryPanel => _inventoryPanel;

        private void Start()
        {
            _sellButton.onClick.AddListener(SellCurrentItem);
            _useButton.onClick.AddListener(UseCurrentItem);
        }

        public void SetCurrentItem(ItemButtons item)
        {
            _currentItemSelected = item;
            _sellButton.gameObject.SetActive(_currentItemSelected.CurrentItem is ISellables);
            _useButton.gameObject.SetActive(_currentItemSelected.CurrentItem is IUsables);
        }

        private void SellCurrentItem()
        {
            (_currentItemSelected.CurrentItem as ISellables)?.Sell();
            Consume(_currentItemSelected);
        }

        private void UseCurrentItem()
        {
            (_currentItemSelected.CurrentItem as IUsables)?.Use();
            if (_currentItemSelected.CurrentItem is IConsumables)
            {
                Consume(_currentItemSelected);
            }
        }

        private void Consume(ItemButtons currentItemSelected)
        {
            Destroy(currentItemSelected.gameObject);
            _currentItemSelected = null;
            _sellButton.gameObject.SetActive(false);
            _useButton.gameObject.SetActive(false);
        }

    }
}
