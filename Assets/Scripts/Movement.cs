using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public void MoveGameObject(float speed)
    {

        float movementX = Input.GetAxis("Horizontal");
        float movementY = Input.GetAxis("Vertical");

        Vector3 movement = new(movementX, 0, movementY);
        transform.Translate(speed * Time.deltaTime * movement);
    }

   public void PushGameObject(GameObject gameObj, float margin, HashSet<string> tags)
    {
        Vector3 direction = GetPushDirection(gameObj);

        if (!AreGameObjectsAligned(gameObj, margin))
        {
            return;
        }

        if (IsGameObjectBlocked(gameObj, direction, tags))
        {
            return;
        }

        FindAnyObjectByType<ActionUndo>().SaveStates();

        gameObj.transform.position += direction;
    }

    private Vector3 GetPushDirection(GameObject gameObj)
    {
        Vector3 direction = gameObj.transform.position - transform.position;
        direction = direction.normalized;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.z))
        {
            return new Vector3(Mathf.Sign(direction.x), 0, 0);
        }
        else
        {
            return new Vector3(0, 0, Mathf.Sign(direction.z));
        }
    }

    private bool AreGameObjectsAligned(GameObject gameObj, float margin)
    {
        Vector3 baseGameObject = transform.position;
        Vector3 newGameObject = gameObj.transform.position;

        return Mathf.Abs(baseGameObject.x - newGameObject.x) <= margin || Mathf.Abs(baseGameObject.z - newGameObject.z) <= margin;
    }

    private bool IsGameObjectBlocked(GameObject gameObj, Vector3 direction, HashSet<string> tags)
    {
        RaycastHit hit;
        if (Physics.Raycast(gameObj.transform.position, direction, out hit, 1f))
        {
            return tags.Contains(hit.collider.tag);
        }

        return false;
    }
}
