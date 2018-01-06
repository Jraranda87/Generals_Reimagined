/* -----------------------------------------------------------------------------------
 * Class Name: WLD_Node
 * -----------------------------------------------------------------------------------
 * Author: Joseph Aranda
 * Date: #DATE#
 * Credit: 
 * -----------------------------------------------------------------------------------
 * Purpose: 
 * -----------------------------------------------------------------------------------
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class WLD_Node : MonoBehaviour 
{
    #region Variables
    // ------------------------------------------------------------------------------
    // Public Variables
    // ------------------------------------------------------------------------------
    //[HideInInspector]
    public GameObject gamePiecePrefab;

    [Header("PlayerOne Rotation Cord")]
    public float p1_xRotation = -45f;
    public float p1_yRotation = 0f;
    public float p1_zRotation = 0f;

    [Header("PlayerTwo Rotation Cord")]
    public float p2_xRotation = 45f;
    public float p2_yRotation = 0f;
    public float p2_zRotation = 0f;


    // ------------------------------------------------------------------------------
    // Protected Variables
    // ------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------
    // Private VariablesVector3(0f,1f,-.5f)
    // ------------------------------------------------------------------------------

    GameObject manager;
    Renderer nodeRender;

    int spyStartingValue = 15;
    int privateStartingValue = 2;

    float temp;

    bool canBuildHere = false, isempty = false;

    Vector3 P1_positionOffset = new Vector3(0f, 1f, 0f);
    Vector3 P2_positionOffset = new Vector3(0f, 1f, 0f);

    Vector3 posOneTemp = new Vector3 (11f, 0, 15.4f);

    Vector3 placementLeft = new Vector3(-2.2f, 1, 0);

    GameObject temptemp;
    public static GameObject flagTemp;

    #endregion

    #region Getters/Setters



    #endregion

    #region Constructors



    #endregion

    // ------------------------------------------------------------------------------
    // FUNCTIONS
    // ------------------------------------------------------------------------------
    void Start()
    {
        manager = WLD_GameController.managers;
        nodeRender = GetComponent<Renderer>();
    }

    //void Update()
    //{
    //    Debug.Log(gamePiecePrefab.transform.position - placementLeft);
    //}
    // ------------------------------------------------------------------------------
    // Function Name: 
    // Return types: 
    // Argument types: 
    // Author: 
    // Date: 
    // ------------------------------------------------------------------------------
    // Purpose: 
    // ------------------------------------------------------------------------------
    #region OnMouseClicks
    // ------------------------------------------------------------------------------
    // Function Name: 
    // Return types: 
    // Argument types: 
    // Author: 
    // Date: 
    // ------------------------------------------------------------------------------
    // Purpose: 
    // ------------------------------------------------------------------------------
    void OnMouseEnter()
    {
        if (!manager.GetComponent<WLD_BuildManager>().CanBuild)
        {
            return;
        }

        P1_BuildTurn_HighLight();
        P2_BuildTurn_Highlight();

        PlayTurn_HighLight();
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
    void OnMouseExit()
    {
        nodeRender.material.color = WLD_GameController.boardColors[GameBoardColors.NormalSlot];
    }
    // ------------------------------------------------------------------------------
    // Function Name: 
    // Return types: 
    // Argument types: 
    // Author: 
    // Date: 
    // ------------------------------------------------------------------------------
    // Purpose: When mouse is over this game object
    // ------------------------------------------------------------------------------
    void OnMouseDown()
    {
        if (!manager.GetComponent<WLD_BuildManager>().CanBuild)
        {
            return;
        }

        BuildMode();
        PlayMode();

       

    }

  
    #endregion
    // ------------------------------------------------------------------------------
    // Function Name: 
    // Return types: 
    // Argument types: 
    // Author: 
    // Date: 
    // ------------------------------------------------------------------------------
    // Purpose: 
    // ------------------------------------------------------------------------------
    #region GameModes

    void EndGame()
    {
        if (WLD_BuildManager.isPlaceMode)
        {          
            if (gameObject.transform.position.z == 0 && gamePiecePrefab.transform.position.z == 0 && gamePiecePrefab.tag == UNA_Tags.P2_Flag)
            {
                //Place end UI here
                Debug.Log("Player two Wins");
            }
            if (gameObject.transform.position.z >= 15f && gamePiecePrefab.transform.position.z >= 15f && gamePiecePrefab.tag == UNA_Tags.P1_Flag)
            {
                //if (gamePiecePrefab.transform.position.x == 8.8f)
                //{
                //    temptemp = gamePiecePrefab.transform.position - placementLeft;

                //    if (temptemp == posOneTemp)
                //    {               
                //        if (transform.position == temptemp)
                //        {
                //            if (gamePiecePrefab == null)
                //            {
                //                Debug.Log("Player One Wins");
                //            }
                //        }
                //    }                  
                //}

                //Place end UI here
                Debug.Log("Player One Wins");
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
    void BuildMode()
    {
        if (gameObject.tag == UNA_Tags.PlayerOne)
        {
            if (manager.GetComponent<WLD_BuildManager>().IsBuildMode && manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn && canBuildHere)
            {
                P1_BuildGamePiece(manager.GetComponent<WLD_BuildManager>().GetGamePieceToBuild(), 1);

                canBuildHere = false;
            }
        }
        else if (gameObject.tag == UNA_Tags.PlayerTwo)
        {
            if (manager.GetComponent<WLD_BuildManager>().IsBuildMode && manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn && canBuildHere)
            {
                P2_BuildGamePiece(manager.GetComponent<WLD_BuildManager>().GetGamePieceToBuild(), 1);

                canBuildHere = false;
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
    void PlayMode()
    {
        if (WLD_BuildManager.isPlaceMode)
        {
            if (manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
            {
                if (gamePiecePrefab == null)
                {
                    P1_MoveGamePiece();
                }
                else if (gamePiecePrefab != null)
                {
                    P1_Attacking();

                    nodeRender.material.color = WLD_GameController.boardColors[GameBoardColors.CloasedSlot];
                }
            }
            else if (manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn)
            {
                if (gamePiecePrefab == null)
                {
                    P2_MoveGamePiece();
                }
                else if (gamePiecePrefab != null)
                {
                    P2_Attacking();

                    nodeRender.material.color = WLD_GameController.boardColors[GameBoardColors.CloasedSlot];
                }
            }
        }
    }

    #endregion

    // ------------------------------------------------------------------------------
    // Function Name: 
    // Return types: 
    // Argument types: 
    // Author: 
    // Date: 
    // ------------------------------------------------------------------------------
    // Purpose: 
    // ------------------------------------------------------------------------------
    #region SupportingFunctions
  
    // ------------------------------------------------------------------------------
    // Function Name: 
    // Return types: 
    // Argument types: 
    // Author: 
    // Date: 
    // ------------------------------------------------------------------------------
    // Purpose: 
    // ------------------------------------------------------------------------------
    void P1_Attacking()
    {
        if (WLD_GameController.p1_chosenGamePiece[0].layer != gamePiecePrefab.layer)
        {
            if (transform.position + P1_positionOffset == manager.GetComponent<WLD_BuildManager>().PlacementUp || transform.position + P1_positionOffset == manager.GetComponent<WLD_BuildManager>().PlacementDown ||
              transform.position + P1_positionOffset == manager.GetComponent<WLD_BuildManager>().PlacementLeft || transform.position + P1_positionOffset == manager.GetComponent<WLD_BuildManager>().PlacementRight)
            {

                P1_SpyVsPrivate();

                if (WLD_GameController.p1_chosenGamePiece[0].GetComponent<GP_Attack>().attackPower == gamePiecePrefab.GetComponent<GP_Attack>().attackPower)
                {
                    //Place end UI here
                    Debug.Log("1B Tie");
                    WLD_GameController.p1_chosenGamePiece.Remove(WLD_GameController.p1_chosenGamePiece[0]);

                    SwitchToPlayerTwo();
                }
                else if (WLD_GameController.p1_chosenGamePiece[0].GetComponent<GP_Attack>().attackPower >= gamePiecePrefab.GetComponent<GP_Attack>().attackPower)
                {
                    //Place end UI here
                    Debug.Log("1B P1_Win");

                    if (gamePiecePrefab.tag == UNA_Tags.P2_Flag)
                    {
                        WLD_GameController.p2_Flag -= 1;                 
                    }

                    Destroy(gamePiecePrefab);

                    P1_PlayMode_PlacePiece();

                    SwitchToPlayerTwo();
                }
                else if (WLD_GameController.p1_chosenGamePiece[0].GetComponent<GP_Attack>().attackPower <= gamePiecePrefab.GetComponent<GP_Attack>().attackPower)
                {
                    //Place end UI here
                    Debug.Log("1B P1_Lose");
                    if (gamePiecePrefab.tag == UNA_Tags.P2_Flag)
                    {
                        WLD_GameController.p2_Flag -= 1;
                    }

                    Destroy(WLD_GameController.p1_chosenGamePiece[0]);
                    WLD_GameController.p1_chosenGamePiece.Remove(WLD_GameController.p1_chosenGamePiece[0]);
                   
                    SwitchToPlayerTwo();
                }
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
    void P2_Attacking()
    {
        if (WLD_GameController.p2_chosenGamePiece[0].layer != gamePiecePrefab.layer)
        {
            if (transform.position + P1_positionOffset == manager.GetComponent<WLD_BuildManager>().PlacementUp || transform.position + P1_positionOffset == manager.GetComponent<WLD_BuildManager>().PlacementDown ||
              transform.position + P1_positionOffset == manager.GetComponent<WLD_BuildManager>().PlacementLeft || transform.position + P1_positionOffset == manager.GetComponent<WLD_BuildManager>().PlacementRight)
            {

                P2_SpyVsPrivate();


                if (WLD_GameController.p2_chosenGamePiece[0].GetComponent<GP_Attack>().attackPower == gamePiecePrefab.GetComponent<GP_Attack>().attackPower)
                {
                    //Place end UI here
                    Debug.Log("2B Tie");
                    WLD_GameController.p2_chosenGamePiece.Remove(WLD_GameController.p2_chosenGamePiece[0]);

                    SwitchToPlayerOne();
                }
                else if (WLD_GameController.p2_chosenGamePiece[0].GetComponent<GP_Attack>().attackPower >= gamePiecePrefab.GetComponent<GP_Attack>().attackPower)
                {
                    //Place end UI here
                    Debug.Log(" 2B P2_Win");

                    if (gamePiecePrefab.tag == UNA_Tags.P1_Flag)
                    {
                        WLD_GameController.p1_Flag -= 1;
                    }


                    Destroy(gamePiecePrefab);

                    P2_PlayMode_PlacePiece();

                    SwitchToPlayerOne();
                }
                else if (WLD_GameController.p2_chosenGamePiece[0].GetComponent<GP_Attack>().attackPower <= gamePiecePrefab.GetComponent<GP_Attack>().attackPower)
                {
                    //Place end UI here
                    Debug.Log("2B P2_Lose");
                    if (gamePiecePrefab.tag == UNA_Tags.P1_Flag)
                    {
                        WLD_GameController.p1_Flag -= 1;
                    }

                    Destroy(WLD_GameController.p2_chosenGamePiece[0]);
                    WLD_GameController.p2_chosenGamePiece.Remove(WLD_GameController.p2_chosenGamePiece[0]);

                    SwitchToPlayerOne();
                }
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
    void P1_SpyVsPrivate()
    {
        if (WLD_GameController.p1_chosenGamePiece[0].tag == UNA_Tags.Private && gamePiecePrefab.tag == UNA_Tags.P2_Spy)
        {

            WLD_GameController.p1_chosenGamePiece[0].GetComponent<GP_Attack>().attackPower = 15;
            gamePiecePrefab.GetComponent<GP_Attack>().attackPower = 2;

            if (WLD_GameController.p1_chosenGamePiece[0].GetComponent<GP_Attack>().attackPower >= gamePiecePrefab.GetComponent<GP_Attack>().attackPower)
            {
                //Place end UI here

                //if (gamePiecePrefab.tag == UNA_Tags.P2_Spy)
                //{
                //    Debug.Log("1a");
                //    WLD_BuildManager.p1_Temp.Remove(WLD_GameController.P1_GamePieces[GamePieces.Spy]);

                //}
          
                Destroy(gamePiecePrefab);

                P1_PlayMode_PlacePiece();

                SwitchToPlayerTwo();

                WLD_GameController.p1_chosenGamePiece[0].GetComponent<GP_Attack>().attackPower = privateStartingValue;
                gamePiecePrefab.GetComponent<GP_Attack>().attackPower = spyStartingValue;
            }
        }
        else if (WLD_GameController.p1_chosenGamePiece[0].tag == UNA_Tags.Spy && gamePiecePrefab.tag == UNA_Tags.P2_Private)
        {
            WLD_GameController.p1_chosenGamePiece[0].GetComponent<GP_Attack>().attackPower = 2;
            gamePiecePrefab.GetComponent<GP_Attack>().attackPower = 15;

            if (WLD_GameController.p1_chosenGamePiece[0].GetComponent<GP_Attack>().attackPower <= gamePiecePrefab.GetComponent<GP_Attack>().attackPower)
            {
                //Place end UI here

               
                //if (WLD_BuildManager.p1_chosenGamePiece[0].tag == UNA_Tags.P2_Private)
                //{
                //    Debug.Log("1a");
                //    WLD_BuildManager.p1_Temp.Remove(WLD_GameController.P1_GamePieces[GamePieces.Private]);
                //}

                Destroy(WLD_GameController.p1_chosenGamePiece[0]);
                WLD_GameController.p1_chosenGamePiece.Remove(WLD_GameController.p1_chosenGamePiece[0]);

                SwitchToPlayerTwo();

                gamePiecePrefab.GetComponent<GP_Attack>().attackPower = privateStartingValue;
                WLD_GameController.p1_chosenGamePiece[0].GetComponent<GP_Attack>().attackPower = spyStartingValue;
                
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
    void P2_SpyVsPrivate()
    {
        if (WLD_GameController.p2_chosenGamePiece[0].tag == UNA_Tags.P2_Private && gamePiecePrefab.tag == UNA_Tags.Spy)
        {
            WLD_GameController.p2_chosenGamePiece[0].GetComponent<GP_Attack>().attackPower = 15;
            gamePiecePrefab.GetComponent<GP_Attack>().attackPower = 2;

            if (WLD_GameController.p2_chosenGamePiece[0].GetComponent<GP_Attack>().attackPower >= gamePiecePrefab.GetComponent<GP_Attack>().attackPower)
            {
                //Place end UI here
                //if (gamePiecePrefab.tag == UNA_Tags.Spy)
                //{
                //    WLD_BuildManager.p2_Temp.Remove(WLD_GameController.P2_GamePieces[GamePieces.Spy]);
                //}
                Destroy(gamePiecePrefab);

                P2_PlayMode_PlacePiece();

                SwitchToPlayerOne();

                WLD_GameController.p2_chosenGamePiece[0].GetComponent<GP_Attack>().attackPower = privateStartingValue;
                gamePiecePrefab.GetComponent<GP_Attack>().attackPower = spyStartingValue;
            }
        }
        else if (WLD_GameController.p2_chosenGamePiece[0].tag == UNA_Tags.P2_Spy && gamePiecePrefab.tag == UNA_Tags.Private)
        {
            Debug.Log(WLD_GameController.p2_chosenGamePiece[0].tag + "p2");
            Debug.Log(gamePiecePrefab.tag + "gameobject");

            WLD_GameController.p2_chosenGamePiece[0].GetComponent<GP_Attack>().attackPower = 2;
            gamePiecePrefab.GetComponent<GP_Attack>().attackPower = 15;

            if (WLD_GameController.p2_chosenGamePiece[0].GetComponent<GP_Attack>().attackPower <= gamePiecePrefab.GetComponent<GP_Attack>().attackPower)
            {
                //Place end UI here

                //if (WLD_BuildManager.p2_chosenGamePiece[0].tag == UNA_Tags.Private)
                //{
                //    WLD_BuildManager.p2_Temp.Remove(WLD_GameController.P2_GamePieces[GamePieces.Private]);
                //}

                Destroy(WLD_GameController.p2_chosenGamePiece[0]);
                WLD_GameController.p2_chosenGamePiece.Remove(WLD_GameController.p2_chosenGamePiece[0]);

                SwitchToPlayerOne();

                gamePiecePrefab.GetComponent<GP_Attack>().attackPower = privateStartingValue;
                WLD_GameController.p2_chosenGamePiece[0].GetComponent<GP_Attack>().attackPower = spyStartingValue;                
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
    void P1_MoveGamePiece()
    {
        if (WLD_BuildManager.isPlaceMode)
        {
          
            if (transform.position + P1_positionOffset == manager.GetComponent<WLD_BuildManager>().PlacementUp || transform.position + P1_positionOffset == manager.GetComponent<WLD_BuildManager>().PlacementDown ||
                transform.position + P1_positionOffset == manager.GetComponent<WLD_BuildManager>().PlacementLeft || transform.position + P1_positionOffset == manager.GetComponent<WLD_BuildManager>().PlacementRight)
            {
                GameObject tempMovePiece = Instantiate(WLD_GameController.p1_chosenGamePiece[0], P1_GetBuildPosition(), Quaternion.Euler(p1_xRotation, p1_yRotation, p1_zRotation));
                gamePiecePrefab = tempMovePiece;

                Destroy(WLD_GameController.p1_chosenGamePiece[0]);

                WLD_GameController.p1_chosenGamePiece.Remove(WLD_GameController.p1_chosenGamePiece[0]);

                EndGame();

                manager.GetComponent<WLD_BuildManager>().P1_SwitchTurn(false);
                manager.GetComponent<WLD_BuildManager>().P2_SwitchTurn(true);
            }
            else
            {
                WLD_GameController.p1_chosenGamePiece.Remove(WLD_GameController.p1_chosenGamePiece[0]);
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
    void P2_MoveGamePiece()
    {
        if (WLD_BuildManager.isPlaceMode)
        {
            if (transform.position + P1_positionOffset == manager.GetComponent<WLD_BuildManager>().PlacementUp || transform.position + P1_positionOffset == manager.GetComponent<WLD_BuildManager>().PlacementDown ||
               transform.position + P1_positionOffset == manager.GetComponent<WLD_BuildManager>().PlacementLeft || transform.position + P1_positionOffset == manager.GetComponent<WLD_BuildManager>().PlacementRight)
            {
                GameObject tempMovePiece = Instantiate(WLD_GameController.p2_chosenGamePiece[0], P2_GetBuildPosition(), Quaternion.Euler(p2_xRotation, p2_yRotation, p2_zRotation));
                gamePiecePrefab = tempMovePiece;

                Destroy(WLD_GameController.p2_chosenGamePiece[0]);
                WLD_GameController.p2_chosenGamePiece.Remove(WLD_GameController.p2_chosenGamePiece[0]);

                EndGame();

                manager.GetComponent<WLD_BuildManager>().P1_SwitchTurn(true);
                manager.GetComponent<WLD_BuildManager>().P2_SwitchTurn(false);
            }
            else
            {
                WLD_GameController.p1_chosenGamePiece.Remove(WLD_GameController.p1_chosenGamePiece[0]);
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
    void P1_PlayMode_PlacePiece()
    {
        GameObject tempMovePiece = Instantiate(WLD_GameController.p1_chosenGamePiece[0], P1_GetBuildPosition(), Quaternion.Euler(p1_xRotation, p1_yRotation, p1_zRotation));
        gamePiecePrefab = tempMovePiece;

        EndGame();

        Destroy(WLD_GameController.p1_chosenGamePiece[0]);
        WLD_GameController.p1_chosenGamePiece.Remove(WLD_GameController.p1_chosenGamePiece[0]);
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
    void P2_PlayMode_PlacePiece()
    {
        GameObject tempMovePiece = Instantiate(WLD_GameController.p2_chosenGamePiece[0], P2_GetBuildPosition(), Quaternion.Euler(p2_xRotation, p2_yRotation, p2_zRotation));
        gamePiecePrefab = tempMovePiece;

        EndGame();

        Destroy(WLD_GameController.p2_chosenGamePiece[0]);
        WLD_GameController.p2_chosenGamePiece.Remove(WLD_GameController.p2_chosenGamePiece[0]);
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
    void SwitchToPlayerOne()
    {
        manager.GetComponent<WLD_BuildManager>().P1_SwitchTurn(true);
        manager.GetComponent<WLD_BuildManager>().P2_SwitchTurn(false);
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
    void SwitchToPlayerTwo()
    {
        manager.GetComponent<WLD_BuildManager>().P1_SwitchTurn(false);
        manager.GetComponent<WLD_BuildManager>().P2_SwitchTurn(true);
    }
   
    // ------------------------------------------------------------------------------
    // Function Name: 
    // Return types: 
    // Argument types: 
    // Author: 
    // Date: 
    // ------------------------------------------------------------------------------
    // Purpose: the position in which the prefab will spawn
    // ------------------------------------------------------------------------------
    public Vector3 P1_GetBuildPosition()
    {
        return transform.position + P1_positionOffset;
    }
    // ------------------------------------------------------------------------------
    // Function Name: 
    // Return types: 
    // Argument types: 
    // Author: 
    // Date: 
    // ------------------------------------------------------------------------------
    // Purpose: the position in which the prefab will spawn
    // ------------------------------------------------------------------------------
    public Vector3 P2_GetBuildPosition()
    {
        return transform.position + P2_positionOffset;
    }
    #endregion

    // ------------------------------------------------------------------------------
    // Function Name: 
    // Return types: 
    // Argument types: 
    // Author: 
    // Date: 
    // ------------------------------------------------------------------------------
    // Purpose: 
    // ------------------------------------------------------------------------------
    #region HighlightingNodes

    // ------------------------------------------------------------------------------
    // Function Name: 
    // Return types: 
    // Argument types: 
    // Author: 
    // Date: 
    // ------------------------------------------------------------------------------
    // Purpose: 
    // ------------------------------------------------------------------------------
    void PlayTurn_HighLight()
    {
        if (WLD_BuildManager.isPlaceMode)
        {        
            if (transform.position + P1_positionOffset == manager.GetComponent<WLD_BuildManager>().PlacementUp || transform.position + P1_positionOffset == manager.GetComponent<WLD_BuildManager>().PlacementDown ||
                transform.position + P1_positionOffset == manager.GetComponent<WLD_BuildManager>().PlacementLeft || transform.position + P1_positionOffset == manager.GetComponent<WLD_BuildManager>().PlacementRight)
            {
                if (manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
                {
                    if (gamePiecePrefab == null)
                    {
                        nodeRender.material.color = WLD_GameController.boardColors[GameBoardColors.OpenSlot];
                    }
                    else
                    {
                        if (gamePiecePrefab != null)
                        {
                            for (int i = 0; i < WLD_GameController.P1_tagNames.Count; i++)
                            {
                                if (gamePiecePrefab.tag == WLD_GameController.P1_tagNames[i])
                                {
                                    nodeRender.material.color = WLD_GameController.boardColors[GameBoardColors.CloasedSlot];
                                }
                            }
                            for (int i = 0; i < WLD_GameController.P2_tagNames.Count; i++)
                            {
                                if (gamePiecePrefab.tag == WLD_GameController.P2_tagNames[i])
                                {
                                    nodeRender.material.color = WLD_GameController.boardColors[GameBoardColors.OpenSlot];
                                }
                            }
                        }                    
                    }
                }             
                if (manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn)
                {
                    if (gamePiecePrefab == null)
                    {
                        nodeRender.material.color = WLD_GameController.boardColors[GameBoardColors.OpenSlot];
                    }
                    else
                    {
                        if (gamePiecePrefab != null)
                        {
                            for (int i = 0; i < WLD_GameController.P2_tagNames.Count; i++)
                            {
                                if (gamePiecePrefab.tag == WLD_GameController.P2_tagNames[i])
                                {
                                    nodeRender.material.color = WLD_GameController.boardColors[GameBoardColors.CloasedSlot];
                                }
                            }
                            for (int i = 0; i < WLD_GameController.P1_tagNames.Count; i++)
                            {
                                if (gamePiecePrefab.tag == WLD_GameController.P1_tagNames[i])
                                {
                                    nodeRender.material.color = WLD_GameController.boardColors[GameBoardColors.OpenSlot];
                                }
                            }                            
                        }
                    }
                }
            }
            else
            {
                nodeRender.material.color = WLD_GameController.boardColors[GameBoardColors.CloasedSlot];
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
    void P1_BuildTurn_HighLight()
    {
        if (gameObject.tag == UNA_Tags.PlayerOne)
        {
            if (manager.GetComponent<WLD_BuildManager>().IsBuildMode && manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
            {

                if (gamePiecePrefab != null)
                {
                    canBuildHere = false;
                }
                else
                {
                    canBuildHere = true;
                }

                if (!canBuildHere)
                {
                    nodeRender.material.color = WLD_GameController.boardColors[GameBoardColors.CloasedSlot];
                }
                else
                {
                    nodeRender.material.color = WLD_GameController.boardColors[GameBoardColors.OpenSlot];
                }
            }
        }
        if (gameObject.tag == UNA_Tags.PlayerTwo && manager.GetComponent<WLD_BuildManager>().IsBuildMode && manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
        {
            nodeRender.material.color = WLD_GameController.boardColors[GameBoardColors.CloasedSlot];
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
    void P2_BuildTurn_Highlight()
    {
        if (gameObject.tag == UNA_Tags.PlayerTwo)
        {
            if (manager.GetComponent<WLD_BuildManager>().IsBuildMode && manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn)
            {

                if (gamePiecePrefab != null)
                {
                    canBuildHere = false;
                }
                else
                {
                    canBuildHere = true;
                }

                if (!canBuildHere)
                {
                    nodeRender.material.color = WLD_GameController.boardColors[GameBoardColors.CloasedSlot];
                }
                else
                {
                    nodeRender.material.color = WLD_GameController.boardColors[GameBoardColors.OpenSlot];
                }
            }
        }
    }



    #endregion
   
    // ------------------------------------------------------------------------------
    // Function Name: 
    // Return types: 
    // Argument types: 
    // Author: 
    // Date: 
    // ------------------------------------------------------------------------------
    // Purpose: Instantiates the prefab that the gamemanager passes through
    // ------------------------------------------------------------------------------

    #region P1_BuildGamePieces

    void P1_BuildGamePiece(GameObject _gamePiecePrefab, int value)
    {
        if (WLD_GameController.P1_GamePieceInv[GamePieces.FiveStarGeneral] >= 1 && WLD_GameController.isFivePressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P1_GetBuildPosition(), Quaternion.Euler(p1_xRotation, p1_yRotation, p1_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p1_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P1_GamePieceInv[GamePieces.FiveStarGeneral] -= value;
            manager.GetComponent<WLD_BuildManager>().P1_TotalInventory -= value;

            WLD_GameController.p1_Temp.Add(WLD_BuildManager.fiveGeneral);

            manager.GetComponent<UI_UIManager>().P1_SwitchButtonsOn(WLD_GameController.P1_UI_Buttons[GamePieces.FiveStarGeneral]);
        }

        else if (WLD_GameController.P1_GamePieceInv[GamePieces.FourStarGeneral] >= 1 && WLD_GameController.isFourPressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P1_GetBuildPosition(), Quaternion.Euler(p1_xRotation, p1_yRotation, p1_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p1_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P1_GamePieceInv[GamePieces.FourStarGeneral] -= value;
            manager.GetComponent<WLD_BuildManager>().P1_TotalInventory -= value;

            WLD_GameController.p1_Temp.Add(WLD_BuildManager.fourGeneral);

            manager.GetComponent<UI_UIManager>().P1_SwitchButtonsOn(WLD_GameController.P1_UI_Buttons[GamePieces.FourStarGeneral]);

        }

        else if (WLD_GameController.P1_GamePieceInv[GamePieces.ThreeStarGeneral] >= 1 && WLD_GameController.isThreePressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P1_GetBuildPosition(), Quaternion.Euler(p1_xRotation, p1_yRotation, p1_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p1_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P1_GamePieceInv[GamePieces.ThreeStarGeneral] -= value;
            manager.GetComponent<WLD_BuildManager>().P1_TotalInventory -= value;

            WLD_GameController.p1_Temp.Add(WLD_BuildManager.threeGeneral);

            manager.GetComponent<UI_UIManager>().P1_SwitchButtonsOn(WLD_GameController.P1_UI_Buttons[GamePieces.ThreeStarGeneral]);
        }

        else if (WLD_GameController.P1_GamePieceInv[GamePieces.TwoStarGenreal] >= 1 && WLD_GameController.isTwoPressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P1_GetBuildPosition(), Quaternion.Euler(p1_xRotation, p1_yRotation, p1_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p1_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P1_GamePieceInv[GamePieces.TwoStarGenreal] -= value;
            manager.GetComponent<WLD_BuildManager>().P1_TotalInventory -= value;

            WLD_GameController.p1_Temp.Add(WLD_BuildManager.twoGeneral);

            manager.GetComponent<UI_UIManager>().P1_SwitchButtonsOn(WLD_GameController.P1_UI_Buttons[GamePieces.TwoStarGenreal]);
        }

        else if (WLD_GameController.P1_GamePieceInv[GamePieces.OneStarGeneral] >= 1 && WLD_GameController.isOnePressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P1_GetBuildPosition(), Quaternion.Euler(p1_xRotation, p1_yRotation, p1_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p1_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P1_GamePieceInv[GamePieces.OneStarGeneral] -= value;
            manager.GetComponent<WLD_BuildManager>().P1_TotalInventory -= value;

            WLD_GameController.p1_Temp.Add(WLD_BuildManager.oneGeneral);

            manager.GetComponent<UI_UIManager>().P1_SwitchButtonsOn(WLD_GameController.P1_UI_Buttons[GamePieces.OneStarGeneral]);
        }
        else if (WLD_GameController.P1_GamePieceInv[GamePieces.Colonel] >= 1 && WLD_GameController.isColonelPressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P1_GetBuildPosition(), Quaternion.Euler(p1_xRotation, p1_yRotation, p1_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p1_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P1_GamePieceInv[GamePieces.Colonel] -= value;
            manager.GetComponent<WLD_BuildManager>().P1_TotalInventory -= value;

            WLD_GameController.p1_Temp.Add(WLD_BuildManager.colonel);

            manager.GetComponent<UI_UIManager>().P1_SwitchButtonsOn(WLD_GameController.P1_UI_Buttons[GamePieces.Colonel]);
        }
        else if (WLD_GameController.P1_GamePieceInv[GamePieces.LtColonel] >= 1 && WLD_GameController.isLtColonelPressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P1_GetBuildPosition(), Quaternion.Euler(p1_xRotation, p1_yRotation, p1_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p1_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P1_GamePieceInv[GamePieces.LtColonel] -= value;
            manager.GetComponent<WLD_BuildManager>().P1_TotalInventory -= value;

            WLD_GameController.p1_Temp.Add(WLD_BuildManager.ltColonel);

            manager.GetComponent<UI_UIManager>().P1_SwitchButtonsOn(WLD_GameController.P1_UI_Buttons[GamePieces.LtColonel]);
        }
        else if (WLD_GameController.P1_GamePieceInv[GamePieces.Major] >= 1 && WLD_GameController.isMajorPressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P1_GetBuildPosition(), Quaternion.Euler(p1_xRotation, p1_yRotation, p1_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p1_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P1_GamePieceInv[GamePieces.Major] -= value;
            manager.GetComponent<WLD_BuildManager>().P1_TotalInventory -= value;

            WLD_GameController.p1_Temp.Add(WLD_BuildManager.major);

            manager.GetComponent<UI_UIManager>().P1_SwitchButtonsOn(WLD_GameController.P1_UI_Buttons[GamePieces.Major]);
        }
        else if (WLD_GameController.P1_GamePieceInv[GamePieces.Captain] >= 1 && WLD_GameController.isCaptainPressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P1_GetBuildPosition(), Quaternion.Euler(p1_xRotation, p1_yRotation, p1_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p1_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P1_GamePieceInv[GamePieces.Captain] -= value;
            manager.GetComponent<WLD_BuildManager>().P1_TotalInventory -= value;

            WLD_GameController.p1_Temp.Add(WLD_BuildManager.captain);

            manager.GetComponent<UI_UIManager>().P1_SwitchButtonsOn(WLD_GameController.P1_UI_Buttons[GamePieces.Captain]);
        }
        else if (WLD_GameController.P1_GamePieceInv[GamePieces.FirstLieutenant] >= 1 && WLD_GameController.isFirstLtPressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P1_GetBuildPosition(), Quaternion.Euler(p1_xRotation, p1_yRotation, p1_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p1_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P1_GamePieceInv[GamePieces.FirstLieutenant] -= value;
            manager.GetComponent<WLD_BuildManager>().P1_TotalInventory -= value;

            WLD_GameController.p1_Temp.Add(WLD_BuildManager.firstLieutenant);

            manager.GetComponent<UI_UIManager>().P1_SwitchButtonsOn(WLD_GameController.P1_UI_Buttons[GamePieces.FirstLieutenant]);
        }
        else if (WLD_GameController.P1_GamePieceInv[GamePieces.SecondLietenant] >= 1 && WLD_GameController.isSecondPressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P1_GetBuildPosition(), Quaternion.Euler(p1_xRotation, p1_yRotation, p1_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p1_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P1_GamePieceInv[GamePieces.SecondLietenant] -= value;
            manager.GetComponent<WLD_BuildManager>().P1_TotalInventory -= value;

            WLD_GameController.p1_Temp.Add(WLD_BuildManager.secLieutenant);

            manager.GetComponent<UI_UIManager>().P1_SwitchButtonsOn(WLD_GameController.P1_UI_Buttons[GamePieces.SecondLietenant]);
        }
        else if (WLD_GameController.P1_GamePieceInv[GamePieces.sergeant] >= 1 && WLD_GameController.isSergeantPressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P1_GetBuildPosition(), Quaternion.Euler(p1_xRotation, p1_yRotation, p1_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p1_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P1_GamePieceInv[GamePieces.sergeant] -= value;
            manager.GetComponent<WLD_BuildManager>().P1_TotalInventory -= value;

            WLD_GameController.p1_Temp.Add(WLD_BuildManager.sergeant);

            manager.GetComponent<UI_UIManager>().P1_SwitchButtonsOn(WLD_GameController.P1_UI_Buttons[GamePieces.sergeant]);
        }
        else if (WLD_GameController.P1_GamePieceInv[GamePieces.Private] <= 6 && WLD_GameController.P1_GamePieceInv[GamePieces.Private] >= 1 && WLD_GameController.isPrivatePressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P1_GetBuildPosition(), Quaternion.Euler(p1_xRotation, p1_yRotation, p1_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p1_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P1_GamePieceInv[GamePieces.Private] -= value;
            manager.GetComponent<WLD_BuildManager>().P1_TotalInventory -= value;

            WLD_GameController.p1_Temp.Add(WLD_BuildManager.privates);

            manager.GetComponent<UI_UIManager>().P1_SwitchButtonsOn(WLD_GameController.P1_UI_Buttons[GamePieces.Private]);
        }
        else if (WLD_GameController.P1_GamePieceInv[GamePieces.Spy] <= 2 && WLD_GameController.P1_GamePieceInv[GamePieces.Spy] >= 1 && WLD_GameController.isSpyPressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P1_GetBuildPosition(), Quaternion.Euler(p1_xRotation, p1_yRotation, p1_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p1_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P1_GamePieceInv[GamePieces.Spy] -= value;
            manager.GetComponent<WLD_BuildManager>().P1_TotalInventory -= value;

            WLD_GameController.p1_Temp.Add(WLD_BuildManager.spy);

            manager.GetComponent<UI_UIManager>().P1_SwitchButtonsOn(WLD_GameController.P1_UI_Buttons[GamePieces.Spy]);
        }
        else if (WLD_GameController.P1_GamePieceInv[GamePieces.P1_Flag] >= 1 && WLD_GameController.isFlagPressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P1_GetBuildPosition(), Quaternion.Euler(p1_xRotation, p1_yRotation, p1_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p1_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P1_GamePieceInv[GamePieces.P1_Flag] -= value;
            manager.GetComponent<WLD_BuildManager>().P1_TotalInventory -= value;

            WLD_GameController.p1_Temp.Add(WLD_BuildManager.flag);

            manager.GetComponent<UI_UIManager>().P1_SwitchButtonsOn(WLD_GameController.P1_UI_Buttons[GamePieces.P1_Flag]);
        }
    }

    #endregion
    // ------------------------------------------------------------------------------
    // Function Name: 
    // Return types: 
    // Argument types: 
    // Author: 
    // Date: 
    // ------------------------------------------------------------------------------
    // Purpose: Instantiates the prefab that the gamemanager passes through
    // ------------------------------------------------------------------------------

    #region P2_BuildGamePieces

    void P2_BuildGamePiece(GameObject _gamePiecePrefab, int value)
    {
        if (WLD_GameController.P2_GamePieceInv[GamePieces.FiveStarGeneral] >= 1 && WLD_GameController.isFivePressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P2_GetBuildPosition(), Quaternion.Euler(p2_xRotation, p2_yRotation, p2_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p2_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P2_GamePieceInv[GamePieces.FiveStarGeneral] -= value;
            manager.GetComponent<WLD_BuildManager>().P2_TotalInventory -= value;

            WLD_GameController.p2_Temp.Add(WLD_BuildManager.p2_fiveGeneral);

            manager.GetComponent<UI_UIManager>().P2_SwitchButtonsOn(WLD_GameController.P2_UI_Buttons[GamePieces.FiveStarGeneral]);        
        }

        else if (WLD_GameController.P2_GamePieceInv[GamePieces.FourStarGeneral] >= 1 && WLD_GameController.isFourPressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P2_GetBuildPosition(), Quaternion.Euler(p2_xRotation, p2_yRotation, p2_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p2_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P2_GamePieceInv[GamePieces.FourStarGeneral] -= value;
            manager.GetComponent<WLD_BuildManager>().P2_TotalInventory -= value;

            WLD_GameController.p2_Temp.Add(WLD_BuildManager.p2_fourGeneral);

            manager.GetComponent<UI_UIManager>().P2_SwitchButtonsOn(WLD_GameController.P2_UI_Buttons[GamePieces.FourStarGeneral]);         
        }

        else if (WLD_GameController.P2_GamePieceInv[GamePieces.ThreeStarGeneral] >= 1 && WLD_GameController.isThreePressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P2_GetBuildPosition(), Quaternion.Euler(p2_xRotation, p2_yRotation, p2_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p2_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P2_GamePieceInv[GamePieces.ThreeStarGeneral] -= value;
            manager.GetComponent<WLD_BuildManager>().P2_TotalInventory -= value;

            WLD_GameController.p2_Temp.Add(WLD_BuildManager.p2_threeGeneral);

            manager.GetComponent<UI_UIManager>().P2_SwitchButtonsOn(WLD_GameController.P2_UI_Buttons[GamePieces.ThreeStarGeneral]);
        }

        else if (WLD_GameController.P2_GamePieceInv[GamePieces.TwoStarGenreal] >= 1 && WLD_GameController.isTwoPressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P2_GetBuildPosition(), Quaternion.Euler(p2_xRotation, p2_yRotation, p2_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p2_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P2_GamePieceInv[GamePieces.TwoStarGenreal] -= value;
            manager.GetComponent<WLD_BuildManager>().P2_TotalInventory -= value;

            WLD_GameController.p2_Temp.Add(WLD_BuildManager.p2_twoGeneral);

            manager.GetComponent<UI_UIManager>().P2_SwitchButtonsOn(WLD_GameController.P2_UI_Buttons[GamePieces.TwoStarGenreal]);
        }

        else if (WLD_GameController.P2_GamePieceInv[GamePieces.OneStarGeneral] >= 1 && WLD_GameController.isOnePressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P2_GetBuildPosition(), Quaternion.Euler(p2_xRotation, p2_yRotation, p2_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p2_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P2_GamePieceInv[GamePieces.OneStarGeneral] -= value;
            manager.GetComponent<WLD_BuildManager>().P2_TotalInventory -= value;

            WLD_GameController.p2_Temp.Add(WLD_BuildManager.p2_oneGeneral);

            manager.GetComponent<UI_UIManager>().P2_SwitchButtonsOn(WLD_GameController.P2_UI_Buttons[GamePieces.OneStarGeneral]);
        }
        else if (WLD_GameController.P2_GamePieceInv[GamePieces.Colonel] >= 1 && WLD_GameController.isColonelPressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P2_GetBuildPosition(), Quaternion.Euler(p2_xRotation, p2_yRotation, p2_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p2_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P2_GamePieceInv[GamePieces.Colonel] -= value;
            manager.GetComponent<WLD_BuildManager>().P2_TotalInventory -= value;

            WLD_GameController.p2_Temp.Add(WLD_BuildManager.p2_colonel);

            manager.GetComponent<UI_UIManager>().P2_SwitchButtonsOn(WLD_GameController.P2_UI_Buttons[GamePieces.Colonel]);
        }
        else if (WLD_GameController.P2_GamePieceInv[GamePieces.LtColonel] >= 1 && WLD_GameController.isLtColonelPressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P2_GetBuildPosition(), Quaternion.Euler(p2_xRotation, p2_yRotation, p2_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p2_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P2_GamePieceInv[GamePieces.LtColonel] -= value;
            manager.GetComponent<WLD_BuildManager>().P2_TotalInventory -= value;

            WLD_GameController.p2_Temp.Add(WLD_BuildManager.p2_ltColonel);

            manager.GetComponent<UI_UIManager>().P2_SwitchButtonsOn(WLD_GameController.P2_UI_Buttons[GamePieces.LtColonel]);
        }
        else if (WLD_GameController.P2_GamePieceInv[GamePieces.Major] >= 1 && WLD_GameController.isMajorPressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P2_GetBuildPosition(), Quaternion.Euler(p2_xRotation, p2_yRotation, p2_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p2_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P2_GamePieceInv[GamePieces.Major] -= value;
            manager.GetComponent<WLD_BuildManager>().P2_TotalInventory -= value;

            WLD_GameController.p2_Temp.Add(WLD_BuildManager.p2_major );

            manager.GetComponent<UI_UIManager>().P2_SwitchButtonsOn(WLD_GameController.P2_UI_Buttons[GamePieces.Major]);
        }
        else if (WLD_GameController.P2_GamePieceInv[GamePieces.Captain] >= 1 && WLD_GameController.isCaptainPressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P2_GetBuildPosition(), Quaternion.Euler(p2_xRotation, p2_yRotation, p2_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p2_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P2_GamePieceInv[GamePieces.Captain] -= value;
            manager.GetComponent<WLD_BuildManager>().P2_TotalInventory -= value;

            WLD_GameController.p2_Temp.Add(WLD_BuildManager.p2_captain);

            manager.GetComponent<UI_UIManager>().P2_SwitchButtonsOn(WLD_GameController.P2_UI_Buttons[GamePieces.Captain]);
        }
        else if (WLD_GameController.P2_GamePieceInv[GamePieces.FirstLieutenant] >= 1 && WLD_GameController.isFirstLtPressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P2_GetBuildPosition(), Quaternion.Euler(p2_xRotation, p2_yRotation, p2_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p2_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P2_GamePieceInv[GamePieces.FirstLieutenant] -= value;
            manager.GetComponent<WLD_BuildManager>().P2_TotalInventory -= value;

            WLD_GameController.p2_Temp.Add(WLD_BuildManager.p2_firstLieutenant);

            manager.GetComponent<UI_UIManager>().P2_SwitchButtonsOn(WLD_GameController.P2_UI_Buttons[GamePieces.FirstLieutenant]);
        }
        else if (WLD_GameController.P2_GamePieceInv[GamePieces.SecondLietenant] >= 1 && WLD_GameController.isSecondPressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P2_GetBuildPosition(), Quaternion.Euler(p2_xRotation, p2_yRotation, p2_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p2_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P2_GamePieceInv[GamePieces.SecondLietenant] -= value;
            manager.GetComponent<WLD_BuildManager>().P2_TotalInventory -= value;

            WLD_GameController.p2_Temp.Add(WLD_BuildManager.p2_secLieutenant);

            manager.GetComponent<UI_UIManager>().P2_SwitchButtonsOn(WLD_GameController.P2_UI_Buttons[GamePieces.SecondLietenant]);
        }
        else if (WLD_GameController.P2_GamePieceInv[GamePieces.sergeant] >= 1 && WLD_GameController.isSergeantPressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P2_GetBuildPosition(), Quaternion.Euler(p2_xRotation, p2_yRotation, p2_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p2_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P2_GamePieceInv[GamePieces.sergeant] -= value;
            manager.GetComponent<WLD_BuildManager>().P2_TotalInventory -= value;

            WLD_GameController.p2_Temp.Add(WLD_BuildManager.p2_sergeant);

            manager.GetComponent<UI_UIManager>().P2_SwitchButtonsOn(WLD_GameController.P2_UI_Buttons[GamePieces.sergeant]);
        }
        else if (WLD_GameController.P2_GamePieceInv[GamePieces.Private] <= 6 && WLD_GameController.P2_GamePieceInv[GamePieces.Private] >= 1 && WLD_GameController.isPrivatePressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P2_GetBuildPosition(), Quaternion.Euler(p2_xRotation, p2_yRotation, p2_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p2_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P2_GamePieceInv[GamePieces.Private] -= value;
            manager.GetComponent<WLD_BuildManager>().P2_TotalInventory -= value;

            WLD_GameController.p2_Temp.Add(WLD_BuildManager.p2_privates);

            manager.GetComponent<UI_UIManager>().P2_SwitchButtonsOn(WLD_GameController.P2_UI_Buttons[GamePieces.Private]);
        }
        else if (WLD_GameController.P2_GamePieceInv[GamePieces.Spy] <= 2 && WLD_GameController.P2_GamePieceInv[GamePieces.Spy] >= 1 && WLD_GameController.isSpyPressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P2_GetBuildPosition(), Quaternion.Euler(p2_xRotation, p2_yRotation, p2_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p2_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P2_GamePieceInv[GamePieces.Spy] -= value;
            manager.GetComponent<WLD_BuildManager>().P2_TotalInventory -= value;

            WLD_GameController.p2_Temp.Add(WLD_BuildManager.p2_spy);

            manager.GetComponent<UI_UIManager>().P2_SwitchButtonsOn(WLD_GameController.P2_UI_Buttons[GamePieces.Spy]);
        }
        else if (WLD_GameController.P2_GamePieceInv[GamePieces.P2_Flag] >= 1 && WLD_GameController.isFlagPressed)
        {
            GameObject _GamePiecePrefab = Instantiate(_gamePiecePrefab, P2_GetBuildPosition(), Quaternion.Euler(p2_xRotation, p2_yRotation, p2_zRotation));
            gamePiecePrefab = _GamePiecePrefab;

            manager.GetComponent<UI_UIManager>().p2_GamePiecePrefabTemp.Add(gamePiecePrefab);

            WLD_GameController.P2_GamePieceInv[GamePieces.P2_Flag] -= value;
            manager.GetComponent<WLD_BuildManager>().P2_TotalInventory -= value;

            WLD_GameController.p2_Temp.Add(WLD_BuildManager.p2_flag);

            manager.GetComponent<UI_UIManager>().P2_SwitchButtonsOn(WLD_GameController.P2_UI_Buttons[GamePieces.P2_Flag]);
        }
    }

    #endregion
   
} // End WLD_Node