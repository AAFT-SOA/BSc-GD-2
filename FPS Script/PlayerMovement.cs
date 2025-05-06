using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Public_Variables
    public float mouseSensitivity;
    public float playerSpeed;
    #endregion


    #region Private_Variables
    float mouseX, mouseY;
    Camera mainCamera;
    float verticalValue = 0;

    float horizontalInput, verticalInput;
    Rigidbody rb;
    #endregion


    #region Monobehaviour_Funcions
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Start()
    {
        mainCamera = GetComponentInChildren<Camera>();
        rb = GetComponent<Rigidbody>();
    }    
    void Update()
    {
        GetMouseInput();
        RotateCamera();

        GetKeyboardInput();
    }
    void FixedUpdate()
    {
        MovePlayer();
    }
    #endregion



    #region Custom_Functions
    void GetMouseInput()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;        
    }

    void RotateCamera()
    {
        transform.Rotate(Vector3.up * mouseX);

        verticalValue -= mouseY;
        verticalValue = Mathf.Clamp(verticalValue, -90f, 90f);
        mainCamera.transform.localRotation = Quaternion.Euler(verticalValue, 0,0);
    }


    void GetKeyboardInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
    void MovePlayer()
    {
        Vector3 direction = transform.right * horizontalInput + transform.forward * verticalInput;
        Vector3 movement = direction * playerSpeed;
        rb.linearVelocity = new Vector3(movement.x,rb.linearVelocity.y,movement.z);
    }

    #endregion


}
