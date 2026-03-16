using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallOff : MonoBehaviour
{
	public AudioSource fallSound;
	public GameObject levelBGM;
	public GameObject fadeOut;

	void OnTriggerEnter(Collider other)
	{
		levelBGM.SetActive(false);
		fallSound.Play();
		fadeOut.SetActive(true);
		ScoreControl.totalScore = 0;
		StartCoroutine(Respawn());
	}

	IEnumerator Respawn()
	{
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene(3);
	}
}