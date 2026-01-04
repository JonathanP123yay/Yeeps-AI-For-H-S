
using UnityEngine;

public class ClientPredictor : MonoBehaviour
{
    public Transform hand;
    public Transform target;
    public float leadTime = 0.15f;
    public float baseThrowSpeed = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AttemptThrow();
        }
    }

    void AttemptThrow()
    {
        Vector3 predictedTarget = target.position + target.GetComponent<Rigidbody>().linearVelocity * leadTime;
        Vector3 dir = (predictedTarget - hand.position).normalized;
        Vector3 velocity = dir * baseThrowSpeed;

        bool hit = ServerSimulator.Instance.ResolveThrow(hand.position, velocity, predictedTarget);
        Debug.Log(hit ? "HIT (server accepted)" : "MISS (server rejected)");
    }
}
