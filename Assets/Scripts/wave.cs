// No namespaces required yet

[System.Serializable]
public class wave {
    
	private int totalEnemiesSpawned;    // Number of enemies spawned
	private int waveNumber;             // Current wave number

    // Wave taking in aarguments wave number and amount of enemies to spawn
    // for each wave
	public wave(int wn, int enemiesToSpawn){
		totalEnemiesSpawned = waveSpawner.totalEnemiesSpawned + enemiesToSpawn;
		waveSpawner.totalEnemiesSpawned += enemiesToSpawn;
		waveNumber = wn;
	}

    // Get the amount of enemies spawned
	public int getSpawned(){
		return totalEnemiesSpawned;
	}

    // Get the number of the current wave
	public int getWaveNumber(){
		return waveNumber;
	}

    // Display information about the wave
	public override string ToString(){
		return "Wave Number: " + waveNumber + "\nSpawned Total: " + totalEnemiesSpawned;
	}
}
