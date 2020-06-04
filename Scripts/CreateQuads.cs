using UnityEngine;

public class CreateQuads : MonoBehaviour
{
    #region Serialized
#pragma warning disable IDE0044
    [SerializeField]
    private GameObject _particulePrefabs;
    [SerializeField, Range(0, 1)]
    private float _spawnRadius = 1f;
    [SerializeField, Range(5, 100)]
    private float _initial_speed = 35f;
#pragma warning restore IDE0044
    #endregion

    #region Private
    private float _delay1;
    private float _delay2;
    private float _delay3;

    private Transform _transform;
    #endregion

    #region Unity Lifecycle
    private void Awake()
    {
        _transform = this.GetComponent<Transform>();
        _delay1 = Random.Range(0f, 0.3f);
        _delay2 = Random.Range(0f, 0.3f);
        _delay3 = Random.Range(0f, 0.3f);
    }

    private void Update()
    {
        _delay1 -= Time.deltaTime;
        _delay2 -= Time.deltaTime;
        _delay3 -= Time.deltaTime;

        if ( _delay1 <= 0)
        {
            SpawnParticles();
            _delay1 = Random.Range(0f, 0.3f);
        }

        if ( _delay2 <= 0)
        {
            SpawnParticles();
            _delay2 = Random.Range(0f, 0.3f);
        }

        if ( _delay3 <= 0)
        {
            SpawnParticles();
            _delay3 = Random.Range(0f, 0.3f);
        }
    }
    #endregion

    #region Functions
    public void SpawnParticles()
    {
        Vector2 randomPosition = Random.insideUnitCircle * _spawnRadius;
        GameObject particle = Instantiate(_particulePrefabs, ((Vector2)_transform.position) + randomPosition, _transform.rotation, _transform);
        Rigidbody2D rigidbodyParticle = particle.GetComponent<Rigidbody2D>();
        rigidbodyParticle.velocity = transform.right * _initial_speed;
        //rigidbodyParticle.AddForce(particle.transform.right * _initial_speed, ForceMode2D.Impulse);
    }
    #endregion

    #region Debug
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, _spawnRadius);
    }
    #endregion

    #region With Coroutine
    /*
    private void Start()
    {
        StartCoroutine("SpawnQuads");
        StartCoroutine("SpawnQuads");
        StartCoroutine("SpawnQuads");
    }

    IEnumerator SpawnQuads()
    {
        for(;;)
        {
            SpawnParticles();
            yield return new WaitForSeconds(Random.Range(0f , 0.3f));
        }
    }

    direction = Vector2.right; //direction dans le référenciel local
    direction = transform.right; //direction dans le référenciel global
    direction = transform.TransformDirection(Vector2.right); // direction dans le référenciel local
    direction = transform.InverseTransformDirection(transform.right); // direction dans le référenciel global

    */
    #endregion

}
