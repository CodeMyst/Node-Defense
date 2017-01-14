﻿using UnityEngine;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour {

	[Header("Menu Screen")]
	public Text welcome;
	public GameObject mainUI;

	[Header("Save Screen")]
	public GameObject saveUI;
	public InputField saveUIIF;

	[Header("Skill Screen")]
	public GameObject skillUI;

	[Header ("Prestige Screen")]
	public GameObject prestigeUI;

	[Header ("Difficulty Screen")]
	public GameObject diffUI;

	[Header ("How to Screen")]
	public GameObject howToUI;

	[Header ("Save Texts")]
	public Text save1;
	public Text save2;
	public Text save3;

	[Header ("Load Texts/Buttons")]
	public Text[] loadTexts;
	public Button[] loadButtons;

	[Header ("Stat Texts")]
	public Text levelText;
	public Text expText;
	public Text prestigeText;

	[Header ("Other Setup")]
	public GameObject cameraGO;

	private Text textToChange;
	private int saveIndex = -1;
	private playerStats tempStats;

	// Use this for initialization
	void Start () {
		//Load the saved games names into their buttons
		if (SaveLoad.Load ()) {
			for(int i = 0; i < SaveLoad.savedGames.Count; i++) {
				playerStats save = SaveLoad.savedGames [i];
				loadTexts [i].text = "Load: " + save.saveName;
			}
		}

        //If player has played a game using the New Player name without saving,
        //show their stats, other wise they've just started the game and set
        //their temp stats = to a new player
		if(playerStats.current != null)
        {
			showStats ();
			setLoadText (playerStats.saveIndex);
		}
        else
        {
			tempStats = new playerStats ();
		}

        // Update the level of the user every 2 seconds so it won't
        // cause any performance issues
		InvokeRepeating("SlowUpdate", 0.1f, 2f);
	}

	//Called every x Seconds
	void SlowUpdate(){
		//Update the player's level
		if (playerStats.current != null) {
			playerStats.current.getLevelFunction ();
		}
	}

	//Quit the game
	public void Quit(){
		Application.Quit();
	}

	//Open the UI for saving a game and setup parameters for saving
	public void openSaveUI(int index){
		setLoadText (index);
		openSave ();
		saveUIIF.text = string.Empty;
	}

	//Set the load text for when leaving the skill tree (Make sure we change the appropriate load box)
	public void setLoadText(int index){
		switch (index) {
		case 0:
			textToChange = loadTexts [0];
			saveIndex = 0;
			break;
		case 1:
			textToChange = loadTexts [1];
			saveIndex = 1;
			break;
		case 2:
			textToChange = loadTexts [2];
			saveIndex = 2;
			break;
		}
	}

	//Set the save file to a specific index in the list
	public void setSave(string name){
		//If the players stats are not null then this is a save file that came from a game that just started, load these stats
		if(playerStats.current != null)
			playerStats.current = new playerStats (name, playerStats.current.getLevelFunction (), playerStats.current.getExp (), playerStats.current.getSkillPoints(), playerStats.current.getSkillPointsUsed(), playerStats.current.getBuffMatrix(), playerStats.current.getPrestige());
		else
			playerStats.current = new playerStats(name, tempStats.getLevelFunction(), tempStats.getLevelFunction(), tempStats.getSkillPoints(), tempStats.getSkillPointsUsed(), tempStats.getBuffMatrix(), tempStats.getPrestige());
		SaveLoad.Save (saveIndex); //Use the save index from the openSaveUI Setup to save this

		closeSave ();
		textToChange.text = "Load: " + playerStats.current.saveName;
		showStats ();
	}

	//Load the game file at this index
	public void Load(int index){
		setLoadText (index);
		if (SaveLoad.savedGames.Count > index) {
			playerStats.current = SaveLoad.savedGames [index];
			playerStats.saveIndex = index; 
		}

		showStats ();
	}

	//Delete the save file by putting a new game file in that slot
	public void deleteSave(int index){
		if (SaveLoad.savedGames.Count > index) {
			SaveLoad.savedGames[index] = new playerStats ();
			Load (index);
			textToChange.text = "Load: " + playerStats.current.saveName; //Show the name in the appropriate load box
		}
	}

	//Show this players stats from their save file
	void showStats(){
		if (playerStats.current != null) {
			welcome.text = "Welcome, " + playerStats.current.saveName;
			levelText.text = playerStats.current.getLevelFunction ().ToString();
			expText.text = playerStats.current.getExp ().ToString();
			prestigeText.text = playerStats.current.getPrestige().ToString ();
		}
	}

	/*
	* Open specific "windows" (Sets of UI elements)
	*/

	public void openSkills(){
		openScreen (skillUI);
	}

	public void closeSkills(){
		if (GameObject.FindGameObjectWithTag ("Tree") != null)
			GameObject.FindGameObjectWithTag ("Tree").SetActive (false);
		closeScreen (skillUI);
		if(saveIndex >= 0)
			setSave (playerStats.current.saveName); //Save upon leaving skill tree
		
	}

	public void openPrestige(){
		openScreen (prestigeUI);
	}

	public void closePrestige(){
		closeScreen (prestigeUI);
		if(saveIndex >= 0){
			setSave (playerStats.current.saveName); //Save upon leaving skill tree
			Load(playerStats.saveIndex);
		}
	}

	public void openSave(){
		openScreen (saveUI);
	}

	public void closeSave(){
		closeScreen (saveUI);
	}

	public void openHow(){
		openScreen (howToUI);
	}

	public void closeHow(){
		closeScreen (howToUI);
	}

	public void openDiff(){
		gameStats.setEnemyDiff (-1);
		gameStats.setMapDiff (-1);
		openScreen (diffUI);
	}

	public void closeDiff(){
		closeScreen (diffUI);
	}
		
	/*
	* Camera Controls for Menu
	*/

	public void openScreen(GameObject toOpen){
		mainUI.SetActive (false);
		toOpen.SetActive (true);
	}

	public void closeScreen(GameObject toClose){
		mainUI.SetActive (true);
		toClose.SetActive (false);
	}

    //Neat move where the camera rotates up into the sky box to make
    //room for UI elements (takes in a gameobject (which should hold
    //a set of UI elements))
	/*public void rotateCameraUpAndOpen(GameObject toOpen){
		mainUI.SetActive (false);
		toOpen.SetActive (true);
		cameraGO.GetComponent<Camera> ().transform.rotation *= Quaternion.Euler(-24,0,0);
	}

	//Rotate back down to the base FOV
	public void rotateCameraDownAndClose(GameObject toClose){
		mainUI.SetActive (true);
		toClose.SetActive (false);
		cameraGO.GetComponent<Camera> ().transform.rotation *= Quaternion.Euler(24,0,0);
	}
    */
	/*
	* Skill functions
	*/

    // TODO: Skill functions? Is this intentional?
}
