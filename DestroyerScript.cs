using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class DestroyerScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy") 
		{
			//Debug.Break (); when hits it pauses
			Destroy (GameObject.FindWithTag ("Enemy"));


		}
		if (other.gameObject.transform.parent) 
		{
			//Destroy (GameObject.FindWithTag ("Enemy"));
			//Destroy (GameObject.FindWithTag ("Enemy"));
			//Destroy (GameObject.FindWithTag ("Trap"));
		}

		else
		{
			//Destroy (GameObject.FindWithTag ("Enemy"));
			//Destroy (GameObject.FindWithTag ("Trap"));
			//Destroy (GameObject.FindWithTag ("Enemy"));

		}
	}
}
