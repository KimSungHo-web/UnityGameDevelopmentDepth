using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float changeDirectionTime = 3.0f;
    public Vector2 minBounds = new Vector2(-74f, -20f);
    public Vector2 maxBounds = new Vector2(70f, 14f);

    private Vector3 targetPosition;
    private float timer;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        SetNewTargetPosition();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= changeDirectionTime)
        {
            SetNewTargetPosition();
            timer = 0;
        }

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, speed * Time.deltaTime);

        bool isMoving = Vector3.Distance(transform.localPosition, targetPosition) > 0.1f;
        animator.SetBool("isWalk", isMoving);
    }

    private void SetNewTargetPosition()
    {
        float randomX = Random.Range(minBounds.x, maxBounds.x);
        float randomY = Random.Range(minBounds.y, maxBounds.y);
        targetPosition = new Vector3(randomX, randomY, transform.localPosition.z);
    }

    public void OutPosition()
    {
        float clampedX = Mathf.Clamp(transform.localPosition.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(transform.localPosition.y, minBounds.y, maxBounds.y);
        transform.localPosition = new Vector3(clampedX, clampedY, transform.localPosition.z);
    }

    public void OnTouch()
    {
        animator.SetTrigger("doTouch");
    }
}
