using UnityEngine;

public class SimulationLogger : MonoBehaviour
{
    int totalTests = 10;
    int hits = 0;

    public void LogTest(int testNum, bool thrown, float confidence, bool hit)
    {
        Debug.Log(
            $"Test {testNum}:\n" +
            $"Throwed: {thrown}\n" +
            $"Confidence: {confidence * 100f}%\n" +
            $"Hit Percent: {hit}\n"
        );

        if (hit) hits++;
    }

    public void PrintSummary()
    {
        Debug.Log(
            $"Overall Confidence: {(hits / (float)totalTests) * 100f}%\n" +
            $"Overall Success: {(hits / (float)totalTests) * 100f}%"
        );
    }
}
