using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public Image healthBar;
    public Image[] healthPoints;

    public float health, maxHealth = 100f;
    public float lerpSpeed;
    void Start()
    {
        health = maxHealth;

    }

    void Update()
    {
        healthText.text = "Health " + health + "%" ;
        if(health > maxHealth) health = maxHealth;

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
        ColorChange();
    }

    void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health / maxHealth, lerpSpeed);
        for (int i = 0; i < healthPoints.Length; i++)
        {
                       healthPoints[i].enabled = !DisplayHealthPoint(health, i);
        }
    }
    void ColorChange()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, health / maxHealth);

        healthBar.color = healthColor;
    }
    public bool DisplayHealthPoint(float _health, int pointNumber)
    {
        return ((pointNumber * 10) >= _health);
    }
    public void Damage(float damagePoints)
    {
        if (health > 0)
        {
            health -= damagePoints;
        }
    }
    public void Heal(float healPoints)
    {
        if (health < maxHealth)
        {
            health += healPoints;
        }
    }
}
