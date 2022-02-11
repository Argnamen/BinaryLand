using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    private Vector2 MoveStart, MoveEnd;
    private Vector2 SaveMovePoint;
    private Vector2[] MovePoints = new Vector2[4] { Vector2.up, Vector2.down, Vector2.right, Vector2.left };
    private int PointScore = 0;
    private bool isCoroutineStop = true;
    private IEnumerator Move()
    {
        MoveStart = this.transform.localPosition;
        yield return new WaitForFixedUpdate();
        yield return new WaitForFixedUpdate();
        MoveEnd = this.transform.localPosition;
        isCoroutineStop = true;
    }

    private void Start()
    {
        SaveMovePoint = Vector2.down;
    }
    private void FixedUpdate()
    {
        this.GetComponent<Rigidbody2D>().velocity = MovePoints[PointScore];
        if (isCoroutineStop)
        {
            isCoroutineStop = false;

            if (MoveStart == MoveEnd)
            {
                PointScore = PointScore <= 2 ? ++PointScore : 0;
                //Debug.Log(PointScore);
            }
            
            StartCoroutine(Move());
        }
    }
}
