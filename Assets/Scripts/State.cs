using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "State", menuName = "Scriptable Objects/State")]
public class State : ScriptableObject
{
    public Vector3 playerPosition;
    public List<Vector3> boxPostions = new List<Vector3>();

    public void SavePlayerState(Transform player)
    {
        playerPosition = player.position;
    }

    public void SaveBoxesState(List<Transform> boxes)
    {
        boxPostions.Clear();

        foreach (var box in boxes)
        {
            boxPostions.Add(box.position);
        }
    }

    public void LoadPlayerState(Transform player)
    {
        Vector3 roundedPosition = new Vector3(
            Mathf.Round(playerPosition.x),
            1,
            Mathf.Round(playerPosition.z)
        );

        player.position = roundedPosition;
    }

    public void LoadBoxesState(List<Transform> boxes)
    {
        for (int i = 0; i < boxes.Count; i++)
        {
            if(i < boxPostions.Count)
            {
                boxes[i].position = boxPostions[i];
            }
        }
    }
}
