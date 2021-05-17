/***
 * GameHandler.cs 
 * Made by Tsogtbayar
 * 2021/05/17
 * 
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public GameObject objCube;
    public bool bPause = false;
    public Transform[] transPoints;
    public float fCubeWaitTime = 3f;
    public float fCubeSpeed = 1f;
    List<CubeUnit> listCubeUnit = new List<CubeUnit>();

    public static GameHandler handler;
    public static GameHandler Instance()
    {
        if (handler == null)
        {
            handler = FindObjectOfType<GameHandler>();
        }
        return handler;
    }

    private void Update()
    {
        if (Input.GetKeyDown("c")) SpawnCube();
        if (Input.GetKeyDown("p"))
        {
            if (bPause) 
                bPause = false;
            else 
                bPause = true;
        } 
    }

    //Spawns the cube object when click the spawn button
    public void SpawnCube ()
    {
        if (bPause) return;
        GameObject cube = Instantiate(objCube, transPoints[0].transform.position, Quaternion.identity) as GameObject;
        CubeUnit cubeUnit = cube.GetComponent<CubeUnit>();
        cubeUnit.InitCube(this, transPoints, fCubeWaitTime, fCubeSpeed);
        listCubeUnit.Add(cubeUnit);
    }

    //Pause all cube movement
    public void PauseGame()
    {
        bPause = true;
    }

    //Resume the movements
    public void ResumeGame()
    {
        bPause = false;
    }
}
