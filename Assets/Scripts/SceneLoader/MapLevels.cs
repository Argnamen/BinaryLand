using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapLevels
{
    public float[,] Levels(int numberLevel)
    {
        switch (numberLevel)
        {
            case 1:
                Player.isInvertMoveY = true;
                return new float[,] {{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
{2,6,10,0,0,0,10,0,13,0,10,0,10,0,0,0,2},
{2,0,10,0,10,0,10,0,13,0,10,0,10,0,10,0,2},
{2,0,10,0,10,0,10,0,12,0,10,0,10,0,10,0,2},
{2,0,10,0,10,0,10,0,13,0,10,0,10,0,10,0,2},
{2,0,10,0,10,0,10,0,12,0,0,0,10,0,10,0,2},
{2,0,10,0,10,0,10,0,13,0,10,0,10,0,10,0,2},
{2,0,10,0,10,0,10,0,12,0,10,0,10,0,10,0,2},
{2,0,10,0,10,0,10,0,12,0,10,0,10,0,10,0,2},
{2,0,10,0,10,0,10,0,3,0,10,0,10,0,10,7,2},
{2,0,0,0,10,0,0,0,13,0,10,0,0,0,10,0,2},
{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2}};
            case 0:
                MirrorPlayer.isInvertMoveX = true;
                return new float[,] {{10,10,10,10,10,10,10,10,10,10,10,10},
{10,10,10,12,0,0,0,10,10,10,10,10},
{10,10,2,12,0,9,0,0,0,10,10,10},
{10,0,0,12,0,0,0,0,0,0,10,10},
{10,6,0,0,0,0,0,9,0,0,10,10},
{10,0,0,13,0,0,0,0,0,0,5,10},
{10,10,2,13,0,0,9,0,0,0,10,10},
{10,10,10,13,0,0,0,0,0,10,10,10},
{10,10,10,10,10,3,10,10,10,10,10,10},
{10,10,10,12,4,0,0,0,0,10,10,10},
{10,10,2,12,0,0,0,9,0,0,10,10},
{10,0,0,12,0,0,0,0,0,0,5,10},
{10,7,0,0,0,0,0,0,0,0,10,10},
{10,0,0,13,0,9,0,9,0,0,10,10},
{10,10,2,13,0,0,0,0,0,10,10,10},
{10,10,10,13,0,0,0,10,10,10,10,10},
{10,10,10,10,10,10,10,10,10,10,10,10}};


            case 2:
                Player.isInvertMoveY = true;
                return new float[,] {
                   {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
{2,0,0,0,1,5,0,0,0,0,13,20,0,0,0,0,2},
{2,0,1,0,1,0,1,11,11,0,12,0,0,1,1,0,2},
{2,0,13,0,10,0,1,0,0,0,1,0,1,0,0,0,2},
{2,6,12,0,10,0,2,0,1,10,10,0,10,0,13,11,2},
{2,11,11,0,10,0,13,0,1,0,0,0,10,0,12,7,2},
{2,0,0,0,10,0,12,0,3,0,10,0,13,0,1,0,2},
{2,0,1,11,11,0,13,0,1,0,10,0,12,0,10,0,2},
{2,0,0,0,0,4,12,0,1,0,1,0,10,0,0,0,2},
{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2}};

            case 3:
                MirrorPlayer.isInvertMoveX = true;
                return new float[,] {{1,1,1,1,1,1,1,1,1,1,1,1},
{1,1,1,1,1,1,1,1,1,1,5,1},
{1,6,0,0,0,1,0,1,0,0,9,1},
{1,1,1,20,0,20,9,20,0,1,0,1},
{1,1,1,1,0,0,0,0,0,1,0,1},
{1,1,1,1,1,1,1,1,9,1,0,1},
{1,0,0,0,9,0,0,0,0,0,0,1},
{1,0,1,1,1,1,0,0,0,1,9,1},
{1,1,1,1,1,1,20,3,20,1,1,1},
{1,1,1,1,1,1,1,0,0,0,9,1},
{1,0,0,0,0,0,1,1,1,1,0,1},
{1,0,20,1,20,0,1,0,9,1,0,1},
{1,0,0,1,0,0,5,1,0,1,0,1},
{1,1,0,1,9,1,1,1,0,20,0,1},
{1,7,0,1,0,0,0,0,9,0,0,1},
{1,1,1,1,1,1,1,1,1,20,0,1},
{1,1,1,1,1,1,1,1,1,1,1,1}};


            case 4:
                MirrorPlayer.isInvertMoveX = true;
                return new float[,]
                {{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
{2,0,1,0,0,14,1,0,13,0,0,13,0,0,0,9,2},
{2,0,0,0,13,0,1,0,12,5,0,12,0,10,10,0,2},
{2,0,1,0,12,0,2,0,13,0,0,12,0,8,10,0,2},
{2,7,1,0,13,0,2,0,12,0,0,1,1,0,1,0,2},
{2,1,1,0,12,0,2,0,3,0,0,10,0,0,1,6,2},
{2,0,0,0,10,0,2,0,13,0,10,0,0,0,1,0,2},
{2,0,10,10,10,0,2,0,12,0,10,0,10,0,10,0,2},
{2,0,0,0,5,0,0,0,12,0,0,0,10,4,0,0,2},
{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2}};

            case 5:
                Player.isInvertMoveY = true;
                return new float[,] {
                    {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
{2,0,10,10,10,10,10,2,2,2,12,0,0,5,12,7,2},
{2,0,10,10,10,0,0,2,2,2,12,0,2,0,12,0,2},
{2,0,10,10,0,0,0,0,2,2,0,0,0,0,12,0,2},
{2,0,10,0,0,0,0,0,2,2,9,11,11,11,12,0,2},
{2,6,0,0,0,0,0,0,2,0,0,0,0,0,0,0,2},
{2,0,0,0,0,0,0,0,3,0,0,9,0,0,0,0,2},
{2,0,10,0,0,0,0,0,2,0,0,11,11,11,13,0,2},
{2,0,10,10,0,0,0,0,2,0,0,0,0,0,13,0,2},
{2,0,10,10,10,0,0,2,2,2,13,0,2,0,13,0,2},
{2,0,10,10,10,10,10,2,2,2,13,0,0,8,13,0,2},
{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2}};



        }

        return null;
    }
}
