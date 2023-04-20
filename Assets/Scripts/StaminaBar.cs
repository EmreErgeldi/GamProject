using UnityEngine;
using UnityEngine.UI;
public class StaminaBar : MonoBehaviour
{
    private float fillAmount;
    private float smoothFillAmount;
    private Image staminaBar;

    private float currentVelocity = 0;
    void Start()
    {
        staminaBar = GetComponent<Image>();
    }

    
    void Update()
    {
        fillAmount = PlayerStats.stamina / 100f;
        smoothFillAmount = Mathf.SmoothDamp(staminaBar.fillAmount, fillAmount, ref currentVelocity, 100 * Time.deltaTime);
        staminaBar.fillAmount = smoothFillAmount;
    }
}
