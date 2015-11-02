using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System.Collections;
//using VirusHunt;


public class GooglePlayManager : MonoBehaviour
{
	public static GooglePlayManager Instance;

	void Awake()
	{
		Instance = this;
		DontDestroyOnLoad(this);
	}
	
	void Start ()
	{
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().EnableSavedGames().Build();
		PlayGamesPlatform.InitializeInstance(config);

		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate();

		AuthentificateUser();
	}

	public void AuthentificateUser()
	{
		Social.localUser.Authenticate((bool success) => 
		{
			string message = Social.localUser.userName + " : " + Social.localUser.id;
		});
	}

	public void UnlockPointsAchievement(int points)
	{
		if(Social.localUser.authenticated)
		{
//			if(points > 100)
//			{
//				Social.ReportProgress(GPGSIds.achievement_get_100_points, 100.0f, (bool success) => {});
//			}
//
//			if(points > 500)
//			{
//				Social.ReportProgress(GPGSIds.achievement_get_500_points, 100.0f, (bool success) => {});
//			}
//
//			if(points > 1000)
//			{
//				Social.ReportProgress(GPGSIds.achievement_get_1000_points, 100.0f, (bool success) => {});
//			}
//
//			if(points > 5000)
//			{
//				Social.ReportProgress(GPGSIds.achievement_get_5000_points, 100.0f, (bool success) => {});
//			}
//
//			if(points > 10000)
//			{
//				Social.ReportProgress(GPGSIds.achievement_get_10000_points, 100.0f, (bool success) => {});
//			}
//
//			if(points > 100000)
//			{
//				Social.ReportProgress(GPGSIds.achievement_get_100000_points, 100.0f, (bool success) => {});
//			}
//
//			if(points > 1000000)
//			{
//				Social.ReportProgress(GPGSIds.achievement_get_1000000_points, 100.0f, (bool success) => {});
//			}
		}
	}
}
