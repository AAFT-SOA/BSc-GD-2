using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Public_Variables
    public static PlayerMovement Instance;

    public float mouseSensitivity;
    public float playerSpeed;
    #endregion


    #region Private_Variables
    float mouseX, mouseY;
    Camera mainCamera;
    float verticalValue = 0;

    float horizontalInput, verticalInput;
    Rigidbody rb;


    public float maxHealth;
    public float currentHealth;
    
    
    #endregion


    #region Monobehaviour_Funcions
    private void Awake()
    {
        if(Instance == null)
            Instance = this;

        Cursor.lockState = CursorLockMode.Locked;       
    }

    void Start()
    {
        mainCamera = GetComponentInChildren<Camera>();
        rb = GetComponent<Rigidbody>();
            

        currentHealth = maxHealth;
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


    public void TakeDamage(float _damage)
    {
        currentHealth = currentHealth - _damage;
        if(PlayerHealthBar.instance != null)
        {
            Debug.Log("aaaaaaaaaaaaaaaaaaaaa");
            PlayerHealthBar.instance.UpdateHealthBar(currentHealth, maxHealth);
        }

        if(currentHealth <= 0)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }



    #endregion


}
