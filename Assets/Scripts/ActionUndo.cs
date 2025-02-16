using System.Collections.Generic;
using UnityEngine;

public class ActionUndo : MonoBehaviour
{
    public State state;

    public Transform player;
    public List<Transform> boxes;

    private Stack<State> moveHistory = new Stack<State>();

    public void SaveStates()
    {
        player = FindPlayer();
        boxes = FindBoxes();

        if (player == null || boxes == null)
        {
            Debug.Log("Cannot save state, missing player or boxes");
            return;
        }

        State newState = ScriptableObject.CreateInstance<State>();
        newState.SavePlayerState(player);
        newState.SaveBoxesState(boxes);

        moveHistory.Push(newState);
    }

    public void SavePlayerState()
    {
        player = FindPlayer();

        if (player == null)
        {
            Debug.Log("Player is null");
            return;
        }

        State newState = ScriptableObject.CreateInstance<State>();
        newState.SavePlayerState(player);

        moveHistory.Push(newState);
    }

    public void SaveBoxesState()
    {
        boxes = FindBoxes();

        if (boxes == null)
        {
            Debug.Log("Boxes are null");
            return;
        }

        State newState = ScriptableObject.CreateInstance<State>();
        newState.SaveBoxesState(boxes);

        moveHistory.Push(newState);
    }

    public void Undo()
    {
        if (moveHistory.Count > 0)
        {
            State lastState = moveHistory.Pop();

            lastState.LoadPlayerState(player);
            lastState.LoadBoxesState(boxes);
        } else
        {
            Debug.Log("No history");
        }
    }

    private Transform FindPlayer()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        return playerObj ? playerObj.transform : null;
    }

    private List<Transform> FindBoxes()
    {
        List<Transform> boxes = new List<Transform>();
        GameObject[] boxObjects = GameObject.FindGameObjectsWithTag("Box");

        foreach (GameObject box in boxObjects)
        {
            boxes.Add(box.transform);
        }

        return boxes;
    }
}