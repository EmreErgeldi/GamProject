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
       Debug.Assert(health >= 0, "Health can't be negative!");
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
            health += 1f * Time.deltaTime;
        }

        if (health > 100)
        {
            health = 100;
        }
        if (health < 0) { health = 0; }
    }


}
