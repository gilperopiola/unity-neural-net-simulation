using UnityEngine;
using System.Collections.Generic;

public static class ReproductionHelper {
    public static List<Individual> Reproduce(List<Individual> individuals, int nChildren, int totalFitness) {
        List<Individual> children = new List<Individual>();

        for (int i = 0; i < nChildren; i++) {
            Individual parent1 = SpinRoulette(individuals, totalFitness);
            Individual parent2 = SpinRoulette(individuals, totalFitness, parent1);
            children.Add(new Individual(parent1.dna.Merge(parent2.dna)));
        }

        return children;
    }

    private static Individual SpinRoulette(List<Individual> population, int totalFitness, Individual alreadySelectedIndividual = null) {
        float rouletteResult = Random.Range(0, totalFitness);
        float portionCounter = 0;

        if (totalFitness == 0) {
            return population[Random.Range(0, population.Count)];
        }

        for (int i = 0; i < population.Count; i++) {
            portionCounter += population[i].fitness;

            if (portionCounter > rouletteResult) {
                if (alreadySelectedIndividual != null && alreadySelectedIndividual.dna.movements == population[i].dna.movements) {
                    return SpinRoulette(population, totalFitness, alreadySelectedIndividual);
                } else {
                    return population[i];
                }
            }
        }

        Debug.LogError("roulette error: " + totalFitness + " | " + rouletteResult);
        return null;
    }
}