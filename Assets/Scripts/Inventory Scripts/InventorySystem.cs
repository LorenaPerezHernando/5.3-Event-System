
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Inventorys
{


    public class InventorySystem : MonoBehaviour
    {

        #region Properties

        #endregion

        #region Fields
        //TO-Do Move this to UI Controller
        [Header("UI Reffs")]
        [SerializeField] private ItemButtons _prefabButton;
        [SerializeField] private Transform _inventoryPanel;
        [SerializeField] private Button _sellButton; 
        [SerializeField] private Button _useButton; 

        [Header("Item Pool")]
        [SerializeField] private List<Items> _items = new List<Items>();

        [Header("Object Definition")]
        [SerializeField] private Weapons[] _weapons;
        [SerializeField] private Foods[] _foods;
        [SerializeField] private Others[] _others;

        [Header("Item Selected")]
        [SerializeField] private ItemButtons _currentItemSelected;


        #endregion

        #region Unity Callbacks

        void Start()
        {
            
            InitializeItems();
            InitializeUI();

            //To-Do 
            _useButton.onClick.AddListener(UseCurrentItem);
            _sellButton.onClick.AddListener(SellCurrentItem);

        }


        void Update()
        {

        }
        #endregion

        #region Public Methods
        public void AddItem(ItemButtons buttonItemtoAdd)
        {
            
            ItemButtons newIButtonItem = Instantiate(buttonItemtoAdd, _inventoryPanel);
            newIButtonItem.CurrentItem = buttonItemtoAdd.CurrentItem;
            newIButtonItem.OnClick += () => SelectItem(newIButtonItem);
        }

        public void SelectItem(ItemButtons currentItem)
        {
            _currentItemSelected = currentItem;
            if (_currentItemSelected.CurrentItem is ISellables)            
                _sellButton.gameObject.SetActive(true);
           

            if (_currentItemSelected.CurrentItem is IUsables)
                _useButton.gameObject.SetActive(true);
           
        }

        #endregion

        #region Private Methods
        private void SellCurrentItem()
        {
            (_currentItemSelected.CurrentItem as ISellables).Sell();
            Consume(_currentItemSelected);
        }
        private void UseCurrentItem()
        {
            (_currentItemSelected.CurrentItem as IUsables).Use();
            if(_currentItemSelected.CurrentItem is IConsumables)
            {
                Consume(_currentItemSelected);
            }
        }

        private void Consume(ItemButtons currentItemSelected)
        {
            Destroy(_currentItemSelected.gameObject);
            _currentItemSelected = null;
            _sellButton.gameObject.SetActive(false);
            _useButton.gameObject.SetActive(false);
        }

        private void InitializeItems()
        {
            for (int i = 0; i < _weapons.Length; i++)
                _items.Add(_weapons[i]);  //Podemos hacer la lista pq los weapons son items tambn
            for (int i = 0; i < _foods.Length; i++)
                _items.Add(_foods[i]);
            for (int i = 0; i < _others.Length; i++)
                _items.Add(_others[i]);
        }
        private void InitializeUI()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                ItemButtons newButton = Instantiate(_prefabButton, _prefabButton.transform.parent);
                newButton.CurrentItem = _items[i];
                newButton.OnClick += () => AddItem(newButton);

            }
            _prefabButton.gameObject.SetActive(false);
        }


        #endregion
    }

}