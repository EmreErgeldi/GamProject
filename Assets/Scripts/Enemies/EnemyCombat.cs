using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] Collider weapon;
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

    public void WizardAttack()
    {
        if (!player.GetBool("isRunning"))
        {
            player.SetTrigger("takeDamage");
            PlayerStats.health -= 20;
        }
    }

    public void DragonAttack()
    {
		if (!player.GetBool("isRunning"))
		{
			player.SetTrigger("takeDamage");
			PlayerStats.health -= 30;
		}
	}
}
