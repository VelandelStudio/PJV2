using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnables
{
    int maxSpawn { get; }
    float calculTimeToNextSpawn { get; }
    void spawnMob();
}
