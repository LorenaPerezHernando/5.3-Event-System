
using UnityEngine;
using System;

public class GettersSetters : MonoBehaviour
{
	#region Properties	
	public int Points { get; set; }
	public int LevelPoints
	{
		get
		{
			return _levelPoints;
		}
	}
	//Delegate shotcut
	//public int LevelPoints => _levelPoints;
	#endregion

	#region Fields
	[SerializeField] private int _levelPoints = 1000;
	#endregion

	#region Unity Callbacks
	// Start is called before the first frame update
	void Start()
    {
		Points = 100; //Set
		Debug.Log("Points " + Points); //Get
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	#endregion

	#region Public Methods
	#endregion

	#region Private Methods
	#endregion
}
