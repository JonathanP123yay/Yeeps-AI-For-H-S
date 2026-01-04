
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    public Vector3 bounds = new Vector3(3,1,3);
    public float speed = 1.5f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void FixedUpdate()
    {
        Vector3 dir = new Vector3(Mathf.Sin(Time.time), 0, Mathf.Cos(Time.time));
        rb.linearVelocity = dir * speed;
        transform.position = Vector3.Max(-bounds, Vector3.Min(bounds, transform.position));
    }
}
