using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

	public float translationTime = 10.0f;
	public float totalTranslation = 2000.0f;
	public float totalTime = 14.0f;

	float currentTime = -0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		float t = Mathf.Clamp01(currentTime / translationTime);
		float delta = Mathf.Lerp(0, totalTranslation, t);
		transform.localPosition = new Vector3(0, delta, 0);

		if (currentTime >= totalTime)
		{
			SceneManager.LoadScene("MainMenu");
		}
	}
}
