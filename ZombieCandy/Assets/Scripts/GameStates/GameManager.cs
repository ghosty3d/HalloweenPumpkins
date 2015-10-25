using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	//View 
	public GameUI GameViewUI;

	//Spawner
	public EnemiesSpawner enemiesSpawner;

	//States
	public IGameState currentGameState;

	public MainMenuState mainMenuState;
	public LevelSelectionState levelSelectionState;
	public LevelStartState levelStartState;
	public LevelLoseState levelLoseState;

	public PauseState pauseState;

	public bool InPause;

	void Awake()
	{
		Instance = this;
		mainMenuState = new MainMenuState(this);
		levelSelectionState = new LevelSelectionState(this);
		levelStartState = new LevelStartState(this);
		levelLoseState = new LevelLoseState(this);

		pauseState = new PauseState(this);

		currentGameState = mainMenuState;
	}

	void Start ()
	{
		enemiesSpawner = EnemiesSpawner.Instance;
		GoToMainMenu();
	}

	public void GoToMainMenu()
	{
		currentGameState.ToMainMenuState();
		currentGameState = mainMenuState;
	}

	public void GoToLevelsSelection()
	{
		currentGameState.ToLevelSelectionState();
		currentGameState = levelSelectionState;
	}

	public void GoToLevelStart()
	{
		currentGameState.ToLevelStartState();
		currentGameState = levelStartState;
	}

	public void GoToPause()
	{
		currentGameState.ToPauseState();
		currentGameState = pauseState;
	}

	public void GoToResumeGame()
	{
		currentGameState.ToResumeState();
		currentGameState = levelStartState;
	}

	public void GoToExit()
	{
		currentGameState.ToExitState();
	}

	public void GoToLoseState()
	{
		currentGameState.ToLevelLoseState();
	}
}
