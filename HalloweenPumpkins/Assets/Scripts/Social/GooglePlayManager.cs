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

	public void UnlockUsingBombsAchievement(int bombs)
	{
		if (Social.localUser.authenticated) {
			#if ACHIEVEMNTS_TEST
			if (bombs == 1) {
				Social.ReportProgress (GooglePlayData.achievement_use_10_bombs, 100.0f, (bool success) => {
				});
			}

			if (bombs == 2) {
				Social.ReportProgress (GooglePlayData.achievement_use_20_bombs, 100.0f, (bool success) => {
				});
			}

			if (bombs == 3) {
				Social.ReportProgress (GooglePlayData.achievement_use_30_bombs, 100.0f, (bool success) => {
				});
			}

			if (bombs == 4) {
				Social.ReportProgress (GooglePlayData.achievement_use_40_bombs, 100.0f, (bool success) => {
				});
			}

			if (bombs == 5) {
				Social.ReportProgress (GooglePlayData.achievement_use_50_bombs, 100.0f, (bool success) => {
				});
			}

			if (bombs == 6) {
				Social.ReportProgress (GooglePlayData.achievement_use_60_bombs, 100.0f, (bool success) => {
				});
			}

			if (bombs == 7) {
				Social.ReportProgress (GooglePlayData.achievement_use_70_bombs, 100.0f, (bool success) => {
				});
			}

			if (bombs == 8) {
				Social.ReportProgress (GooglePlayData.achievement_use_80_bombs, 100.0f, (bool success) => {
				});
			}

			if (bombs == 9) {
				Social.ReportProgress (GooglePlayData.achievement_use_90_bombs, 100.0f, (bool success) => {
				});
			}

			if (bombs == 10) {
				Social.ReportProgress (GooglePlayData.achievement_use_100_bombs, 100.0f, (bool success) => {
				});
			}
			#else
			if(bombs == 10)
			{
			Social.ReportProgress(GooglePlayData.achievement_use_10_bombs, 100.0f, (bool success) => {});
			}

			if(bombs == 20)
			{
			Social.ReportProgress(GooglePlayData.achievement_use_20_bombs, 100.0f, (bool success) => {});
			}

			if(bombs == 30)
			{
			Social.ReportProgress(GooglePlayData.achievement_use_30_bombs, 100.0f, (bool success) => {});
			}

			if(bombs == 40)
			{
			Social.ReportProgress(GooglePlayData.achievement_use_40_bombs, 100.0f, (bool success) => {});
			}

			if(bombs == 50)
			{
			Social.ReportProgress(GooglePlayData.achievement_use_50_bombs, 100.0f, (bool success) => {});
			}

			if(bombs == 60)
			{
			Social.ReportProgress(GooglePlayData.achievement_use_60_bombs, 100.0f, (bool success) => {});
			}

			if(bombs == 70)
			{
			Social.ReportProgress(GooglePlayData.achievement_use_70_bombs, 100.0f, (bool success) => {});
			}

			if(bombs == 80)
			{
			Social.ReportProgress(GooglePlayData.achievement_use_80_bombs, 100.0f, (bool success) => {});
			}

			if(bombs == 90)
			{
			Social.ReportProgress(GooglePlayData.achievement_use_90_bombs, 100.0f, (bool success) => {});
			}

			if(bombs == 100)
			{
			Social.ReportProgress(GooglePlayData.achievement_use_100_bombs, 100.0f, (bool success) => {});
			}
			#endif
		}
	}

	public void UnlockStopGhostsAchievement(int ghostStops)
	{
		if(Social.localUser.authenticated)
		{
			#if ACHIEVEMNTS_TEST
			if(ghostStops == 1)
			{
				Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv1, 100.0f, (bool success) => {});
			}

			if(ghostStops == 2)
			{
				Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv2, 100.0f, (bool success) => {});
			}

			if(ghostStops == 3)
			{
				Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv3, 100.0f, (bool success) => {});
			}

			if(ghostStops == 4)
			{
				Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv4, 100.0f, (bool success) => {});
			}

			if(ghostStops == 5)
			{
				Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv5, 100.0f, (bool success) => {});
			}

			if(ghostStops == 6)
			{
				Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv6, 100.0f, (bool success) => {});
			}

			if(ghostStops == 7)
			{
				Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv7, 100.0f, (bool success) => {});
			}

			if(ghostStops == 8)
			{
				Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv8, 100.0f, (bool success) => {});
			}

			if(ghostStops == 9)
			{
				Social.ReportProgress(GooglePlayData.achievement_gostbuster_lv9, 100.0f, (bool success) => {});
			}

			if(ghostStops == 10)
			{
				Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv10, 100.0f, (bool success) => {});
			}
			if(ghostStops == 11)
			{
				Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv11, 100.0f, (bool success) => {});
			}

			if(ghostStops == 12)
			{
				Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv12, 100.0f, (bool success) => {});
			}

			if(ghostStops == 13)
			{
				Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv13, 100.0f, (bool success) => {});
			}

			if(ghostStops == 14)
			{
				Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv_14, 100.0f, (bool success) => {});
			}

			if(ghostStops == 15)
			{
				Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv15, 100.0f, (bool success) => {});
			}

			if(ghostStops == 16)
			{
				Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv16, 100.0f, (bool success) => {});
			}

			if(ghostStops == 17)
			{
				Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv17, 100.0f, (bool success) => {});
			}

			if(ghostStops == 18)
			{
				Social.ReportProgress(GooglePlayData.achievement_ghostbusters_lv18, 100.0f, (bool success) => {});
			}

			if(ghostStops == 19)
			{
				Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv19, 100.0f, (bool success) => {});
			}

			if(ghostStops == 20)
			{
				Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv20, 100.0f, (bool success) => {});
			}
			if(ghostStops == 21)
			{
				Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv21, 100.0f, (bool success) => {});
			}
			#else
			if(ghostStops == 1)
			{
			Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv1, 100.0f, (bool success) => {});
			}

			if(ghostStops == 5)
			{
			Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv2, 100.0f, (bool success) => {});
			}

			if(ghostStops == 10)
			{
			Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv3, 100.0f, (bool success) => {});
			}

			if(ghostStops == 15)
			{
			Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv4, 100.0f, (bool success) => {});
			}

			if(ghostStops == 20)
			{
			Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv5, 100.0f, (bool success) => {});
			}

			if(ghostStops == 25)
			{
			Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv6, 100.0f, (bool success) => {});
			}

			if(ghostStops == 30)
			{
			Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv7, 100.0f, (bool success) => {});
			}

			if(ghostStops == 35)
			{
			Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv8, 100.0f, (bool success) => {});
			}

			if(ghostStops == 40)
			{
			Social.ReportProgress(GooglePlayData.achievement_gostbuster_lv9, 100.0f, (bool success) => {});
			}

			if(ghostStops == 45)
			{
			Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv10, 100.0f, (bool success) => {});
			}
			if(ghostStops == 50)
			{
			Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv11, 100.0f, (bool success) => {});
			}

			if(ghostStops == 55)
			{
			Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv12, 100.0f, (bool success) => {});
			}

			if(ghostStops == 60)
			{
			Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv13, 100.0f, (bool success) => {});
			}

			if(ghostStops == 65)
			{
			Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv_14, 100.0f, (bool success) => {});
			}

			if(ghostStops == 70)
			{
			Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv15, 100.0f, (bool success) => {});
			}

			if(ghostStops == 75)
			{
			Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv16, 100.0f, (bool success) => {});
			}

			if(ghostStops == 80)
			{
			Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv17, 100.0f, (bool success) => {});
			}

			if(ghostStops == 85)
			{
			Social.ReportProgress(GooglePlayData.achievement_ghostbusters_lv18, 100.0f, (bool success) => {});
			}

			if(ghostStops == 90)
			{
			Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv19, 100.0f, (bool success) => {});
			}

			if(ghostStops == 95)
			{
			Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv20, 100.0f, (bool success) => {});
			}
			if(ghostStops == 100)
			{
			Social.ReportProgress(GooglePlayData.achievement_ghostbuster_lv21, 100.0f, (bool success) => {});
			}
			#endif
		}
	}
}
