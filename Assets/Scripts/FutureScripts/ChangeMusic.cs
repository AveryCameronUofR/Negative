using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    public AudioSource music;
    private void OnTriggerEnter(Collider other)
    {
        music.clip = AudioClip.Create("Track2", 16, 1, 44100, false);
        music.Play();

    }
}
