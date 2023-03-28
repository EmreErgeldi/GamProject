using UnityEngine.UI;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static float stamina;
    [SerializeField] private Text staminaText;
    void Start()
    {
        stamina = 100f;
        staminaText.text = "Stamina : " + stamina.ToString();

    }

    void Update()
    {
       HandleStamina();

    }

    void HandleStamina()
    {
        staminaText.text = "Stamina : " + ((int)stamina).ToString();
        if(stamina < 100)
        {
            stamina += 1 * Time.deltaTime;
        }

        else if(stamina > 100)
        {
            stamina = 100;
        }
    }
}
