using UnityEngine;
using System.Collections;

public class JetPack : MonoBehaviour {
	//private Animator myAnimator;
	public string destroy2 = "yes";
	//private int destroyedJet;

	void Start()
	{
		//myAnimator.GetComponent<Animator> ();
	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.isTrigger  != true && coll.CompareTag("Player"))//coll.tag == ("Enemy")
		{
			//Debug.Log ("DESTROYED");
			//myAnimator.SetBool("Destroy",true);
			//audio.PlayOneShot(powerClip);
			coll.SendMessageUpwards("DestroyPowerUp2",destroy2);
			Destroy(this.gameObject.collider2D);
			Destroy(this.gameObject.renderer);
//			bla= true;
//			if(bla == true)
//			{
			//destroyedJet = 1;


		}
	}

	
//	public int DestroyedJet
//	{
//		get 
//		{
//			return destroyedJet; 
//		}
//		set 
//		{ 
//			destroyedJet = value; 
//		}
//	}
	
	
	
}
