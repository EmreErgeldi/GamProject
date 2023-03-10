using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private float speed = 10f;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveInputs = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        Vector3 moveVelocity = moveInputs * Time.deltaTime * speed;

        characterController.Move(moveVelocity);

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isSprinting", true);
        }
        if (Input.GetKeyUp(KeyCode.W)){
            animator.SetBool("isSprinting", false);
        }
    }

}
