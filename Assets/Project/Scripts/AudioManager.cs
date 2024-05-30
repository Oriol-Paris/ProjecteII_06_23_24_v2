using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance = null;

    public AudioSource[] audioTracks;
    int songCounter;

    public bool play = true;

    float volume;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            this.transform.parent = null;
            DontDestroyOnLoad(gameObject);

            SetGlobalVolume(1f);
        }
        else
            Destroy(gameObject);
    }

    void Start()
    {
        foreach(var track in audioTracks)
        {
            track.Stop();
        }

        StartCoroutine(ChangeSongs());
    }

    IEnumerator ChangeSongs()
    {
        while (play)
        {
            audioTracks[songCounter % audioTracks.Length].Play();

            yield return new WaitForSeconds(audioTracks[songCounter].clip.length);
            audioTracks[songCounter % audioTracks.Length].Stop();

            songCounter++;
        }
        yield return null;
    }

    public void SetGlobalVolume(float volume)
    {
        foreach(AudioSource audioTrack in audioTracks)
            audioTrack.volume = volume;
    }

    public void ToggleMute()
    {
        foreach (AudioSource audioTrack in audioTracks)
            if(!audioTrack.mute)
                audioTrack.mute = true;
            else
                audioTrack.mute = false;
    }
}
