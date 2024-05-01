using UnityEngine;

public class CarController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float acceleration = 2.0f;
    [SerializeField]
    private float maxSpeed = 10.0f;
    [SerializeField]
    private float angularAcceleration = 2.0f;
    [SerializeField]
    private float maxAngularSpeed = 10.0f;
    [SerializeField]
    private float boostMultiplier = 2f;
    [SerializeField]
    private float brakeForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) && 
            rb.velocity.magnitude < maxSpeed * (Input.GetKey(KeyCode.LeftShift) ? boostMultiplier : 1f))
        {
            rb.AddForce(acceleration * boostMultiplier * Time.fixedDeltaTime * transform.right);
        }
        else if (Input.GetKey(KeyCode.S) && rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(acceleration * Time.fixedDeltaTime * -transform.right);
        }
        if (Input.GetKey(KeyCode.A) && Mathf.Abs(rb.angularVelocity) < maxAngularSpeed)
        {
            rb.AddTorque(angularAcceleration * rb.velocity.magnitude / maxSpeed * Time.fixedDeltaTime);
        }
        else if (Input.GetKey(KeyCode.D) && Mathf.Abs(rb.angularVelocity) < maxAngularSpeed)
        {
            rb.AddTorque(-angularAcceleration * rb.velocity.magnitude / maxSpeed * Time.fixedDeltaTime);
        }
        rb.drag = Input.GetKey(KeyCode.Space) ? brakeForce : 1f;
    }
}
