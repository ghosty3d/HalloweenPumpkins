using UnityEngine;
using System.Collections;

public class GameStatesManager : MonoBehaviour
{
	public static GameStatesManager Instance;

	//View 
	public GameUI GameViewUI;

	//Spawner
	public EnemiesSpawner enemiesSpawner;

	//States
	public IGameState currentGameState;

	//Level Manager
	public LevelsManager levelManager;

	public MainMenuState mainMenuState;
	public LevelSelectionState levelSelectionState;
	public LevelGameState levelGameState;
	public LevelLoseState levelLoseState;
	public LevelWonState levelWonState;
	public ExitGameState levelExitState;

	public PauseState pauseState;

	public bool InPause;

	public int PlayerLivesMax = 3;
	public int PlayerLives = 3;
	public int PlayerBombsCount = 3;

	void Awake()
	{
		Instance = this;

		mainMenuState = new MainMenuState(this);
		levelSelectionState = new LevelSelectionState(this);
		levelGameState = new LevelGameState(this);
		levelLoseState = new LevelLoseState(this);
		levelWonState = new LevelWonState(this);
		levelExitState = new ExitGameState(this);

		pauseState = new PauseState(this);

		currentGameState = mainMenuState;
		currentGameState.EnableState ();

		if (!levelManager)
		{
			levelManager = LevelsManager.Instance;
		}
	}

	void Start ()
	{
		enemiesSpawner = EnemiesSpawner.Instance;
		GoToMainMenu();
	}

	void Update()
	{
		if (currentGameState != null)
		{
			currentGameState.UpdateState ();
		}
	}

	public void AjustPlayerLives(int value)
	{
		PlayerLives += value;
		GameUI.Instance.UpdatePlayerLives(PlayerLives);

		if (PlayerLives == 0)
		{
			GoToLoseState ();
		}
	}

	public void GetNewLevelRank()
	{
		int rank = 0;

		//Add point for level complete
		rank++;

		//Add point if player didn't lose no one lives
		if(PlayerLives == PlayerLivesMax)
		{
			rank++;
		}

		//Add point if player didn't use any bombs
		if (BombManger.BombsCount >= 3)
		{
			rank++;
		}

		GameUI.Instance.ActiveStars (rank);

		//Update Model Data
		levelManager.CurrentLevel.Stars = rank;
	}

	public void GoToMainMenu()
	{
        ConfigManager.SaveLevelStorage(LevelsManager.Instance.levelStorage);
        levelLoseState.DisableState ();
		levelWonState.DisableState ();
		pauseState.DisableState ();
		levelGameState.DisableState ();

		currentGameState = mainMenuState;
		currentGameState.EnableState();
	}

	public void GoToLevelsSelection()
	{
		currentGameState = levelSelectionState;
		currentGameState.EnableState();
	}

	public void GoToLevelStart()
	{
		mainMenuState.DisableState ();
		levelSelectionState.DisableState ();
		levelWonState.DisableState ();
		levelLoseState.DisableState ();

		currentGameState = levelGameState;
		currentGameState.EnableState();
	}

	public void GoToPause()
	{
		currentGameState = pauseState;
		currentGameState.EnableState();
	}

	public void GoToResumeGame()
	{
		pauseState.DisableState ();

		currentGameState = levelGameState;
		currentGameState.EnableState();
	}

	public void GoToExit()
	{
		currentGameState = levelExitState;
		currentGameState.EnableState ();
	}

	public void GoToLoseState()
	{
		currentGameState = levelLoseState;
		currentGameState.EnableState();
	}

	public void GoToWonState()
	{
		currentGameState = levelWonState;
		currentGameState.EnableState();
	}
}
