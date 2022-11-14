using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoudManager : MonoBehaviour
{
    public static SoudManager sharedInstance;
    private AudioSource audioSource;
    public AudioClip shootSound;
    // Start is called before the first frame update
    void Awake()
    {
        sharedInstance = sharedInstance ?? this;
        audioSource = GetComponent<AudioSource>();

        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayShoot()
    {
        audioSource?.PlayOneShot(shootSound);
    }

}
