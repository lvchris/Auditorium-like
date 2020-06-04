using System.Collections.Generic;
using UnityEngine;

public class AudioTracks : MonoBehaviour
{
    #region Private
    private List<AudioSource> _audioSources;
    #endregion

    #region Unity Lifecycle
    private void Start()
    {
        GameObject[] musicBoxes = GameObject.FindGameObjectsWithTag("MusicBox");
        _audioSources = new List<AudioSource>(musicBoxes.Length);
        foreach (GameObject musicBox in musicBoxes) _audioSources.Add(musicBox.GetComponent<AudioSource>());

        MuteAllTracks();
        PlayAllTracks();
    }

    private void Update()
    {
        if (!_audioSources[_audioSources.Count - 1].isPlaying)
        {
            StopAllTracks();
            PlayAllTracks();
        }
    }
    #endregion

    #region Functions
    private void MuteAllTracks()
    {
        foreach (AudioSource audioSource in _audioSources)
        {
            audioSource.volume = 0;
        }
    }
    private void PlayAllTracks()
    {
        foreach (AudioSource audioSource in _audioSources)
        {
            audioSource.Play();
        }
    }
    private void StopAllTracks()
    {
        foreach (AudioSource audioSource in _audioSources)
        {
            audioSource.Stop();
        }
    }
    #endregion
}
