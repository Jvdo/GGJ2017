using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FrequencyObstacleTarget : MonoBehaviour {

	FrequencyObstacle parent;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!parent)
		{
			parent = transform.GetComponentInParent<FrequencyObstacle>();
		}
	}

	void OnDrawGizmos() {
		
		if (parent)
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(transform.position, 0.5f);
			Gizmos.DrawLine(transform.position, parent.transform.position);
		}
	}
}
