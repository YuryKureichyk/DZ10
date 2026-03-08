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
        if (playerRenderer != null && enemyRenderer != null )
        {
            Debug.Log("Enemy color: " + GetColorName(playerRenderer.color));
            Debug.Log("Player color: " + GetColorName(enemyRenderer.color));
        }
        

        (playerRenderer.color, enemyRenderer.color) =
            (enemyRenderer.color, playerRenderer.color);
    }

    private void OnMouseEnter()
    {
        _originalColor = _myRenderer.color;
        _myRenderer.color = _colorMouse;
    }
    private string GetColorName(Color color)
    {
        if (color == Color.red) return "Red";
        if (color == Color.green) return "Green";
        if (color == Color.blue) return "Blue";
        if (color == Color.yellow) return "Yellow";

        return "Color" + color.ToString();
    }

    private void OnMouseExit()
    {
        _myRenderer.color = _originalColor;
    }
}