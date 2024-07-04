using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    
    [SerializeField] private AudioClip matchSound;
    [SerializeField] private AudioClip misMatchSound;
    private AudioSource _audioSource;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else if (_instance != null)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        RoundHandler.MatchMade += PlayMatchSound;
        RoundHandler.Mismatch += PlayMisMatchSound;
    }
    
    private void PlayMatchSound()
    {
        _audioSource.PlayOneShot(matchSound);
    }
    private void PlayMisMatchSound()
    {
        _audioSource.PlayOneShot(misMatchSound);
    }
}
