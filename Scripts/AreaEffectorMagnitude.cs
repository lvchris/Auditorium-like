using UnityEngine;

[RequireComponent(typeof(AreaEffector2D))]
public class AreaEffectorMagnitude : MonoBehaviour
{
    #region Serialized
    [SerializeField, Range(.1f, .5f)]
    private float _magnitudeCoefficient = .25f;
    #endregion

    #region Private
    private float _radius;
    private float _magnitude;
    private Transform _transform;
    private AreaEffector2D _areaEffector;
    #endregion

    #region Unity Lifecycle
    private void Awake()
    {
        _areaEffector = gameObject.GetComponent<AreaEffector2D>();
        _magnitude = _areaEffector.forceMagnitude;
        _transform = gameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        _radius = _transform.localScale.x;
        _areaEffector.forceMagnitude = _magnitude * _magnitudeCoefficient * _radius;
    }
    #endregion
}
