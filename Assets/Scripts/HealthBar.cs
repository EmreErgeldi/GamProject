using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private float fillAmount;
    private float smoothFillAmount;
    private Image healthBar;

    private float currentVelocity = 0;
    
    void Start()
    {
        healthBar = GetComponent<Image>();
        
    }

    void Update()
    {
        fillAmount = PlayerStats.health / 100f;
        smoothFillAmount = Mathf.SmoothDamp(healthBar.fillAmount, fillAmount, ref currentVelocity, 100 * Time.deltaTime);
        healthBar.fillAmount = smoothFillAmount;
    }
}
