using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

namespace Inventory
{
	public class IntentorySystem : MonoBehaviour
	{
		#region Properties
		#endregion

		#region Fields
		//TODO: Refactor: move this to UIController
		[Header("UI Reffs")]
		[SerializeField] private ItemButtom _prefabButton;
		[SerializeField] private Transform _inventoryPanel;
		[SerializeField] private Button _useButton;
		[SerializeField] private Button _sellButton;

		[Header("Object Definition")]
		[SerializeField] private Weapon[] _weapons;
		[SerializeField] private Food[] _foods;
		[SerializeField] private Other[] _others;
		[Header("Item Pool")]
		[SerializeField] private List<Item> _items = new List<Item>();
		[Header("Item Seleced")]
		[SerializeField] private ItemButtom _currentItemSelected;
		#endregion

		#region Unity Callbacks
		// Start is called before the first frame update
		void Start()
		{
			InitializeItems();
			InitializeUI();

			//TODO: refactort
			_useButton.onClick.AddListener(UseCurrentItem);
			_sellButton.onClick.AddListener(SellCurrentItem);
		}
		
		#endregion

		#region Public Methods
		public void AddItem(ItemButtom buttonItemToAdd)
		{
			ItemButtom newButtonItem = Instantiate(buttonItemToAdd, _inventoryPanel);
			newButtonItem.CurrentItem = buttonItemToAdd.CurrentItem;
			newButtonItem.OnClick += () => SelecItem(newButtonItem);
		}

		public void SelecItem(ItemButtom currentItem)
		{
			_currentItemSelected = currentItem;
			//If Sellable
			if (_currentItemSelected.CurrentItem is ISellable)
				_sellButton.gameObject.SetActive(true);
			else
				_sellButton.gameObject.SetActive(false);

			//If Usable
			if (_currentItemSelected.CurrentItem is IUsable)
				_useButton.gameObject.SetActive(true);
			else
				_useButton.gameObject.SetActive(false);


		}
		#endregion

		#region Private Methods
		private void InitializeItems()
		{
			//Weapons
			for (int i = 0; i < _weapons.Length; i++)
				_items.Add(_weapons[i]);

			//Food
			for (int i = 0; i < _foods.Length; i++)
				_items.Add(_foods[i]);

			//Other
			for (int i = 0; i < _others.Length; i++)
				_items.Add(_others[i]);
		}
		private void InitializeUI()
		{
			for (int i = 0; i < _items.Count; i++)
			{
				ItemButtom newButton = Instantiate(_prefabButton, _prefabButton.transform.parent);
				newButton.CurrentItem = _items[i];
				newButton.OnClick += () => AddItem(newButton);
			}
			_prefabButton.gameObject.SetActive(false);
		}

		//Refactor
		private void SellCurrentItem()
		{
			(_currentItemSelected.CurrentItem as ISellable).Sell();
			Consume(_currentItemSelected);
		}
		//Refactor
		private void UseCurrentItem()
		{
			(_currentItemSelected.CurrentItem as IUsable).Use();
			if (_currentItemSelected.CurrentItem is IConsumable)
				Consume(_currentItemSelected);
		}

		private void Consume(ItemButtom currentItemSelected)
		{
			Destroy(_currentItemSelected.gameObject);
			_currentItemSelected = null;
			_sellButton.gameObject.SetActive(false);
			_useButton.gameObject.SetActive(false);
		}

		#endregion
	}
}
