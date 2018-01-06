/* -----------------------------------------------------------------------------------
 * Class Name: UI_Manager
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
using UnityEngine.UI;
public class UI_UIManager : MonoBehaviour 
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
    
    bool tempSelectionBool;
    
    public List<GameObject> p1_GamePiecePrefabTemp = new List<GameObject>();
    public List<GameObject> p2_GamePiecePrefabTemp = new List<GameObject>();

   

    Button p1_ButtonTemp;
    Button p2_ButtonTempp;
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

    void Update()
    {
        TurnOnSwitchQuestion();
        ResetSinglePiece();
        P2_DisableUiGamePieceButtons();
        P1_DisableUiGamePieceButtons();
        ModeText();
        PlayerTurnText();
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
    void ModeText()
    {
        if (manager.GetComponent<WLD_BuildManager>().IsBuildMode)
        {
            WLD_GameController.UI_Text[NonGamePieces.BuildText].enabled = true;
            WLD_GameController.UI_Text[NonGamePieces.PlayText].enabled = false;
        }
        else if (!manager.GetComponent<WLD_BuildManager>().IsBuildMode)
        {
            WLD_GameController.UI_Text[NonGamePieces.BuildText].enabled = false;
            WLD_GameController.UI_Text[NonGamePieces.PlayText].enabled = true;
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
    void PlayerTurnText()
    {
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
        {
            WLD_GameController.UI_Text[NonGamePieces.PlayerOneText].enabled = true;
            WLD_GameController.UI_Text[NonGamePieces.PlayerTwoText].enabled = false;
        }
        else if (manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn)
        {
            WLD_GameController.UI_Text[NonGamePieces.PlayerOneText].enabled = false;
            WLD_GameController.UI_Text[NonGamePieces.PlayerTwoText].enabled = true;
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
    void TurnOnSwitchQuestion()
    {
        if (manager.GetComponent<WLD_BuildManager>().P1_TotalInventory <= 0 && manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn && manager.GetComponent<WLD_BuildManager>().IsBuildMode)
        {
           
            WLD_GameController.UI_Panel[GamePieces.continuePanel].SetActive(true);
        }
        else if (manager.GetComponent<WLD_BuildManager>().P2_TotalInventory <= 0 && manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn && manager.GetComponent<WLD_BuildManager>().IsBuildMode)
        {
            WLD_GameController.UI_Panel[GamePieces.continuePanel].SetActive(true);
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
    void ResetSinglePiece()
    {
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
        {
            if (Input.GetMouseButtonDown(1) && manager.GetComponent<WLD_BuildManager>().IsBuildMode)
            {
                manager.GetComponent<WLD_ResetAll>().P1_ResetAllButtons(true);
                manager.GetComponent<WLD_ResetAll>().ResetAllButtonBool(false);
            }
        }
        else if (manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn)
        {
            if (Input.GetMouseButtonDown(1) && manager.GetComponent<WLD_BuildManager>().IsBuildMode)
            {
                manager.GetComponent<WLD_ResetAll>().P2_ResetAllButtons(true);
                manager.GetComponent<WLD_ResetAll>().ResetAllButtonBool(false);
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
    #region SwitchButtonsOff
    // ------------------------------------------------------------------------------
    // Function Name: 
    // Return types: 
    // Argument types: 
    // Author: 
    // Date: 
    // ------------------------------------------------------------------------------
    // Purpose: 
    // ------------------------------------------------------------------------------
    public void SwitchButtonsOff()
    {
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
        {
            for (int i = 0; i < WLD_GameController.p1_UIButtons.Count; i++)
            {
                if (p1_ButtonTemp == WLD_GameController.p1_UIButtons[i])
                {
                    p1_ButtonTemp.interactable = true;
                }
                else
                {
                    WLD_GameController.p1_UIButtons[i].interactable = false;
                }

            }
        }
        else if (manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn)
        {
            for (int i = 0; i < WLD_GameController.p2_UIButtons.Count; i++)
            {
                if (p2_ButtonTempp == WLD_GameController.p2_UIButtons[i])
                {
                    p2_ButtonTempp.interactable = true;
                }
                else
                {
                    WLD_GameController.p2_UIButtons[i].interactable = false;
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

    #region SwitchButtonsOn
    // ------------------------------------------------------------------------------
    // Function Name: 
    // Return types: 
    // Argument types: 
    // Author: 
    // Date: 
    // ------------------------------------------------------------------------------
    // Purpose: 
    // ------------------------------------------------------------------------------
    public void P1_SwitchButtonsOn(Button button)
    {
        Button temp = button;
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
        {
            for (int i = 0; i < WLD_GameController.p1_UIButtons.Count; i++)
            {
                if (temp == WLD_GameController.p1_UIButtons[i])
                {
                    temp.interactable = false;
                }
                else
                {
                    WLD_GameController.p1_UIButtons[i].interactable = true;
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
    public void P2_SwitchButtonsOn(Button button)
    {
        Button temp = button;

        if (manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn)
        {
            for (int i = 0; i < WLD_GameController.p2_UIButtons.Count; i++)
            {
                if (temp == WLD_GameController.p2_UIButtons[i])
                {
                    temp.interactable = false;
                }
                else
                {
                    WLD_GameController.p2_UIButtons[i].interactable = true;
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
    #region DisableButtons
   
    // ------------------------------------------------------------------------------
    // Function Name: 
    // Return types: 
    // Argument types: 
    // Author: 
    // Date: 
    // ------------------------------------------------------------------------------
    // Purpose: Disables the Button when maximum number of a particular gamepiece is played
    // ------------------------------------------------------------------------------
    void P1_DisableUiGamePieceButtons()
    {
        if (!manager.GetComponent<WLD_BuildManager>().IsBuildMode)
        {
            return;
        }
        if (!manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
        {
            return;
        }

        if (WLD_GameController.P1_GamePieceInv[GamePieces.FiveStarGeneral] <= 0)
        {
            WLD_GameController.P1_UI_Buttons[GamePieces.FiveStarGeneral].interactable = false;
        }
        if (WLD_GameController.P1_GamePieceInv[GamePieces.FourStarGeneral] <= 0)
        {
            WLD_GameController.P1_UI_Buttons[GamePieces.FourStarGeneral].interactable = false;
        }
        if (WLD_GameController.P1_GamePieceInv[GamePieces.ThreeStarGeneral] <= 0)
        {
            WLD_GameController.P1_UI_Buttons[GamePieces.ThreeStarGeneral].interactable = false;
        }
        if (WLD_GameController.P1_GamePieceInv[GamePieces.TwoStarGenreal] <= 0)
        {
            WLD_GameController.P1_UI_Buttons[GamePieces.TwoStarGenreal].interactable = false;
        }
        if (WLD_GameController.P1_GamePieceInv[GamePieces.OneStarGeneral] <= 0)
        {
            WLD_GameController.P1_UI_Buttons[GamePieces.OneStarGeneral].interactable = false;
        }
        if (WLD_GameController.P1_GamePieceInv[GamePieces.Colonel] <= 0)
        {
            WLD_GameController.P1_UI_Buttons[GamePieces.Colonel].interactable = false;
        }
        if (WLD_GameController.P1_GamePieceInv[GamePieces.LtColonel] <= 0)
        {
            WLD_GameController.P1_UI_Buttons[GamePieces.LtColonel].interactable = false;
        }
        if (WLD_GameController.P1_GamePieceInv[GamePieces.Major] <= 0)
        {
            WLD_GameController.P1_UI_Buttons[GamePieces.Major].interactable = false;
        }
        if (WLD_GameController.P1_GamePieceInv[GamePieces.Captain] <= 0)
        {
            WLD_GameController.P1_UI_Buttons[GamePieces.Captain].interactable = false;
        }
        if (WLD_GameController.P1_GamePieceInv[GamePieces.FirstLieutenant] <= 0)
        {
            WLD_GameController.P1_UI_Buttons[GamePieces.FirstLieutenant].interactable = false;
        }
        if (WLD_GameController.P1_GamePieceInv[GamePieces.SecondLietenant] <= 0)
        {
            WLD_GameController.P1_UI_Buttons[GamePieces.SecondLietenant].interactable = false;
        }
        if (WLD_GameController.P1_GamePieceInv[GamePieces.sergeant] <= 0)
        {
            WLD_GameController.P1_UI_Buttons[GamePieces.sergeant].interactable = false;
        }
        if (WLD_GameController.P1_GamePieceInv[GamePieces.Private] <= 0)
        {
            WLD_GameController.P1_UI_Buttons[GamePieces.Private].interactable = false;
        }
        if (WLD_GameController.P1_GamePieceInv[GamePieces.Spy] <= 0)
        {
            WLD_GameController.P1_UI_Buttons[GamePieces.Spy].interactable = false;
        }
        if (WLD_GameController.P1_GamePieceInv[GamePieces.P1_Flag] <= 0)
        {
            WLD_GameController.P1_UI_Buttons[GamePieces.P1_Flag].interactable = false;
        }
    }
    // ------------------------------------------------------------------------------
    // Function Name: 
    // Return types: 
    // Argument types: 
    // Author: 
    // Date: 
    // ------------------------------------------------------------------------------
    // Purpose: Disables the Button when maximum number of a particular gamepiece is played
    // ------------------------------------------------------------------------------
    void P2_DisableUiGamePieceButtons()
    {
        if (!manager.GetComponent<WLD_BuildManager>().IsBuildMode)
        {
            return;
        }
        if (!manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn)
        {
            return;
        }
        if (WLD_GameController.P2_GamePieceInv[GamePieces.FiveStarGeneral] <= 0)
        {
            WLD_GameController.P2_UI_Buttons[GamePieces.FiveStarGeneral].interactable = false;
        }
        if (WLD_GameController.P2_GamePieceInv[GamePieces.FourStarGeneral] <= 0)
        {
            WLD_GameController.P2_UI_Buttons[GamePieces.FourStarGeneral].interactable = false;
        }
        if (WLD_GameController.P2_GamePieceInv[GamePieces.ThreeStarGeneral] <= 0)
        {
            WLD_GameController.P2_UI_Buttons[GamePieces.ThreeStarGeneral].interactable = false;
        }
        if (WLD_GameController.P2_GamePieceInv[GamePieces.TwoStarGenreal] <= 0)
        {
            WLD_GameController.P2_UI_Buttons[GamePieces.TwoStarGenreal].interactable = false;
        }
        if (WLD_GameController.P2_GamePieceInv[GamePieces.OneStarGeneral] <= 0)
        {
            WLD_GameController.P2_UI_Buttons[GamePieces.OneStarGeneral].interactable = false;
        }
        if (WLD_GameController.P2_GamePieceInv[GamePieces.Colonel] <= 0)
        {
            WLD_GameController.P2_UI_Buttons[GamePieces.Colonel].interactable = false;
        }
        if (WLD_GameController.P2_GamePieceInv[GamePieces.LtColonel] <= 0)
        {
            WLD_GameController.P2_UI_Buttons[GamePieces.LtColonel].interactable = false;
        }
        if (WLD_GameController.P2_GamePieceInv[GamePieces.Major] <= 0)
        {
            WLD_GameController.P2_UI_Buttons[GamePieces.Major].interactable = false;
        }
        if (WLD_GameController.P2_GamePieceInv[GamePieces.Captain] <= 0)
        {
            WLD_GameController.P2_UI_Buttons[GamePieces.Captain].interactable = false;
        }
        if (WLD_GameController.P2_GamePieceInv[GamePieces.FirstLieutenant] <= 0)
        {
            WLD_GameController.P2_UI_Buttons[GamePieces.FirstLieutenant].interactable = false;
        }
        if (WLD_GameController.P2_GamePieceInv[GamePieces.SecondLietenant] <= 0)
        {
            WLD_GameController.P2_UI_Buttons[GamePieces.SecondLietenant].interactable = false;
        }
        if (WLD_GameController.P2_GamePieceInv[GamePieces.sergeant] <= 0)
        {
            WLD_GameController.P2_UI_Buttons[GamePieces.sergeant].interactable = false;
        }
        if (WLD_GameController.P2_GamePieceInv[GamePieces.Private] <= 0)
        {
            WLD_GameController.P2_UI_Buttons[GamePieces.Private].interactable = false;
        }
        if (WLD_GameController.P2_GamePieceInv[GamePieces.Spy] <= 0)
        {
            WLD_GameController.P2_UI_Buttons[GamePieces.Spy].interactable = false;
        }
        if (WLD_GameController.P2_GamePieceInv[GamePieces.P2_Flag] <= 0)
        {
            WLD_GameController.P2_UI_Buttons[GamePieces.P2_Flag].interactable = false;
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

    #region BulltonSelection
    // ------------------------------------------------------------------------------
    // Function Name: 
    // Return types: 
    // Argument types: 
    // Author: 
    // Date: 
    // ------------------------------------------------------------------------------
    // Purpose: 
    // ------------------------------------------------------------------------------
    public void ResignButton()
    {
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
        {
            Debug.Log("Player Two wins");
            //Link to the Stats Page
        }
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn)
        {
            Debug.Log("Player One wins");
            //Link to the Stats Page
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
    void SetFlagSpyAndPrivateFalse()
    {
        WLD_GameController.isFlagPressed = false;
        WLD_GameController.isSpyPressed = false;
        WLD_GameController.isPrivatePressed = false;
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
    public void YesSwitchTurn()
    {
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
        {
            WLD_GameController.UI_Panel[GamePieces.continuePanel].SetActive(!WLD_GameController.UI_Panel[GamePieces.continuePanel].activeSelf);

            manager.GetComponent<WLD_ResetAll>().ResetAllButtonBool(false);

            WLD_GameController.UI_Panel[GamePieces.GamePiecePanel].SetActive(false);
            WLD_GameController.UI_Panel[GamePieces.P2_gamePiecePanel].SetActive(!WLD_GameController.UI_Panel[GamePieces.P2_gamePiecePanel].activeSelf);
            WLD_GameController.UI_Panel[GamePieces.GamePiecePanelRestart].SetActive(true);

            manager.GetComponent<UI_Timer>().ResetTimer();

            manager.GetComponent<WLD_BuildManager>().P1_SwitchTurn(false);
            manager.GetComponent<WLD_BuildManager>().P2_SwitchTurn(true);
        }
        else if (manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn)
        {

            manager.GetComponent<WLD_BuildManager>().IsBuildMode = false;

            WLD_GameController.UI_Panel[GamePieces.continuePanel].SetActive(!WLD_GameController.UI_Panel[GamePieces.continuePanel].activeSelf);

            WLD_GameController.UI_Panel[GamePieces.P2_gamePiecePanel].SetActive(!WLD_GameController.UI_Panel[GamePieces.P2_gamePiecePanel].activeSelf);
            WLD_GameController.UI_Panel[GamePieces.GamePiecePanelRestart].SetActive(!WLD_GameController.UI_Panel[GamePieces.GamePiecePanelRestart].activeSelf);

            manager.GetComponent<WLD_BuildManager>().P1_SwitchTurn(true);
            manager.GetComponent<WLD_BuildManager>().P2_SwitchTurn(false);

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
    public void NoSwitchTurn()
    {
        WLD_GameController.UI_Panel[GamePieces.continuePanel].SetActive(!WLD_GameController.UI_Panel[GamePieces.continuePanel].activeSelf);
        ResetPieces();
        manager.GetComponent<UI_Timer>().ResetTimer();
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
    public void ResetPieces()
    {
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
        {
            for (int i = 0; i < p1_GamePiecePrefabTemp.Count; i++)
            {
                Destroy(p1_GamePiecePrefabTemp[i]);
            }

            manager.GetComponent<WLD_ResetAll>().P1_ResetAllButtons(true);          
            manager.GetComponent<WLD_ResetAll>().ResetAllButtonBool(false);
            manager.GetComponent<WLD_ResetAll>().P1_TotalInv(21);
            manager.GetComponent<WLD_ResetAll>().P1_SpyValue(2);
            manager.GetComponent<WLD_ResetAll>().P1_PrivateValue(6);
            manager.GetComponent<WLD_ResetAll>().P1_BasicValue(1);
        }
        else if (manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn)
        {
            for (int i = 0; i < p2_GamePiecePrefabTemp.Count; i++)
            {
                Destroy(p2_GamePiecePrefabTemp[i]);
            }

            manager.GetComponent<WLD_ResetAll>().P2_ResetAllButtons(true);
            manager.GetComponent<WLD_ResetAll>().ResetAllButtonBool(false);
            manager.GetComponent<WLD_ResetAll>().P2_TotalInv(21);
            manager.GetComponent<WLD_ResetAll>().P2_SpyValue(2);
            manager.GetComponent<WLD_ResetAll>().P2_PrivateValue(6);
            manager.GetComponent<WLD_ResetAll>().P2_BasicValue(1);
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
    public void SelectFiveStarGeneral()
    {
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
        {
            manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P1_GamePieces[GamePieces.FiveStarGeneral]);
        }
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn)
        {
            manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P2_GamePieces[GamePieces.FiveStarGeneral]);
        }
        WLD_GameController.isFivePressed = true;
        
        p1_ButtonTemp = WLD_GameController.P1_UI_Buttons[GamePieces.FiveStarGeneral];
        p2_ButtonTempp = WLD_GameController.P2_UI_Buttons[GamePieces.FiveStarGeneral];
        SwitchButtonsOff();

        SetFlagSpyAndPrivateFalse();
    }
    public void SelectFourStarGeneral()
    {
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
        {
            manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P1_GamePieces[GamePieces.FourStarGeneral]);
        }
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn)
        {
            manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P2_GamePieces[GamePieces.FourStarGeneral]);
        }

        WLD_GameController.isFourPressed = true;

        p1_ButtonTemp = WLD_GameController.P1_UI_Buttons[GamePieces.FourStarGeneral];
        p2_ButtonTempp = WLD_GameController.P2_UI_Buttons[GamePieces.FourStarGeneral];
        SwitchButtonsOff();
        SetFlagSpyAndPrivateFalse();
    }
    public void SelectThreeStarGeneral()
    {
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
        {
            manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P1_GamePieces[GamePieces.ThreeStarGeneral]);
        }
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn)
        {
            manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P2_GamePieces[GamePieces.ThreeStarGeneral]);
        }

        WLD_GameController.isThreePressed = true;
       
        p1_ButtonTemp = WLD_GameController.P1_UI_Buttons[GamePieces.ThreeStarGeneral];
        p2_ButtonTempp = WLD_GameController.P2_UI_Buttons[GamePieces.ThreeStarGeneral];
        SwitchButtonsOff();
        SetFlagSpyAndPrivateFalse();
    }
    public void SelectTwoStarGeneral()
    {
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
        {
            manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P1_GamePieces[GamePieces.TwoStarGenreal]);
        }
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn)
        {
            manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P2_GamePieces[GamePieces.TwoStarGenreal]);
        }

        WLD_GameController.isTwoPressed = true;
        SetFlagSpyAndPrivateFalse();
        p1_ButtonTemp = WLD_GameController.P1_UI_Buttons[GamePieces.TwoStarGenreal];
        p2_ButtonTempp = WLD_GameController.P2_UI_Buttons[GamePieces.TwoStarGenreal];
        SwitchButtonsOff();
    }
    public void SelectOneStarGeneral()
    {
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
        {
            manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P1_GamePieces[GamePieces.OneStarGeneral]);
        }
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn)
        {
            manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P2_GamePieces[GamePieces.OneStarGeneral]);
        }

        WLD_GameController.isOnePressed = true;
        SetFlagSpyAndPrivateFalse();
        p1_ButtonTemp = WLD_GameController.P1_UI_Buttons[GamePieces.OneStarGeneral];
        p2_ButtonTempp = WLD_GameController.P2_UI_Buttons[GamePieces.OneStarGeneral];
        SwitchButtonsOff();
    }
    public void SelectColonel()
    {
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
        {
            manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P1_GamePieces[GamePieces.Colonel]);
        }
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn)
        {
            manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P2_GamePieces[GamePieces.Colonel]);
        }

        WLD_GameController.isColonelPressed = true;
        SetFlagSpyAndPrivateFalse();
        p1_ButtonTemp = WLD_GameController.P1_UI_Buttons[GamePieces.Colonel];
        p2_ButtonTempp = WLD_GameController.P2_UI_Buttons[GamePieces.Colonel];
        SwitchButtonsOff();
    }
    public void SelectLTColonel()
    {
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
        {
            manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P1_GamePieces[GamePieces.LtColonel]);
        }
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn)
        {
            manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P2_GamePieces[GamePieces.LtColonel]);
        }

        WLD_GameController.isLtColonelPressed = true;
        SetFlagSpyAndPrivateFalse();
        p1_ButtonTemp = WLD_GameController.P1_UI_Buttons[GamePieces.LtColonel];
        p2_ButtonTempp = WLD_GameController.P2_UI_Buttons[GamePieces.LtColonel];
        SwitchButtonsOff();
    }
    public void SelectMajor()
    {
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
        {
            manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P1_GamePieces[GamePieces.Major]);
        }
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn)
        {
            manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P2_GamePieces[GamePieces.Major]);
        }

        WLD_GameController.isMajorPressed = true;
        SetFlagSpyAndPrivateFalse();
        p1_ButtonTemp = WLD_GameController.P1_UI_Buttons[GamePieces.Major];
        p2_ButtonTempp = WLD_GameController.P2_UI_Buttons[GamePieces.Major];
        SwitchButtonsOff();
    }
    public void SelectCaptain()
    {
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
        {
            manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P1_GamePieces[GamePieces.Captain]);
        }
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn)
        {
            manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P2_GamePieces[GamePieces.Captain]);
        }

        WLD_GameController.isCaptainPressed = true;
        SetFlagSpyAndPrivateFalse();
        p1_ButtonTemp = WLD_GameController.P1_UI_Buttons[GamePieces.Captain];
        p2_ButtonTempp = WLD_GameController.P2_UI_Buttons[GamePieces.Captain];
        SwitchButtonsOff();
    }
    public void SelectFirstLT()
    {
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
        {
            manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P1_GamePieces[GamePieces.FirstLieutenant]);
        }
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn)
        {
            manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P2_GamePieces[GamePieces.FirstLieutenant]);
        }

        WLD_GameController.isFirstLtPressed = true;
        SetFlagSpyAndPrivateFalse();
        p1_ButtonTemp = WLD_GameController.P1_UI_Buttons[GamePieces.FirstLieutenant];
        p2_ButtonTempp = WLD_GameController.P2_UI_Buttons[GamePieces.FirstLieutenant];
        SwitchButtonsOff();
    }
    public void SelectSecondLt()
    {
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
        {
            manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P1_GamePieces[GamePieces.SecondLietenant]);
        }
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn)
        {
            manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P2_GamePieces[GamePieces.SecondLietenant]);
        }

        WLD_GameController.isSecondPressed = true;
        SetFlagSpyAndPrivateFalse();
        p1_ButtonTemp = WLD_GameController.P1_UI_Buttons[GamePieces.SecondLietenant];
        p2_ButtonTempp = WLD_GameController.P2_UI_Buttons[GamePieces.SecondLietenant];
        SwitchButtonsOff();
    }
    public void SelectSergeant()
    {
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
        {
            manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P1_GamePieces[GamePieces.sergeant]);
        }
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn)
        {
            manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P2_GamePieces[GamePieces.sergeant]);
        }

        WLD_GameController.isSergeantPressed = true;
        SetFlagSpyAndPrivateFalse();
        p1_ButtonTemp = WLD_GameController.P1_UI_Buttons[GamePieces.sergeant];
        p2_ButtonTempp = WLD_GameController.P2_UI_Buttons[GamePieces.sergeant];
        SwitchButtonsOff();
    }
    public void SelectPrivate()
    {
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
        {
            manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P1_GamePieces[GamePieces.Private]);
        }
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn)
        {
            manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P2_GamePieces[GamePieces.Private]);
        }

        WLD_GameController.isPrivatePressed = true;
        WLD_GameController.isFlagPressed = false;
        WLD_GameController.isSpyPressed = false;
        p1_ButtonTemp = WLD_GameController.P1_UI_Buttons[GamePieces.Private];
        p2_ButtonTempp = WLD_GameController.P2_UI_Buttons[GamePieces.Private];
        SwitchButtonsOff();
    }
    public void SelectSpy()
    {
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
        {
            manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P1_GamePieces[GamePieces.Spy]);
        }
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn)
        {
            manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P2_GamePieces[GamePieces.Spy]);
        }

        WLD_GameController.isSpyPressed = true;
        WLD_GameController.isFlagPressed = false;
        WLD_GameController.isPrivatePressed = false;
        p1_ButtonTemp = WLD_GameController.P1_UI_Buttons[GamePieces.Spy];
        p2_ButtonTempp = WLD_GameController.P2_UI_Buttons[GamePieces.Spy];
        SwitchButtonsOff();
    }
    public void P1_SelectFlag()
    {
        manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P1_GamePieces[GamePieces.P1_Flag]);

        WLD_GameController.isFlagPressed = true;
        WLD_GameController.isSpyPressed = false;
        WLD_GameController.isPrivatePressed = false;
        p1_ButtonTemp = WLD_GameController.P1_UI_Buttons[GamePieces.P1_Flag];
        SwitchButtonsOff();
    }
    public void P2_SelectFlag()
    {
        manager.GetComponent<WLD_BuildManager>().SelecGamePieceToBuild(WLD_GameController.P2_GamePieces[GamePieces.P2_Flag]);

        WLD_GameController.isFlagPressed = true;
        WLD_GameController.isSpyPressed = false;
        WLD_GameController.isPrivatePressed = false;
        p2_ButtonTempp = WLD_GameController.P2_UI_Buttons[GamePieces.P2_Flag];
        SwitchButtonsOff();
    }
    #endregion

    
} // End UI_Manager