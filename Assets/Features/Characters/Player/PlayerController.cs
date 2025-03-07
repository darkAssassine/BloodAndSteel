using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInputs))]
[RequireComponent(typeof(AttackEvents))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform camLock;

    [SerializeField]
    private float walkSpeed;

    [SerializeField]
    private float dashSpeed;

    [SerializeField]
    private float dashTime;

    [SerializeField] 
    private float dashCooldown;

    [SerializeField]
    private float MouseSensivityX;

    [SerializeField] 
    private float MouseSensivityY;

    [SerializeField]
    private Animator anim;

    [SerializeField] 
    private VisualEffect dashVFX;
    [SerializeField]
    private Transform[] camLockAndChildren;
    private PlayerInputs input;
    private Rigidbody rb;


    [SerializeField]
    private AudioSource walkSound;
    private Vector3 movement;

    private bool canDash = true;
    private bool isDashing = false;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Awake()
    {
      
        rb = GetComponent<Rigidbody>();
        input = GetComponent<PlayerInputs>();
        yaw = transform.eulerAngles.y;
    }

    private void Start()
    {
        dashVFX.Stop();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        anim.SetFloat("Speed", rb.velocity.magnitude / walkSpeed);

        Look();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (input.Dash && canDash)
            StartCoroutine(Dash());   
        if (isDashing)
            movement = new Vector3(input.MoveX * dashSpeed, rb.velocity.y, input.MoveY * dashSpeed);
        else
            movement = new Vector3(input.MoveX * (walkSpeed), rb.velocity.y, input.MoveY * (walkSpeed ));

        rb.velocity = transform.TransformDirection(movement);
        if (input.MoveX == 0 && input.MoveY == 0 || Time.timeScale < 0.3f)
        {
         
            walkSound.Stop();
        }
        else
        {
            if (walkSound.isPlaying == false)
            {
                walkSound.Play();
            }
      
        }
    }

    private IEnumerator Dash()
    {
        dashVFX.Play();
        isDashing = true;
        canDash = false;
        yield return new WaitForSeconds(dashTime);
        dashVFX.Stop();
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);

        canDash = true;
    }

    private void Look()
    {
        if (Time.timeScale < 0.5f)
        {
            return;
        }
        yaw += MouseSensivityX * Input.GetAxis("Mouse X") + (MouseSensivityX * input.MouseX * 0.75f);
        pitch -= MouseSensivityY * Input.GetAxis("Mouse Y") + (MouseSensivityY * input.MouseY * 0.75f);

        foreach(Transform tran in camLockAndChildren)
        {
            tran.eulerAngles = new Vector3(tran.eulerAngles.x, transform.eulerAngles.y , tran.eulerAngles.z);
        }
        transform.eulerAngles = new Vector3(0, yaw, 0);
        pitch = Mathf.Clamp(pitch, -88, 88);
        camLock.eulerAngles = new Vector3(pitch, camLock.eulerAngles.y, camLock.eulerAngles.z);
    }
}
