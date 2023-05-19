using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFeedBack : MonoBehaviour
{
    public static float EnemyHealth;
    string getEnemyName;
    Collider[] colliders;
    EnemyAI EAI;
    EnemyAIRanged EAIR;
    private Animator animator;
    private Animator playerAnimator;
    void Start()
    {
        /*colliders = gameObject.GetComponents<Collider>();
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
        animator = GetComponent<Animator>();
        EAI = GetComponent<EnemyAI>();
        EAIR = GetComponent<EnemyAIRanged>();
        getEnemyName = gameObject.tag;
        if (getEnemyName == "Troll")
            EnemyHealth = 200f;
        else if (getEnemyName == "Skeleton")
            EnemyHealth = 100f;
        else if (getEnemyName == "DemonGirl")
            EnemyHealth = 150f;
        else if (getEnemyName == "Wizard")
            EnemyHealth = 500f;
		else if (getEnemyName == "Dragon")
			EnemyHealth = 500f;*/
	}

    // Update is called once per frame
    void Update()
    {
       print(EnemyHealth);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword") && playerAnimator.GetBool("combo"))
        {
            animator.SetTrigger("GetHit");
            EnemyHealth -= 15f;
            Diead();
        }
    }
    void Diead()
    {
        if(EnemyHealth <=0 && !animator.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            foreach (Collider col in colliders)
            {
                col.enabled = false;
            }
            animator.SetTrigger("Die");
            Destroy(EAI);
            Destroy(EAIR);
            Destroy(gameObject ,4f);
        }
    }

}
