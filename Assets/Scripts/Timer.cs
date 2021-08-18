using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [Header("Settings")]
    public float duration = 0.0f;
    [Header("Events")]
    public UnityEvent onCompleted = null;
    //Varibles
    bool isStarted = false;
    float elapsedTime = 0.0f;
    bool isCompleted = false;

    void Update()
    {
        if (isStarted && !isCompleted) Complete();
    }

    public void Begin() => Begin(duration);
    
    public void Begin(float duration)
    {
        this.duration = duration;
        isStarted = true;
        elapsedTime = 0.0f;
        isCompleted = false;
    }

    void Complete()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= duration)
        {
            isCompleted = true;
            onCompleted.Invoke();
        }
    }

    public void Stop()
    {
        isStarted = false;
    }
}
