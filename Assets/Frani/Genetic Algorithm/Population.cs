using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Population {
    public List<Individual> individuals;
    public TileMap tileMap;
    public int nGeneration = 0;

    public Population(TileMap _tileMap) {
        individuals = new List<Individual>();
        tileMap = _tileMap;

        for (var i = 0; i < ConfigManager.config.geneticAlgorithm.nIndividuals; i++) {
            individuals.Add(new Individual(tileMap.GetRandomTile()));
        }
    }

    public void Epoch() {
        PrintStats();
        DestroyGameObjects();
        nGeneration++;

        individuals = individuals.OrderByDescending(o => o.fitness).ToList();

        List<Individual> newIndividuals = new List<Individual>();
        newIndividuals.AddRange(CloneElite(ConfigManager.config.geneticAlgorithm.nElite));
        newIndividuals.AddRange(ReproductionHelper.Reproduce(individuals, ConfigManager.config.geneticAlgorithm.nIndividuals - ConfigManager.config.geneticAlgorithm.nElite, GetFitness()));
        MutationHelper.Mutate(newIndividuals);

        for (int i = 0; i < newIndividuals.Count; i++) {
            newIndividuals[i].SetTile(tileMap.GetRandomTile());
        }

        individuals = new List<Individual>(newIndividuals);
        CreateGameObjects();
    }

    public List<Individual> CloneElite(int nElite) {
        List<Individual> elite = new List<Individual>();
        for (var i = 0; i < nElite; i++) {
            elite.Add(individuals[i].Clone());
        }
        return elite;
    }

    public int GetFitness() {
        int sum = 0;
        for (int i = 0; i < individuals.Count; i++) {
            sum += individuals[i].fitness;
        }
        return sum;
    }

    public void Advance() {
        for (var i = 0; i < individuals.Count; i++) {
            individuals[i].Advance();
        }

        if (HasFinished()) {
            Epoch();
        }
    }

    public bool HasFinished() {
        return (individuals[0].HasFinished());
    }

    public void CreateGameObjects() {
        for (int i = 0; i < individuals.Count; i++) {
            individuals[i].CreateGameObject();
        }
    }

    public void DestroyGameObjects() {
        for (int i = 0; i < individuals.Count; i++) {
            individuals[i].DestroyGameObject();
        }
    }

    public void PrintStats() {
        Debug.Log("Finished generation " + nGeneration + " with a total fitness of " + GetFitness());
    }

    public override string ToString() {
        string s = "Population: ";
        for (int i = 0; i < individuals.Count; i++) {
            s += individuals[i].ToString();
        }
        return s;
    }
}