using UnityEngine;
using System;

public class CollisionDetection : MonoBehaviour
{

	#region Unity Callbacks
	private void OnCollisionEnter(Collision collision)
	{
		Debug.Break();
	}
	#endregion
}
