using System.Collections.Generic;
using System;
using UnityEngine;

public class Mob : MonoBehaviour
{
    private MobNavigationMap navigationMap = new MobNavigationMap();

    private bool isCoroutineStop = true;

    private int BearHeals = 2;

    public static float Speed = 1f;

    private Vector3 MoveVector = Vector3.up;

    private int[,] LevelMap;

    private Vector3 oldMoveVector;

    private bool isLife = true;

    private int pointMove = 0;

    private bool MoveStart = true;

    private void Move()
    {
        if (MoveStart)
        {
            ++pointMove;
        }
        else
        {
            --pointMove;
        }

        if(pointMove == 0)
        {
            MoveStart = true;
            Move();
        }

        int right = LevelMap[(int)this.transform.position.x + 1, (int)this.transform.position.y];
        int left = LevelMap[(int)this.transform.position.x - 1, (int)this.transform.position.y];
        int up = LevelMap[(int)this.transform.position.x, (int)this.transform.position.y + 1];
        int down = LevelMap[(int)this.transform.position.x, (int)this.transform.position.y - 1];

        //Debug.Log("Right " + right);
        //Debug.Log("Left " + left);
        //Debug.Log("Up " + up);
        //Debug.Log("Down " + down);

        oldMoveVector = MoveVector;

        if (pointMove == right)
        {
            MoveVector = Vector3.right;
        }
        else if (pointMove == left)
        {
            MoveVector = Vector3.left;
        }
        else if (pointMove == up)
        {
            MoveVector = Vector3.up;
        }
        else if (pointMove == down)
        {
            MoveVector = Vector3.down;
        }
        else
        {
            List<int> list = new List<int>(4) { right, left, up, down };

            list.Sort();

            for(int i = 0; i < list.Count; i++)
            {
                if(list[i] != 0)
                {
                    if (MoveStart)
                    {
                        MoveStart = false;

                        pointMove = list[i] + 1;
                    }
                    else
                    {
                        MoveStart = true;

                        pointMove = list[i] - 1;

                    }
                    break;
                }
            }

            //Debug.Log(MoveStart);
            Move();
        }
        
    }

    private void Start()
    {
        //LevelMap = SceneLoader.navigationMap;
        LevelMap = navigationMap.Levels(PlayerPrefs.GetInt("Level"));
    }

    private void FixedUpdate()
    {
        if (PlayerMoving.isStartGame && isLife)
        {
            Vector3 mobFloorPoint = new Vector3(
            Int32.Parse(Mathf.FloorToInt(this.transform.position.x).ToString()),
            Int32.Parse(Mathf.FloorToInt(this.transform.position.y).ToString()),
            this.transform.position.z);

            int idle = LevelMap[(int)(mobFloorPoint.x + MoveVector.x), (int)(mobFloorPoint.y + MoveVector.y)];

            //if (this.transform.position == mobFloorPoint && (idle != 0f && idle != 3 && idle != 4))
            //{
            //Move();
            //}

            //Debug.Log(idle + " " + (pointMove));

            if (this.transform.position == mobFloorPoint && (idle == 0))
            {
                Move();
            }

            if (MoveVector == Vector3.left)
                this.gameObject.GetComponent<Animator>().Play("Left");
            if (MoveVector == Vector3.right)
                this.gameObject.GetComponent<Animator>().Play("Right");
            if (MoveVector == Vector3.up)
                this.gameObject.GetComponent<Animator>().Play("Up");
            if (MoveVector == Vector3.down)
                this.gameObject.GetComponent<Animator>().Play("Down");

            

            this.transform.position = Vector3.MoveTowards(this.transform.position, this.transform.position + MoveVector, Speed / 32);
        }
    }
}
