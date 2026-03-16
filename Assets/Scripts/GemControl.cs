using UnityEngine;

public class GemControl : MonoBehaviour
{
    public int rotateSpeed = 2;
    public AudioSource gemCollect;
    public int gemScore = 100;

    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
		ScoreControl.totalScore += gemScore;
		gemCollect.Play();
        Destroy(gameObject);
    }
}
