using UnityEngine;

public class gameManager : MonoBehaviour {

	public GameObject gameoverUI;       // Store the gameOverUI object so we can disable it or enable it
	public GameObject yes, no, toMenu;
	[Header("Speed")]
    // Buttons for allowing the player to increase or decrease the time scale
	public GameObject speedUp;
	public GameObject slowDown;

	[HideInInspector]
	public static bool gameEnded;       // Check if the game has ended

	dreamloLeaderBoard leaderboard;     // Get the leaderboard script

    // Used for initialization (called before Start())
	void Awake(){
		Application.runInBackground = true; //Keep the game playing even if it loses focus

        // Need to do this on scene start or static variable will be preserved
        // since the static variables stay loaded even after scene load
        gameEnded = false;
		gameObject.GetComponent<activeBuffs> ().applyNodeBuffs(); //Apply node buffs at start
	}

    // Used for initialization (called after Awake())
	void Start(){
		this.leaderboard = dreamloLeaderBoard.GetSceneDreamloLeaderboard ();
		//playerStats.current.printBuffs ();
		gameObject.GetComponent<activeBuffs> ().applyEconBuffs (); //Apply econ buffs at start but after Node buffs (can't change gameStats before they are created)
	}

	// Update is called once per frame
	void Update () {
		//Check framerate
		//Debug.Log (Mathf.FloorToInt(1.0f / Time.deltaTime));

        // If the game has ended exit the Update method
        // so it wont do anything
		if (gameEnded)
			return;

		//Debug Statement
		if(Input.GetKeyDown("e")){
			playerStats.current.addExpPerDiff (5000);
		}

        // If the player's lives reach 0 then end the game
		if (gameStats.lives <= 0) {
			endGame ();
		}
	}

    // Used for ending the game
	void endGame(){
		waveSpawner.enemiesAlive = 0;       // Set the enemies alive to 0
		gameEnded = true;                   // Set the game ended to true
		gameoverUI.SetActive(true);         // Enable the game over screen

        // Add experience to the player
		playerStats.current.addExpPerDiff (waveSpawner.getLastWave());
		playerStats.current.setLevel ();

		//IF the player is using a saved file, save it at that index, if not, don't save
		if (playerStats.saveIndex >= 0)
			SaveLoad.Save (playerStats.saveIndex);

        // Add the score to the leaderboard
		leaderboard.AddScore (playerStats.current.saveName, waveSpawner.getLastWave ());
	}
		

	//Confirm the user wants to use the menu
	public void openConfirmation(){
		yes.SetActive (true);
		no.SetActive (true);
		toMenu.SetActive (false);
	}

	//Close in the event that the user does not want to go to the menu
	public void closeConfirmation(){
		yes.SetActive (false);
		no.SetActive (false);
		toMenu.SetActive (true);
	}

    // Used for increasing the time scale (speed at which the game is running)
	public void incSpeed(){
		speedUp.SetActive (false);
		slowDown.SetActive (true);
        // Speed the game 3 time
		Time.timeScale *= 3f;
	}

    // Used for decreasing the time scale
	public void decSpeed(){
		speedUp.SetActive (true);
		slowDown.SetActive (false);
        // Slow the game 3 times to the starting speed
        // TODO: Change this from /= 3f to only 1f?
		Time.timeScale /= 3f;
	}
}
