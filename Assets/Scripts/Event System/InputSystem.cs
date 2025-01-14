using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{

    #region Properties

    #endregion

    #region Fields
    [SerializeField] private Health _playerHealth;
    private int _damage = 20;
    private int _life = 20;

    [SerializeField] private Points _points;
    private int _pointsToAdd = 50;
#endregion

#region Unity Callbacks

    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
            _playerHealth.GetDamage(_damage);

        if(Input.GetKeyUp(KeyCode.Space))
            _playerHealth.GetHeal(_life);

        if(Input.GetKeyUp(KeyCode.Escape))
            _points.AddPoints(_pointsToAdd);
    }
#endregion

#region Public Methods

#endregion

#region Private Methods

#endregion
}
