using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour {

	bool finished = false;

	characterMovement player;

	void Start()
	{
		player = FindObjectOfType<characterMovement>();
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
		if (coll.tag == "Player" && !finished)
        {
			GetComponent<AudioSource>().Play();
			finished = true;
			StartCoroutine(GoToNextLevelRoutine());
        }
    }

	IEnumerator GoToNextLevelRoutine()
	{
		if (player)
		{
			player.EndLevel();
		}
		yield return new WaitForSeconds(2.0f);
		SceneManager.LoadScene("Level Select");
	}
}
