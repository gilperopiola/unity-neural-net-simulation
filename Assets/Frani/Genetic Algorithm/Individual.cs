using UnityEngine;
using System.Collections.Generic;

public class Individual {
    public GameObject gameObject;
    public Tile tileOn;
    public Vector2 position;
    public DNA dna;
    public List<Direction> movements;
    public int fitness = 0;

    public Individual(Tile _tile) {
        SetTile(_tile);
        dna = new DNA();
        movements = new List<Direction>(dna.movements);
    }

    public Individual(DNA _dna) {
        dna = _dna;
        movements = new List<Direction>(dna.movements);
    }

    public void Advance() {
        Direction direction = movements[0];
        movements.RemoveAt(0);

        Tile destinationTile = tileOn.GetNeighbour(direction);
        if (destinationTile != null) {
            Move(destinationTile);
        }

        if (tileOn.type == TileType.GRASS) {
            fitness++;
        }
    }

    public Individual Clone() {
        Individual clone = new Individual(dna);
        return clone;
    }

    public void Move(Tile newTile) {
        SetTile(newTile);

        if (gameObject != null) {
            gameObject.transform.position = tileOn.gameObject.transform.position;
        }
    }

    public void SetTile(Tile _tile) {
        if (tileOn != null) {
            tileOn.RemoveIndividual(this);
        }

        tileOn = _tile;
        position = tileOn.position;

        tileOn.AddIndividual(this);
    }

    public bool HasFinished() {
        return (movements.Count == 0);
    }

    public void CreateGameObject() {
        gameObject = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/Individual"), new Vector3(position.x * 32, position.y * -32, 0), Quaternion.identity);
    }

    public void DestroyGameObject() {
        GameObject.Destroy(gameObject);
    }

    public override string ToString() {
        return "Individual[" + position.x + "][" + position.y + "] / Fitness: " + fitness + " / Movements: " + dna.ToString();
    }
}