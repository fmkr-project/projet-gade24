using System;
using System.Collections.Generic;

public class CreatureSpawnTable
{
    public Dictionary<float, Creature> Data;

    public Creature GetRandomCreature()
        // Selects a random creature to spawn
    {
        var rand = (float) new Random().NextDouble();
        var spawned = new Creature();
        var sum = 0f;

        foreach (var couple in Data)
        {
            sum += couple.Key;
            spawned = couple.Value;
            if (rand < sum) break;
        }
        // assert: sum == 1
        return spawned;
    }
}