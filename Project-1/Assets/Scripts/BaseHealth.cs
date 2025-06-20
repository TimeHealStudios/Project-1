using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; 

public class BaseHealth : MonoBehaviour
{
    public int health = 100;
    public GameObject gameOverUI;

    public TextMeshProUGUI BaseHealthText;   
    public TextMeshProUGUI healthText;
    public Image healthBarFill;
    public Image HealthBar;          
    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        if (health <= 0 && !gameOverUI.activeSelf)
        {
            TriggerGameOver();
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health < 0) health = 0;
        UpdateUI();
    }

    void UpdateUI()
    {
        healthText.text = "Base Health: " + health;
        healthBarFill.fillAmount = health / 100f; // assuming 100 is max health
    }

    void TriggerGameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(20);
            Destroy(other.gameObject);
        }
    }
}
