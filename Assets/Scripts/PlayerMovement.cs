using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 3.0f;
    public float acceleration = 12f;

    private Vector3 currentVelocity;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 inputDir = new Vector3(h, 0, v);
        Vector3 targetVelocity = inputDir.normalized * maxSpeed;

        currentVelocity = Vector3.Lerp(
            currentVelocity,
            targetVelocity,
            acceleration * Time.deltaTime
        );

        transform.position += currentVelocity * Time.deltaTime;
    }

    public Vector3 GetVelocity()
    {
        return currentVelocity;
    }
}
