using UnityEngine.UI;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static float stamina;
    public static float health;
 
    void Start()
    {
        stamina = 100f;
        health = 100f;
    }

    void Update()
    {
       HandleStats();

    }

    void HandleStats()
    {
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
