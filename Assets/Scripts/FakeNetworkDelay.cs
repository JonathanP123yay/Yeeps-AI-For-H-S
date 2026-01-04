using UnityEngine;
using System.Collections.Generic;

public class FakeNetworkDelay : MonoBehaviour
{
    public float delaySeconds = 0.08f;

    private struct State
    {
        public Vector3 pos;
        public float time;
    }

    private Queue<State> history = new Queue<State>();

    void Update()
    {
        history.Enqueue(new State {
            pos = transform.position,
            time = Time.time
        });

        while (history.Count > 0 && Time.time - history.Peek().time > delaySeconds)
            history.Dequeue();
    }

    public Vector3 GetDelayedPosition()
    {
        return history.Count > 0 ? history.Peek().pos : transform.position;
    }
}
