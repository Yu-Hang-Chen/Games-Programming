using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayFootStep : MonoBehaviour
{   
    public AudioSource audioSource;

    void Start()
    {
        audioSource.loop = true; 
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        bool isMoving = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;

        if (isMoving)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}