using Inventorys;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace Inventorys
{

    public class ItemButtons : MonoBehaviour
    {

        #region Properties
        public Items CurrentItem
        {
            get
            {
                return _currentItem;
            }
            set
            {
                _currentItem = value;
                _buttonText.text =_currentItem.Name;   
            }
        }

        public event Action OnClick;

        #endregion

        #region Fields
        private TextMeshProUGUI _buttonText;
        private Button _button;
        private Items _currentItem;
        #endregion

        #region Unity Callbacks

        void Awake()
        {
            _button = GetComponent<Button>();
            _buttonText = GetComponentInChildren<TextMeshProUGUI>();
            _button.onClick.AddListener(() => OnClick?.Invoke());    //Delegate Example
        }

        #endregion

     

        #region Private Methods

        #endregion
    }

}