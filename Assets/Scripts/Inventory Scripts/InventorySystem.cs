
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
        //[Header("UI Reffs")]
        //[SerializeField] private ItemButtons _prefabButton;
        //[SerializeField] private Transform _inventoryPanel;
        //[SerializeField] private Button _sellButton; 
        //[SerializeField] private Button _useButton; 

        [Header("Item Pool")]
        [SerializeField] private List<Items> _items = new List<Items>();
        

        [Header("Object Definition")]
        [SerializeField] private Weapons[] _weapons;
        [SerializeField] private Foods[] _foods;
        [SerializeField] private Others[] _others;
      
        private InventoryUI _inventoryUI;


        #endregion

        #region Unity Callbacks

        private void Awake()
        {
        }

        void Start()
        {
            
            _inventoryUI = FindAnyObjectByType<InventoryUI>();           
            InitializeItems();
            InitializeUI();


        }

        #endregion

        #region Public Methods
        public void AddItem(ItemButtons buttonItemtoAdd)
        {            
            ItemButtons newIButtonItem = Instantiate(buttonItemtoAdd, _inventoryUI.InventoryPanel);
            newIButtonItem.CurrentItem = buttonItemtoAdd.CurrentItem;
            newIButtonItem.OnClick += () => SelectItem(newIButtonItem);
        }

        public void SelectItem(ItemButtons currentItem) 
        {
            _inventoryUI.SetCurrentItem(currentItem);
            
           
        }

        #endregion
        #region Private Methods
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
                AddItem(_inventoryUI.PrefabButton);

            }
            _inventoryUI.PrefabButton.gameObject.SetActive(false);
        }

        #endregion


    }

}