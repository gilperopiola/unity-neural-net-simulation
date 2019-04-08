using UnityEngine;

public enum Direction {
    NONE,
    UP,
    UP_RIGHT,
    RIGHT,
    RIGHT_DOWN,
    DOWN,
    DOWN_LEFT,
    LEFT,
    LEFT_UP
}

public static class FileHandler {
    public static string Read(string fileName) {
        return System.IO.File.ReadAllText(fileName);
    }
}

public static class RandomGenerator {
    public static int Int(int minInclusive, int maxInclusive) {
        return UnityEngine.Random.Range(minInclusive, maxInclusive + 1);
    }
    public static float Float(float minInclusive, float maxInclusive) {
        return UnityEngine.Random.Range(minInclusive, maxInclusive);
    }
}

public static class Instantiator {
    public static GameObject InstantiateGameObject(string fileName, Vector3 pos, Quaternion rot) {
        return (GameObject)MonoBehaviour.Instantiate(Resources.Load(fileName), pos, rot);
    }

    public static Sprite InstantiateSprite(string fileName, Vector3 pos, Quaternion rot) {
        return (Sprite)MonoBehaviour.Instantiate(Resources.Load(fileName), pos, rot);
    }
}

