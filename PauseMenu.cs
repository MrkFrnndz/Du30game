using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	public GameObject pauseBtn,pausePanel,btnA,btnB,btnC;
	// Use this for initialization


	public void Start()
	{
		Resume ();
	}
	public void Pause()
	{
		pausePanel.SetActive (true);
		pauseBtn.SetActive (false);
		btnA.SetActive (false);
		btnB.SetActive (false);
		btnC.SetActive (false);
		Time.timeScale = 0;
	}
	public void Resume()
	{
		pausePanel.SetActive (false);
		pauseBtn.SetActive (true);
		btnA.SetActive (true);
		btnB.SetActive (true);
		btnC.SetActive (true);
		Time.timeScale = 1;
	}
}
