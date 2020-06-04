using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    #region Serialized
#pragma warning disable IDE0044
    [SerializeField]
    private AudioClip[] _audioClips;
#pragma warning restore IDE0044
    #endregion

    #region Private
    private AudioSource _audioSource;
    #endregion

    #region Unity Lifecycle
    public void Awake()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
    }
    #endregion

    #region Functions
    public void PlayRequestedMusic( int i )
    {
        _audioSource.PlayOneShot(_audioClips[i], 1);
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
    #endregion
}
