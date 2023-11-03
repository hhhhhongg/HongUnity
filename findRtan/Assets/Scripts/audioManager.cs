using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public AudioClip bgmusic;
    public AudioSource audioSource;
    void Start()
    {
        // 계속해서 음악 실행
        audioSource.clip = bgmusic;
        audioSource.Play();
    }

    void Update()
    {
        
    }
}
