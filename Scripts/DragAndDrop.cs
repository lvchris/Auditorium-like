using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    #region Serialized
    [SerializeField]
    private LayerMask _effector_layer;
    [SerializeField]
    private LayerMask _areaEffector_layer;
    //Les deux vont de pair
    //[Serialized Field] private float _radiusSize;
    //public float RadiusSize = { get => _radiusSize; set => _radiusSize = Mathf.Clamp(value, _minRadius, _maxRadius); }
    #endregion

    #region Private
    private Camera _camera;
    private const float _minScale = 0.6f;
    private const float _maxScale = 1.5f;
    private GameObject _currentEffector;
    private GameObject _currentAreaEffector;
    #endregion

    #region Unity Lifecycle
    private void Awake()
    {
        if (_camera == null)
        {
            _camera = Camera.main;
        }
    }

    private void Update()
    {
        // Fire1 is mouse left click
        Vector2 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Fire1") && _currentEffector == null && _currentAreaEffector == null)
        {
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, _effector_layer);
            RaycastHit2D hit2 = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, _areaEffector_layer);

            if (hit.collider == null && hit2.collider == null) return;

            if (hit.collider != null)
            {
                _currentEffector = hit.collider.gameObject;
            }
            else if (hit2.collider != null)
            {
                _currentAreaEffector = hit2.collider.gameObject;
            }
            Cursor.visible = false;
        }

        if (Input.GetButton("Fire1"))
        {
            if (_currentEffector != null)
            {
                _currentEffector.transform.position = mousePos;
            }
            if (_currentAreaEffector != null)
            {
                float distance = Vector2.Distance(_currentAreaEffector.transform.parent.position, mousePos);
                if (distance < _minScale) distance = _minScale;
                else if (distance > _maxScale) distance = _maxScale;
                _currentAreaEffector.transform.localScale = new Vector2(distance, distance);
            }
            
        }

        if (Input.GetButtonUp("Fire1"))
        {
            _currentEffector = null;
            _currentAreaEffector = null;
            Cursor.visible = true;
        }
    }
    #endregion
}
