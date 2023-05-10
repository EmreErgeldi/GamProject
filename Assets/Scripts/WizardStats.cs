using Unity.VisualScripting;
using UnityEngine;

public class WizardStats : MonoBehaviour
{
    public static int health = 100;
    public static int armor;
    public int armorValue;
    public Animator wizard;
    void Start()
    {
        armor = armorValue;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Die();
            
        }
    }
    public static void TakeDamage()
    {
        health -= (35 - armor);
        Debug.Log(health);
    }

    private void Die()
    {
        wizard.SetTrigger("isDead");
        Destroy(gameObject, 2f);
    }
}
