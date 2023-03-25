using UnityEngine.UI;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float stamina;
    [SerializeField] private Text staminaText;
    void Start()
    {
        stamina = 100f;
        staminaText.text = "Stamina : " + stamina.ToString();

    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(stamina < 20)
            {
                Debug.Log("Stamina yetersiz !");
                return;
            } 
            
            stamina -= 20f;
            staminaText.text = "Stamina : " + stamina.ToString();
        }
    }

    
}
