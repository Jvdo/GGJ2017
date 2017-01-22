using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGlow : MonoBehaviour {

	Vector3 startSize;
	Vector3 tmpScale = new Vector3(1.0f, 1.0f, 1.0f);
	public bool effectHorizontal = true;

	public float min = 0.8f;
	public float max = 1.2f;

	public float intervalMin = 0.12f;
	public float intervalMax = 0.2f;

	// Use this for initialization
	void Start () {
		startSize = transform.localScale;
		StartCoroutine(GFXRoutine());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator GFXRoutine()
	{
		for(;true;)
		{
			tmpScale = new Vector3(1.0f, 1.0f, 1.0f);
			if (effectHorizontal)
			{
				tmpScale.y = Random.Range(min, max);
			}
			else
			{
				tmpScale.x = Random.Range(min, max);
			}

			tmpScale.Scale(startSize);
			transform.localScale = tmpScale;
			yield return new WaitForSeconds(Random.Range(intervalMin, intervalMax));
		}
	}
}
