using UnityEngine;
using System.Collections;

public class attackTriggered : MonoBehaviour {

	public string destroy = "yes";

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.isTrigger  != true && coll.CompareTag("Enemy"))//coll.tag == ("Enemy")
		{
			//Debug.Log ("DESTROYED");
			coll.SendMessageUpwards("DestroyEnemy",destroy);
			
		}
	}



}
