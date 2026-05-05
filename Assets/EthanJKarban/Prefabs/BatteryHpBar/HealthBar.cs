using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    AudioManager audioManager;
    public TextMeshProUGUI healthText;
    public Image healthBar;
    public Image[] healthPoints;

    public float health, maxHealth;
    public character_movement playerHealth;
    public float lerpSpeed;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<character_movement>();
    }
        void Start()
    { 
        health = playerHealth.currentHealth;
        maxHealth = playerHealth.maxHealth;

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
    public void Damage(float damage)
    {
        if (health > 0)
        {
            audioManager.PlaySFX(audioManager.damage);
            health -= damage;
        }
    }
    public void Heal(float powerup)
    {
        if (health < maxHealth)
        {
            audioManager.PlaySFX(audioManager.HealAndPowerUp);
            health += powerup;
        }
    }
}
