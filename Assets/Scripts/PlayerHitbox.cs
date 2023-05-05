using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    public Animator wizard;
    public void Damage()
    {
        if(wizard.GetBool("isAttacking"))
        {
            WizardStats.TakeDamage();
            wizard.SetTrigger("takeDamage");
        }
        
    }
}
