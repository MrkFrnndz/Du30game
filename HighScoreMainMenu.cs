using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreMainMenu : MonoBehaviour {


	private ScoreManager theScoreManager;
	private float plyrHscore;

	public Text highScoreMainMenu;

	// Use this for initialization
	void Start () {
		theScoreManager = FindObjectOfType<ScoreManager> ();
		plyrHscore = PlayerPrefs.GetFloat("HighScore");

		highScoreMainMenu.text = "" + Mathf.Round(plyrHscore);
	
	}


}
