using UnityEngine;
using System.Collections;

public class EnemyController2 : MonoBehaviour {

	
	private Animator myAnimator;
	private bool attack;
	public LayerMask sight; 
	
	public Transform fireTriggeredTrnfrm;
	public float radiuss;
	
	
	private string destroyed;
	
	//for CHARACTER killing
	public bool attacking = false;
	private float attackTimer = 0;
	private float attackCD = 0.5f;


	//NEW
	//Drag in the Bullet Emitter from the Component Inspector.
	public GameObject Bullet_Emitter;
	
	//Drag in the Bullet Prefab from the Component Inspector.
	public GameObject Bullet;
	
	//Enter the Speed of the Bullet from the Component Inspector.
	public float Bullet_Forward_Force;


	//float atkSpeed = .5f;
	//float coolDown;


	float timerShoot = 0;
	
	
	// Use this for initialization
	void Start () {
	
		myAnimator = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		StartCoroutine (DeathEnemy2 ());

		timerShoot += 1;

		attack = Physics2D.OverlapCircle (fireTriggeredTrnfrm.transform.position,radiuss,sight);
		
		if (attack) 
		{
			if(timerShoot >= 80)
			{
				//Debug.Log("Collides");
				attacking = true;
				attackTimer = attackCD;
				myAnimator.SetBool ("attack",true);
				Fires();
				timerShoot = 0;
			}
		}
		if (!attack) 
		{	
			myAnimator.SetBool ("attack",false);
		}

		if (attacking) 
		{
			if(attackTimer > 0)
			{
				attackTimer -= Time.deltaTime;
			}
			else
			{
				attacking = false;
			}
			
		}
		
	}

	public void Fires()
	{
		//The Bullet instantiation happens here.
		GameObject Temporary_Bullet_Handler;
		Temporary_Bullet_Handler = Instantiate(Bullet,Bullet_Emitter.transform.position,Bullet_Emitter.transform.rotation) as GameObject;
		
		//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
		//This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
		Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 0);
		
		//Retrieve the Rigidbody component from the instantiated Bullet and control it.
		Rigidbody2D Temporary_RigidBody;
		Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody2D>();
		
		//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
		Temporary_RigidBody.AddForce(Vector3.left * Bullet_Forward_Force);

		//coolDown = Time.time + atkSpeed;
		
		//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
		Destroy(Temporary_Bullet_Handler, 4.0f);
	}


	IEnumerator DeathEnemy2()
	{
		if(destroyed == "yes")
		{	
			myAnimator.SetTrigger("death");
			yield return new WaitForSeconds (2.0f);
			Destroy (GameObject.FindWithTag ("Enemy"));
		}
	}
	
	public void DestroyEnemy(string destroy)
	{
		destroyed = destroy;
	}
	void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(fireTriggeredTrnfrm.transform.position,radiuss);
	}
	
	
	
}

