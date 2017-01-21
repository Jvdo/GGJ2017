using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrequencyObstacle : MonoBehaviour {

	Speach speach;

	public FrequencyObstacleTarget target;
	Vector3 startPos;
	Vector3 endPos;

	public float animationTime = 2f;

	float currentAnimTime;
	bool reverse;

	// Use this for initialization
	void Start () {
		speach = FindObjectOfType<Speach>();
		target = transform.GetComponentInChildren<FrequencyObstacleTarget>();

		startPos = transform.localPosition;
		endPos = transform.localPosition + target.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		currentAnimTime += Time.deltaTime;

		if (currentAnimTime >= animationTime)
		{
			currentAnimTime -= animationTime;
			reverse = !reverse;
		}

		float factor = Mathf.SmoothStep(0.0f, 1.0f, currentAnimTime / animationTime);

		if (reverse)
		{
			factor = 1.0f - factor;
		}

		transform.localPosition = Vector3.Lerp(startPos, endPos, factor);

	}
}
