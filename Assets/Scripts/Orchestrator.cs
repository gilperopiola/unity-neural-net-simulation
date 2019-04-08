using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orchestrator : MonoBehaviour {
    public TileMap tileMap;
    public Population population;

    void Start() {
        ConfigManager.Init("Assets/config.json");

        tileMap = new TileMap(ConfigManager.config.tileMap);
        tileMap.CreateGameObjects();

        population = new Population(tileMap);
        population.CreateGameObjects();

        CameraManager.SetCamera(Camera.main);
        CameraManager.SetZoom(330);
        CameraManager.CenterOnGameObject(tileMap.tiles[9][9].gameObject);

        Debug.Log(ConfigManager.config.projectName + " started | debug = " + ConfigManager.config.debugMode);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            tileMap.DestroyGameObjects();
            tileMap = new TileMap(ConfigManager.config.tileMap);
            tileMap.CreateGameObjects();

            population.DestroyGameObjects();
            population = new Population(tileMap);
            population.CreateGameObjects();
        }

        if (Input.GetKey(KeyCode.A)) {
            population.Advance();
        }
    }
}
