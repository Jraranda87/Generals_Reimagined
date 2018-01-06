/* -----------------------------------------------------------------------------------
 * Class Name: WLD_BuildManager
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

public class WLD_BuildManager : MonoBehaviour
{
    #region Variables
    // ------------------------------------------------------------------------------
    // Public Variables
    // ------------------------------------------------------------------------------
 
    // ------------------------------------------------------------------------------
    // Purpose: 
    // ------------------------------------------------------------------------------   
    public static GameObject spy, fiveGeneral, fourGeneral, threeGeneral, twoGeneral, oneGeneral, colonel, ltColonel, major,
              captain, firstLieutenant, secLieutenant, sergeant, privates, flag;
    // ------------------------------------------------------------------------------
    // Purpose: 
    // ------------------------------------------------------------------------------
    public static GameObject p2_spy, p2_fiveGeneral, p2_fourGeneral, p2_threeGeneral, p2_twoGeneral, p2_oneGeneral, p2_colonel, p2_ltColonel, p2_major,
               p2_captain, p2_firstLieutenant, p2_secLieutenant, p2_sergeant, p2_privates, p2_flag;
    // ------------------------------------------------------------------------------
    // Purpose: 
    // ------------------------------------------------------------------------------
    public static bool isPlaceMode;
    // ------------------------------------------------------------------------------
    // Protected Variables
    // ------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------
    // Private Variables
    // ------------------------------------------------------------------------------
    // ------------------------------------------------------------------------------
    // Purpose: 
    // ------------------------------------------------------------------------------
    WLD_Node selectedNode;
    GameObject gamePieceOn, manager;
    // ------------------------------------------------------------------------------
    // Purpose: 
    // ------------------------------------------------------------------------------
    int p1_TotalInv = 21, p2_TotalInv = 21;
    // ------------------------------------------------------------------------------
    // Purpose: 
    // ------------------------------------------------------------------------------
    bool isNotInBuildMode = true, isPlayerOneTurn = true, isPlayerTwoTurn = false;
    // ------------------------------------------------------------------------------
    // Purpose: 
    // ------------------------------------------------------------------------------
    Vector3 placementUp;
    Vector3 placementDown;
    Vector3 placementLeft;
    Vector3 placementRight;

   
    #endregion

    #region Getters/Setters
    public bool CanBuild { get { return gamePieceOn != null; } }

    public bool IsBuildMode
    {
        get { return isNotInBuildMode; }
        set { isNotInBuildMode = value; }
    }
    public int P1_TotalInventory
    {
        get { return p1_TotalInv; }
        set { p1_TotalInv = value; }
    }
    public int P2_TotalInventory
    {
        get { return p2_TotalInv; }
        set { p2_TotalInv = value; }
    }
    public bool IsPlayerOneTurn
    {
        get { return isPlayerOneTurn; }
        set { isPlayerOneTurn = value; }
    }
    public bool IsPlayerTwoTurn
    {
        get { return isPlayerTwoTurn; }
        set { isPlayerTwoTurn = value; }
    }
    public Vector3 PlacementUp
    {
        get { return placementUp; }
        set { placementUp = value; }
    }
    public Vector3 PlacementDown
    {
        get { return placementDown; }
        set { placementDown = value; }
    }
    public Vector3 PlacementLeft
    {
        get { return placementLeft; }
        set { placementLeft = value; }
    }
    public Vector3 PlacementRight
    {
        get { return placementRight; }
        set { placementRight = value; }
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

        PlayerOneAssignment();
        PlayerTwoAssignment();
       
    }
    void Update()
    {
        SwitchCamera();
        //Draw();

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
    public void P1_SwitchTurn(bool value)
    {
        IsPlayerOneTurn = value;
    }
    public void P2_SwitchTurn(bool value)
    {
        isPlayerTwoTurn = value;
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
    void EndGame()
    {
        if (WLD_GameController.p1_Flag <= 0)
        {
            //Place end UI here
            Debug.Log("Player Two Wins");
        }
        else if (WLD_GameController.p2_Flag <= 0)
        {
            //Place end UI here
            Debug.Log("Player One Wins");
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
    //void Draw()
    //{
    //    if (!IsBuildMode)
    //    {
    //        for (int i = 0; i < p1_Temp.Count; i++)
    //        {
    //            if (p1_Temp.Count == 1 )
    //            {
    //                if (p1_EndPiece.Count <= 1)
    //                {
    //                    switch (p1_Temp[i].tag)
    //                    {
    //                        case UNA_Tags.FiveStarGeneral:
    //                            p1_EndPiece.Add(WLD_GameController.P1_GamePieces[GamePieces.FiveStarGeneral]);
    //                            break;
    //                        case UNA_Tags.FourStarGeneral:
    //                            p1_EndPiece.Add(WLD_GameController.P1_GamePieces[GamePieces.FourStarGeneral]);
    //                            break;
    //                        case UNA_Tags.ThreeStarGeneral:
    //                            p1_EndPiece.Add(WLD_GameController.P1_GamePieces[GamePieces.ThreeStarGeneral]);
    //                            break;
    //                        case UNA_Tags.TwoStarGenreal:
    //                            p1_EndPiece.Add(WLD_GameController.P1_GamePieces[GamePieces.TwoStarGenreal]);
    //                            break;
    //                        case UNA_Tags.OneStarGeneral:
    //                            p1_EndPiece.Add(WLD_GameController.P1_GamePieces[GamePieces.OneStarGeneral]);
    //                            break;
    //                        case UNA_Tags.Colonel:
    //                            p1_EndPiece.Add(WLD_GameController.P1_GamePieces[GamePieces.Colonel]);
    //                            break;
    //                        case UNA_Tags.LtColonel:
    //                            p1_EndPiece.Add(WLD_GameController.P1_GamePieces[GamePieces.LtColonel]);
    //                            break;
    //                        case UNA_Tags.Major:
    //                            p1_EndPiece.Add(WLD_GameController.P1_GamePieces[GamePieces.Major]);
    //                            break;
    //                        case UNA_Tags.Captain:
    //                            p1_EndPiece.Add(WLD_GameController.P1_GamePieces[GamePieces.Captain]);
    //                            break;
    //                        case UNA_Tags.FirstLieutenant:
    //                            p1_EndPiece.Add(WLD_GameController.P1_GamePieces[GamePieces.FirstLieutenant]);
    //                            break;
    //                        case UNA_Tags.SecondLietenant:
    //                            p1_EndPiece.Add(WLD_GameController.P1_GamePieces[GamePieces.SecondLietenant]);
    //                            break;
    //                        case UNA_Tags.Sergeant:
    //                            p1_EndPiece.Add(WLD_GameController.P1_GamePieces[GamePieces.sergeant]);
    //                            break;
    //                        case UNA_Tags.Private:
    //                            p1_EndPiece.Add(WLD_GameController.P1_GamePieces[GamePieces.Private]);
    //                            break;
    //                        case UNA_Tags.Spy:
    //                            p1_EndPiece.Add(WLD_GameController.P1_GamePieces[GamePieces.Spy]);
    //                            break;
    //                        default:
    //                            break;
    //                    }
    //                }                  
    //            }
    //        }
    //        for (int i = 0; i < p2_Temp.Count; i++)
    //        {
    //            if (p2_Temp.Count == 1)
    //            {
    //                if (p2_EndPiece.Count <= 1)
    //                {
    //                    switch (p2_Temp[i].tag)
    //                    {
    //                        case UNA_Tags.P2_FiveStarGeneral:
    //                            p2_EndPiece.Add(WLD_GameController.P1_GamePieces[GamePieces.FiveStarGeneral]);
    //                            break;
    //                        case UNA_Tags.P2_FourStarGeneral:
    //                            p2_EndPiece.Add(WLD_GameController.P1_GamePieces[GamePieces.FourStarGeneral]);
    //                            break;
    //                        case UNA_Tags.P2_ThreeStarGeneral:
    //                            p2_EndPiece.Add(WLD_GameController.P1_GamePieces[GamePieces.ThreeStarGeneral]);
    //                            break;
    //                        case UNA_Tags.P2_TwoStarGenreal:
    //                            p2_EndPiece.Add(WLD_GameController.P1_GamePieces[GamePieces.TwoStarGenreal]);
    //                            break;
    //                        case UNA_Tags.P2_OneStarGeneral:
    //                            p2_EndPiece.Add(WLD_GameController.P1_GamePieces[GamePieces.OneStarGeneral]);
    //                            break;
    //                        case UNA_Tags.P2_Colonel:
    //                            p2_EndPiece.Add(WLD_GameController.P1_GamePieces[GamePieces.Colonel]);
    //                            break;
    //                        case UNA_Tags.P2_LtColonel:
    //                            p2_EndPiece.Add(WLD_GameController.P1_GamePieces[GamePieces.LtColonel]);
    //                            break;
    //                        case UNA_Tags.P2_Major:
    //                            p2_EndPiece.Add(WLD_GameController.P1_GamePieces[GamePieces.Major]);
    //                            break;
    //                        case UNA_Tags.P2_Captain:
    //                            p2_EndPiece.Add(WLD_GameController.P1_GamePieces[GamePieces.Captain]);
    //                            break;
    //                        case UNA_Tags.P2_FirstLieutenant:
    //                            p2_EndPiece.Add(WLD_GameController.P1_GamePieces[GamePieces.FirstLieutenant]);
    //                            break;
    //                        case UNA_Tags.P2_SecondLietenant:
    //                            p2_EndPiece.Add(WLD_GameController.P1_GamePieces[GamePieces.SecondLietenant]);
    //                            break;
    //                        case UNA_Tags.P2_Sergeant:
    //                            p2_EndPiece.Add(WLD_GameController.P1_GamePieces[GamePieces.sergeant]);
    //                            break;
    //                        case UNA_Tags.P2_Private:
    //                            p2_EndPiece.Add(WLD_GameController.P1_GamePieces[GamePieces.Private]);
    //                            break;
    //                        case UNA_Tags.P2_Spy:
    //                            p2_EndPiece.Add(WLD_GameController.P1_GamePieces[GamePieces.Spy]);
    //                            break;
    //                        default:
    //                            break;
    //                    }
    //                }                 
    //            }
    //        }
    //    }

    //    if (p1_EndPiece.Count == p2_EndPiece.Count)
    //    {
    //        for (int i = 0; i < p1_EndPiece.Count; i++)
    //        {
    //            for (int b = 0; b < p2_EndPiece.Count; b++)
    //            {
    //                if (p1_EndPiece[i] == p2_EndPiece[i])
    //                {
    //                    Debug.Log("Draw");

    //                    //Place end UI here
    //                }
    //            }
    //        }
    //    }
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
    void SwitchCamera()
    {
        if (IsPlayerOneTurn)
        {
            WLD_GameController.Cameras[NonGamePieces.playerOneCamera].SetActive(true);
            WLD_GameController.Cameras[NonGamePieces.PlayerTwoCamera].SetActive(false);
        }
        else if (IsPlayerTwoTurn)
        {
            WLD_GameController.Cameras[NonGamePieces.PlayerTwoCamera].SetActive(true);
            WLD_GameController.Cameras[NonGamePieces.playerOneCamera].SetActive(false);

        }

    }
   
    // ------------------------------------------------------------------------------
    // Function Name: 
    // Return types: 
    // Argument types: 
    // Author: 
    // Date: 
    // ------------------------------------------------------------------------------
    // Purpose: Called from the GamePice Manager 
    // ------------------------------------------------------------------------------
    public void SelecGamePieceToBuild(GameObject gamePiece)
    {
        gamePieceOn = gamePiece;

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
    public GameObject GetGamePieceToBuild()
    {
        return gamePieceOn;
    }

    void PlayerOneAssignment()
    {
        fiveGeneral = WLD_GameController.P1_GamePieces[GamePieces.FiveStarGeneral];
        fourGeneral = WLD_GameController.P1_GamePieces[GamePieces.FourStarGeneral];
        threeGeneral = WLD_GameController.P1_GamePieces[GamePieces.ThreeStarGeneral];
        twoGeneral = WLD_GameController.P1_GamePieces[GamePieces.TwoStarGenreal];
        oneGeneral = WLD_GameController.P1_GamePieces[GamePieces.OneStarGeneral];
        colonel = WLD_GameController.P1_GamePieces[GamePieces.Colonel];
        ltColonel = WLD_GameController.P1_GamePieces[GamePieces.LtColonel];
        major = WLD_GameController.P1_GamePieces[GamePieces.Major];
        captain = WLD_GameController.P1_GamePieces[GamePieces.Captain];
        firstLieutenant = WLD_GameController.P1_GamePieces[GamePieces.FirstLieutenant];
        secLieutenant = WLD_GameController.P1_GamePieces[GamePieces.SecondLietenant];
        sergeant = WLD_GameController.P1_GamePieces[GamePieces.sergeant];
        privates = WLD_GameController.P1_GamePieces[GamePieces.Private];
        spy = WLD_GameController.P1_GamePieces[GamePieces.Spy];
        flag = WLD_GameController.P1_GamePieces[GamePieces.P1_Flag];
    }
    void PlayerTwoAssignment()
    {
        p2_fiveGeneral = WLD_GameController.P2_GamePieces[GamePieces.FiveStarGeneral];
        p2_fourGeneral = WLD_GameController.P2_GamePieces[GamePieces.FourStarGeneral];
        p2_threeGeneral = WLD_GameController.P2_GamePieces[GamePieces.ThreeStarGeneral];
        p2_twoGeneral = WLD_GameController.P2_GamePieces[GamePieces.TwoStarGenreal];
        p2_oneGeneral = WLD_GameController.P2_GamePieces[GamePieces.OneStarGeneral];
        p2_colonel = WLD_GameController.P2_GamePieces[GamePieces.Colonel];
        p2_ltColonel = WLD_GameController.P2_GamePieces[GamePieces.LtColonel];
        p2_major = WLD_GameController.P2_GamePieces[GamePieces.Major];
        p2_captain = WLD_GameController.P2_GamePieces[GamePieces.Captain];
        p2_firstLieutenant = WLD_GameController.P2_GamePieces[GamePieces.FirstLieutenant];
        p2_secLieutenant = WLD_GameController.P2_GamePieces[GamePieces.SecondLietenant];
        p2_sergeant = WLD_GameController.P2_GamePieces[GamePieces.sergeant];
        p2_privates = WLD_GameController.P2_GamePieces[GamePieces.Private];
        p2_spy = WLD_GameController.P2_GamePieces[GamePieces.Spy];
        p2_flag = WLD_GameController.P2_GamePieces[GamePieces.P2_Flag];
    }
} // End WLD_BuildManager