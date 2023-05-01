using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] MeshCollider weapon;
    [SerializeField] Animator player;
    public void ActivateCollider()
    {
        weapon.enabled = true;
        
    }

    public void DeactivateCollider()
    {
        weapon.enabled = false;
    }

    public void DealDamage()
    {
        if(!player.GetBool("isRunning"))
        {
            player.SetTrigger("takeDamage");
        }
            
    }
}
