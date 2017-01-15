using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

// Used for saving and loading a game
[System.Serializable]
public class SaveLoad : MonoBehaviour{

    // The path to saved games
	private static string savedGamesPath;

    // Get the list of saved games
	public static List<playerStats> savedGames = new List<playerStats>();

    // Used for initializaton
    void Awake()
    {
        savedGamesPath = Application.persistentDataPath + "/savedGames.tdi";
    }

	//Save the current list of games as the saved games and serialize it
	public static void Save(int index){
		if (savedGames.Count-1 < index) {
			savedGames.Add (playerStats.current);
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Create (savedGamesPath);
			bf.Serialize (file, SaveLoad.savedGames);
			file.Close ();
		} else {
			savedGames [index] = playerStats.current;
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Create (savedGamesPath);
			bf.Serialize (file, SaveLoad.savedGames);
			file.Close ();
		}
	}

	//Load/Deserialize the List of save files
	public static bool Load(){
		if (File.Exists (savedGamesPath)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (savedGamesPath, FileMode.Open);
			SaveLoad.savedGames = (List<playerStats>)bf.Deserialize (file);
			file.Close ();
			return true;
		}
		return false;
	}	
}
