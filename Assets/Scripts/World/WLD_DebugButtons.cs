/* -----------------------------------------------------------------------------------
 * Class Name: WLD_DebugButtons
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

public class WLD_DebugButtons : MonoBehaviour 
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
    GameObject managers;
    int shortCut = 0;

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
        managers = WLD_GameController.managers;
    }
    void Update()
    {
        if (managers.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                managers.GetComponent<WLD_BuildManager>().P1_TotalInventory = shortCut;
            }
        }      
        else
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                managers.GetComponent<WLD_BuildManager>().P2_TotalInventory = shortCut;
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


} // End WLD_DebugButtons