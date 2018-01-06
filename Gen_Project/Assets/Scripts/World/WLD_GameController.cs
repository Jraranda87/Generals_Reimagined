/* -----------------------------------------------------------------------------------
 * Class Name: WLD_GameController
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

public enum GamePieces
{
    FiveStarGeneral, FourStarGeneral, ThreeStarGeneral, TwoStarGenreal, OneStarGeneral, Colonel,
    LtColonel, Major, Captain, FirstLieutenant, SecondLietenant, sergeant, Spy, Private, P2_Flag, P1_Flag, GamePiecePanel, P2_gamePiecePanel, GamePiecePanelRestart, continuePanel,
    
}
public enum GameBoardColors
{
    OpenSlot, CloasedSlot, NormalSlot
}
public enum NonGamePieces
{
    playerOneCamera, PlayerTwoCamera, BuildText, PlayText, PlayerOneText, PlayerTwoText, PlayerOneTimerText, PlayerTwoTimerText
}

public class WLD_GameController : MonoBehaviour
{
    #region Variables
    // ------------------------------------------------------------------------------
    // Public Variables
    // ------------------------------------------------------------------------------
    //public static Dictionary<GamePieces, GameObject> gamePieces = new Dictionary<GamePieces, GameObject>();
    public static Dictionary<GamePieces, int> gamePieceValues = new Dictionary<GamePieces, int>(); 
    public static Dictionary<GamePieces, int> P1_GamePieceInv = new Dictionary<GamePieces, int>();
    public static Dictionary<GamePieces, int> P2_GamePieceInv = new Dictionary<GamePieces, int>();

    public static Dictionary<GamePieces, GameObject> UI_Panel = new Dictionary<GamePieces, GameObject>();  
    public static Dictionary<GamePieces, GameObject> P1_GamePieces = new Dictionary<GamePieces, GameObject>();
    public static Dictionary<GamePieces, GameObject> P2_GamePieces = new Dictionary<GamePieces, GameObject>();
    public static Dictionary<NonGamePieces, GameObject> Cameras = new Dictionary<NonGamePieces, GameObject>();

    public static Dictionary<GamePieces, Button> P1_UI_Buttons = new Dictionary<GamePieces, Button>();
    public static Dictionary<GamePieces, Button> P2_UI_Buttons = new Dictionary<GamePieces, Button>();

    public static Dictionary<GamePieces, Image> UI_Images = new Dictionary<GamePieces, Image>();

    public static Dictionary<NonGamePieces, Text> UI_Text = new Dictionary<NonGamePieces, Text>();

    public static Dictionary<GameBoardColors, Color32> boardColors = new Dictionary<GameBoardColors, Color32>();

    public static List<Button> p1_UIButtons = new List<Button>();
    public static List<Button> p2_UIButtons = new List<Button>();

    public static List<int> p1_Inventory = new List<int>();
    public static List<int> p2_Inventory = new List<int>();
    public static List<int> p1_ListPieceInventory = new List<int>();
    public static List<int> p2_ListPieceInventory = new List<int>();

    public static List<string> P1_tagNames = new List<string>();
    public static List<string> P2_tagNames = new List<string>();

    public static List<float> p1_EndGameTransform = new List<float>();
    public static List<float> p2_EndGameTransform = new List<float>();

    public static List<int> DrawCount = new List<int>();

    public static List<GameObject> p1_chosenGamePiece = new List<GameObject>();
    public static List<GameObject> p2_chosenGamePiece = new List<GameObject>();
    public static List<GameObject> p1_Temp = new List<GameObject>();
    public static List<GameObject> p2_Temp = new List<GameObject>();

    //public static List<Vector3> p1_EndGameFlagLocation = new List<Vector3>();
    //public static List<GameObject> p1_EndPiece = new List<GameObject>();
    //public static List<GameObject> p2_EndPiece = new List<GameObject>();

    [Header("UI Panel")]
    [SerializeField]
    private GameObject p1_gamePiecePanel;
    [SerializeField]
    private GameObject p2_gamePiecePanel;
    [SerializeField]
    private GameObject continuePanel;
    [SerializeField]
    private GameObject gamePiecePanelRestart;

    [Header("UI Text")]
    [SerializeField]
    private Text buildText;
    [SerializeField]
    private Text playText;
    [SerializeField]
    private Text playerOneText;
    [SerializeField]
    private Text playerTwoText;
    [SerializeField]
    private Text playerOneTimer;
    [SerializeField]
    private Text playerTwoTimer;

    [Header("Player One Prefabs")]
    [SerializeField]
    private GameObject fiveStarGeneralGO;
    [SerializeField]
    private GameObject fourStarGeneralGO;
    [SerializeField]
    private GameObject threeStarGeneralGO;
    [SerializeField]
    private GameObject twoStarGeneralGO;
    [SerializeField]
    private GameObject oneStarGeneralGO;
    [SerializeField]
    private GameObject colonelGO;
    [SerializeField]
    private GameObject ltColonelGO;
    [SerializeField]
    private GameObject majorGO;
    [SerializeField]
    private GameObject captainGO;
    [SerializeField]
    private GameObject firstLieutenatntGO;
    [SerializeField]
    private GameObject secondLieutenatntGO;
    [SerializeField]
    private GameObject sergeantGO;
    [SerializeField]
    private GameObject privatesGO;
    [SerializeField]
    private GameObject spyGO;
    [SerializeField]
    private GameObject p1_flagGO; 

    [Header("Player Two Prefabs")]
    [SerializeField]
    private GameObject p2_fiveStarGeneralGO;
    [SerializeField]
    private GameObject p2_fourStarGeneralGO;
    [SerializeField]
    private GameObject p2_threeStarGeneralGO;
    [SerializeField]
    private GameObject p2_twoStarGeneralGO;
    [SerializeField]
    private GameObject p2_oneStarGeneralGO;
    [SerializeField]
    private GameObject p2_colonelGO;
    [SerializeField]
    private GameObject p2_ltColonelGO;
    [SerializeField]
    private GameObject p2_majorGO;
    [SerializeField]
    private GameObject p2_captainGO;
    [SerializeField]
    private GameObject p2_firstLieutenatntGO;
    [SerializeField]
    private GameObject p2_secondLieutenatntGO;
    [SerializeField]
    private GameObject p2_sergeantGO;
    [SerializeField]
    private GameObject p2_privatesGO;
    [SerializeField]
    private GameObject p2_spyGO;
    [SerializeField]
    private GameObject p2_flagGO;

    [Header("PlayerOne UI Buttons")]
    [SerializeField]
    private Button P1_fiveStarButton;
    [SerializeField]
    public Button P1_fourStarGeneralButton;
    [SerializeField]
    public Button P1_threeStarGeneralButton;
    [SerializeField]
    public Button P1_twoStarGeneralButton;
    [SerializeField]
    public Button P1_OneStarGeneralButton;
    [SerializeField]
    public Button P1_colonelButton;
    [SerializeField]
    public Button P1_ltColonelButton;
    [SerializeField]
    public Button P1_majorButton;
    [SerializeField]
    public Button P1_captainButton;
    [SerializeField]
    public Button P1_firstLieutenatntButton;
    [SerializeField]
    public Button P1_secondLieutenatntButton;
    [SerializeField]
    public Button P1_sergeantButton;
    [SerializeField]
    public Button P1_privatesButton;
    [SerializeField]
    public Button P1_spyButton;
    [SerializeField]
    public Button P1_flagButton;

    [Header("PlayerTeo UI Buttons")]
    [SerializeField]
    private Button P2_fiveStarButton;
    [SerializeField]
    public Button P2_fourStarGeneralButton;
    [SerializeField]
    public Button P2_threeStarGeneralButton;
    [SerializeField]
    public Button P2_twoStarGeneralButton;
    [SerializeField]
    public Button P2_OneStarGeneralButton;
    [SerializeField]
    public Button P2_colonelButton;
    [SerializeField]
    public Button P2_ltColonelButton;
    [SerializeField]
    public Button P2_majorButton;
    [SerializeField]
    public Button P2_captainButton;
    [SerializeField]
    public Button P2_firstLieutenatntButton;
    [SerializeField]
    public Button P2_secondLieutenatntButton;
    [SerializeField]
    public Button P2_sergeantButton;
    [SerializeField]
    public Button P2_privatesButton;
    [SerializeField]
    public Button P2_spyButton;
    [SerializeField]
    public Button P2_flagButton;

    [Header("Cameras")]
    [SerializeField]
    public GameObject P1_Camera;
    [SerializeField]
    public GameObject P2_Camera;

    public static int p1_Flag = 1, p2_Flag = 1;

    [Header("GamePiece Damage Values")]
    public int spy = 15, fiveGeneral = 14, fourGeneral = 13, threeGeneral = 12, twoGeneral = 11, oneGeneral = 10, colonel = 9, ltColonel = 8, major = 7,
               captain = 6, firstLieutenant = 5, secLieutenant = 4, sergeant = 3, privates = 2, flag = 1;

    [Header("P1_GamePiece Inventory Values")]
    public static int P1_fiveStarInv = 1, P1_fourStarInv = 1, P1_threeStarInv = 1, P1_twoStarInv = 1, P1_oneStarInv = 1, P1_colonelInv = 1, P1_ltColonelInv = 1, P1_captainInv = 1, P1_firstLtInv = 1, P1_secondLtInv = 1,
                P1_majorLtInv = 1, P1_sargeantInv = 1, P1_privateInv = 6, P1_spyInv = 2, P1_flagInv = 1;

    [Header("P2_GamePiece Inventory Values")]
    public static int P2_fiveStarInv = 1, P2_fourStarInv = 1, P2_threeStarInv = 1, P2_twoStarInv = 1, P2_oneStarInv = 1, P2_colonelInv = 1, P2_ltColonelInv = 1, P2_captainInv = 1, P2_firstLtInv = 1, P2_secondLtInv = 1,
               P2_majorLtInv = 1, P2_sargeantInv = 1, P2_privateInv = 6, P2_spyInv = 2, P2_flagInv = 1;

    [Header("Board Colors")]
    public Color32 openSlot = new Color32(0, 255, 0, 255), closedSlot = new Color32(255, 0, 0, 50), normalSlot = new Color32(110,76,45,255);

    [Header("GamePiece Bool")]
    public static bool isFivePressed = false, isFourPressed = false, isThreePressed = false, isTwoPressed = false, isOnePressed = false, isColonelPressed = false, isLtColonelPressed = false, 
                    isMajorPressed = false, isCaptainPressed = false, isFirstLtPressed = false, isSecondPressed = false, isSergeantPressed = false, isPrivatePressed = false, isSpyPressed = false, isFlagPressed = false,
                    isChosen = false;

   
    //[Header("P1 EndGame Transforms")]
    //Vector3 p1_EndGamePosition = 
    // ------------------------------------------------------------------------------
    // Protected Variables
    // ------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------
    // Private Variables
    // ------------------------------------------------------------------------------
    public static WLD_GameController controller;
    public static GameObject managers;

    #endregion

    #region Getters/Setters



    #endregion

    #region Constructors



    #endregion

    // ------------------------------------------------------------------------------
    // FUNCTIONS
    // ------------------------------------------------------------------------------
    void Awake()
    {
        ListAttributes();
        DictionaryAttributes();
        LocateResources();

    }
    void Start()
    {
        P2_Camera.SetActive(false);
        p2_gamePiecePanel.SetActive(false);
        playText.enabled = false;
        playerOneTimer.enabled = false;
        playerTwoTimer.enabled = false;

        continuePanel.SetActive(!continuePanel.activeSelf);


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


    // ------------------------------------------------------------------------------
    // Function Name: 
    // Return types: 
    // Argument types: 
    // Author: 
    // Date: 
    // ------------------------------------------------------------------------------
    // Purpose: 
    // ------------------------------------------------------------------------------
    void ListAttributes()
    {
        //EndGameTransform.Add();

        P1_tagNames.Add(UNA_Tags.FiveStarGeneral);
        P1_tagNames.Add(UNA_Tags.FourStarGeneral);
        P1_tagNames.Add(UNA_Tags.ThreeStarGeneral);
        P1_tagNames.Add(UNA_Tags.TwoStarGenreal);
        P1_tagNames.Add(UNA_Tags.OneStarGeneral);
        P1_tagNames.Add(UNA_Tags.Colonel);
        P1_tagNames.Add(UNA_Tags.LtColonel);
        P1_tagNames.Add(UNA_Tags.Major);
        P1_tagNames.Add(UNA_Tags.Captain);
        P1_tagNames.Add(UNA_Tags.FirstLieutenant);
        P1_tagNames.Add(UNA_Tags.SecondLietenant);
        P1_tagNames.Add(UNA_Tags.Sergeant);
        P1_tagNames.Add(UNA_Tags.Spy);
        P1_tagNames.Add(UNA_Tags.Private);
        P1_tagNames.Add(UNA_Tags.P1_Flag);

        P2_tagNames.Add(UNA_Tags.P2_FiveStarGeneral);
        P2_tagNames.Add(UNA_Tags.P2_FourStarGeneral);
        P2_tagNames.Add(UNA_Tags.P2_ThreeStarGeneral);
        P2_tagNames.Add(UNA_Tags.P2_TwoStarGenreal);
        P2_tagNames.Add(UNA_Tags.P2_OneStarGeneral);
        P2_tagNames.Add(UNA_Tags.P2_Colonel);
        P2_tagNames.Add(UNA_Tags.P2_LtColonel);
        P2_tagNames.Add(UNA_Tags.P2_Major);
        P2_tagNames.Add(UNA_Tags.P2_Captain);
        P2_tagNames.Add(UNA_Tags.P2_FirstLieutenant);
        P2_tagNames.Add(UNA_Tags.P2_SecondLietenant);
        P2_tagNames.Add(UNA_Tags.P2_Sergeant);
        P2_tagNames.Add(UNA_Tags.P2_Spy);
        P2_tagNames.Add(UNA_Tags.P2_Private);
        P2_tagNames.Add(UNA_Tags.P2_Flag);

        p1_UIButtons.Add(P1_fiveStarButton);
        p1_UIButtons.Add(P1_fourStarGeneralButton);
        p1_UIButtons.Add(P1_threeStarGeneralButton);
        p1_UIButtons.Add(P1_twoStarGeneralButton);
        p1_UIButtons.Add(P1_OneStarGeneralButton);
        p1_UIButtons.Add(P1_colonelButton);
        p1_UIButtons.Add(P1_ltColonelButton);
        p1_UIButtons.Add(P1_captainButton);
        p1_UIButtons.Add(P1_majorButton);
        p1_UIButtons.Add(P1_firstLieutenatntButton);
        p1_UIButtons.Add(P1_secondLieutenatntButton);
        p1_UIButtons.Add(P1_sergeantButton);
        p1_UIButtons.Add(P1_flagButton);
        p1_UIButtons.Add(P1_privatesButton);
        p1_UIButtons.Add(P1_spyButton);

        p2_UIButtons.Add(P2_fiveStarButton);
        p2_UIButtons.Add(P2_fourStarGeneralButton);
        p2_UIButtons.Add(P2_threeStarGeneralButton);
        p2_UIButtons.Add(P2_twoStarGeneralButton);
        p2_UIButtons.Add(P2_OneStarGeneralButton);
        p2_UIButtons.Add(P2_colonelButton);
        p2_UIButtons.Add(P2_ltColonelButton);
        p2_UIButtons.Add(P2_captainButton);
        p2_UIButtons.Add(P2_majorButton);
        p2_UIButtons.Add(P2_firstLieutenatntButton);
        p2_UIButtons.Add(P2_secondLieutenatntButton);
        p2_UIButtons.Add(P2_sergeantButton);
        p2_UIButtons.Add(P2_flagButton);
        p2_UIButtons.Add(P2_privatesButton);
        p2_UIButtons.Add(P2_spyButton);

        p1_Inventory.Add(P1_fiveStarInv);
        p1_Inventory.Add(P1_fourStarInv);
        p1_Inventory.Add(P1_threeStarInv);
        p1_Inventory.Add(P1_twoStarInv);
        p1_Inventory.Add(P1_oneStarInv);
        p1_Inventory.Add(P1_colonelInv);
        p1_Inventory.Add(P1_ltColonelInv);
        p1_Inventory.Add(P1_captainInv);
        p1_Inventory.Add(P1_firstLtInv);
        p1_Inventory.Add(P1_secondLtInv);
        p1_Inventory.Add(P1_majorLtInv);
        p1_Inventory.Add(P1_sargeantInv);
        p1_Inventory.Add(P1_privateInv);
        p1_Inventory.Add(P1_spyInv);
        p1_Inventory.Add(P1_flagInv);

        p2_Inventory.Add(P2_fiveStarInv);
        p2_Inventory.Add(P2_fourStarInv);
        p2_Inventory.Add(P2_threeStarInv);
        p2_Inventory.Add(P2_twoStarInv);
        p2_Inventory.Add(P2_oneStarInv);
        p2_Inventory.Add(P2_colonelInv);
        p2_Inventory.Add(P2_ltColonelInv);
        p2_Inventory.Add(P2_captainInv);
        p2_Inventory.Add(P2_firstLtInv);
        p2_Inventory.Add(P2_secondLtInv);
        p2_Inventory.Add(P2_majorLtInv);
        p2_Inventory.Add(P2_sargeantInv);
        p2_Inventory.Add(P2_privateInv);
        p2_Inventory.Add(P2_spyInv);
        p2_Inventory.Add(P2_flagInv);

        p1_ListPieceInventory.Add(P1_fiveStarInv);
        p1_ListPieceInventory.Add(P1_fourStarInv);
        p1_ListPieceInventory.Add(P1_threeStarInv);
        p1_ListPieceInventory.Add(P1_twoStarInv);
        p1_ListPieceInventory.Add(P1_oneStarInv);
        p1_ListPieceInventory.Add(P1_colonelInv);
        p1_ListPieceInventory.Add(P1_ltColonelInv);
        p1_ListPieceInventory.Add(P1_captainInv);
        p1_ListPieceInventory.Add(P1_firstLtInv);
        p1_ListPieceInventory.Add(P1_secondLtInv);
        p1_ListPieceInventory.Add(P1_majorLtInv);
        p1_ListPieceInventory.Add(P1_sargeantInv);
        p1_ListPieceInventory.Add(P1_privateInv);
        p1_ListPieceInventory.Add(P1_spyInv);
        p1_ListPieceInventory.Add(P1_flagInv);

        p2_ListPieceInventory.Add(P2_fiveStarInv);
        p2_ListPieceInventory.Add(P2_fourStarInv);
        p2_ListPieceInventory.Add(P2_threeStarInv);
        p2_ListPieceInventory.Add(P2_twoStarInv);
        p2_ListPieceInventory.Add(P2_oneStarInv);
        p2_ListPieceInventory.Add(P2_colonelInv);
        p2_ListPieceInventory.Add(P2_ltColonelInv);
        p2_ListPieceInventory.Add(P2_captainInv);
        p2_ListPieceInventory.Add(P2_firstLtInv);
        p2_ListPieceInventory.Add(P2_secondLtInv);
        p2_ListPieceInventory.Add(P2_majorLtInv);
        p2_ListPieceInventory.Add(P2_sargeantInv);
        p2_ListPieceInventory.Add(P2_privateInv);
        p2_ListPieceInventory.Add(P2_spyInv);
        p2_ListPieceInventory.Add(P2_flagInv);
    }
    void DictionaryAttributes()
    {

        UI_Text.Add(NonGamePieces.BuildText, buildText);
        UI_Text.Add(NonGamePieces.PlayText, playText);
        UI_Text.Add(NonGamePieces.PlayerOneText, playerOneText);
        UI_Text.Add(NonGamePieces.PlayerTwoText, playerTwoText);
        UI_Text.Add(NonGamePieces.PlayerOneTimerText, playerOneTimer);
        UI_Text.Add(NonGamePieces.PlayerTwoTimerText, playerTwoTimer);

        Cameras.Add(NonGamePieces.playerOneCamera,P1_Camera);
        Cameras.Add(NonGamePieces.PlayerTwoCamera, P2_Camera);

        UI_Panel.Add(GamePieces.GamePiecePanel, p1_gamePiecePanel);
        UI_Panel.Add(GamePieces.P2_gamePiecePanel, p2_gamePiecePanel);
        UI_Panel.Add(GamePieces.continuePanel, continuePanel);
        UI_Panel.Add(GamePieces.GamePiecePanelRestart, gamePiecePanelRestart);

        boardColors.Add(GameBoardColors.OpenSlot,openSlot);
        boardColors.Add(GameBoardColors.CloasedSlot, closedSlot);
        boardColors.Add(GameBoardColors.NormalSlot, normalSlot);

        gamePieceValues.Add(GamePieces.FiveStarGeneral, fiveGeneral);
        gamePieceValues.Add(GamePieces.FourStarGeneral, fourGeneral);
        gamePieceValues.Add(GamePieces.ThreeStarGeneral, threeGeneral);
        gamePieceValues.Add(GamePieces.TwoStarGenreal, twoGeneral);
        gamePieceValues.Add(GamePieces.OneStarGeneral, oneGeneral);
        gamePieceValues.Add(GamePieces.Colonel, colonel);
        gamePieceValues.Add(GamePieces.LtColonel, ltColonel);
        gamePieceValues.Add(GamePieces.Major, major);
        gamePieceValues.Add(GamePieces.Captain, captain);
        gamePieceValues.Add(GamePieces.FirstLieutenant, firstLieutenant);
        gamePieceValues.Add(GamePieces.SecondLietenant, secLieutenant);
        gamePieceValues.Add(GamePieces.sergeant, sergeant);
        gamePieceValues.Add(GamePieces.Private, privates);
        gamePieceValues.Add(GamePieces.Spy, spy);
        gamePieceValues.Add(GamePieces.P1_Flag, flag);
        gamePieceValues.Add(GamePieces.P2_Flag, flag);

        P1_GamePieceInv.Add(GamePieces.FiveStarGeneral, P1_fiveStarInv);
        P1_GamePieceInv.Add(GamePieces.FourStarGeneral, P1_fourStarInv);
        P1_GamePieceInv.Add(GamePieces.ThreeStarGeneral, P1_threeStarInv);
        P1_GamePieceInv.Add(GamePieces.TwoStarGenreal, P1_twoStarInv);
        P1_GamePieceInv.Add(GamePieces.OneStarGeneral, P1_oneStarInv);
        P1_GamePieceInv.Add(GamePieces.Colonel, P1_colonelInv);
        P1_GamePieceInv.Add(GamePieces.LtColonel, P1_ltColonelInv);
        P1_GamePieceInv.Add(GamePieces.Captain, P1_captainInv);
        P1_GamePieceInv.Add(GamePieces.FirstLieutenant, P1_firstLtInv);
        P1_GamePieceInv.Add(GamePieces.SecondLietenant, P1_secondLtInv);
        P1_GamePieceInv.Add(GamePieces.Major, P1_majorLtInv);
        P1_GamePieceInv.Add(GamePieces.sergeant, P1_secondLtInv);
        P1_GamePieceInv.Add(GamePieces.Private, P1_privateInv);
        P1_GamePieceInv.Add(GamePieces.Spy, P1_spyInv);
        P1_GamePieceInv.Add(GamePieces.P1_Flag, P1_firstLtInv);

        P2_GamePieceInv.Add(GamePieces.FiveStarGeneral, P2_fiveStarInv);
        P2_GamePieceInv.Add(GamePieces.FourStarGeneral, P2_fourStarInv);
        P2_GamePieceInv.Add(GamePieces.ThreeStarGeneral, P2_threeStarInv);
        P2_GamePieceInv.Add(GamePieces.TwoStarGenreal, P2_twoStarInv);
        P2_GamePieceInv.Add(GamePieces.OneStarGeneral, P2_oneStarInv);
        P2_GamePieceInv.Add(GamePieces.Colonel, P2_colonelInv);
        P2_GamePieceInv.Add(GamePieces.LtColonel, P2_ltColonelInv);
        P2_GamePieceInv.Add(GamePieces.Captain, P2_captainInv);
        P2_GamePieceInv.Add(GamePieces.FirstLieutenant, P2_firstLtInv);
        P2_GamePieceInv.Add(GamePieces.SecondLietenant, P2_secondLtInv);
        P2_GamePieceInv.Add(GamePieces.Major, P2_majorLtInv);
        P2_GamePieceInv.Add(GamePieces.sergeant, P2_secondLtInv);
        P2_GamePieceInv.Add(GamePieces.Private, P2_privateInv);
        P2_GamePieceInv.Add(GamePieces.Spy, P2_spyInv);
        P2_GamePieceInv.Add(GamePieces.P2_Flag, P2_flagInv);

        P1_GamePieces.Add(GamePieces.FiveStarGeneral, fiveStarGeneralGO);
        P1_GamePieces.Add(GamePieces.FourStarGeneral, fourStarGeneralGO);
        P1_GamePieces.Add(GamePieces.ThreeStarGeneral, threeStarGeneralGO);
        P1_GamePieces.Add(GamePieces.TwoStarGenreal, twoStarGeneralGO);
        P1_GamePieces.Add(GamePieces.OneStarGeneral, oneStarGeneralGO);
        P1_GamePieces.Add(GamePieces.Colonel, colonelGO);
        P1_GamePieces.Add(GamePieces.LtColonel, ltColonelGO);
        P1_GamePieces.Add(GamePieces.Major, majorGO);
        P1_GamePieces.Add(GamePieces.Captain, captainGO);
        P1_GamePieces.Add(GamePieces.FirstLieutenant, firstLieutenatntGO);
        P1_GamePieces.Add(GamePieces.SecondLietenant, secondLieutenatntGO);
        P1_GamePieces.Add(GamePieces.sergeant, sergeantGO);
        P1_GamePieces.Add(GamePieces.Private, privatesGO);
        P1_GamePieces.Add(GamePieces.P1_Flag, p1_flagGO);
        P1_GamePieces.Add(GamePieces.Spy, spyGO);

        P2_GamePieces.Add(GamePieces.FiveStarGeneral, p2_fiveStarGeneralGO);
        P2_GamePieces.Add(GamePieces.FourStarGeneral, p2_fourStarGeneralGO);
        P2_GamePieces.Add(GamePieces.ThreeStarGeneral, p2_threeStarGeneralGO);
        P2_GamePieces.Add(GamePieces.TwoStarGenreal, p2_twoStarGeneralGO);
        P2_GamePieces.Add(GamePieces.OneStarGeneral, p2_oneStarGeneralGO);
        P2_GamePieces.Add(GamePieces.Colonel, p2_colonelGO);
        P2_GamePieces.Add(GamePieces.LtColonel, p2_ltColonelGO);
        P2_GamePieces.Add(GamePieces.Major, p2_majorGO);
        P2_GamePieces.Add(GamePieces.Captain, p2_captainGO);
        P2_GamePieces.Add(GamePieces.FirstLieutenant, p2_firstLieutenatntGO);
        P2_GamePieces.Add(GamePieces.SecondLietenant, p2_secondLieutenatntGO);
        P2_GamePieces.Add(GamePieces.sergeant, p2_sergeantGO);
        P2_GamePieces.Add(GamePieces.Private, p2_privatesGO);
        P2_GamePieces.Add(GamePieces.P2_Flag, p2_flagGO);
        P2_GamePieces.Add(GamePieces.Spy, p2_spyGO);

        P1_UI_Buttons.Add(GamePieces.FiveStarGeneral, P1_fiveStarButton);
        P1_UI_Buttons.Add(GamePieces.FourStarGeneral, P1_fourStarGeneralButton);
        P1_UI_Buttons.Add(GamePieces.ThreeStarGeneral, P1_threeStarGeneralButton);
        P1_UI_Buttons.Add(GamePieces.TwoStarGenreal, P1_twoStarGeneralButton);
        P1_UI_Buttons.Add(GamePieces.OneStarGeneral, P1_OneStarGeneralButton);
        P1_UI_Buttons.Add(GamePieces.Colonel, P1_colonelButton);
        P1_UI_Buttons.Add(GamePieces.LtColonel, P1_ltColonelButton);
        P1_UI_Buttons.Add(GamePieces.Major, P1_majorButton);
        P1_UI_Buttons.Add(GamePieces.Captain, P1_captainButton);
        P1_UI_Buttons.Add(GamePieces.FirstLieutenant, P1_firstLieutenatntButton);
        P1_UI_Buttons.Add(GamePieces.SecondLietenant, P1_secondLieutenatntButton);
        P1_UI_Buttons.Add(GamePieces.sergeant, P1_sergeantButton);
        P1_UI_Buttons.Add(GamePieces.Private, P1_privatesButton);
        P1_UI_Buttons.Add(GamePieces.P1_Flag, P1_flagButton);
        P1_UI_Buttons.Add(GamePieces.Spy, P1_spyButton);

        P2_UI_Buttons.Add(GamePieces.FiveStarGeneral, P2_fiveStarButton);
        P2_UI_Buttons.Add(GamePieces.FourStarGeneral, P2_fourStarGeneralButton);
        P2_UI_Buttons.Add(GamePieces.ThreeStarGeneral, P2_threeStarGeneralButton);
        P2_UI_Buttons.Add(GamePieces.TwoStarGenreal, P2_twoStarGeneralButton);
        P2_UI_Buttons.Add(GamePieces.OneStarGeneral, P2_OneStarGeneralButton);
        P2_UI_Buttons.Add(GamePieces.Colonel, P2_colonelButton);
        P2_UI_Buttons.Add(GamePieces.LtColonel, P2_ltColonelButton);
        P2_UI_Buttons.Add(GamePieces.Major, P2_majorButton);
        P2_UI_Buttons.Add(GamePieces.Captain, P2_captainButton);
        P2_UI_Buttons.Add(GamePieces.FirstLieutenant, P2_firstLieutenatntButton);
        P2_UI_Buttons.Add(GamePieces.SecondLietenant, P2_secondLieutenatntButton);
        P2_UI_Buttons.Add(GamePieces.sergeant, P2_sergeantButton);
        P2_UI_Buttons.Add(GamePieces.Private, P2_privatesButton);
        P2_UI_Buttons.Add(GamePieces.P2_Flag, P2_flagButton);
        P2_UI_Buttons.Add(GamePieces.Spy, P2_spyButton);
    }

    void LocateResources()
    {
        managers = GameObject.Find("Managers");
        p1_gamePiecePanel = GameObject.Find("P1_GamePiecePanel");
        p2_gamePiecePanel = GameObject.Find("P2_GamePiecePanel ");
        continuePanel = GameObject.Find("ContinuePanel");

        gamePiecePanelRestart = GameObject.Find("ResetPanel");
        P1_Camera = GameObject.Find("P1_Main Camera");
        P2_Camera = GameObject.Find("P2_Main Camera");

        playerOneTimer = GameObject.Find("PlayerOneTimer").GetComponent<Text>();
        playerTwoTimer = GameObject.Find("PlayerTwoTimer").GetComponent<Text>();

        P1_fiveStarButton = GameObject.Find("FiveStarButton").GetComponent<Button>();
        P1_fourStarGeneralButton = GameObject.Find("FourStarButton").GetComponent<Button>();
        P1_threeStarGeneralButton = GameObject.Find("ThreeStarButton").GetComponent<Button>();
        P1_twoStarGeneralButton = GameObject.Find("TwoStarButton").GetComponent<Button>();
        P1_OneStarGeneralButton = GameObject.Find("OneStarButton").GetComponent<Button>();
        P1_colonelButton = GameObject.Find("ColonelButton").GetComponent<Button>();
        P1_ltColonelButton = GameObject.Find("LTColonelButton").GetComponent<Button>();
        P1_majorButton = GameObject.Find("MajorButton").GetComponent<Button>();
        P1_captainButton = GameObject.Find("CaptainButton").GetComponent<Button>();
        P1_firstLieutenatntButton = GameObject.Find("1stLTButton").GetComponent<Button>();
        P1_secondLieutenatntButton = GameObject.Find("2ndLTButton").GetComponent<Button>();
        P1_sergeantButton = GameObject.Find("SeargentButton").GetComponent<Button>();
        P1_privatesButton = GameObject.Find("PrivateButton").GetComponent<Button>();
        P1_flagButton = GameObject.Find("FlagButton").GetComponent<Button>();
        P1_spyButton = GameObject.Find("SpyButton").GetComponent<Button>();

        P2_fiveStarButton = GameObject.Find("P2_FiveStarButton").GetComponent<Button>();
        P2_fourStarGeneralButton = GameObject.Find("P2_FoutStarButton").GetComponent<Button>();
        P2_threeStarGeneralButton = GameObject.Find("P2_ThreeStarButton").GetComponent<Button>();
        P2_twoStarGeneralButton = GameObject.Find("P2_TwoStarButton").GetComponent<Button>();
        P2_OneStarGeneralButton = GameObject.Find("P2_OneStarButton").GetComponent<Button>();
        P2_colonelButton = GameObject.Find("P2_ColonelButton").GetComponent<Button>();
        P2_ltColonelButton = GameObject.Find("P2_LTColonelButton").GetComponent<Button>();
        P2_majorButton = GameObject.Find("P2_MajorButton").GetComponent<Button>();
        P2_captainButton = GameObject.Find("P2_CaptainButton").GetComponent<Button>();
        P2_firstLieutenatntButton = GameObject.Find("P2_1stLTButton").GetComponent<Button>();
        P2_secondLieutenatntButton = GameObject.Find("P2_2ndLTButton").GetComponent<Button>();
        P2_sergeantButton = GameObject.Find("P2_SeargentButton").GetComponent<Button>();
        P2_privatesButton = GameObject.Find("P2_PrivateButton").GetComponent<Button>();
        P2_flagButton = GameObject.Find("P2_FlagButton").GetComponent<Button>();
        P2_spyButton = GameObject.Find("P2_SpyButton").GetComponent<Button>();
    }

} // End WLD_GameController