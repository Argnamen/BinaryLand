using System.Collections;
using System;
using UnityEngine;

public class Mob : MonoBehaviour
{
    private bool isCoroutineStop = true;

    public static float Speed = 1f;

    private Vector3 MoveVector = Vector3.up;

    public static int[,] LevelMap;

    private Vector3 oldMoveVector;


    private void Move()
    {
        int right = LevelMap[(int)this.transform.position.x + 1, (int)this.transform.position.y];
        int left = LevelMap[(int)this.transform.position.x - 1, (int)this.transform.position.y];
        int up = LevelMap[(int)this.transform.position.x, (int)this.transform.position.y + 1];
        int down = LevelMap[(int)this.transform.position.x, (int)this.transform.position.y - 1];

        oldMoveVector = MoveVector;

        switch (UnityEngine.Random.Range(0, 4))
        {
            case 0:
                if (right == 0 || right == 3 || right == 4)
                    MoveVector = Vector3.right;
                else if (left == 0 || left == 3 || left == 4)
                    MoveVector = Vector3.left;
                else if (up == 0 || up == 3 || up == 4)
                    MoveVector = Vector3.up;
                else if (down == 0 || down == 3 || down == 4)
                    MoveVector = Vector3.down;
                break;
            case 1:
                if (left == 0 || left == 3 || left == 4)
                    MoveVector = Vector3.left;
                else if (right == 0 || right == 3 || right == 4)
                    MoveVector = Vector3.right;
                else if (up == 0 || up == 3 || up == 4)
                    MoveVector = Vector3.up;
                else if (down == 0 || down == 3 || down == 4)
                    MoveVector = Vector3.down;
                break;
            case 2:
                if (up == 0 || up == 3 || up == 4)
                    MoveVector = Vector3.up;
                else if (left == 0 || left == 3 || left == 4)
                    MoveVector = Vector3.left;
                else if (right == 0 || right == 3 || right == 4)
                    MoveVector = Vector3.right;
                else if (down == 0 || down == 3 || down == 4)
                    MoveVector = Vector3.down;
                break;
            case 3:
                if (down == 0 || down == 3 || down == 4)
                    MoveVector = Vector3.down;
                else if (up == 0 || up == 3 || up == 4)
                    MoveVector = Vector3.up;
                else if (left == 0 || left == 3 || left == 4)
                    MoveVector = Vector3.left;
                else if (right == 0 || right == 3 || right == 4)
                    MoveVector = Vector3.right;
                break;
        }
    }

    private void Start()
    {
        LevelMap = SceneLoader.navigationMap;
    }
    private void FixedUpdate()
    {
        if (PlayerMoving.isStartGame)
        {
            Vector3 mobFloorPoint = new Vector3(
            Int32.Parse(Mathf.FloorToInt(this.transform.position.x).ToString()),
            Int32.Parse(Mathf.FloorToInt(this.transform.position.y).ToString()),
            this.transform.position.z);

            int idle = LevelMap[(int)(mobFloorPoint.x + MoveVector.x), (int)(mobFloorPoint.y + MoveVector.y)];

            if (this.transform.position == mobFloorPoint && (idle != 0f && idle != 3 && idle != 4))
            {
                Move();

                if (MoveVector == Vector3.left)
                    this.gameObject.GetComponent<Animator>().Play("Left");
                if (MoveVector == Vector3.right)
                    this.gameObject.GetComponent<Animator>().Play("Right");
            }

            if (LevelMap[(int)(mobFloorPoint.x + oldMoveVector.x), (int)(mobFloorPoint.y + oldMoveVector.y)] == 3)
                LevelMap[(int)(mobFloorPoint.x + oldMoveVector.x), (int)(mobFloorPoint.y + oldMoveVector.y)] = 3;
            else if (LevelMap[(int)(mobFloorPoint.x + oldMoveVector.x), (int)(mobFloorPoint.y + oldMoveVector.y)] == 2)
                LevelMap[(int)(mobFloorPoint.x + oldMoveVector.x), (int)(mobFloorPoint.y + oldMoveVector.y)] = 2;
            else if (LevelMap[(int)(mobFloorPoint.x + oldMoveVector.x), (int)(mobFloorPoint.y + oldMoveVector.y)] == 4)
                LevelMap[(int)(mobFloorPoint.x + oldMoveVector.x), (int)(mobFloorPoint.y + oldMoveVector.y)] = 0;

            if (this.transform.position == mobFloorPoint && idle != 3)
                LevelMap[(int)(mobFloorPoint.x + MoveVector.x), (int)(mobFloorPoint.y + MoveVector.y)] = 4;

            this.transform.position = Vector3.MoveTowards(this.transform.position, this.transform.position + MoveVector, Speed / 32);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Projectile>())
            Destroy(this.gameObject);
        if ((collision.GetComponent<Player>() || collision.GetComponent<MirrorPlayer>()) && PlayerMoving.isStartGame)
        {
            collision.GetComponent<Animator>().Play("Fail");
            GameManager.LevelStart.Invoke(-1);
            PlayerMoving.isStartGame = false;
        }
    }
}
