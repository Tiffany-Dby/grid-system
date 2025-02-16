using UnityEngine;

public class GoalFinishTriggers : MonoBehaviour
{
    private GameStatus gameStatus;

    void Start()
    {
        gameStatus = FindAnyObjectByType<GameStatus>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            gameStatus.AddToTotalOnGoals();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            gameStatus.RemoveFromTotalOnGoals();
        }
    }
}
