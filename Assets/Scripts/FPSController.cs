using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{

    public Camera playerCamera;
    public float walkSpeed;
    public float runSpeed;
    public float jumpPower;
    public float gravity;

    public float lookSpeed;
    public float lookXLimit;

    public GameObject Sword;
    [SerializeField] private Animator anim;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;

    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //anim.SetTrigger("walk");
    }

    // Update is called once per frame
    void Update()
    {
        #region Handles Movment
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        #endregion

        #region Handles Jumping
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        #endregion

        #region Handles Rotation
        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        #endregion

        #region Sword Swing
        if (Input.GetMouseButtonDown(0)/* || Input.GetKey(KeyCode.LeftArrow)*/)
        {
            anim.SetBool("attack 0", true);
            Debug.Log("lEFT mOUSE BUTTON CLICKED");
            Debug.Log(anim);
            Debug.Log(anim.GetBool("attack 0"));

        }
        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("attack 0", false);
            Debug.Log("lEFT mOUSE BUTTON up");
            Debug.Log(anim.GetBool("attack 0"));


        }
        #endregion

        #region Walk and Jump
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("w pressed");
            anim.SetBool("walk 0", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("walk 0", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space bar pressed");
            anim.SetBool("jump 0", true);
        }
        if (Input.GetKeyUp(KeyCode.Space) /*|| characterController.isGrounded*/)
        {
            anim.SetBool("jump 0", false);
        }
        #endregion

    }

    private IEnumerator HandleIt()
    {
        bool beingHandled = true;
        // process pre-yield
        Debug.Log("Waiting 3 seconds");
        yield return new WaitForSeconds(3.0f);
        // process post-yield
        Debug.Log("Waited");
        
        beingHandled = false;
    }
}
