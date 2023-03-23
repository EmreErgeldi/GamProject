using System.Collections;
using UnityEngine;

public class IsometricController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Rigidbody rb;
    private Vector3 input;
    public float speed = 10f;
    [SerializeField] private float turnSpeed = 1080f;

    [Header("Animation")]
    [SerializeField] private Animator animator;

    [Header("Combat")]
    [SerializeField] private Transform sword;
    [SerializeField] private Transform rightHand;
    [SerializeField] private Transform swordRest;

    [Header("Dash")]
    [SerializeField] private float dashSpeed = 50f;

    
    private void Update()
    {
        GatherInput();
        Look();
        HandeAnimations();
        HandleCombo();

        HandleRigidbody();
        
        SheathBack();

        Dash();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void HandleRigidbody()
    {
        if(!animator.GetBool("isRunning"))
        {
            rb.Sleep();
        }
    }

    void Dash()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = transform.forward * dashSpeed;
        }
        
    }

    #region Sword

    void SheathBack()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (rb.IsSleeping())
            {
                StartCoroutine(DelaySheath());
            }
            else
            {
                animator.SetBool("sheath", true);
                sword.SetParent(swordRest);
                sword.localPosition = new Vector3(0f, -.4f, 0f);
                sword.localRotation = Quaternion.Euler(0f, 0f, 0f);
            }
            
        }
    }

    IEnumerator DelaySheath()
    {
        animator.SetBool("sheath", true);
        yield return new WaitForSeconds(.4f);
        sword.SetParent(swordRest);
        sword.localPosition = new Vector3(0f, -.4f, 0f);
        sword.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }

    IEnumerator DelayDraw()
    {
        yield return new WaitForSeconds(.4f);
        sword.SetParent(rightHand);
        sword.localPosition = new Vector3(0f, 0f, 0f);
        sword.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }

   void HandleCombo()
    {
        if(Input.GetMouseButton(0) && rb.IsSleeping())
        {
            animator.SetBool("combo", true);
            animator.SetBool("sheath", false);
            StartCoroutine(DelayDraw());
            
        }
        else if(Input.GetMouseButtonUp(0))
        {
            animator.SetBool("combo", false);
        }
    }

    #endregion

    void GatherInput()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
    }

    void Move()
    {
        if (!animator.GetBool("combo"))
        {
            rb.MovePosition(transform.position + (transform.forward * input.magnitude) * speed * Time.fixedDeltaTime);
        }
        
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
