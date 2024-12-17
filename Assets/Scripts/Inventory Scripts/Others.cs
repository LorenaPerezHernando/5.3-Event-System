using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Inventorys
{

    [Serializable]
    public class Others : Items, ISellables
    {


        #region Properties
        [field: SerializeField] public float Price { get; set; }

        #endregion

        #region Unity Callbacks

        void Start()
        {

        }


        void Update()
        {

        }
        #endregion

        #region Public Methods
        public float Sell()
        {
            Debug.Log("Has ganado" + Price + "dineros!");
            return Price;
        }

        #endregion


    }

}