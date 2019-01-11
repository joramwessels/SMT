using UnityEngine;
using System.Collections;

public class MusicLevel : Level
{

    ////////////////////
    // TODO:
    // - Create level
    // - Star's don't disappear
    // - Something isn't in sync

    //float bar = 0.944889764f; // 1 bar at 127bpm
    //float beat = 0.4725f;


    protected override IEnumerator LevelScript()
    {
        PlayBackground();
        rafts.Spawn(v2(-0.3f, -1f), true);
        yield return WaitBars(11f);

        //------------------------
        // Stage 1: Tutorial
        

        // Getting to know the controls
        // 12
        stars.Spawn(v2(-0.5f, 2f), true);
        yield return WaitBars(2f);

        // 14
        stars.Spawn(v2(.5f, 2f), true);
        yield return WaitBars(5f);


        // Flood
        // 19
        StartFlood(5f, 20f, false);
        yield return WaitBars(2f);

        // 21
        stars.Spawn(v2(-.8f, 2f), true);
        yield return WaitBars(2f);

        // 23
        stars.Spawn(v2(.8f, 2f), true);
        yield return WaitBars(2f);

        // 25
        spawnCloud(.3f);
        yield return WaitBars(8f);


        // Bomb
        // 33
        spawnBomb(0f, 0.05f, 4);
        yield return WaitBars(3f);

        // 35
        stars.Spawn(v2(-.8f, 2f), true);
        yield return WaitBars(1f);

        // 36
        stars.Spawn(v2(.8f, 2f), true);
        spawnBomb(.6f, 0.05f, 3);
        yield return WaitBars(2f);


        // Clouds
        // 39
        spawnCloud(-0.5f, 1, 1);
        yield return WaitBars(1f);

        // 40
        stars.Spawn(v2(-.9f, 2f), true);
        yield return WaitBars(5f);

        // 45
        spawnCloud(0.5f, 1, 1);
        yield return WaitBars(6f);


        //-----------------------
        // Stage 2: breakdown
        yield return WaitBars(4f);

        // 51
        StartFlood(5f, 30f, false);
        yield return WaitBars(8f);

        // 55
        spawnCloud(-0.3f);
        yield return WaitBars(1f);

        // 58
        spawnCloud(.3f);
        yield return WaitBars(6f);

        // 64
        stars.Spawn(v2(.3f, 2), true);
        yield return WaitBars(2f);

        //------------------------
        // Stage 3: Climax
        yield return WaitBars(1f);

        // 65


        // test
        yield return WaitBars(16f);
        spawnCloud(0);
        yield return WaitBars(8f);
        // test

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
