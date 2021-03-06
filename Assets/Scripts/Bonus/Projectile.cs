using System.Collections;
using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool isCoroutineStop = true;

    public float Speed = 1f;

    private Vector3 MoveVector = Vector3.zero;

    public static float[,] LevelMap;
    private void OnEnable()
    {
        if(SceneLoader.navigationMap != null)
            LevelMap = SceneLoader.navigationMap;
    }
    private void FixedUpdate()
    {
        if (SceneLoader.navigationMap != null)
        {
            LevelMap = SceneLoader.navigationMap;
            if (isCoroutineStop)
            {
                Vector3 FloorPoint = new Vector3(
                Int32.Parse(Mathf.FloorToInt(this.transform.position.x).ToString()),
                Int32.Parse(Mathf.FloorToInt(this.transform.position.y).ToString()),
                this.transform.position.z);

                //Debug.Log(this.transform.parent.gameObject.transform.localRotation.eulerAngles.z);

                if (this.transform.position == FloorPoint && (this.transform.parent.transform.localRotation.eulerAngles.z == 0 && this.transform.parent.transform.localRotation.eulerAngles.y == 0))
                {
                    int left = -1;

                    try
                    {
                        left = (int)LevelMap[(int)this.transform.position.x - 1, (int)this.transform.position.y];
                    }
                    catch
                    {

                    }
                    if (left == 0 || left >= 2)
                        MoveVector = Vector3.left;
                    else
                    {
                        MoveVector = Vector3.zero;
                        Destroy(this.gameObject);
                    }
                }

                else if (this.transform.position == FloorPoint && this.transform.parent.transform.localRotation.eulerAngles.y == 180)
                {
                    int right = -1;
                    try
                    {
                        right = (int)LevelMap[(int)this.transform.position.x + 1, (int)this.transform.position.y];
                    }
                    catch
                    {

                    }
                    Debug.Log(this.transform.parent.transform.localRotation.eulerAngles.z);
                    if (right == 0 || right >= 2)
                        MoveVector = Vector3.right;
                    else
                    {
                        MoveVector = Vector3.zero;
                        Destroy(this.gameObject);
                    }
                }

                else if (this.transform.position == FloorPoint && this.transform.parent.transform.localRotation.eulerAngles.z == 90)
                {
                    int down = -1;

                    try
                    {
                        down = (int)LevelMap[(int)this.transform.position.x, (int)this.transform.position.y - 1];
                    }
                    catch
                    {

                    }

                    if (down == 0 || down >= 2)
                        MoveVector = Vector3.down;
                    else
                    {
                        MoveVector = Vector3.zero;
                        Destroy(this.gameObject);
                    }
                }

                else if (this.transform.position == FloorPoint && this.transform.parent.transform.localRotation.eulerAngles.z == 270)
                {
                    int up = -1;

                    try
                    {
                        up = (int)LevelMap[(int)this.transform.position.x, (int)this.transform.position.y + 1];
                    }
                    catch
                    {

                    }

                    Debug.Log((int)this.transform.position.y + 1);

                    if (up == 0 || up >= 2)
                        MoveVector = Vector3.up;
                    else
                    {
                        MoveVector = Vector3.zero;
                        Destroy(this.gameObject);
                    }
                }
            }

            if (MoveVector == Vector3.up)
            {
                int up = (int)LevelMap[(int)this.transform.position.x, (int)this.transform.position.y + 1];
                if (up == 1)
                {
                    MoveVector = Vector3.zero;
                    Destroy(this.gameObject);
                }
            }


            this.transform.position = Vector3.MoveTowards(this.transform.position, this.transform.position + MoveVector, Speed / 32);
        }
    }
}
