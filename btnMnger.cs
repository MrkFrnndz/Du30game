using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class btnMnger : MonoBehaviour {

	//public GameObject btnExit;

	public void ChangeToScene (int sceneToChangeTo) 
	{
		Application.LoadLevel (sceneToChangeTo);
	}

	public void QuitApp()
	{
		Application.Quit ();
	}

			
		

}
