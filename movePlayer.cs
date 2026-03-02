using UnityEngine;

public class movePlayer : MonoBehaviour
{
    private Rigidbody2D _rbPlayer;
    private bool _isGround;
    public float distanceToGround = 0.6f;
    public float speed = 10f;
    public float jumpForce = 12f;
    private float _run;
    [SerializeField] private LayerMask groundLayer;


    void Awake()
    {
        _rbPlayer = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _run = Input.GetAxisRaw("Horizontal");

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distanceToGround, groundLayer);

        if (hit.collider != null)
        {
            _isGround = true;
        }
        else
        {
            _isGround = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Jump()
    {
        _rbPlayer.linearVelocity = new Vector2(_rbPlayer.linearVelocity.x, jumpForce);
    }

    void Move()
    {
        _rbPlayer.linearVelocity = new Vector2(_run * speed, _rbPlayer.linearVelocity.y);
        
    }
}
