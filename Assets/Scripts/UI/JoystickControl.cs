using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickControl : MonoBehaviour
{
    [SerializeField] private GameObject TouchPoint;
    private Vector2 TargetVector;

    private void Movement()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 touchPos = Input.mousePosition;

            TargetVector = touchPos - new Vector2(transform.position.x, transform.position.y);
            TargetVector = Vector2.ClampMagnitude(TargetVector, 100);

            TouchPoint.transform.localPosition = TargetVector;
            GameManager.MovePlayer.Invoke(TargetVector, 1);

            return;
        }
        TouchPoint.transform.position = transform.position;
        TargetVector = Vector2.zero;
        GameManager.MovePlayer.Invoke(TargetVector, 1);
    }

    private void Start()
    {
        TouchPoint.transform.position = transform.position;
    }

    private void FixedUpdate()
    {
        Movement();
    }


}
