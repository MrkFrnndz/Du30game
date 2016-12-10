using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;
	public bool isGrounded;
	public LayerMask ground;

	public Transform grounder;
	public float radiuss;



	private Rigidbody2D myRigidbody;
	private Animator myAnimator;

	//ATTACKING
	public Collider2D attackTrigger;
	public bool attacking = false;
	private float attackTimer = 0;
	private float attackCD = .3f;

	private string destroyed;

	//COUNTER FOR POWER UPS
	//public float timer = 0.0f;
	//public Rigidbody2D rgdPowerUps;

	//Drag in the Bullet Emitter from the Component Inspector.
	public GameObject Punch_Emitter;
	//Drag in the Bullet Prefab from the Component Inspector.
	public GameObject Punch;
	//Enter the Speed of the Bullet from the Component Inspector.
	public float Punch_Forward_Force;

	//DISABLING POWERPUNCH button
	public float coolDown; //put value for COOLDOWN
	public float coolDownTimer;
	bool fireHolder;
	public GameObject btnPower;

	//float blurValue = 10.0f;
//	private float cdTimer = 5.0f;
//	public float coolDown;
//	public float coolDownTimer;


	//POWERUPS BIKE & JETPACK

	private string pdestroyed;
	private string pdestroyed2;


	//DEATH VARIABLES
	//string doesHolder;

	//SCORE MANAGER
	private ScoreManager theScoreManager;
	private float plyrHscore;








	// Use this for initialization
	void Start () {
		
		myRigidbody = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator> ();
		attackTrigger.enabled = false;

		//blurValue = coolDownTimer / 10;
		theScoreManager = FindObjectOfType<ScoreManager> ();
		theScoreManager.scoreCount = 0;//scoring
		theScoreManager.scoreIncreasing = true;//scoring
		plyrHscore = PlayerPrefs.GetFloat("HighScore");
		//PlayerPrefs.SetFloat("HighScore", plyrHscore);//scoring



}
	
	// Update is called once per frame
	void Update () 
	{
//		theScoreManager.scoreIncreasing = false;
//		theScoreManager.scoreCount = 0;
//		theScoreManager.scoreIncreasing = true;
		
		//TIMER FOR POWERPUNCH
		if (coolDownTimer > 0) 
		{
			coolDownTimer -= Time.deltaTime;
		}
		if (coolDownTimer < 0) 
		{
			coolDownTimer = 0;
			btnPower.SetActive(true);
		}
		if (fireHolder == true && coolDownTimer ==0) 
		{
			coolDownTimer = coolDown;
			fireHolder = false;


						//The Bullet instantiation happens here.
						GameObject Temporary_Bullet_Handler;
						Temporary_Bullet_Handler = Instantiate(Punch,Punch_Emitter.transform.position,Punch_Emitter.transform.rotation) as GameObject;
						
						//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
						//This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
						Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 0);
						
						//Retrieve the Rigidbody component from the instantiated Bullet and control it.
						Rigidbody2D Temporary_RigidBody;
						Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody2D>();
						
						//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
						Temporary_RigidBody.AddForce(Vector3.right * Punch_Forward_Force);
						
						//coolDown = Time.time + atkSpeed;
						
						//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
						Destroy(Temporary_Bullet_Handler, 3.0f);

		}

		//Player Death Animation
		StartCoroutine (DeathPlayer ());



		//RUN AND JUMP INITIALS
		myRigidbody.velocity = new Vector2 (moveSpeed,myRigidbody.velocity.y); //if else happens change moveSpeed = 5.0f
		isGrounded = Physics2D.OverlapCircle (grounder.transform.position,radiuss,ground); //bool TRUE value



		//FOR POWER UP BIKE JETPACK ANIMATION
		if(pdestroyed == "yes")//&& pdestroyed2 != "yes")
		{ 
			moveSpeed = 10.0f;
			myAnimator.SetBool("Bike",true);
			StartCoroutine(BikeEnds());
			//myAnimator.SetBool("JetPack",false);
			//myAnimator.SetBool("JetPack",false);
		}
		if(pdestroyed2 == "yes" )//&& pdestroyed != "yes")
		{
			myAnimator.SetBool("JetPack",true);
			StartCoroutine(JetPackEnds());
			//myAnimator.SetBool("Bike",false);

		}

//		else if(pdestroyed2 == "yes" && pdestroyed != "yes")
//		{	
//			//Debug.Log("OCCURED");
//			//Destroy (GameObject.FindWithTag ("PowerUp"));
//			myAnimator.SetBool("JetPack",true);
//			//myAnimator.SetBool("Bike",false);
//		}
		
		//myAnimator.SetFloat ("Speed", myRigidbody.velocity.x);
		//myAnimator.SetBool ("Grounded", isGrounded);



		//FOR ATTACK ANIMATION
		if (attacking) 
		{
			if(attackTimer > 0)
			{
				attackTimer -= Time.deltaTime;
			}
			else
			{
				attacking = false;
				attackTrigger.enabled = false;
			}

		}
		
		myAnimator.SetFloat ("Speed", myRigidbody.velocity.x);
		myAnimator.SetBool ("Grounded", isGrounded);

	}
	IEnumerator BikeEnds()
	{
		if (pdestroyed == "yes") 
		{
			yield return new WaitForSeconds (5.0f);
			myAnimator.SetBool ("Bike", false);
			pdestroyed2 = "";
		}
	}
	IEnumerator JetPackEnds()
	{
		if (pdestroyed2 == "yes") 
		{
			yield return new WaitForSeconds (5.0f);
			myAnimator.SetBool ("JetPack", false);
			pdestroyed2 = "";
		}
	}
	//death Animation Player
	IEnumerator DeathPlayer()
	{	
		if (destroyed == "yes") 
		{
			theScoreManager.scoreIncreasing = false;//scoring
			myAnimator.SetTrigger("Death");
			isGrounded = false;
			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.y, 0.0f);
			yield return new WaitForSeconds (2.0f);
			Destroy (GameObject.FindWithTag ("Player"));

		}
	}
	//PLAYER BUTTONS
	public void playerDo(string does)
	{
		if (does == "a") 
		{
			attacking = true;
			attackTimer = attackCD;
			attackTrigger.enabled = true;
			myAnimator.SetTrigger("Attack");
		}
		if (does == "b") 
		{
			if(isGrounded)
			{	
				//Debug.Log ("JUMP!");
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.y, jumpForce);
				//doesHolder = does;
			}
		}
		if(does == "b" && pdestroyed2 == "yes")
		{
			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.y, jumpForce);
		}
		if (does == "c") 
		{
			fireHolder = true;
			btnPower.SetActive(false);

		}
	}
	//BUTTON POWER BLUR EFFECT
//	public void ButtonBlur(float blurValue)
//	{
//		//Image image = GetComponentsInChildren<Image> ();
//		blurValue = cdTimerBlurValue;
//	}


	//Destroying Player Method
	public void DestroyPlayer(string destroy)
	{
		destroyed = destroy;
	}
	//Destroying Power Ups Method
	public void DestroyPowerUp(string pdestroy)
	{
		pdestroyed = pdestroy;
	}
	//Destroying Power Ups2 Method
	public void DestroyPowerUp2(string destroy2)
	{
		pdestroyed2 = destroy2;
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(grounder.transform.position,radiuss);
	}


}
