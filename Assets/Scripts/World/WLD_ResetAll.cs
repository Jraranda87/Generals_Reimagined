/* -----------------------------------------------------------------------------------
 * Class Name: WLD_ResetAll
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

public class WLD_ResetAll : MonoBehaviour 
{
    #region Variables
    // ------------------------------------------------------------------------------
    // Public Variables
    // ------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------
    // Protected Variables
    // ------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------
    // Private Variables
    // ------------------------------------------------------------------------------
    GameObject manager;
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
    public void P1_TotalInv(int value)
    {
        manager.GetComponent<WLD_BuildManager>().P1_TotalInventory = value;
    }
    public void P1_SpyValue(int value)
    {       
        WLD_GameController.P1_GamePieceInv[GamePieces.Spy] = value;
    }
    public void P1_PrivateValue(int value)
    {
        WLD_GameController.P1_GamePieceInv[GamePieces.Private] = value;
    }
    public void P1_BasicValue(int value)
    {
        WLD_GameController.P1_GamePieceInv[GamePieces.FiveStarGeneral] = value;
        WLD_GameController.P1_GamePieceInv[GamePieces.FourStarGeneral] = value;
        WLD_GameController.P1_GamePieceInv[GamePieces.ThreeStarGeneral] = value;
        WLD_GameController.P1_GamePieceInv[GamePieces.TwoStarGenreal] = value;
        WLD_GameController.P1_GamePieceInv[GamePieces.OneStarGeneral] = value;
        WLD_GameController.P1_GamePieceInv[GamePieces.Colonel] = value;
        WLD_GameController.P1_GamePieceInv[GamePieces.LtColonel] = value;
        WLD_GameController.P1_GamePieceInv[GamePieces.Major] = value;
        WLD_GameController.P1_GamePieceInv[GamePieces.Captain] = value;
        WLD_GameController.P1_GamePieceInv[GamePieces.FirstLieutenant] = value;
        WLD_GameController.P1_GamePieceInv[GamePieces.SecondLietenant] = value;
        WLD_GameController.P1_GamePieceInv[GamePieces.sergeant] = value;
        WLD_GameController.P1_GamePieceInv[GamePieces.P1_Flag] = value;
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
   
    public void P2_TotalInv(int value)
    {
        manager.GetComponent<WLD_BuildManager>().P2_TotalInventory = value;
    }
    public void P2_SpyValue(int value)
    {        
        WLD_GameController.P2_GamePieceInv[GamePieces.Spy] = value;
    }
    public void P2_PrivateValue(int value)
    {
        WLD_GameController.P2_GamePieceInv[GamePieces.Private] = value;
    }
    public void P2_BasicValue(int value)
    {
        WLD_GameController.P2_GamePieceInv[GamePieces.FiveStarGeneral] = value;
        WLD_GameController.P2_GamePieceInv[GamePieces.FourStarGeneral] = value;
        WLD_GameController.P2_GamePieceInv[GamePieces.ThreeStarGeneral] = value;
        WLD_GameController.P2_GamePieceInv[GamePieces.TwoStarGenreal] = value;
        WLD_GameController.P2_GamePieceInv[GamePieces.OneStarGeneral] = value;
        WLD_GameController.P2_GamePieceInv[GamePieces.Colonel] = value;
        WLD_GameController.P2_GamePieceInv[GamePieces.LtColonel] = value;
        WLD_GameController.P2_GamePieceInv[GamePieces.Major] = value;
        WLD_GameController.P2_GamePieceInv[GamePieces.Captain] = value;
        WLD_GameController.P2_GamePieceInv[GamePieces.FirstLieutenant] = value;
        WLD_GameController.P2_GamePieceInv[GamePieces.SecondLietenant] = value;
        WLD_GameController.P2_GamePieceInv[GamePieces.sergeant] = value;
        WLD_GameController.P2_GamePieceInv[GamePieces.P2_Flag] = value;
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
    public void ResetAllButtonBool(bool value) // false
    {
        WLD_GameController.isFivePressed = value;
        WLD_GameController.isFourPressed = value;
        WLD_GameController.isThreePressed = value;
        WLD_GameController.isTwoPressed = value;
        WLD_GameController.isOnePressed = value;
        WLD_GameController.isColonelPressed = value;
        WLD_GameController.isLtColonelPressed = value;
        WLD_GameController.isCaptainPressed = value;
        WLD_GameController.isFirstLtPressed = value;
        WLD_GameController.isSecondPressed = value;
        WLD_GameController.isMajorPressed = value;
        WLD_GameController.isSergeantPressed = value;
        WLD_GameController.isPrivatePressed = value;
        WLD_GameController.isSpyPressed = value;
        WLD_GameController.isFlagPressed = value;
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
    public void P1_ResetAllButtons(bool value) // true
    {
        WLD_GameController.P1_UI_Buttons[GamePieces.FiveStarGeneral].interactable = value;
        WLD_GameController.P1_UI_Buttons[GamePieces.FourStarGeneral].interactable = value;
        WLD_GameController.P1_UI_Buttons[GamePieces.ThreeStarGeneral].interactable = value;
        WLD_GameController.P1_UI_Buttons[GamePieces.TwoStarGenreal].interactable = value;
        WLD_GameController.P1_UI_Buttons[GamePieces.OneStarGeneral].interactable = value;
        WLD_GameController.P1_UI_Buttons[GamePieces.Colonel].interactable = value;
        WLD_GameController.P1_UI_Buttons[GamePieces.LtColonel].interactable = value;
        WLD_GameController.P1_UI_Buttons[GamePieces.Major].interactable = value;
        WLD_GameController.P1_UI_Buttons[GamePieces.Captain].interactable = value;
        WLD_GameController.P1_UI_Buttons[GamePieces.FirstLieutenant].interactable = value;
        WLD_GameController.P1_UI_Buttons[GamePieces.SecondLietenant].interactable = value;
        WLD_GameController.P1_UI_Buttons[GamePieces.sergeant].interactable = value;
        WLD_GameController.P1_UI_Buttons[GamePieces.Private].interactable = value;
        WLD_GameController.P1_UI_Buttons[GamePieces.Spy].interactable = value;
        WLD_GameController.P1_UI_Buttons[GamePieces.P1_Flag].interactable = value;
    }
    // ------------------------------------------------------------------------------
    // Function Name: 
    // Return types: 
    // Argument types: 
    // Author: 
    // Date: 
    // ------------------------------------------------------------------------------
    // Purpose: 
    // ----------------------------------------------------------------------------
    public void P2_ResetAllButtons(bool value) //true
    {
        WLD_GameController.P2_UI_Buttons[GamePieces.FiveStarGeneral].interactable = value;
        WLD_GameController.P2_UI_Buttons[GamePieces.FourStarGeneral].interactable = value;
        WLD_GameController.P2_UI_Buttons[GamePieces.ThreeStarGeneral].interactable = value;
        WLD_GameController.P2_UI_Buttons[GamePieces.TwoStarGenreal].interactable = value;
        WLD_GameController.P2_UI_Buttons[GamePieces.OneStarGeneral].interactable = value;
        WLD_GameController.P2_UI_Buttons[GamePieces.Colonel].interactable = value;
        WLD_GameController.P2_UI_Buttons[GamePieces.LtColonel].interactable = value;
        WLD_GameController.P2_UI_Buttons[GamePieces.Major].interactable = value;
        WLD_GameController.P2_UI_Buttons[GamePieces.Captain].interactable = value;
        WLD_GameController.P2_UI_Buttons[GamePieces.FirstLieutenant].interactable = value;
        WLD_GameController.P2_UI_Buttons[GamePieces.SecondLietenant].interactable = value;
        WLD_GameController.P2_UI_Buttons[GamePieces.sergeant].interactable = value;
        WLD_GameController.P2_UI_Buttons[GamePieces.Private].interactable = value;
        WLD_GameController.P2_UI_Buttons[GamePieces.Spy].interactable = value;
        WLD_GameController.P2_UI_Buttons[GamePieces.P2_Flag].interactable = value;
    }
} // End WLD_ResetAll