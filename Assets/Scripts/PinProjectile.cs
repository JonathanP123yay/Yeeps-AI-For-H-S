using UnityEngine;

public class PinProjectile : MonoBehaviour
{
    public float lifetime = 5f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision col)
    {
        // Placeholder for hit logic
        Debug.Log("Pin hit: " + col.gameObject.name);
    }
}
