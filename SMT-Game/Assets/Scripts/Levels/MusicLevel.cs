using UnityEngine;
using System.Collections;

public class MusicLevel : Level
{

    ////////////////////
    // TODO:
    // - Create level
    // - (create level.cs/SpawnStar() function to include star music)?
    // - game music modes

    //float bar = 0.944889764f; // 1 bar at 127bpm
    //float beat = 0.4725f;


    protected override IEnumerator LevelScript()
    {
        PlayBackground();
        rafts.Spawn(v2(-0.3f, -1f), true);
        yield return WaitBars(18f);

        // 19
        StartFlood(5f, 26f, true);
        yield return WaitBars(26f);

        // 35
        var cloud1 = spawnCloud(-0.5f, 1, 1, 4f, 1f, 3f, 3f);
        yield return WaitBars(8f);

        // 43
        var cloud2 = spawnCloud(-0.5f, 1, 1, 4f, 1f, 3f, 3f);
        yield return WaitBars(12f);

        // 55
        var bomb1 = spawnBomb(-0.5f, 0.05f, 4, 8, 6);
        yield return WaitBars(8f);

        // 63

        //yield return WaitBars(8f);
        //var bomb2 = spawnBomb(-0.5f, 0.05f, 4, 8, 6);
        //yield return WaitBars(8f);
        //var cloud3 = spawnCloud(-0.5f, 1, 1, 4f, 1f, 3f, 3f);
        //yield return WaitBars(8f);

        /*//0
        var bomb1 = spawnBomb(-0.5f, 0.05f, 4, 4, 2);
        var star1 = stars.Spawn(v2(0.9f, 1f), true);
        var star2 = stars.Spawn(v2(-0.9f, 1f), true);
        PlayBackground();
        yield return WaitTick(4);
        //4
        var cloud1 = spawnCloud(-0.5f, 0.05f, 1, 2, 2);
        yield return WaitTick(4);
        //8
        var star3 = stars.Spawn(v2(-0.2f, 1f), true);
        yield return WaitTick(3);
        //11
        ObjectPool.Despawn(star1, "star pool");
        ObjectPool.Despawn(star2, "star pool");
        StartFlood();
        yield return WaitTick(1);
        //12
        ObjectPool.Despawn(cloud1, "cloud pool");
        yield return WaitTick(4);
        //16
        EndFlood();
        ObjectPool.Despawn(star3, "star pool");*/
        yield return WaitTick(4);
        yield return base.LevelScript();
    }
}
