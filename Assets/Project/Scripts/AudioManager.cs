using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public AudioSource[] audioTracks;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        foreach (AudioSource audioTrack in audioTracks)
        {
            audioTrack.Play();
        }
    }

    public void SetLoop(int trackIndex, bool loop)
    {
        if (trackIndex >= 0 && trackIndex < audioTracks.Length)
        {
            audioTracks[trackIndex].loop = loop;
        }
        else
        {
            Debug.LogWarning("Índice de pista de audio no válido.");
        }
    }

    public void StopTrack(int trackIndex)
    {
        if (trackIndex >= 0 && trackIndex < audioTracks.Length)
        {
            audioTracks[trackIndex].Stop();
        }
        else
        {
            Debug.LogWarning("Índice de pista de audio no válido.");
        }
    }
}
