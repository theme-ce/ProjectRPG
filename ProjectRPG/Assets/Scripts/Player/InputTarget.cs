using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTarget : MonoBehaviour
{
    public GameObject player;

    private void Update()
    {
        ClickTarget();
    }

    private void ClickTarget()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, 64);

            if (hit)
            {
                if (hit.collider.GetComponent<Enemy>() != null)
                {
                    player.GetComponent<PlayerBase>().targetedEnemy = hit.collider.gameObject;
                }
                else if (hit.collider.GetComponent<Enemy>() == null)
                {
                    player.GetComponent<PlayerBase>().targetedEnemy = null;
                }
            }
        }
    }
}
