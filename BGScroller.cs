using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour
{
	public float speed = 0;
	public static BGScroller current;
	
	float pos = 0;

	
		// Use this for initialization
		void Start () {
			current = this;
		}
		
		// Update is called once per frame
		public void Go () {
			pos += speed;
			if (pos > 1.0f)
				pos -= 1.0f;
	
			GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (pos, 0);
		}




	void Update()
	{
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.time *speed, 0f);
	}
}
//	public static BGScroller current;
//
//	float pos = 0;
//
//	// Use this for initialization
//	void Start () {
//		current = this;
//	}
//	
//	// Update is called once per frame
//	public void Go () {
//		pos += speed;
//		if (pos > 1.0f)
//			pos -= 1.0f;
//
//		renderer.material.mainTextureOffset = new Vector2 (pos, 0);
//	}