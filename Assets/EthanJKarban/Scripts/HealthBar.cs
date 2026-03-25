using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public Image healthBar;

    float health, maxHealth = 100f;
    float lerpSpeed;
    void Start()
    {
        health = maxHealth;

    }

    void Update()
    {
        healthText.text = "health" + health + "%" ;
        if(health > maxHealth) health = maxHealth;

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
        ColorChange();
    }

    void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health / maxHealth, lerpSpeed);
    }
    void ColorChange()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, health / maxHealth);

        healthBar.color = healthColor;
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
