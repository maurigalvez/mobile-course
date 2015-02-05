using UnityEngine;
using System.Collections;
//===================
// GAME MANAGER - 
//===================
/// <summary>
/// Game manager - Class in charge of managing states of game
/// </summary>
public class GameManager : MonoBehaviour 
{
	//================
	// GAME STATES
	//================
	public enum eGameState
	{
		mainMenu,
		inGame,
		pause,
		inventory,
		gameOver,
	}
	//=================
	// VARIABLES
	//=================
	public eGameState currentState;				// CurrentState of the game
	// Use this for initialization
	void Start () 
	{}	
	// Update is called once per frame
	void Update () 
	{}
	//===============
	// MANAGE STATES
	//===============
	/// <summary>
	/// Manages the currentState in the game
	/// </summary>
	private void manageStates()
	{
		switch(currentState)
		{
			case eGameState.inGame:
			break;

			case eGameState.mainMenu:
			break;

			case eGameState.gameOver:
			break;
		}
	}
	//===============
	// IS IN GAME
	//===============
	/// <summary>
	/// Determines whether currentState is InGame.
	/// </summary>
	/// <returns><c>true</c> if currentState  isin game; otherwise, <c>false</c>.</returns>
	public bool IsInGame()
	{
		return currentState == eGameState.inGame;
	}
	//===============
	// IS IN PAUSE
	//===============
	/// <summary>
	/// Determines whether currentState is in pause.
	/// </summary>
	/// <returns><c>true</c> if currentState is in pause; otherwise, <c>false</c>.</returns>
	public bool IsInPause()
	{
		return currentState == eGameState.pause;
	}
	//===============
	// IS INVENTORY
	//===============
	/// <summary>
	/// Determines whether currentState is in inventory.
	/// </summary>
	/// <returns><c>true</c> if currentState is in inventory; otherwise, <c>false</c>.</returns>
	public bool IsInInventory()
	{
		return currentState == eGameState.inventory;
	}
	//===============
	// IS MAIN MENU
	//===============
	/// <summary>
	/// Determines whether currentState is main menu.
	/// </summary>
	/// <returns><c>true</c> if tcurrentState  is main menu; otherwise, <c>false</c>.</returns>
	public bool IsMainMenu()
	{
		return currentState == eGameState.mainMenu;
	}
	//===============
	// IS GAME OVER
	//===============
	/// <summary>
	/// Determines whether currentState is main menu.
	/// </summary>
	/// <returns><c>true</c> if currentState is game over; otherwise, <c>false</c>.</returns>
	public bool IsGameOver()
	{
		return currentState == eGameState.gameOver;
	}
}
