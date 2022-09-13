using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinMovement : MonoBehaviour
{
    private Vector2 startTouch, swipeDelta;
    private bool isDraging;
    private float xPos;
    public float turnSpeed, speedForward;
    public GameObject coinStack;
    void Start()
    {
        isDraging = false;
    }

    private void Update()
    {
        if (isDraging)
        {
            if (Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }

        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }

        if (swipeDelta.magnitude > 126)
        {
            float x = swipeDelta.x;

            if (x < 0)
            {
                xPos = -1;
                LocalMoveL(xPos);
            }
            else
            {
                xPos = 1;
                LocalMoveR(xPos);
            }
        }
        else { xPos = 0; }

        if (coinHandler.levelEnd == false && coinHandler.gameOver == false)
        {
            transform.localPosition += new Vector3(0, 0, 1) * speedForward * Time.deltaTime;
        }
    }

    void LocalMoveL(float x)
    {
        transform.localPosition += new Vector3(x, 0, 0) * turnSpeed * Time.deltaTime;
    }

    void LocalMoveR(float x)
    {
        transform.localPosition += new Vector3(x, 0, 0) * turnSpeed * Time.deltaTime;
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
}
