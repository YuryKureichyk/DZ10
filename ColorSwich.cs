using UnityEngine;

public class Swich : MonoBehaviour
{
    
    private Color _originalColor;
    public Color _colorMouse = Color.orange;
    private SpriteRenderer _myRenderer;

    private void Awake()
    {
        _myRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var playerRenderer = GetComponent<SpriteRenderer>();
        var enemyRenderer = other.GetComponent<SpriteRenderer>();
        
        (playerRenderer.color, enemyRenderer.color) =
            (enemyRenderer.color, playerRenderer.color);
    }

    private void OnMouseEnter()
    {
        _originalColor = _myRenderer.color;
        _myRenderer.color = _colorMouse;
        
    }

    private void OnMouseExit()
    {
        _myRenderer.color = _originalColor;
    }
}
