using UnityEngine;

public class GameStatus : MonoBehaviour
{
    private int totalBoxesOnGoals;
    private int totalBoxesOnGoalsToWin;

    private bool isGameOver = false;

    void Update()
    {
        if (!isGameOver && IsWin())
        {
            OnGameWin();
        }
    }

    public void GetTotalBoxesToWin(int count) => totalBoxesOnGoalsToWin = count;

    public void AddToTotalOnGoals()
    {
        totalBoxesOnGoals++;
        IsWin();
    }

    public void RemoveFromTotalOnGoals() => totalBoxesOnGoals--;

    private bool IsWin() => totalBoxesOnGoals == totalBoxesOnGoalsToWin;

    private void OnGameWin()
    {
        Debug.Log("You won !");
        FindAnyObjectByType<Scenes>().TriggerWinMenu();
        isGameOver = true;
    }
}
