using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeLevel : MonoBehaviour
{
	public GameObject timeBox;
	public int timeLeft = 30;
	public bool takingSecond = false;

	public AudioSource timeUpSound;
	public GameObject levelBGM;
	public GameObject fadeOut;
	public GameObject timeUp;

	public GameObject playerControl;
	public bool isRespawning = false;

	void Update()
	{
		timeBox.GetComponent<TMPro.TMP_Text>().text = "TIME LEFT: " + timeLeft;
		if (takingSecond == false)
		{
			StartCoroutine(RemoveSecond());
		}
		if (timeLeft == 0 && isRespawning == false)
		{
			isRespawning = true;
			takingSecond = true;
			levelBGM.SetActive(false);
			timeUpSound.Play();
			fadeOut.SetActive(true);
			timeUp.SetActive(true);
			playerControl.GetComponent<PlayerControls>().enabled = false;
			playerControl.GetComponent<Animator>().Play("Idle");
			StartCoroutine(Respawn());
		}
	}

	IEnumerator RemoveSecond()
	{
		takingSecond = true;
		yield return new WaitForSeconds(1);
		timeLeft -= 1;
		takingSecond = false;
	}

	IEnumerator Respawn()
	{
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene(3);
	}
}