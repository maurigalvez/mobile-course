using UnityEngine;
using System.Collections;
//===================
// UI MANAGER 
//==================
/// <summary>
/// UI Manager- Class in charge of drawing game's UI
/// </summary>
public class UIManager : MonoBehaviour 
{
	//===================
	// GUI ELEMENTS
	//===================
	public Texture healthIcon;						// Texture for player's health
	public Texture gold;						// Texture for gold
	public Texture menubg;						// Texture of mainMenu background
	public Texture menuPointer;					// Texture of mainMenu pointer
	public Texture inventorybg;					// Texture of inventory
	//===================
	// INSTANCE VARIABLES
	//===================
	public GameObject player;					// GameObject of the player
	private GameManager gameMgr;				// Instance of GameManager
	// Use this for initialization
	void Start () 
	{
		// Obtain instance of gameManager
		gameMgr = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update (){}
	private void OnGUI()
	{	
		// Draw GUI
		manageStates();
	}
	//===============
	// MANAGE STATES
	//===============
	/// Manages the currentState in the game
	private void manageStates()
	{
		//--------------------
		// Check current state of game and determine GUI
		//---------------------
		if(gameMgr.IsMainMenu())
			MainMenuGUI();	
		else if(gameMgr.IsInGame())
			inGameGUI();
		else if(gameMgr.IsGameOver())
			GameOverGUI();
		else if(gameMgr.IsInPause())
			PauseGUI();
		else if(gameMgr.IsInInventory())
			InventoryGUI();
	}
	//===============
	// MAIN MENU GUI
	//===============
	/// Draws Main Menu GUI
	private void MainMenuGUI()
	{
      //---------------
      // DRAW BACKGROUND
      //---------------
      if(menubg)
       GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), menubg);
	}
	//===============
	// INVENTORY GUI
	//===============
	/// Draws Inventory GUI
	private void InventoryGUI()
	{
		//---------------
		// Obtain Data from player - Collection Data
		//---------------
	}
	//===============
	// IN GAME GUI
	//===============
	/// Draws InGame GUI
	private void inGameGUI()
	{
		//--------------
		// Obtain Data from player - health, money 
		//--------------
      // DRAW HEALTH
      // obtain positions X and Y
      float posX = Screen.width * 0.1f;
      float posY = Screen.height * 0.1f;
      float w = Screen.width * 0.05f;
      float h = Screen.height * 0.05f;
      // Draw them on screeen
      for (int i = 0; i < 3; i++)
         GUI.DrawTexture(new Rect(posX, posY, w, h), healthIcon);
	}
	//===============
	// PAUSE
	//===============
	/// Draws Pause GUI
	private void PauseGUI()
	{
		
	}
	//===============
	// GAME OVER GUI
	//===============
	/// Draws GAmeOver GUI
	private void GameOverGUI()
	{

	}
}
