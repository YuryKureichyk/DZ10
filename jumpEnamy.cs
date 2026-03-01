using UnityEngine;

public class jumpEnamy : MonoBehaviour
{
    
    private Rigidbody2D _rbPlayer;
    private bool _isGround;
    public float distanceToGround = 0.6f;
    public float jumpForce = 12f;
    private float _run;
    [SerializeField] private LayerMask groundLayer;
    

    void Awake()
    {
        _rbPlayer = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position,
            Vector2.down, distanceToGround, groundLayer);
        _isGround = hit.collider != null;

        if (_isGround)
        {
            Jump();
        }

        
    }

    

    void Jump()
    {
        
        _rbPlayer.linearVelocity = new Vector2(_rbPlayer.linearVelocity.x, jumpForce);
    }
}