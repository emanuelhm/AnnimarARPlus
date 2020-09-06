using System.Collections;
using UnityEngine;

public class AudioBehavior : MonoBehaviour
{
    public AudioSource AudioSource;

    private bool state;

    private bool isStopped;

    public void ToggleState()
    {
        state = !state;
        AudioSource.Play();

        if (state)
        {
            PlayAudio();
        }
        else
        {
            PlayReverseAudio();
        }
    }

    public void PlayAudio()
    {
        AudioSource.pitch = 1;
        AudioSource.Play();

    }
    public void PlayReverseAudio()
    {
        AudioSource.pitch = -1;
        AudioSource.loop = true;
        AudioSource.Play();
        StartCoroutine(StopLoop());
    }

    public IEnumerator StopLoop()
    {
        yield return new WaitForSeconds(1f);
        AudioSource.loop = false;
    }

    public void ToggleSpeed()
    {
        if (isStopped)
        {
            AudioSource.pitch = state ? -1 : 1;
        }
        else
        {
            AudioSource.pitch = 0;
        }

        isStopped = !isStopped;
    }
}