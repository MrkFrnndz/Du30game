using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text hiScoreText;

	public float scoreCount;
	public float hiScoreCount;

	public float pointsPerSecond;

	public bool scoreIncreasing;


	// Use this for initialization
	void Start () 
	{
		if (PlayerPrefs.HasKey ("HighScore")) 
		{
			hiScoreCount = PlayerPrefs.GetFloat ("HighScore");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (scoreIncreasing) 
		{
			scoreCount += pointsPerSecond * Time.deltaTime;

			if(scoreCount > hiScoreCount)
			{
				hiScoreCount = scoreCount;
				PlayerPrefs.SetFloat("HighScore", hiScoreCount);
			}

			scoreText.text = "" + Mathf.Round(scoreCount);
			hiScoreText.text = "" +Mathf.Round(hiScoreCount);








		}
	}
}
