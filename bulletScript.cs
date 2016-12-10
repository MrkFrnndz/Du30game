using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {

	public string destroy = "yes";
//	public Rigidbody2D bulletPrefab;
//	float atkSpeed = .5f;
//	float moveSpeed = -5f;
//	float coolDown ;

	private string bulletFireds;

	
	void Update () {

//		if (bulletFireds == "yes") 
//		{
//			Fire();
//		}



	}
//	void Fire()
//	{
//		Rigidbody bPrefab = Instantiate (bulletPrefab, transform.position, Quaternion.identity) as Rigidbody;
//		bPrefab.rigidbody.AddForce(Vector3.left * 500);
//
//		coolDown = Time.time + atkSpeed;
//
//	}


	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.isTrigger  != true && coll.CompareTag("Player"))//coll.tag == ("Enemy")
		{
			Debug.Log ("DESTROYED");
			coll.SendMessageUpwards("DestroyPlayer",destroy);
			
		}
	}

//	public void FireBullets(string fireBullet)
//	{
//		bulletFireds = fireBullet;
//	}
}