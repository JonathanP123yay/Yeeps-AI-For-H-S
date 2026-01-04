
using UnityEngine;

public class ServerSimulator : MonoBehaviour
{
    public static ServerSimulator Instance;
    public float maxThrowSpeed = 12f;
    public float hitRadius = 0.4f;

    void Awake()
    {
        Instance = this;
    }

    public bool ResolveThrow(Vector3 origin, Vector3 velocity, Vector3 targetPos)
    {
        velocity = Vector3.ClampMagnitude(velocity, maxThrowSpeed);
        float time = Vector3.Distance(origin, targetPos) / Mathf.Max(velocity.magnitude, 0.01f);
        Vector3 predicted = origin + velocity * time;
        return Vector3.Distance(predicted, targetPos) <= hitRadius;
    }
}
