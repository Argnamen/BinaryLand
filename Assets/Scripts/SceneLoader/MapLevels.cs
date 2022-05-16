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
            case 0:
                MirrorPlayer.isInvertMoveX = true;
                return new float[,] {{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10},
{10,0,0,0,1,0,0,0,0,0,0,0,0,1,10},
{10,0,1,0,1,0,1,0,1,1,0,1,0,0,10},
{10,0,1,0,0,0,1,0,0,1,0,1,0,1,10},
{10,6,1,0,1,0,0,0,0,1,0,1,0,0,10},
{10,1,1,1,1,1,1,1,1,1,1,1,1,3,10},
{10,7,1,0,0,0,0,0,1,0,0,0,0,0,10},
{10,0,1,0,1,0,1,0,1,1,0,1,0,1,10},
{10,0,1,0,0,0,1,0,0,1,0,1,0,0,10},
{10,0,1,0,1,0,1,0,1,1,0,1,0,0,10},
{10,0,0,0,1,0,0,0,0,0,0,1,0,1,10},
{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10}};


            case 1:
                MirrorPlayer.isInvertMoveX = true;
                return new float[,] {{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10},
{10,0,1,0,1,0,0,0,0,0,0,1,1,0,10},
{10,0,0,0,1,0,0,1,0,1,0,0,0,0,10},
{10,1,1,0,0,0,1,1,0,1,1,0,1,0,10},
{10,6,0,0,1,0,0,1,0,0,0,0,1,0,10},
{10,1,1,1,1,1,1,1,1,1,1,1,1,3,10},
{10,7,1,0,0,0,0,1,0,1,0,0,1,0,10},
{10,0,0,0,1,1,0,1,0,1,0,1,1,0,10},
{10,0,1,0,1,0,0,0,0,0,0,1,0,0,10},
{10,0,0,0,1,1,0,1,0,1,1,1,1,0,10},
{10,0,1,0,0,0,0,1,0,0,0,0,0,0,10},
{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10}};

            case 2:
                MirrorPlayer.isInvertMoveX = true;
                return new float[,] {
                   {10,10,10,10,10,10,10,10,10,10,10,10,10,10,10},
{10,0,0,0,0,0,0,0,1,0,0,0,0,0,10},
{10,0,1,0,1,0,1,1,1,1,1,1,1,0,10},
{10,1,1,1,1,0,0,0,0,0,0,0,1,0,10},
{10,6,0,0,0,0,1,0,1,0,1,0,0,0,10},
{10,1,1,1,1,1,1,1,1,1,1,1,1,3,10},
{10,7,1,0,0,0,14,1,0,0,0,1,0,0,10},
{10,0,0,0,0,0,0,1,0,1,1,1,1,0,10},
{10,0,1,1,1,1,0,0,0,0,0,0,0,0,10},
{10,0,0,0,0,1,0,0,1,0,1,1,1,0,10},
{10,1,1,1,1,1,0,0,1,0,0,0,1,5,10},
{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10}};

            case 3:
                MirrorPlayer.isInvertMoveX = true;
                return new float[,] {{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10},
{10,0,1,0,1,0,0,0,0,0,0,1,1,0,10},
{10,0,0,0,1,0,0,1,0,1,0,0,0,0,10},
{10,1,1,0,0,0,1,1,0,1,1,0,1,0,10},
{10,6,0,0,1,0,0,1,0,0,0,0,1,0,10},
{10,1,1,1,1,1,1,1,1,1,1,1,1,3,10},
{10,7,1,0,0,0,0,1,0,1,0,0,1,0,10},
{10,0,0,0,1,1,0,1,0,1,0,1,1,0,10},
{10,0,1,0,1,0,0,0,0,0,0,1,0,0,10},
{10,0,0,0,1,1,0,1,0,1,1,1,1,0,10},
{10,0,1,0,0,0,0,1,0,0,0,0,0,0,10},
{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10}};


            case 4:
                MirrorPlayer.isInvertMoveX = true;
                return new float[,] {{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10},
{10,0,0,0,0,0,0,0,1,0,0,0,0,0,10},
{10,0,1,0,1,0,1,1,1,1,1,1,1,0,10},
{10,1,1,1,1,0,0,0,0,0,0,0,1,0,10},
{10,6,0,0,0,0,1,0,1,0,1,0,0,0,10},
{10,1,1,1,1,1,1,1,1,1,1,1,1,3,10},
{10,7,1,0,0,0,14,1,0,0,0,1,0,0,10},
{10,0,0,0,0,0,0,1,0,1,1,1,1,0,10},
{10,0,1,1,1,1,0,0,0,0,0,0,0,0,10},
{10,0,0,0,0,1,0,0,1,0,1,1,1,0,10},
{10,1,1,1,1,1,0,0,1,0,0,0,1,5,10},
{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10}};

            case 5:
                MirrorPlayer.isInvertMoveX = true;
                return new float[,] {
                    {10,10,10,10,10,10,10,10,10,10,10,10,10,10,10},
{10,0,1,0,0,0,1,0,0,1,0,0,1,8,10},
{10,0,1,0,1,0,1,0,0,1,0,1,1,0,10},
{10,0,1,0,0,0,1,0,1,1,0,0,0,0,10},
{10,0,1,0,1,0,1,0,0,0,9,1,1,0,10},
{10,6,0,0,1,0,0,0,0,0,4,0,1,0,10},
{10,1,1,1,1,1,1,1,1,1,1,1,1,3,10},
{10,7,0,0,0,0,1,0,1,0,1,0,1,0,10},
{10,1,1,1,1,0,0,0,1,0,0,0,0,0,10},
{10,0,0,0,1,0,1,0,15,0,1,1,1,1,10},
{10,0,1,0,0,0,1,0,1,0,0,0,0,5,10},
{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10}};

            case 6:
                MirrorPlayer.isInvertMoveX = true;
                return new float[,] {{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10},
{10,0,1,0,1,0,1,0,0,0,0,0,1,0,10},
{10,0,1,0,0,0,1,0,1,1,1,0,0,0,10},
{10,0,1,0,1,0,0,0,1,0,1,0,1,1,10},
{10,6,0,0,1,0,1,1,1,0,0,0,0,0,10},
{10,1,1,1,1,1,1,1,1,1,1,1,1,3,10},
{10,7,0,0,1,0,0,1,0,0,0,1,0,0,10},
{10,0,1,1,1,0,1,1,0,1,0,1,1,0,10},
{10,0,1,0,0,0,0,0,0,1,0,0,0,0,10},
{10,0,0,0,1,1,1,1,0,0,0,1,1,1,10},
{10,0,1,0,0,0,0,1,0,1,0,0,0,0,10},
{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10}};

            case 7:
                MirrorPlayer.isInvertMoveX = true;
                return new float[,] {{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10},
{10,0,0,0,0,0,0,0,0,0,0,14,0,0,10},
{10,0,1,1,1,1,1,1,1,1,1,0,1,1,10},
{10,5,0,0,0,0,0,0,0,0,1,0,0,8,10},
{10,1,1,1,1,1,1,1,1,0,1,0,1,1,10},
{10,6,0,0,0,0,0,0,0,4,1,0,0,0,10},
{10,1,1,1,1,1,1,1,1,1,1,1,1,3,10},
{10,7,1,0,0,0,1,0,0,0,0,1,0,0,10},
{10,0,1,0,1,0,9,0,1,1,0,1,0,1,10},
{10,0,0,0,1,0,1,0,1,15,0,0,0,0,10},
{10,0,1,0,0,0,1,0,1,1,0,1,0,1,10},
{10,0,1,0,1,0,1,5,9,0,0,1,8,0,10},
{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10}};
            case 8:
                MirrorPlayer.isInvertMoveX = true;
                return new float[,] {{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10},
{10,0,0,0,0,0,0,0,0,0,0,14,0,0,10},
{10,0,1,1,1,1,1,1,1,1,1,0,1,1,10},
{10,5,0,0,0,0,0,0,0,0,1,0,0,8,10},
{10,1,1,1,1,1,1,1,1,0,1,0,1,1,10},
{10,6,0,0,0,0,0,0,0,4,1,0,0,0,10},
{10,1,1,1,1,1,1,1,1,1,1,1,1,3,10},
{10,7,1,0,0,0,1,0,0,0,0,1,0,0,10},
{10,0,1,0,1,0,9,0,1,1,0,1,0,1,10},
{10,0,0,0,1,0,1,0,1,15,0,0,0,0,10},
{10,0,1,0,0,0,1,0,1,1,0,1,0,1,10},
{10,0,1,0,1,0,1,5,9,0,0,1,8,0,10},
{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10}};

            case 9:
                MirrorPlayer.isInvertMoveX = true;
                return new float[,] {{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10},
{10,0,0,0,1,5,1,0,0,0,0,0,0,8,10},
{10,0,1,0,1,0,1,0,1,1,1,0,1,1,10},
{10,6,1,15,0,0,0,4,0,0,1,0,0,0,10},
{10,1,1,1,1,1,1,1,1,1,1,1,1,3,10},
{10,0,0,0,0,0,0,0,9,0,1,0,1,0,10},
{10,1,1,1,1,1,1,1,0,0,0,8,1,0,10},
{10,0,0,0,0,0,0,0,9,0,1,0,1,0,10},
{10,0,1,1,1,1,1,1,1,1,1,0,1,0,10},
{10,5,0,0,0,0,0,0,0,0,1,0,0,0,10},
{10,1,1,1,1,1,1,1,9,9,1,0,1,1,10},
{10,7,0,0,0,0,0,0,0,0,1,0,0,0,10},
{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10}};

            case 10:
                MirrorPlayer.isInvertMoveX = true;
                return new float[,] {
                    {10,10,10,10,10,10,10,10,10,10,10,10,10,10,10},
{10,0,1,5,1,0,1,8,0,0,1,5,0,0,10},
{10,0,9,0,1,0,0,0,1,0,1,1,1,4,10},
{10,0,1,0,9,0,1,0,1,0,0,0,0,0,10},
{10,6,1,0,1,0,1,4,0,0,1,0,1,0,10},
{10,1,1,1,1,1,1,1,1,1,1,1,1,3,10},
{10,7,0,0,0,0,0,16,1,8,0,1,0,0,10},
{10,1,1,0,1,0,1,1,1,0,0,1,0,0,10},
{10,0,1,14,1,5,0,0,9,0,1,1,0,1,10},
{10,0,0,0,1,1,1,1,1,0,9,0,0,0,10},
{10,0,1,0,0,0,0,5,1,0,1,1,0,1,10},
{10,0,1,0,1,1,1,1,1,0,0,1,0,0,10},
{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10}};


            case 11:
                MirrorPlayer.isInvertMoveX = true;
                return new float[,] {
                    {10,10,10,10,10,10,10,10,10,10,10,10,10,10,10},
{10,0,1,0,0,16,1,8,0,0,0,0,0,0,10},
{10,0,1,0,1,1,1,9,1,1,1,9,1,1,10},
{10,0,0,0,0,0,0,0,0,0,1,0,0,0,10},
{10,0,1,0,1,1,1,0,1,1,1,0,1,0,10},
{10,6,1,5,0,16,1,0,0,0,0,4,1,0,10},
{10,1,1,1,1,1,1,1,1,1,1,1,1,3,10},
{10,7,0,0,0,0,0,0,0,0,0,1,0,0,10},
{10,1,1,0,1,1,1,1,9,9,1,1,0,9,10},
{10,1,0,0,1,8,0,0,0,0,0,9,0,1,10},
{10,1,1,9,1,1,9,9,1,1,1,1,0,0,10},
{10,8,0,0,0,0,0,0,0,0,0,1,5,1,10},
{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10}};

            case 12:
                MirrorPlayer.isInvertMoveX = true;
                return new float[,] {{ 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 },
{ 10,0,1,0,0,0,1,0,0,5,1,0,0,0,10},
{ 10,0,1,0,1,0,1,0,1,1,1,0,1,0,10},
{ 10,6,0,0,1,15,0,0,0,0,0,0,1,0,10},
{ 10,1,1,1,1,1,1,1,1,1,1,1,1,3,10},
{ 10,7,0,0,15,0,0,0,0,0,0,0,8,0,10},
{ 10,1,1,1,1,0,1,1,1,1,1,1,1,14,10},
{ 10,0,0,0,0,0,1,0,0,0,0,0,0,8,10},
{ 10,0,1,1,1,1,1,14,1,1,1,1,1,1,10},
{ 10,0,0,0,0,14,1,0,0,0,0,0,0,5,10},
{ 10,1,1,1,1,0,1,1,1,1,1,1,1,0,10},
{ 10,0,0,0,0,5,1,0,0,0,0,0,0,0,10},
{ 10,10,10,10,10,10,10,10,10,10,10,10,10,10,10}
        };

            case 13:
                MirrorPlayer.isInvertMoveX = true;
                return new float[,] {{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10},
{10,0,1,0,1,5,1,0,0,0,8,9,1,0,10},
{10,0,1,0,1,0,9,0,1,1,0,1,1,0,10},
{10,0,0,0,1,0,1,0,1,15,0,0,0,0,10},
{10,0,1,0,1,0,1,0,1,1,0,1,1,0,10},
{10,7,1,15,0,0,1,0,0,0,0,9,1,0,10},
{10,1,1,1,1,1,1,1,1,1,1,1,1,3,10},
{10,6,1,0,9,0,1,0,0,0,0,0,1,0,10},
{10,0,1,0,1,0,1,0,1,1,1,0,1,0,10},
{10,0,1,0,9,0,1,0,0,8,1,0,0,0,10},
{10,0,0,0,1,0,0,9,9,1,1,1,1,14,10},
{10,0,1,0,1,5,1,0,0,1,5,0,0,0,10},
{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10}};

            case 14:
                MirrorPlayer.isInvertMoveX = true;
                return new float[,] {{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10},
{10,5,0,0,0,0,1,0,1,0,0,0,1,0,10},
{10,1,1,1,1,0,1,0,1,0,1,0,9,0,10},
{10,0,0,0,0,0,1,0,9,0,1,0,1,0,10},
{10,4,1,1,1,1,1,0,1,0,1,0,1,0,10},
{10,6,0,0,0,0,0,0,1,0,1,8,1,0,10},
{10,1,1,1,1,1,1,1,1,1,1,1,1,3,10},
{10,7,1,0,0,0,8,1,0,0,0,1,0,5,10},
{10,0,1,0,1,1,1,1,0,1,0,1,1,0,10},
{10,0,1,0,0,16,0,0,0,1,0,0,1,0,10},
{10,0,1,0,1,1,1,1,0,1,0,1,1,0,10},
{10,0,0,0,0,0,0,1,0,1,0,0,0,0,10},
{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10}};

            case 15:
                MirrorPlayer.isInvertMoveX = true;
                return null;

            case 16:
                MirrorPlayer.isInvertMoveX = true;
                return new float[,] {{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10},
{10,0,0,0,1,0,0,5,1,0,0,0,0,0,10},
{10,0,1,0,1,0,1,0,1,1,1,1,0,1,10},
{10,0,1,0,0,0,1,0,0,0,0,1,0,0,10},
{10,0,1,0,1,1,1,0,1,1,1,1,0,1,10},
{10,7,1,0,0,8,1,0,0,0,0,0,8,0,10},
{10,1,1,1,1,1,1,1,1,1,1,1,1,3,10},
{10,6,1,0,0,0,0,0,5,1,0,8,1,0,10},
{10,0,1,9,1,9,1,0,0,1,0,1,1,0,10},
{10,0,0,0,1,0,1,1,1,1,0,0,0,0,10},
{10,0,1,0,1,0,0,1,0,1,0,1,1,1,10},
{10,15,0,0,0,0,0,0,0,0,0,0,0,0,10},
{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10}};

            case 17:
                MirrorPlayer.isInvertMoveX = true;
                return new float[,] {{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10},
{10,0,9,0,1,8,0,1,0,0,0,1,9,0,10},
{10,0,1,0,1,1,0,1,0,1,0,1,1,0,10},
{10,0,1,0,9,1,0,1,0,1,0,1,9,0,10},
{10,0,1,0,1,1,0,1,0,1,0,1,1,0,10},
{10,6,1,0,0,0,0,9,5,1,0,0,0,0,10},
{10,1,1,1,1,1,1,1,1,1,1,1,1,3,10},
{10,7,0,0,9,0,1,5,1,0,0,0,0,0,10},
{10,0,1,1,1,0,1,0,1,1,1,1,1,0,10},
{10,0,0,0,1,0,1,15,0,0,0,0,0,0,10},
{10,1,1,1,1,0,9,0,1,0,1,1,1,1,10},
{10,0,0,0,0,0,1,0,1,0,0,0,8,1,10},
{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10}};

            case 18:
                MirrorPlayer.isInvertMoveX = true;
                return new float[,] {{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10},
{10,15,0,0,0,0,0,0,0,0,0,1,0,0,10},
{10,0,1,1,1,1,1,1,0,1,0,1,0,1,10},
{10,5,0,0,0,0,0,1,0,1,8,1,0,0,10},
{10,9,1,1,1,1,0,1,0,1,1,1,0,1,10},
{10,6,0,0,0,9,0,1,0,0,0,0,0,0,10},
{10,1,1,1,1,1,1,1,1,1,1,1,1,3,10},
{10,7,0,0,0,0,0,1,0,0,0,8,1,0,10},
{10,0,1,1,1,1,1,1,0,1,1,1,1,0,10},
{10,14,0,0,1,15,0,0,0,0,1,0,0,0,10},
{10,0,1,1,1,0,1,1,1,15,0,0,1,1,10},
{10,0,0,0,0,0,0,5,1,0,1,0,0,5,10},
{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10}};

            case 19:
                MirrorPlayer.isInvertMoveX = true;
                return new float[,] {{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10},
{10,0,1,0,0,0,1,0,0,1,0,1,0,0,10},
{10,0,1,0,1,0,1,0,0,1,0,1,0,1,10},
{10,0,1,0,0,0,1,0,1,1,0,1,0,0,10},
{10,0,1,0,1,0,1,0,0,0,0,1,0,1,10},
{10,6,0,0,1,0,0,0,0,1,0,0,0,0,10},
{10,1,1,1,1,1,1,1,1,1,1,1,1,3,10},
{10,7,1,8,1,0,1,5,1,0,1,0,0,0,10},
{10,0,1,0,1,0,1,0,0,0,0,0,1,1,10},
{10,0,15,0,1,0,0,0,1,1,1,0,0,1,10},
{10,0,1,0,1,0,1,0,1,0,0,0,1,1,10},
{10,0,1,0,0,0,1,0,1,1,1,0,0,8,10},
{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10}};

            case 20:
                MirrorPlayer.isInvertMoveX = true;
                return new float[,] {{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10},
{10,0,0,0,0,0,0,0,0,0,0,0,0,0,10},
{10,0,0,1,0,1,1,1,1,1,1,1,14,1,10},
{10,0,1,1,0,0,0,0,1,0,0,0,0,8,10},
{10,0,0,1,0,1,1,1,1,0,1,1,1,1,10},
{10,7,1,1,0,0,0,5,1,0,0,0,0,0,10},
{10,1,1,1,1,1,1,1,1,1,1,1,1,3,10},
{10,6,1,0,0,0,8,1,0,1,0,0,0,0,10},
{10,0,1,0,1,1,1,1,0,1,0,1,1,0,10},
{10,0,1,0,0,0,0,0,0,9,0,1,0,0,10},
{10,0,1,0,1,1,1,0,1,1,0,1,1,0,10},
{10,0,0,0,0,0,1,0,1,0,9,0,0,5,10},
{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10}};

            case 21:
                MirrorPlayer.isInvertMoveX = true;
                return new float[,] {{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10},
{10,0,0,0,0,0,0,0,0,1,0,0,0,0,10},
{10,1,1,1,1,1,1,1,0,1,0,1,1,1,10},
{10,0,0,0,0,0,0,0,0,0,0,0,0,0,10},
{10,7,1,1,1,1,1,1,1,1,0,1,0,0,10},
{10,1,1,1,1,1,1,1,1,1,1,1,1,3,10},
{10,6,1,0,0,0,0,0,8,1,5,1,0,0,10},
{10,0,1,1,0,1,1,1,1,1,0,1,0,0,10},
{10,0,0,1,0,15,0,0,0,0,0,1,1,0,10},
{10,0,1,1,0,1,1,1,1,1,0,0,0,0,10},
{10,15,0,0,0,0,0,1,0,1,1,1,14,1,10},
{10,0,0,1,0,1,1,1,0,0,0,0,0,8,10},
{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10}};

        }



        return null;
    }
}
