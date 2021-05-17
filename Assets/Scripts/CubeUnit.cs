/***
 * CubeUnit.cs for cube prefab
 * Made by Tsogtbayar
 * 2021/05/17
 * 
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeUnit : MonoBehaviour
{
    public GameHandler gameHandler;
    Transform[] transPoints;
    float fWaitTime = 0;
    float fSpeed = 0;
    float fTimeCounter = 0;
    float fTimeMove = 0;
    bool bMoveForward = true;
    bool bPaused = false;
    int currentPointIndex = 0;

    //initialize the cube object 
    public void InitCube(GameHandler handler, Transform[] points, float waitTime, float speed)
    {
        transPoints = points;
        fWaitTime = waitTime;
        fSpeed = speed;
        gameHandler = handler;
        MoveCube();

    }

    //Moves the cube from current to next target position
    void MoveCube()
    {
        fTimeCounter = 0;

        if (bMoveForward)
        {
            if (currentPointIndex < (transPoints.Length - 1))
                fTimeMove = Vector3.Distance(transPoints[currentPointIndex].position, transPoints[currentPointIndex + 1].position) / fSpeed;
            else 
            {
                fTimeMove = Vector3.Distance(transPoints[currentPointIndex].position, transPoints[currentPointIndex - 1].position) / fSpeed;
            }
        } else
        {
            if (currentPointIndex > 0)
                fTimeMove = Vector3.Distance(transPoints[currentPointIndex].position, transPoints[currentPointIndex - 1].position) / fSpeed;
            else 
            {
                fTimeMove = Vector3.Distance(transPoints[currentPointIndex].position, transPoints[currentPointIndex + 1].position) / fSpeed;
            }
        }
        StartCoroutine(MoveToNext());
    }

    //Moves the cube based on time ticks and delays
    IEnumerator MoveToNext()
    {
        while (true)
        {
            if (gameHandler.bPause == false)
            {
                fTimeCounter += Time.deltaTime;
                if (fTimeCounter < fTimeMove)
                {
                    if (bMoveForward)
                        transform.position = Vector3.Lerp(transPoints[currentPointIndex].position, transPoints[currentPointIndex + 1].position, fTimeCounter / fTimeMove);
                    else
                        transform.position = Vector3.Lerp(transPoints[currentPointIndex].position, transPoints[currentPointIndex - 1].position, fTimeCounter / fTimeMove);
                }
                else
                {
                    if (bMoveForward)
                    {
                        if (currentPointIndex == (transPoints.Length - 2))
                        {
                            bMoveForward = false;
                            currentPointIndex = transPoints.Length - 1;
                            MoveCube();
                            break;

                        } else
                        {
                            yield return new WaitForSeconds(fWaitTime);
                            currentPointIndex++;
                            MoveCube();
                            break;
                        }
                    } else
                    {
                        if (currentPointIndex == 1)
                        {
                            bMoveForward = true;
                            currentPointIndex = 0;
                            MoveCube();
                            break;

                        }
                        else
                        {
                            yield return new WaitForSeconds(fWaitTime);
                            currentPointIndex--;
                            MoveCube();
                            break;
                        }
                    }
                }
                yield return null;
            }
            else
            {
                yield return null;
            }
        }
        
    }
}
