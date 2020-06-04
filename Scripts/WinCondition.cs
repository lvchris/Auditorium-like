using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    #region Serialized
#pragma warning disable IDE0044
    [SerializeField, Range(1, 5)]
    private float _timeUntilWin = 3f;
    [SerializeField, Range(1, 5)]
    private float _resetTimer = 3f;
    [SerializeField]
    private GameEvent _launchNextLevel;
    [SerializeField]
    private GameEvent _animation;
#pragma warning restore IDE0044
    #endregion

    #region Private
    private List<AudioSource> _audioSources;
    private float _initial_timeUntilWin;
    private float _initial_resetTimer;
    #endregion

    #region Unity Lifecycle
    private void Awake()
    {
        _initial_resetTimer = _resetTimer;
        _initial_timeUntilWin = _timeUntilWin;
    }

    private void Start()
    {
        GameObject[] musicBoxes = GameObject.FindGameObjectsWithTag("MusicBox");
        _audioSources = new List<AudioSource>(musicBoxes.Length);
        foreach (GameObject musicBox in musicBoxes) _audioSources.Add(musicBox.GetComponent<AudioSource>());
    }

    private void Update()
    {
        if (_timeUntilWin <= 0) _launchNextLevel.Raise();
        else
        {
            if (_timeUntilWin < _initial_timeUntilWin) _resetTimer -= Time.deltaTime;
            if (CheckVolumeMaxed())
            {
                _timeUntilWin -= Time.deltaTime;
                _resetTimer = _initial_resetTimer;
            }
            else if (_resetTimer <= 0) _timeUntilWin = _initial_timeUntilWin;
        }
    }
    #endregion

    #region Functions
    private bool CheckVolumeMaxed()
    {
        foreach(AudioSource audioSource in _audioSources)
            if (audioSource.volume < 1.0f) return false;
        return true;
    }
    #endregion
}
