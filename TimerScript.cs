using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerScript : MonoBehaviour 
{
	public float coolDown =3;
	public float coolDownTimer;
	bool fireHolder;

	void Update()
	{
		if (coolDownTimer > 0) 
		{
			coolDownTimer -= Time.deltaTime;
		}
		if (coolDownTimer < 0) 
		{
			coolDownTimer = 0;
		}
		if (fireHolder == true && coolDownTimer ==0) 
		{
			Debug.Log("FIRE ATTACK!");
			coolDownTimer = coolDown;
			fireHolder = false;
		}
	}

	public void ButtonDo(string does)
	{
		if (does == "fire") 
		{
			fireHolder = true;
		}
	}
}

//	#region Fields
//
//	int startTime;              // timer's initial start time
//	int restSeconds;            // amount of seconds left in countdown
//	int roundedRestSeconds;     // amount of seconds left in countdown (rounded up)
//	int displaySeconds;         // used for displaying seconds on timer
//	int displayMinutes;         // used for displaying minutes on timer
//
//	int countDownSeconds;       // time limit for countdown in seconds
//
//	int guiTime;                // time displayed on GUI
//
//	bool timerActive;           // determines whether timer is active
//
//	Button btnA,btnB; //author mark. . getting buttons
//	#endregion
//
//	#region Functions
//	void Start()
//	{
//		btnA = GET<Button> ();
//		btnB = GetComponent<Button> ();
//	}
//	void Awake()
//	{
//		startTime = (int)Time.time;
//		timerActive = false;
//		countDownSeconds = 5;
//	}
//
//	void Update()
//	{
//		if (timerActive == true)
//			{
//			InitiateCountdown();
//			}
//	
//		if (timerActive == false)
//			{            
//			startTime = (int)Time.time; // reset start time
//			}
//	}
//
//	void OnGUI()
//	{
//		DisplayCountdown();        
//	}
//
//	void InitiateCountdown()
//	{
//	//make sure that your time is based on **when this script was first called**
//	//instead of when your game started
//	guiTime = (int)Time.time - startTime;  // have to base time off of something I can control
//	restSeconds = countDownSeconds - (guiTime);
//	
//	//display the timer
//	roundedRestSeconds = Mathf.CeilToInt(restSeconds);
//	roundedRestSeconds = Mathf.Clamp(roundedRestSeconds, 0, roundedRestSeconds);
//	displaySeconds = roundedRestSeconds % 60;
//	displayMinutes = roundedRestSeconds / 60;
//	
////	Debug.Log("startTime is " + startTime);
////	Debug.Log("guiTime is " + guiTime);
////	Debug.Log("restSeconds are " + restSeconds);
////	Debug.Log("roundedRestSeconds are " + roundedRestSeconds);
//	}
//
//	void DisplayCountdown() 
//	{
//		string text = string.Format("{0:00}:{1:00}", displayMinutes, displaySeconds);
//		GUI.Label(new Rect(400, 25, 100, 30), text);
//	
////		if (GUI.Button(new Rect(10, 10, 100, 30), "Start Timer"))
////		{
////			timerActive = true;
////		}
////		if (GUI.Button(new Rect(10, 40, 100, 30), "Stop Timer"))
////		{
////			timerActive = false;
////		}
//	}
//
//	public void ButtonDo(string does)
//	{
//		if (does == "a") {
//			Debug.Log("pressed A");
//			timerActive = true;
//			btnA.enabled = false;
//			btnB.enabled = true;
//		}
//		if (does == "b") {
//			Debug.Log("pressed B");
//			timerActive = false;
//			btnB.enabled = false;
//			btnA.enabled = true;
//		}
//	}
//	#endregion
