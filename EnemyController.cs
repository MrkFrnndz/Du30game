using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	//public float moveSpeed;
	//private Rigidbody2D myRigidbody;
	private Animator myAnimator;
	//public bool animation_bool;
	//private Collider2D myCollider;
	private bool attack;
	public LayerMask sight; 

	public Transform onSight;
	public float area;


	private string destroyed;

	//for CHARACTER killing
	public Collider2D attackTriggeredEnemy;
	public bool attacking = false;
	private float attackTimer = 0;
	private float attackCD = 0.5f;



	// Use this for initialization
	void Start () {
		//myRigidbody = GetComponent<Rigidbody2D>();
		//myCollider = GetComponent<Collider2D>();
		myAnimator = GetComponent<Animator> ();
		attackTriggeredEnemy.enabled = false;
		//myAnimator.SetBool("takbo", myAnimator);

	}

	// Update is called once per frame
	void Update ()
	{
		//HandleInputFromCollider ();
		StartCoroutine (DeathEnemy1());

		attack = Physics2D.OverlapCircle (onSight.transform.position,area,sight);

		if (attack) 
		{
			//Debug.Log("Collides");
			attacking = true;
			attackTimer = attackCD;
			attackTriggeredEnemy.enabled = true;
			myAnimator.SetBool ("attack",true);
			attack = false;
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
				attackTriggeredEnemy.enabled = false;
			}
			
		}



		//myRigidbody.velocity = new Vector2 (moveSpeed,myRigidbody.velocity.y);

	}
	IEnumerator DeathEnemy1()
	{
		if(destroyed == "yes")
		{	
			myAnimator.SetTrigger("death");
			Destroy(attackTriggeredEnemy);
			yield return new WaitForSeconds (2.0f);
			Destroy (GameObject.FindWithTag ("Enemy"));
		}
	}


//	void OnTriggerEnter2D(Collider2D coll)
//	{
//		if (coll.tag == "Player") 
//		{
//			//animation_bool = true;
//			//attack = true;
//		}
//	}


//	IEnumerator delayMethod() 
//	{
//		if (attack == true)
//		{
//			Debug.Log ("Before Waiting .5 Second");
//			yield return new WaitForSeconds (.25f);
//			Destroy (GameObject.FindWithTag ("Enemy"));
//			myAnimator.SetBool("attack", false);
//			//DestroyObject (myCollider);
//			Debug.Log ("After Waiting .5 Second");
//
//		}
//	}

	public void DestroyEnemy(string destroy)
	{
		destroyed = destroy;
	}
	void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(onSight.transform.position,area);
	}



}
