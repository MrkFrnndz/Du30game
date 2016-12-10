//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;
//
//public class PowerUpTimer : MonoBehaviour {
//
//	//public JetPack jetPackScript;	
//	public Image fillImg;
//	float timeAmt = 10;
//	float time;
//	private bool jtPackDestroyed;
//
//
//	// Use this for initialization
//	void Start () 
//	{
//
//		//jetPackScript = GameObject.Find("pJetPack").GetComponent<JetPack>().Co;
//		fillImg = this.GetComponent<Image>();
//		time = timeAmt;
//		fillImg.enabled = false;
//
//
//	}
//
//	// Update is called once per frame
//	void Update () 
//	{
//		jtPackDestroyed = jetPackScript.destroyedJetPack;
//
//		if (jtPackDestroyed == true && time > 0) 
//		{ 
//			fillImg.enabled = true;
//			time -= Time.deltaTime;
//			fillImg.fillAmount = time / timeAmt; //9/10. 8/10. . .and so on
//			//timeText.text = "Time : " + time.ToString("F");	
//		}
//	}
//}
