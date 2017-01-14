using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class leaderboardMenu : MonoBehaviour {

	public Text leaderBoardText;
	public int maxScoresToDisplay;

    // Get the list of all scores from the leaderboard
	List<dreamloLeaderBoard.Score> scoreList;

	dreamloLeaderBoard leaderboard;
	dreamloPromoCode pc;

    // Used for initialization
	void Start ()
	{
		// get the reference here...
		this.leaderboard = dreamloLeaderBoard.GetSceneDreamloLeaderboard ();

		leaderboard.AddScore ("mmmmmmmmmm", 0); //Need to do this or the leaderboard won't show... weird
	}
	
	// Called once per frame
	void OnGUI () {
        // Order the score list from high to low scores
		scoreList = leaderboard.ToListHighToLow ();

        // If there aren't any scores yet display a message
		if (scoreList == null || scoreList.Count == 0)
        {
			leaderBoardText.text = "No Scores Yet!";
		}
        else
        {
            // If there are scores, display them
		    int count = 0;
		    leaderBoardText.text = "";
		    foreach (dreamloLeaderBoard.Score score in scoreList) {
			    count++;

			    leaderBoardText.text += score.playerName + " - Wave:" + score.score + "\n";

			    if(count >= maxScoresToDisplay) break;
		    }
		}
	}
}
