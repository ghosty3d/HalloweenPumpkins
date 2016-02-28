using UnityEngine;
using System.Collections;

/// <summary>
/// Game States Manager. Allows to swtich between different Game States.
/// </summary>
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

	public bool InPause;

	public int PlayerLivesMax = 3;
	public int PlayerLives = 3;
	public int PlayerBombsCountMax = 3;
	public int PlayerBombsCount = 3;

	public int MaxLevelStars = 3;

	void Awake()
	{
		Instance = this;

		mainMenuState = new MainMenuState(this);
		levelSelectionState = new LevelSelectionState(this);
		levelGameState = new LevelGameState(this);
		levelLoseState = new LevelLoseState(this);
		levelWonState = new LevelWonState(this);
		levelExitState = new ExitGameState(this);

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

	/// <summary>
	/// Check conditions after user will finish level and gets the new level rank.
	/// </summary>
	public void GetNewLevelRank()
	{
		int rank = MaxLevelStars;

		//Add point if player didn't lose no one lives
		if(PlayerLives != PlayerLivesMax)
		{
			rank--;
		}

		//Add point if player didn't use any bombs
		if (BombManger.BombsCount < PlayerBombsCountMax)
		{
			rank--;
		}

		GameUI.Instance.ActiveStars (rank);

		//Update Model Data
		levelManager.CurrentLevel.Stars = rank;
		if (LevelsManager.Instance.userProgress.passedLevels.ContainsKey(levelManager.CurrentLevel.ID))
        {
			if (LevelsManager.Instance.userProgress.passedLevels[levelManager.CurrentLevel.ID] < levelManager.CurrentLevel.Stars)
            {
				LevelsManager.Instance.userProgress.passedLevels[levelManager.CurrentLevel.ID] = levelManager.CurrentLevel.Stars;
            }
        }
        else
        {
			LevelsManager.Instance.userProgress.passedLevels.Add(levelManager.CurrentLevel.ID, levelManager.CurrentLevel.Stars);
        }

        ConfigManager.SaveUserProgress(LevelsManager.Instance.userProgress);
	}

	public void GoToMainMenu()
	{
		if (currentGameState != null) {
			currentGameState.DisableState ();
		}

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
		Time.timeScale = 0f;
		GameUI.Instance.ShowPauseContainer ();

		for (int i = 0; i < EnemiesSpawner.Instance.enemiesList.Count; i++) {
			EnemiesSpawner.Instance.enemiesList [i].GetComponent<Enemy> ().shouldStop = true;
		}
	}

	public void GoToResumeGame()
	{
		Time.timeScale = 1f;
		GameUI.Instance.HidePauseContainer ();

		for (int i = 0; i < EnemiesSpawner.Instance.enemiesList.Count; i++) {
			EnemiesSpawner.Instance.enemiesList [i].GetComponent<Enemy> ().shouldStop = false;
		}
	}

	public void GoToMainMenuFromPause() {

		if (EnemiesSpawner.Instance.enemiesList != null && EnemiesSpawner.Instance.enemiesList.Count > 0) {
			for (int i = 0; i < EnemiesSpawner.Instance.enemiesList.Count; i++) {
				EnemiesSpawner.Instance.enemiesList [i].GetComponent<Enemy> ().exit = true;
			}
		}

		if (Time.timeScale < 1f) {
			Time.timeScale = 1f;
		}

		for (int i = 0; i < EnemiesSpawner.Instance.enemiesList.Count; i++) {
			EnemiesSpawner.Instance.enemiesList [i].GetComponent<Enemy> ().shouldStop = false;
		}

		currentGameState.DisableState ();
		currentGameState = mainMenuState;
		currentGameState.EnableState ();
	}

	public void GoToExit()
	{
		currentGameState = levelExitState;
		currentGameState.EnableState ();
	}

	public void GoToLoseState()
	{
		currentGameState.DisableState ();
		currentGameState = levelLoseState;
		currentGameState.EnableState();
	}

	public void GoToWonState()
	{
		currentGameState.DisableState ();
		currentGameState = levelWonState;
		currentGameState.EnableState();
	}
}
