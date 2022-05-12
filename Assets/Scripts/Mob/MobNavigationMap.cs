using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobNavigationMap : MonoBehaviour
{
    public int[,] Levels(int numberLevel)
    {
        switch (numberLevel)
        {
            case 0:
                return null;


            case 1:
                return null;

            case 2:
                return new int[,] {
                   {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,3,5,2,2,2,2,2,2,0},
{0,0,0,0,0,0,3,5,0,0,0,0,0,1,0},
{0,0,0,0,0,0,4,4,0,0,0,0,0,1,0},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0} };
        }

        return null;
    }
}
