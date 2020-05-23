using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource ButSound;
    public AudioClip click;
    public AudioClip hover;

    public void hoverSound()
    {
        ButSound.PlayOneShot(hover);
    }


    public void clickSound()
    {
        ButSound.PlayOneShot(click);
    }
}
