using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    [SerializeField] private Image _hpBar;
    [SerializeField] private float _hpMax = 100f;
    public float currentHP;

    public void Damage(float damage)
    {
        currentHP -= damage;
        Debug.Log($"Damage:{damage}. hp:{currentHP}");
        currentHP = Mathf.Clamp(currentHP, 0f, _hpMax);
        _hpBar.fillAmount = currentHP / _hpMax;
        UpdateHP();
        if (currentHP <= 0f)
        {
            Debug.Log("GameOver");
        }
        
    }

    public void Heal(float heal)
    {
        currentHP += heal;
        Debug.Log($"Heal:{heal}. hp:{currentHP}");
        currentHP = Mathf.Clamp(currentHP, 0f, _hpMax);
        _hpBar.fillAmount = currentHP / _hpMax;
        UpdateHP();
    }

    public void UpdateHP()
    {
        if (_hpBar!=null)
            _hpBar.fillAmount = currentHP / _hpMax;
    }
}
