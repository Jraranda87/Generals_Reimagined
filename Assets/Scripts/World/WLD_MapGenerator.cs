/* -----------------------------------------------------------------------------------
 * Class Name: WLD_MapGenerator
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

public class WLD_MapGenerator : MonoBehaviour 
{
    #region Variables
    // ------------------------------------------------------------------------------
    // Public Variables
    // ------------------------------------------------------------------------------
    public Transform tilePrefabe;
  
    public int gridWidth = 9;
    public int gridHieght = 8;

    public float gap = 0;

    // ------------------------------------------------------------------------------
    // Protected Variables
    // ------------------------------------------------------------------------------


    public static List<Transform> nodeTransform = new List<Transform>();
    // ------------------------------------------------------------------------------
    // Private Variables
    // ------------------------------------------------------------------------------
 
    float nodeWidth = 2;
    float nodeHight = 2;
    Vector3 startPos;

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
        AddGap();
        CalculateStartPos();
        CreateGrid();
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

    void AddGap()
    {
        nodeHight += nodeHight * gap;
        nodeWidth += nodeWidth * gap;
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
    void CalculateStartPos()
    {
        startPos = Vector3.zero;
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
    Vector3 CalcWorldPos(Vector2 gridPos)
    {
        float offset = 0;

        float x = startPos.x + gridPos.x * nodeWidth + offset;
        float z = startPos.z + gridPos.y * nodeHight * 1;

        return new Vector3(x, 0, z);
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
     void CreateGrid()
     {
        string holderName = "GameBoard";

        if (transform.Find(holderName))
        {
            DestroyImmediate(transform.Find(holderName).gameObject);
        }

        Transform mapHolder = new GameObject(holderName).transform;

        mapHolder.parent = transform;

        for (int x = 0; x < gridHieght; x++)
        {
            for (int y = 0; y < gridWidth; y++)
            {
                Transform newTile = Instantiate(tilePrefabe) as Transform;
                
                Vector2 gridPos = new Vector2(x,y);
                newTile.position = CalcWorldPos(gridPos);

                nodeTransform.Add(newTile);

                newTile.parent = mapHolder;

                if (newTile.position.z <= 7)
                {
                    newTile.tag = UNA_Tags.PlayerOne;
                }
                else
                {
                    newTile.tag = UNA_Tags.PlayerTwo;
                }
           
            }
        }  
    }

} // End WLD_MapGenerator