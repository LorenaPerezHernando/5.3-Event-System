
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Inventorys;

namespace Inventorys
{
    public class InventorySystem : MonoBehaviour
    {

        #region Properties

        #endregion

        #region Fields
        [Header("Item Pool")]
        [SerializeField] private List<Items> _items = new List<Items>();
        

        [Header("Object Definition")]
        [SerializeField] private Weapons[] _weapons;
        [SerializeField] private Foods[] _foods;
        [SerializeField] private Others[] _others;
      
        private InventoryUI _inventoryUI;
        [SerializeField] private ItemButtons _currentItemSelected;


        #endregion

        #region Unity Callbacks

        void Start()
        {            
            _inventoryUI = FindAnyObjectByType<InventoryUI>();           
            InitializeItems();
            InitializeUI();
        }

        #endregion

        #region Public Methods
        public void AddItem(ItemButtons newItem)
        {
            if (newItem == null)
            {
                Debug.LogError("Se intentó agregar un ítem nulo.");
                return;
            }

            // Crear un nuevo botón
            ItemButtons newButton = Instantiate(newItem, _inventoryUI.InventoryPanel);
            newButton.CurrentItem = newItem.CurrentItem;

            // Asegurar que al hacer clic se seleccione correctamente
            newButton.OnClick += () => SelectItem(newButton);
        }

        public void SelectItem(ItemButtons itemButtons)
        {
            _currentItemSelected = itemButtons;
            _inventoryUI.SetCurrentItem(_currentItemSelected);


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
                if (_inventoryUI.PrefabButton == null)
                {
                    Debug.LogError("El PrefabButton en InventoryUI no está asignado.");
                    return;
                }

                ItemButtons newButton = Instantiate(_inventoryUI.PrefabButton, _inventoryUI.PrefabButton.transform.parent);
                newButton.CurrentItem = _items[i];
                newButton.OnClick += () => AddItem(newButton);
               // newButton.OnClick += () => SelectItem(newButton);

            }
            
            _inventoryUI.PrefabButton.gameObject.SetActive(false);
        }

        #endregion


    }

}