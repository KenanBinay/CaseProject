using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class coinMovement : MonoBehaviour
{
    private Vector2 startTouch, swipeDelta;
    public static bool isDraging, startClick, rightTurn, leftTurn;
    private float xPos;
    public float turnSpeed, speedForward, coinRotateAngle;
    public GameObject coinStack, startFinger;
    Rigidbody coinRb;
    void Start()
    {
        coinRb = GetComponent<Rigidbody>();
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
                isDraging = rightTurn = leftTurn = false;            
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

        if (coinHandler.levelEnd && coinHandler.levelEndCoinVal != coinHandler.coinCurrentVal)
        {
            Vector3 desiredPosition = new Vector3(0, transform.position.y, transform.position.z);
            Vector3 SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.1f);
            if (transform.position != SmoothedPosition) { transform.position = SmoothedPosition; }
            if (gameObject.transform.position.z != levelEnd_Controller.distanceRamps_Z - 16f) { transform.localPosition += new Vector3(0, 0, 1) * speedForward * Time.deltaTime; }
        }
        if (coinHandler.levelEndCoinVal == coinHandler.coinCurrentVal)
        {
           
        }
    }

    void LocalMoveL(float x)
    {
        rightTurn = false;
        leftTurn = true;
        transform.DOLocalRotate(new Vector3(0, -130, 0), 0.2f);
        transform.localPosition += new Vector3(x, 0, 0) * turnSpeed * Time.deltaTime;
    }

    void LocalMoveR(float x)
    {
        leftTurn = false;
        rightTurn = true;
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
