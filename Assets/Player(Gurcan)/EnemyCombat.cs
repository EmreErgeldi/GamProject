using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    
    public void DamagePlayer()
    {
        PlayerStats.health -= 10f;
    }
}
