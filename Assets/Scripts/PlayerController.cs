using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Dependencies")]
    public Transform lookTransform = null;
    CharacterController controller = null;
    [Header("Settings")]
    public float maxLookX = 90.0f;
    public float lookSensitivity = 2.0f;
    public float walkSpeed = 1.6f;
    // Variables
    float lookX = 0.0f;
    float lookY = 0.0f;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Look();
        Move();
    }

    void CursorLock()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.visible)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    void Look()
    {
        float lookInputX = Input.GetAxisRaw("Mouse X");
        float lookInputY = Input.GetAxisRaw("Mouse Y");

        lookX += -lookInputY * lookSensitivity;
        lookY += lookInputX * lookSensitivity;

        if (lookX > maxLookX) lookX = maxLookX;
        else if (lookX < -maxLookX) lookX = -maxLookX;

        lookTransform.rotation = Quaternion.Euler(lookX, lookY, 0.0f);
    }

    void Move()
    {
        float moveInputHorizontal = Input.GetAxisRaw("Horizontal");
        float moveInputVertical = Input.GetAxisRaw("Vertical");

        Vector3 inputDirection = new Vector3(moveInputHorizontal, 0.0f, moveInputVertical);
        inputDirection.Normalize();

        Vector3 facingDirection = Vector3.Cross(lookTransform.right, transform.up);
        Quaternion facingRotation = Quaternion.LookRotation(facingDirection);

        Vector3 moveDirection = facingRotation * inputDirection;

        Vector3 movement = moveDirection * walkSpeed * Time.deltaTime;

        controller.Move(movement);
    }
}
