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

	public float targetFrequencyMin = 0.0f;
	public float targetFrequencyMax = 0.0f;

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
		if (targetFrequencyMin == 0.0f && targetFrequencyMax == 0.0f)
		{
			currentAnimTime += Time.deltaTime;

			if (currentAnimTime >= animationTime)
			{
				currentAnimTime -= animationTime;
				reverse = !reverse;
			}
		}
		else
		{
			if (speach.IsInputValid() && speach.frequency >= targetFrequencyMin && speach.freqHight < targetFrequencyMax)
			{
				currentAnimTime += Time.deltaTime;
			}
			else
			{
				currentAnimTime -= Time.deltaTime;
			}

			currentAnimTime = Mathf.Clamp(currentAnimTime, 0.0f, animationTime);
		}

		float factor = Mathf.SmoothStep(0.0f, 1.0f, currentAnimTime / animationTime);

		if (reverse)
		{
			factor = 1.0f - factor;
		}

		transform.localPosition = Vector3.Lerp(startPos, endPos, factor);

	}
}
