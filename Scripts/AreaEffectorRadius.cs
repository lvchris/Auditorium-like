using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(AreaEffector2D))]
public class AreaEffectorRadius : MonoBehaviour
{
    #region Private
    private float _radius;
    private CircleCollider2D _circleCollider;
    #endregion

    #region Unity Lifecycle
    private void Awake()
    {
        _circleCollider = gameObject.GetComponent<CircleCollider2D>();
        _radius = _circleCollider.radius;
    }

    private void Update()
    {
        _circleCollider.radius = _radius;
    }
    #endregion

    #region Debug
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
    #endregion
}
