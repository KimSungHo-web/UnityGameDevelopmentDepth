using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float changeDirectionTime = 3.0f;
    public Vector2 minBounds = new Vector2(-2.5f, -1.5f);
    public Vector2 maxBounds = new Vector2(2.5f, 1.5f);

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

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        bool isMoving = Vector3.Distance(transform.position, targetPosition) > 0.1f;
        animator.SetBool("isWalk", isMoving);
    }

    private void SetNewTargetPosition()
    {
        float randomX = Random.Range(minBounds.x, maxBounds.x);
        float randomY = Random.Range(minBounds.y, maxBounds.y);
        targetPosition = new Vector3(randomX, randomY, transform.position.z);
    }

    public void OnTouch()
    {
        animator.SetTrigger("doTouch");
    }
}
