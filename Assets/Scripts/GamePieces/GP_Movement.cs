/* -----------------------------------------------------------------------------------
 * Class Name: Wld_Movement
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

public class GP_Movement : MonoBehaviour 
{
    #region Variables
    // ------------------------------------------------------------------------------
    // Public Variables
    // ------------------------------------------------------------------------------

    public int gridWidth = 3;
    public int gridHieght = 3;


    // ------------------------------------------------------------------------------
    // Protected Variables
    // ------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------
    // Private Variables
    // ------------------------------------------------------------------------------
    private Vector3 screenPoint;
    private Vector3 offset;
    GameObject manager;
    Vector3 positionTemp;

    
    public static GameObject temp;
    public static GameObject p2_temp;

    Vector3 placementUp = new Vector3(0, 0, 2.2f);
    Vector3 placementDown = new Vector3(0, 0, -2.2f);
    Vector3 placementLeft = new Vector3(-2.2f, 0, 0);
    Vector3 placementRight = new Vector3(2.2f, 0, 0);
    #endregion

    #region Getters/Setters

    public Vector3 PoistionTemp
    {
        get { return positionTemp; }
        set { positionTemp = value; }
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
        CancelSelection();
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
    public void GetNodePositions()
    {

        manager.GetComponent<WLD_BuildManager>().PlacementUp = gameObject.transform.position + placementUp;
        manager.GetComponent<WLD_BuildManager>().PlacementDown = gameObject.transform.position + placementDown;
        manager.GetComponent<WLD_BuildManager>().PlacementLeft = gameObject.transform.position + placementLeft;
        manager.GetComponent<WLD_BuildManager>().PlacementRight = gameObject.transform.position + placementRight;
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
    void OnMouseDown()
    {
        if (!manager.GetComponent<WLD_BuildManager>().IsBuildMode)
        {
            if (manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
            {
                for (int i = 0; i < WLD_GameController.P1_tagNames.Count; i++)
                {
                    if (gameObject.tag == WLD_GameController.P1_tagNames[i])
                    {
                        if (WLD_GameController.p1_chosenGamePiece.Count <= 0)
                        {
                            WLD_GameController.p1_chosenGamePiece.Add(gameObject);

                            GetNodePositions();

                            WLD_BuildManager.isPlaceMode = true;
                        }
                    }
                }
            }
            if (manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn)
            {
                for (int i = 0; i < WLD_GameController.P2_tagNames.Count; i++)
                {
                    if (gameObject.tag == WLD_GameController.P2_tagNames[i])
                    {
                        if (WLD_GameController.p2_chosenGamePiece.Count <= 0)
                        {
                            WLD_GameController.p2_chosenGamePiece.Add(gameObject);

                            GetNodePositions();

                            WLD_BuildManager.isPlaceMode = true;
                        }
                    }
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
    void CancelSelection()
    {
        if (manager.GetComponent<WLD_BuildManager>().IsPlayerOneTurn)
        {
            if (Input.GetMouseButtonDown(1) && WLD_GameController.p1_chosenGamePiece[0] != null)
            {
                WLD_GameController.p1_chosenGamePiece.Remove(WLD_GameController.p1_chosenGamePiece[0]);
                WLD_BuildManager.isPlaceMode = false;
            }

        }
        else if (manager.GetComponent<WLD_BuildManager>().IsPlayerTwoTurn)
        {
            if (Input.GetMouseButtonDown(1) && WLD_GameController.p2_chosenGamePiece[0] != null)
            {
                WLD_GameController.p2_chosenGamePiece.Remove(WLD_GameController.p2_chosenGamePiece[0]);
                WLD_BuildManager.isPlaceMode = false;
            }

        }
    }
    //void OnMouseDown()
    //{
    //    Debug.Log("Mouse Down");

    //    screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

    //    offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    //}

    //void OnMouseDrag()
    //{
    //    Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

    //    Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
    //    transform.position = curPosition;
    //}
} // End Wld_Movement