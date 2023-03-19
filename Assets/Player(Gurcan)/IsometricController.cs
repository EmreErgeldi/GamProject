using UnityEngine;

public class IsometricController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Rigidbody rb;
    private Vector3 input;
    public float speed = 10f;
    [SerializeField] private float turnSpeed = 1080f;

    [SerializeField] private Animator animator;

    [SerializeField] private Transform sword;
    [SerializeField] private Transform rightHand;
    [SerializeField] private Transform swordRest;
    
    private void Update()
    {
        GatherInput();
        Look();
        HandeAnimations();
        HandleCombo();

        if(!Input.GetKey(KeyCode.W))
        {
            rb.Sleep();
        }
    }

   void HandleCombo()
    {
        if(Input.GetMouseButton(0))
        {
            animator.SetBool("combo", true);
            sword.SetParent(rightHand);
            sword.localPosition = new Vector3(0f, 0f, 0f);
            sword.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            animator.SetBool("combo", false);
            sword.SetParent(swordRest);
            sword.localPosition = new Vector3(0f, -.4f, 0f);
            sword.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    

    private void FixedUpdate()
    {
        Move();
    }

    void GatherInput()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
    }

    void Move()
    {
        rb.MovePosition(transform.position + (transform.forward * input.magnitude) * speed * Time.fixedDeltaTime);
    }
    
    void Look()
    {
        if(input != Vector3.zero)
        {
            var relative = (transform.position + input.ToIso()) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);
        }
        
    }

    void HandeAnimations()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isRunning", true);
        }
        else if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("isRunning", false);
        }
    }
}
