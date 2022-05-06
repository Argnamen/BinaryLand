using System.Collections;
using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool isCoroutineStop = true;

    public static float Speed = 1f;

    private Vector3 MoveVector = Vector3.zero;

    public static float[,] LevelMap;
    private void Start()
    {
        LevelMap = SceneLoader.navigationMap;
    }
    private void FixedUpdate()
    {
        if (isCoroutineStop)
        {
            Vector3 FloorPoint = new Vector3(
            Int32.Parse(Mathf.FloorToInt(this.transform.position.x).ToString()),
            Int32.Parse(Mathf.FloorToInt(this.transform.position.y).ToString()),
            this.transform.position.z);

            if (this.transform.position == FloorPoint && this.transform.parent.transform.localScale.x == 1)
            {
                int right = (int)LevelMap[(int)this.transform.position.x + 1, (int)this.transform.position.y];

                if (right == 0 || right >= 2)
                    MoveVector = Vector3.right;
                else
                {
                    MoveVector = Vector3.zero;
                    Destroy(this.gameObject);
                }
            }

            else if (this.transform.position == FloorPoint && this.transform.parent.transform.localScale.x == -1)
            {
                int right = (int)LevelMap[(int)this.transform.position.x - 1, (int)this.transform.position.y];

                if (right == 0 || right >= 2)
                    MoveVector = Vector3.left;
                else
                {
                    MoveVector = Vector3.zero;
                    Destroy(this.gameObject);
                }
            }
        }

        this.transform.position = Vector3.MoveTowards(this.transform.position, this.transform.position + MoveVector, Speed / 32);
    }
}
