using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class coinMovement : MonoBehaviour
{
    private Vector2 startTouch, swipeDelta;
    private static bool isDraging, startClick;
    private float xPos;
    public float turnSpeed, speedForward, coinRotateAngle;
    public GameObject coinStack, startFinger;
    void Start()
    {
        startFinger.SetActive(true);
        isDraging = startClick = false;
    }

    private void Update()
    {
        if (coinHandler.gameOver == false && coinHandler.levelEnd == false)
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
                if (startClick == false) { startingGame(); }   
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

            if (isDraging == false)
            {
                transform.DOLocalRotate(new Vector3(0, -90, 0), 0.5f);
            }

            transform.localPosition += new Vector3(0, 0, 1) * speedForward * Time.deltaTime;
        }

        if (coinHandler.levelEnd && levelEnd_Controller.coinsDroped == false)
        {
            Vector3 desiredPosition = new Vector3(0, transform.position.y, transform.position.z);
            Vector3 SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.1f);
            if (transform.position != SmoothedPosition) { transform.position = SmoothedPosition; }
            transform.localPosition += new Vector3(0, 0, 1) * speedForward * Time.deltaTime;

        }
        if (levelEnd_Controller.coinsDroped)
        {
          //  coinHandler.levelEnd = false;

        }
    }

    void LocalMoveL(float x)
    {
        transform.DOLocalRotate(new Vector3(0, -130, 0), 0.2f);
        transform.localPosition += new Vector3(x, 0, 0) * turnSpeed * Time.deltaTime;
    }

    void LocalMoveR(float x)
    {
        transform.DOLocalRotate(new Vector3(0, -50, 0), 0.2f);
        transform.localPosition += new Vector3(x, 0, 0) * turnSpeed * Time.deltaTime;
    }

    void startingGame()
    {
        startFinger.SetActive(false);
        speedForward = 1.7f;
        startClick = true;
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
}
