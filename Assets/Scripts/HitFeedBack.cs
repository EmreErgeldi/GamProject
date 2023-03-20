using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFeedBack : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    void Start()
    {

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
        if (other.CompareTag("Sword"))
        {
            animator.SetTrigger("GetHit");
        }
    }
}
