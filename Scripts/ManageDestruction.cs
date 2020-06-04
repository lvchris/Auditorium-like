using UnityEngine;

public class ManageDestruction : MonoBehaviour
{
    #region Serialized
    [SerializeField]
    private float m_lifeTime = 3f;
    [SerializeField]
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private float _speedThreshold;
    #endregion

    #region Other methods for speed
    //velocity = direction * speed;
    //speed = velocity.magnitude;
    //speed²= velocity.sqrMagnitude;
    //speed <= speedThreshhold
    #endregion

    #region Unity Lifecycle
    private void Start()
    {
        if ( gameObject )
        {
            Destroy(gameObject, m_lifeTime);
        }
    }

    private void Update()
    {
        // If speed goes under threshhold, gameObject is destroyed
        if(_rigidbody.velocity.magnitude <= _speedThreshold)
        {
            Destroy( gameObject );
        }
    }
    #endregion
}
