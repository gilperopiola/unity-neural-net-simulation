using System.Collections.Generic;

public class DNA {
    public List<Direction> movements;

    public DNA() {
        movements = new List<Direction>();

        for (var i = 0; i < ConfigManager.config.geneticAlgorithm.nMovements; i++) {
            movements.Add((Direction)RandomGenerator.Int(0, 8));
        }
    }

    public DNA(List<Direction> _movements) {
        movements = _movements;
    }

    public DNA Merge(DNA otherDNA) {
        List<Direction> newMovements = new List<Direction>();

        int crossPosition = RandomGenerator.Int(0, movements.Count - 1);

        for (var i = 0; i < movements.Count; i++) {
            newMovements.Add((i <= crossPosition) ? movements[i] : otherDNA.movements[i]);
        }

        return new DNA(newMovements);
    }

    public override string ToString() {
        string movementsString = "";
        for (int i = 0; i < movements.Count; i++) {
            switch (movements[i]) {
                case Direction.NONE:
                    movementsString += "NO |";
                    break;
                case Direction.UP:
                    movementsString += "U |";
                    break;
                case Direction.UP_RIGHT:
                    movementsString += "UR |";
                    break;
                case Direction.RIGHT:
                    movementsString += "R |";
                    break;
                case Direction.RIGHT_DOWN:
                    movementsString += "RD |";
                    break;
                case Direction.DOWN:
                    movementsString += "D |";
                    break;
                case Direction.DOWN_LEFT:
                    movementsString += "DL |";
                    break;
                case Direction.LEFT:
                    movementsString += "L |";
                    break;
                case Direction.LEFT_UP:
                    movementsString += "LU |";
                    break;
            }
        }
        return movementsString;
    }
}