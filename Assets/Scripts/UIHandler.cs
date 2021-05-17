/***
 * UIHandler.cs for cube prefab
 * Made by Tsogtbayar
 * 2021/05/17
 * 
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public GameHandler gameHandler;
    public GameObject objPause;
    public Text txt_count;
    
    public void OnClickPauseGame()
    {
        gameHandler.PauseGame();
        objPause.SetActive(true);
    }

    public void OnClickResumeGame()
    {
        gameHandler.ResumeGame();
        objPause.SetActive(false);

    }

    public void OnClickSpawn()
    {
        gameHandler.SpawnCube();
    }

    public void UpdateCountText (int nCount)
    {
        txt_count.text = nCount + "";
    }

}
