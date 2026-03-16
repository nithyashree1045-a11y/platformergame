using UnityEngine;

public class LevelFinish : MonoBehaviour
{

	public GameObject playerControl;
	public AudioSource levelJingle;
	public GameObject levelBGM;
	public GameObject fadeOut;

	void OnTriggerEnter(Collider other)
	{
		playerControl.GetComponent<PlayerControls>().enabled = false;
		playerControl.GetComponent<Animator>().Play("Idle");
		levelBGM.SetActive(false);
		levelJingle.Play();
		fadeOut.SetActive(true);
	}
}