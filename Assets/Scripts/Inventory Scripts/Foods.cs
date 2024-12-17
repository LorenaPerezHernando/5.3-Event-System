using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventorys
{
    public interface IConsumables { }
    [Serializable]
    public class Foods : Items, IUsables, ISellables, IConsumables
    {

        #region Properties
        [field: SerializeField] public float HealingPoints { get; set; }
        [field: SerializeField] public float Price { get; set; }

        #endregion



        #region Public Methods

        public float Sell()
        {
            Debug.Log("Has ganado" + Price + "dineros!");
            return Price;
        }

        public void Use()
        {
            Debug.Log("Te comes" + Name + "y ganas" + HealingPoints + "vidas!!");
        }

        #endregion

    }

}