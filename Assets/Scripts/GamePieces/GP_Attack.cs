/* -----------------------------------------------------------------------------------
 * Class Name: GP_Attack
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

public class GP_Attack : MonoBehaviour 
{
    #region Variables
    // ------------------------------------------------------------------------------
    // Public Variables
    // ------------------------------------------------------------------------------
    [Header("Attack Power")]
    public int attackPower;

    // ------------------------------------------------------------------------------
    // Protected Variables
    // ------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------
    // Private Variables
    // ------------------------------------------------------------------------------



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
        switch(gameObject.tag)
        {
            case UNA_Tags.FiveStarGeneral:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.FiveStarGeneral];
                break;
            case UNA_Tags.FourStarGeneral:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.FourStarGeneral];
                break;
            case UNA_Tags.ThreeStarGeneral:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.ThreeStarGeneral];
                break;
            case UNA_Tags.TwoStarGenreal:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.TwoStarGenreal];
                break;
            case UNA_Tags.OneStarGeneral:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.OneStarGeneral];
                break;
            case UNA_Tags.Colonel:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.Colonel];
                break;
            case UNA_Tags.LtColonel:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.LtColonel];
                break;
            case UNA_Tags.Major:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.Major];
                break;
            case UNA_Tags.Captain:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.Captain];
                break;
            case UNA_Tags.FirstLieutenant:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.FirstLieutenant];
                break;
            case UNA_Tags.SecondLietenant:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.SecondLietenant];
                break;
            case UNA_Tags.Sergeant:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.sergeant];
                break;
            case UNA_Tags.Private:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.Private];
                break;
            case UNA_Tags.Spy:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.Spy];
                break;
            case UNA_Tags.P1_Flag:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.P1_Flag];
                break;
        }
        switch (gameObject.tag)
        {
            case UNA_Tags.P2_FiveStarGeneral:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.FiveStarGeneral];
                break;
            case UNA_Tags.P2_FourStarGeneral:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.FourStarGeneral];
                break;
            case UNA_Tags.P2_ThreeStarGeneral:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.ThreeStarGeneral];
                break;
            case UNA_Tags.P2_TwoStarGenreal:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.TwoStarGenreal];
                break;
            case UNA_Tags.P2_OneStarGeneral:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.OneStarGeneral];
                break;
            case UNA_Tags.P2_Colonel:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.Colonel];
                break;
            case UNA_Tags.P2_LtColonel:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.LtColonel];
                break;
            case UNA_Tags.P2_Major:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.Major];
                break;
            case UNA_Tags.P2_Captain:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.Captain];
                break;
            case UNA_Tags.P2_FirstLieutenant:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.FirstLieutenant];
                break;
            case UNA_Tags.P2_SecondLietenant:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.SecondLietenant];
                break;
            case UNA_Tags.P2_Sergeant:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.sergeant];
                break;
            case UNA_Tags.P2_Private:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.Private];
                break;
            case UNA_Tags.P2_Spy:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.Spy];
                break;
            case UNA_Tags.P2_Flag:
                attackPower = WLD_GameController.gamePieceValues[GamePieces.P1_Flag];
                break;
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
   

} // End GP_Attack