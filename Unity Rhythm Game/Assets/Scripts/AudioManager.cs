using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip pop;
    public AudioClip snap;

    public void PopSFX()
    {
        Debug.Log("Pop");
        source.PlayOneShot(pop);
    }

    public void SnapSFX()
    {
        Debug.Log("Snap");
        source.PlayOneShot(snap);
    }

}
