using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Rendering.CameraUI;

public class Movement : MonoBehaviour
{
    public float PlayerHealth;
    public Image PlayerHealthBarFill;
    public float Speed;
    public float TurnSensitivity;
    //public Joystick js;
    
    float h, v;
    Vector3 direction;

    Rigidbody rb;
    Animator anim;

    float turnVelocity = 0f;

    public bool InputFromJoystick;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
    }

    void GetInput()
    {
        if (!InputFromJoystick)
        {
            // Input From Keyboard
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
        }
        else
        {
            /*if (js != null)
            {
                // Input From Joystick
                h = js.Horizontal;
                v = js.Vertical;
            }
            else
            {
                Debug.Log("Joystick Reference is null.");
            }*/
        }


        direction = new Vector3(h, 0f ,v);
    }

    void MovePlayer()
    {
        if (h != 0 || v != 0)
        {
            rb.MovePosition(rb.transform.position + direction * Time.fixedDeltaTime * Speed);
        }
    }
    void RotatePlayer()
    {
        if (h != 0 || v != 0)
        {
            float targetAngle = Mathf.Atan2(direction.x,direction.z)*Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, TurnSensitivity);           
            transform.rotation = Quaternion.Euler(0,angle,0);
        }
    }

    public void PlayerHealthDamage(float damage)
    {
        PlayerHealth -= damage;

        
       

        if (PlayerHealth <= 0)
            Invoke(nameof(DestroyPlayer), 0.5f);
    }

    void DestroyPlayer()
    {
        Destroy(gameObject);
    }


}
