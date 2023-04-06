using UnityEngine.UI;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static float stamina;
    public static float health;
    [SerializeField] private Text staminaText;
    [SerializeField] private Text healthText;
    void Start()
    {
        stamina = 100f;
        health = 100f;
        staminaText.text = "Stamina : " + stamina.ToString();
        healthText.text = "Health : " + health.ToString();
    }

    void Update()
    {
       HandleStats();

    }

    void HandleStats()
    {
        staminaText.text = "Stamina : " + ((int)stamina).ToString();
        healthText.text = "Health : " + ((int)health).ToString();
        if(stamina < 100)
        {
            stamina += 1 * Time.deltaTime;
        }

        if(stamina > 100)
        {
            stamina = 100;
        }

        if (health < 100)
        {
            health += .5f * Time.deltaTime;
        }

        if (health > 100)
        {
            health = 100;
        }
    }

}
