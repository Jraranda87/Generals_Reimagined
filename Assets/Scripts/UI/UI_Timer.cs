/* -----------------------------------------------------------------------------------
 * Class Name: UI_Timer
 * -----------------------------------------------------------------------------------
 * Author: Joseph Aranda
 * Date: #DATE#
 * Credit: 
 * -----------------------------------------------------------------------------------
 * Purpose: 
 * -----------------------------------------------------------------------------------
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UI_Timer : MonoBehaviour 
{
    #region Variables
    // ------------------------------------------------------------------------------
    // Public Variables
    // ------------------------------------------------------------------------------
    public float playerOneBuildTimer = 180;
    public float playerTwoBuildTimer = 180;

    public float restartTimer = 180;

    public float playerOnePlayTimer = 120;
    public float playerTwoPlayTimer = 120;

    public float playModeRestartTimer = 120;
    // ------------------------------------------------------------------------------
    // Protected Variables
    // ------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------
    // Private Variables
    // ------------------------------------------------------------------------------

    string now;
    bool p1_IsNotFinished = true, p2_IsNotFinished = true, isStopTimer = false;
    GameObject manager;

    #endregion

    #region Getters/Setters
    public bool P1_IsNotYetFinished
    {
        get {return p1_IsNotFinished; }
        set {  p1_IsNotFinished = value; }
    }
    public bool P2_IsNotYetFinished
    {
        get { return p2_IsNotFinished; }
        set { p2_IsNotFinished = value; }
    }
    public bool IsStopTimer
    {
        get { return isStopTimer; }
        set { isStopTimer = value; }
    }
    #endregion

    #region Constructors



    #endregion

    // ------------------------------------------------------------------------------
    // FUNCTIONS
    // ------------------------------------------------------------------------------
    void Start()
    {
        manager = WLD_GameController.managers;
    }
    void Update()
    {
     
        BuildMode_CurrentTimeUI();
    }
    // ------------------------------------------------------------------------------
    // Function Name: 
    // Return types: 
    // Argument types: 
    // Author: 
    // Date: 
    // ------------------------------------------------------------------------------
    // Purpose: 
    // ------------------------------------------------------------------------------
    public void ResetTimer()
    {
        isStopTimer = false;

        playerOneBuildTimer = restartTimer;
        playerTwoBuildTimer = restartTimer;

        float p1_minutes = Mathf.Floor(playerOneBuildTimer / 60);
        float p1_seconds = (playerOneBuildTimer % 60);

        now = string.Format("{0:00}:{1:00}", p1_minutes, p1_seconds);

        float p2_minutes = Mathf.Floor(playerTwoBuildTimer / 60);
        float p2_seconds = (playerTwoBuildTimer % 60);

        now = string.Format("{0:00}:{1:00}", p2_minutes, p2_seconds);

        WLD_GameController.UI_Text[NonGamePieces.PlayerOneTimerText].enabled = true;
        WLD_GameController.UI_Text[NonGamePieces.PlayerTwoTimerText].enabled = false;
    }
    // ------------------------------------------------------------------------------
    // Function Name: 
    // Return types: 
    // Argument types: 
    // Author: 
    // Date: 
    // ------------------------------------------------------------------------------
    // Purpose: 
    // ------------------------------------------------------------------------------
    void BuildMode_CurrentTimeUI()
    {
        if (manager.GetComponent<WLD_BuildManager>().IsBuildMode)
        {
            if (manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
            {                         
                if (!isStopTimer)
                {
                    if (playerOneBuildTimer >= 0)
                    {
                        playerOneBuildTimer -= Time.deltaTime;
                    }

                    float minutes = Mathf.Floor(playerOneBuildTimer / 60);
                    float seconds = (playerOneBuildTimer % 60);

                    now = string.Format("{0:00}:{1:00}", minutes, seconds);
                }
             
                WLD_GameController.UI_Text[NonGamePieces.PlayerOneTimerText].text = now;

               
                if (playerOneBuildTimer <= 0 && manager.GetComponent<WLD_BuildManager>().P1_TotalInventory >= 0)
                {
                    p1_IsNotFinished = true;

                    manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn = true;
                    manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn = false;

                    playerOneBuildTimer = restartTimer;
                }
                else if (manager.GetComponent<WLD_BuildManager>().P1_TotalInventory <= 0)
                {
                    p1_IsNotFinished = false;
                    isStopTimer = true;
                }

                WLD_GameController.UI_Text[NonGamePieces.PlayerOneTimerText].enabled = true;
                WLD_GameController.UI_Text[NonGamePieces.PlayerTwoTimerText].enabled = false;

            }
            else if (manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn)
            {           
                if (!isStopTimer)
                {
                    Debug.Log("1a");
                    if (playerTwoBuildTimer >= 0)
                    {
                        Debug.Log("2a");
                        playerTwoBuildTimer -= Time.deltaTime;
                    }

                    float minutes = Mathf.Floor(playerTwoBuildTimer / 60);
                    float seconds = (playerTwoBuildTimer % 60);

                    now = string.Format("{0:00}:{1:00}", minutes, seconds);
                }

                WLD_GameController.UI_Text[NonGamePieces.PlayerTwoTimerText].text = now;
            
                if (playerTwoBuildTimer <= 0 && manager.GetComponent<WLD_BuildManager>().P2_TotalInventory >= 0 )
                {
                    p2_IsNotFinished = true;

                    playerTwoBuildTimer = restartTimer;

                    if (p1_IsNotFinished)
                    {
                        manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn = true;
                        manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn = false;
                    }
                }
                else if (manager.GetComponent<WLD_BuildManager>().P2_TotalInventory <= 0)
                {
                    p2_IsNotFinished = false;
                    isStopTimer = true;
                }

                WLD_GameController.UI_Text[NonGamePieces.PlayerTwoTimerText].enabled = true;
                WLD_GameController.UI_Text[NonGamePieces.PlayerOneTimerText].enabled = false;
            }
        }
       
    }

    // ------------------------------------------------------------------------------
    // Function Name: 
    // Return types: 
    // Argument types: 
    // Author: 
    // Date: 
    // ------------------------------------------------------------------------------
    // Purpose: 
    // ------------------------------------------------------------------------------
    void PlayMode_PlayTimer()
    {
        if (WLD_BuildManager.isPlaceMode)
        {
            if (manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
            {

            }
            else if (manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn)
            {

            }
        }
    }
} // End UI_Timer