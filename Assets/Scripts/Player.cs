using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Movement movement;
    private float speed = 5;
    private float margin = 0.25f;
    private HashSet<string> tags = new HashSet<string> { "Wall", "Box" };

    void Start()
    {
        movement = GetComponent<Movement>();

        if (movement == null)
        {
            Debug.LogError("Movement script not found on player");
        }
    }

    void Update()
    {
        PlayerMove();
    }

    private void OnCollisionEnter(Collision collision) => PlayerPushBox(collision);

    private void PlayerMove() => movement.MoveGameObject(speed);

    private void PlayerPushBox(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            movement.PushGameObject(collision.gameObject, margin, tags);
        }
    }
}
