using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private float speed = 10f;
    private Animator animator;
    public float rotationSpeed = 10f;
    public float mouseSensivity = 700f;
    private float xRotation = 0f;
    public float attackSpeed = 5f;


    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        //Cursor
        //Cursor.visible = false; // ekranda mouse gözüksün mü
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveInputs = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        Vector3 moveVelocity = moveInputs * Time.deltaTime * speed;
        //Movement
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isSprinting", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isBackward", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isLeft", true);
        }

        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isRight", true);
        }
        //Rolling
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.A))
        {
            animator.SetBool("RollLeft", true);
            Invoke("ResetRoCooldown", 1.14f);
        }
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.D))
        {
            animator.SetBool("RollRight", true);
            Invoke("ResetRoCooldown", 1.14f);
        }
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.W))
        {
            animator.SetBool("RollForward", true);
            Invoke("ResetRoCooldown", 1.14f);
        }
        //Attacking
        if (Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetBool("Attack", true);
        }
        //Canceling
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.Mouse0))
        {
            animator.SetBool("isSprinting", false);
            animator.SetBool("isBackward", false);
            animator.SetBool("isLeft", false);
            animator.SetBool("isRight", false);
            animator.SetBool("Attack", false);
        }
        transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensivity, 0);
        xRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        // Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0, 0); aþaðý bakma

        characterController.Move(moveVelocity);
        //print(moveVelocity);
    }
    //Roll Animation Cancel Timer
    void ResetRoCooldown()
    {
        animator.SetBool("RollLeft", false);
        animator.SetBool("RollForward", false);
        animator.SetBool("RollRight", false);
    }

}
