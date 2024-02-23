using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource ButtonClick;

    private void Awake()
    {
        ButtonClick = GetComponent<AudioSource>();
    }

    public void ButtonClickSound()
    {
        ButtonClick.Play();
    }
}
