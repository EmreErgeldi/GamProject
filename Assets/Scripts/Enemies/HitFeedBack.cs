using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFeedBack : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    [SerializeField]
    private Animator playerAnimator;
    void Start()
    {
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 

    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Sword") && playerAnimator.GetBool("combo"))
        {
           
            animator.SetTrigger("GetHit");
            
        }
    }

}
