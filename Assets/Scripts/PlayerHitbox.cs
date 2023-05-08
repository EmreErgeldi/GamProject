using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    public Animator wizard;
    public Animator demonGirl;
    public void Damage()
    {
        if(wizard.GetBool("isAttacking"))
        {
            WizardStats.TakeDamage();
            wizard.SetTrigger("takeDamage");
        }
        else if(demonGirl.GetBool("isAttacking"))
        {
            DemonGirlStats.TakeDamage();
            demonGirl.SetTrigger("takeDamage");
        }
        
    }
}
