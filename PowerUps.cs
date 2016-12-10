using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour {

	public string destroy = "yes";
	public string fastBG3string = "changeSpeedStr";
	//private Animator myAnimator;
	
	void Start()
	{
		//myAnimator.GetComponent<Animator> ();
	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.isTrigger  != true && coll.CompareTag("Player"))//coll.tag == ("Enemy")
		{
			//Debug.Log ("DESTROYED");
			coll.SendMessageUpwards("BG3Fast",fastBG3string);
			coll.SendMessageUpwards("DestroyPowerUp",destroy);
			Destroy(this.gameObject.collider2D);
			Destroy(this.gameObject.renderer);
			//myAnimator.SetBool("Destroy",true);
		}
	}
	
	
	
}
