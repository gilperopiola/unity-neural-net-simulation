using System.Collections.Generic;
using UnityEngine;

public static class MutationHelper {
    public static void Mutate(List<Individual> individuals) {
        for (var i = 0; i < individuals.Count; i++) {
            Mutate(individuals[i]);
        }
    }

    public static void Mutate(Individual individual) {
        for (var i = 0; i < individual.dna.movements.Count; i++) {
            if (RandomGenerator.Float(0, 100) < ConfigManager.config.geneticAlgorithm.mutationPercentage) {
                Mutate(individual.dna.movements[i]);
            }
        }
    }

    public static void Mutate(Direction direction) {
        direction = (Direction)RandomGenerator.Int(0, System.Enum.GetValues(typeof(Direction)).Length);
    }
}