using UnityEngine;

public class notSafe : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float moveDistance = 3f; // Set in Inspector

    private bool isMoving = false;
    private Vector3 targetPosition;

    public void move()
    {
        if (!isMoving)
        {
            targetPosition = transform.position + Vector3.down * moveDistance;
            isMoving = true;
        }
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                moveSpeed * Time.deltaTime
            );

            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }
}