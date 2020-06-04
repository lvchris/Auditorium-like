using UnityEngine;

public class LightBar : MonoBehaviour
{
    #region Serialized
    [SerializeField]
    private Renderer[] _bars;
    [SerializeField]
    private Material _lit;
    [SerializeField]
    private Material _notLitYet;
    [SerializeField]
    private AudioSource _audioSource;
    #endregion

    #region Unity Lifecycle
    private void Update()
    {
        int barNum = (int)(_audioSource.volume * _bars.Length);
        for (int i = 0; i < barNum; i++) _bars[i].material = _lit;
        for (int i = barNum; i < _bars.Length; i++) _bars[i].material = _notLitYet;

    }
    #endregion
}
