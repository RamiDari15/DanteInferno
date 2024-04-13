using UnityEngine;

public class ScarySound : MonoBehaviour
{
    public AudioClip soundToPlay;
    private AudioSource audioSource;

    void Start()
    {
        // Add an AudioSource component and configure it
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundToPlay;
        audioSource.playOnAwake = false; // Don't play the sound immediately
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hello");
        audioSource.Play();
    }
}