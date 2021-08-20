using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Header("Events")]
    public UnityEvent onReachedMaximum = null;
    public UnityEvent onReachedMinimum = null;
    public UnityEvent onAdded = null;
    public UnityEvent onSubtracted = null;
    [Header("Settings")]
    public int currentPoints = 1;
    public int maximumPoints = 1;
    public int minimumPoints = 0;

    public void Add(int amount)
    {
        amount = Mathf.Abs(amount);
        int resultPoints = currentPoints + amount;
        if (resultPoints >= maximumPoints)
        {
            currentPoints = maximumPoints;
            onReachedMaximum.Invoke();
        }
        else
        {
            currentPoints = resultPoints;
        }
        onAdded.Invoke();
    }

    public void Subtract(int amount)
    {
        amount = Mathf.Abs(amount);
        int resultPoints = currentPoints - amount;
        if (resultPoints <= minimumPoints)
        {
            currentPoints = minimumPoints;
            onReachedMinimum.Invoke();
        }
        else
        {
            currentPoints = resultPoints;
        }
        onSubtracted.Invoke();
    }
}
