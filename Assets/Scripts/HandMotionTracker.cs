using UnityEngine;
using System.Collections.Generic;

public class HandMotionTracker : MonoBehaviour
{
    public int sampleFrames = 10;
    private Queue<Vector3> positionHistory = new Queue<Vector3>();

    void Update()
    {
        positionHistory.Enqueue(transform.position);
        if (positionHistory.Count > sampleFrames)
            positionHistory.Dequeue();
    }

    public Vector3 GetAverageVelocity()
    {
        if (positionHistory.Count < 2)
            return Vector3.zero;

        Vector3[] positions = positionHistory.ToArray();
        Vector3 delta = positions[positions.Length - 1] - positions[0];
        float time = Time.deltaTime * (positions.Length - 1);

        return delta / Mathf.Max(time, 0.0001f);
    }
}
