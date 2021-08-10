using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerBase
{
    [Space]
    [Header("Move Control: ")]
    [SerializeField] private Vector2 mousePos;
    public float moveSpeed = 1f;
    protected bool moving;
    private Vector2 moveDir;

    protected virtual void Update()
    {
        ProcessInput();
        MoveControl();
    }


    private void ProcessInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moveDir = (mousePos - (Vector2)transform.position).normalized;
            if(moveDir.x < 0)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            moving = true;
            animator.SetFloat("speed", 1f);
        }
    }

    protected void MoveControl()
    {
        if(moving && (Vector2)transform.position != mousePos)
        {
            transform.position = Vector2.MoveTowards(transform.position, mousePos, moveSpeed * Time.deltaTime);
        }
        else
        {
            moving = false;
            animator.SetFloat("speed", 0f);
        }
    }
}
