using UnityEngine;
using System.Collections;

public class MusicLevel : Level
{

    ////////////////////
    // TODO:
    // - Finish level
    // - Make questionnaire
    // - "Try Again" changes sound mode


    protected override IEnumerator LevelScript()
    {
        PlayBackground();
        rafts.Spawn(v2(-0.3f, -1f), true);

        //------------------------
        // Stage 1: Tutorial


        // Getting to know the controls
        // 10
        yield return GoToBar(10);
        stars.Spawn(v2(-0.5f, 2f), true);

        // 12
        yield return GoToBar(12);
        stars.Spawn(v2(.5f, 2f), true);

        // 16
        yield return GoToBar(16);
        stars.Spawn(v2(-.65f, 2f), true);

        // 17
        yield return GoToBar(17);
        stars.Spawn(v2(.65f, 2f), true);


        // Flood
        // 19
        yield return GoToBar(19);
        StartFlood(5f, 20f, false);

        // 21
        yield return GoToBar(21);
        stars.Spawn(v2(-.8f, 2f), true);

        // 23
        yield return GoToBar(23);
        stars.Spawn(v2(.8f, 2f), true);

        // 25
        yield return GoToBar(25);
        spawnCloud(.3f);

        // 26
        yield return GoToBar(26);
        stars.Spawn(v2(.3f, 2f), true);


        // Bomb
        // 32
        yield return GoToBar(31);
        spawnBomb(0f, 0.05f, 4);

        // 36
        yield return GoToBar(36);
        stars.Spawn(v2(.8f, 2f), true);

        // 37
        yield return GoToBar(37);
        stars.Spawn(v2(-.8f, 2f), true);
        spawnBomb(.6f, 0.05f, 3);
        spawnBomb(-.6f, .05f, 3);

        // 38
        yield return GoToBar(38);
        stars.Spawn(v2(.7f, 2f), true);


        // Clouds
        // 39
        yield return GoToBar(39);
        spawnCloud(-0.5f, 1);

        // 40
        yield return GoToBar(40);
        stars.Spawn(v2(-.9f, 2f), true);

        // 45
        yield return GoToBar(45);
        spawnCloud(0.5f, 1);
        spawnCloud(-.5f, 1);

        // 46
        yield return GoToBar(46);
        stars.Spawn(v2(.7f, 2), true);

        // 47
        yield return GoToBar(47);
        stars.Spawn(v2(-.4f, 2), true);


        //-----------------------
        // Stage 2: breakdown

        // 56
        yield return GoToBar(56);
        StartFlood(5f, 32f, false);

        // 64
        yield return GoToBar(64);
        spawnCloud(-0.3f);

        // 65
        yield return GoToBar(65);
        spawnCloud(.3f);

        // 69
        yield return GoToBar(69);
        stars.Spawn(v2(.3f, 2), true);

        //------------------------
        // Stage 3: Climax

        // 74
        yield return GoToBar(74f);


        yield return GoToBar(111f);
        yield return WaitTick(4);
        yield return base.LevelScript();
    }
}
