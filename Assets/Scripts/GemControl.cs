using UnityEngine;

public class GemControl : MonoBehaviour
{
    public int rotateSpeed = 2;
    public AudioSource gemCollect;

    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        gemCollect.Play();
        Destroy(gameObject);
    }
}
