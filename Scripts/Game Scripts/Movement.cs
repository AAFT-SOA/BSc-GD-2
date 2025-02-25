using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class Movement : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    public float speed;
    float h, v;

    Vector3 direction;

    // For Player Rotation
    public float smooth = 0.3f;   
    float yVelocity = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }
    private void FixedUpdate()
    {
        MovePlayer();
        RunAnimation();
        RotatePlayer();
    }

    void GetInput()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        direction = new Vector3(h, 0, v);
    }

    void MovePlayer()
    {
        rb.MovePosition(transform.position + direction * Time.fixedDeltaTime * speed);
    }

    void RotatePlayer()
    {
        if (h != 0f || v != 0f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            //Debug.Log("targetAngle  ==   " + targetAngle);
            float yAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref yVelocity, smooth);

            transform.rotation = Quaternion.Euler(0f, yAngle, 0f);
        }
    }

    void RunAnimation()
    {
        if (h != 0f || v != 0f)
        {
            anim.SetBool("Run",true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }
}
