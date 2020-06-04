using UnityEngine;

public class RequestMusic : MonoBehaviour
{
    #region Serialized
    #pragma warning disable IDE0044
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private float _volumeIncrement = 3f;
    [SerializeField]
    private float _volumeDecrement = 2f;
    [SerializeField]
    private float _delay = 3f;
    #pragma warning restore IDE0044
    #endregion

    #region Private
    private float _volume = 0f;
    private float _initial_delay;
    #endregion

    #region Unity Lifecycle
    private void Awake()
    {
        _initial_delay = _delay;
    }

    private void Update()
    {
        _delay -= Time.deltaTime;
        if (_delay <= 0 && _volume > 0)
        {
            _volume -= _volumeDecrement * Time.deltaTime;
            if (_volume <= 0) _volume = 0;
            _audioSource.volume = _volume;
        }
    }
    #endregion

    #region Trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_audioSource.volume != 100)
        {
            _volume += _volumeIncrement * Time.deltaTime;
            if (_volume > 1) _volume = 1;
            _audioSource.volume = _volume;
        }
        _delay = _initial_delay;
    }
    #endregion
}
