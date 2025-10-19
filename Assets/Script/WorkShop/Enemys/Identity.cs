using UnityEngine;

public class Identity : MonoBehaviour
{
    [SerializeField] private string _name;
    public string Name
    {
        get
        {
            if (string.IsNullOrEmpty(_name))
            {
                _name = gameObject.name;
            }
            else
            {
                gameObject.name = _name;
            }
            return _name;
        }
        set
        {
            gameObject.name = value;
            _name = value;
        }
    }

    public int PositionX
    {
        get
        {
            return Mathf.RoundToInt(transform.position.x);
        }
        set
        {
            transform.position = new Vector3(value,
                                             transform.position.y,
                                             transform.position.z);
        }
    }
    public int PositionY
    {
        get
        {
            return Mathf.RoundToInt(transform.position.y);
        }
        set
        {
            transform.position = new Vector3(transform.position.x,
                                             transform.position.y,
                                             value);
        }
    }

    private Player _player;

    protected Player Player
    {
        get
        {
            if (_player == null)
            {
                _player = FindAnyObjectByType<Player>();
            }
            return _player;
        }
    }
    private float distanPlayer;

    [SerializeField] private float checkDistance = 1f;
    [SerializeField] private float checkRadius = 1f;


    private void Start()
    {
        SetUp();
    }

    public virtual void SetUp()
    {
        _player = FindAnyObjectByType<Player>();
    }

    protected float GetDistanPlayer()
    {
        // ถ้า _player ยังเป็น null ให้หาซ้ำ
        if (_player == null)
        {
            _player = FindAnyObjectByType<Player>();
            if (_player == null)
            {
                return float.MaxValue; // คืนค่าระยะไกลมาก ๆ เพื่อป้องกัน logic ที่เช็คระยะ
            }
        }

        distanPlayer = Vector3.Distance(transform.position, _player.transform.position);
        return distanPlayer;
    }

    public void PrintInfo()
    {
        Debug.Log($"Name:{Name} x:{PositionX} y:{PositionY}");
    }

    private GameObject _IdentityInFront;
    

    public Identity InFront
    {
        get
        {
            if (Physics.SphereCast(transform.position, checkRadius, transform.forward, out RaycastHit hitInfo, checkDistance))
            {
                _IdentityInFront = hitInfo.collider.gameObject;
                Identity id = _IdentityInFront.GetComponent<Identity>();

                if (id != null)
                {
                    return id;
                }
                else
                {
                    Debug.LogWarning("Object in front cannot interact!");
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + (transform.forward * checkDistance));
        Gizmos.DrawWireSphere(transform.position + transform.forward * checkDistance, checkRadius);
    }

}
