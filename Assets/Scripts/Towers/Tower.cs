using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayerMask;
    [SerializeField] private GameObject _projectilePrefab;
    private SpriteRenderer _spriteRenderer;
    
    [Header("Tower Properties")]
    public int GoldCost;
    public Sprite TowerSprite;
    public float TimeBetweenShoot;
    private float _currentTimeBetweenShoot;
    public float Range;

    [Header("Bullet Properties")]
    public float BulletPower;
    public float SpeedPower;

    private Collider2D _target;
    [SerializeField] private Transform _zone;

    // Start is called before the first frame update
    public void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _spriteRenderer.sprite = TowerSprite;
        
        _zone.localScale = Vector3.one * Range * (1 / transform.localScale.x) * 2;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    // Update is called once per frame
    void Update()
    {
        _currentTimeBetweenShoot -= Time.deltaTime;
        Collider2D[] inRange = Physics2D.OverlapCircleAll(transform.position, Range, _targetLayerMask, -Mathf.Infinity, Mathf.Infinity);

        if(_currentTimeBetweenShoot <= 0 &&inRange.Length > 0) 
        {
            if (!IsTargetInRangeAndAlive())
                _target = FindClosest(inRange);
            _currentTimeBetweenShoot = TimeBetweenShoot;
            GameObject go = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
            ProjectileMovement pm = go.GetComponent<ProjectileMovement>();
            if(pm == null)
            {
                Debug.LogError("WTF projectile movement o� ?");
                return;
            }
            pm.SetTarget(_target);
            pm.SetBulletProperties(SpeedPower, BulletPower);
            Debug.Log("Shoot "+_target);
        }
    }

    private bool IsTargetInRangeAndAlive() 
    {
        if (_target == null) 
        {
            return false;
        }
        Vector3 postionZ0 = new Vector3(transform.position.x, transform.position.y, 0);
        Vector3 otherPositionZ0 = new Vector3(_target.transform.position.x, _target.transform.position.y, 0);

        if(Range < Vector3.Distance(postionZ0, otherPositionZ0))
        {
            return false;
        }

        return true;
    }

    private Collider2D FindClosest(Collider2D[] go) 
    {
        Collider2D closest = go[0];
        Vector3 postionZ0 = new Vector3(transform.position.x, transform.position.y, 0);
        Vector3 otherPositionZ0 = new Vector3(go[0].transform.position.x, go[0].transform.position.y, 0);
        float min_dist = Vector3.Distance(postionZ0, otherPositionZ0);

        for(int i = 0; i< go.Length; i++) 
        {
            otherPositionZ0 = new Vector3(go[i].transform.position.x, go[i].transform.position.y, 0);
            float currentDist = Vector3.Distance(postionZ0, otherPositionZ0);
            if(min_dist > currentDist) 
            {
                closest = go[i];
                min_dist = currentDist;
            }
        }
        return closest;
    }
}
