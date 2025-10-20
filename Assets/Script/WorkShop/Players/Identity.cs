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
        get => Mathf.RoundToInt(transform.position.x);
        set => transform.position = new Vector3(value, transform.position.y, transform.position.z);
    }

    public int PositionY
    {
        get => Mathf.RoundToInt(transform.position.y);
        set => transform.position = new Vector3(transform.position.x, value, transform.position.z); // ✅ เซ็ตแกน Y ให้ถูก
    }

    private Player _player;
    protected Player Player
    {
        get
        {
            if (_player == null)
                _player = FindAnyObjectByType<Player>();
            return _player;
        }
    }

    private float _distanceToPlayer;

    [SerializeField] private float checkDistance = 1f;
    [SerializeField] private float checkRadius = 1f;

    // ✅ ให้ override ได้จากคลาสลูก
    protected virtual void Start()
    {
        SetUp();
    }

    public virtual void SetUp()
    {
        _player = FindAnyObjectByType<Player>();
    }

    protected float GetDistanPlayer()
    {
        if (_player == null)
        {
            _player = FindAnyObjectByType<Player>();
            if (_player == null) return float.MaxValue;
        }

        _distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);
        return _distanceToPlayer;
    }

    public void PrintInfo()
    {
        Debug.Log($"Name:{Name} x:{PositionX} y:{PositionY}");
    }

    private GameObject _identityInFront;
    public Identity InFront
    {
        get
        {
            if (Physics.SphereCast(transform.position, checkRadius, transform.forward, out RaycastHit hitInfo, checkDistance))
            {
                _identityInFront = hitInfo.collider.gameObject;
                var id = _identityInFront.GetComponent<Identity>();
                if (id != null) return id;

                Debug.LogWarning("Object in front cannot interact!");
            }
            return null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + (transform.forward * checkDistance));
        Gizmos.DrawWireSphere(transform.position + transform.forward * checkDistance, checkRadius);
    }
}
