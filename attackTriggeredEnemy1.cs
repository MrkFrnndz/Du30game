using UnityEngine;
using System.Collections;

public class attackTriggeredEnemy1 : MonoBehaviour {

	public string destroy = "yes";
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.isTrigger  != true && coll.CompareTag("Player"))//coll.tag == ("Enemy")
		{
			Debug.Log ("DESTROYED");
			coll.SendMessageUpwards("DestroyPlayer",destroy);
			
		}
	}
	
}

