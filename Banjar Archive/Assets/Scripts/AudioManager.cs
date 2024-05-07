using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    public AudioClip background;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = background;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
