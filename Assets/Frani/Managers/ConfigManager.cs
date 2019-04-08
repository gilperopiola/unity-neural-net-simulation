public static class ConfigManager {
    public static Config config;

    public static void Init(string fileName) {
        config = UnityEngine.JsonUtility.FromJson<Config>(FileHandler.Read(fileName));
    }

    [System.Serializable]
    public class Config {
        public string projectName;
        public bool debugMode;
        public TileMapConfig tileMap;
        public GeneticAlgorithmConfig geneticAlgorithm;
    }

    [System.Serializable]
    public class TileMapConfig {
        public string fileName;
        public int width;
        public int height;
    }

    [System.Serializable]
    public class GeneticAlgorithmConfig {
        public int nIndividuals;
        public int nElite;
        public float mutationPercentage;
        public int nMovements;
    }
}
