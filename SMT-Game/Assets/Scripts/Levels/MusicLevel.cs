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

        // Testing purposes
        // 2
        //yield return GoToBar(2);
        //spawnCloud(0f, 1, -2f);
        //spawnCloud(.3f, 1, 4f);

        // Getting to know the controls
        // 10
        yield return GoToBar(10);
        stars.Spawn(v2(-0.5f, 2f), true);

        // 12
        yield return GoToBar(12);
        stars.Spawn(v2(.5f, 2f), true);

        // 14
        yield return GoToBar(14);
        stars.Spawn(v2(-.65f, 2f), true);

        // 15
        yield return GoToBar(15);
        stars.Spawn(v2(.65f, 2f), true);

        // 16
        yield return GoToBar(16);
        stars.Spawn(v2(-.75f, 2f), true);

        // 17
        yield return GoToBar(17);
        stars.Spawn(v2(.8f, 2f), true);


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
        // 31
        yield return GoToBar(31);
        spawnBomb(0f, 0.05f, 4);

        // 32
        yield return GoToBar(32);
        stars.Spawn(v2(.8f, 2), true);

        // 33
        yield return GoToBar(33.5f);
        stars.Spawn(v2(-.7f, 2), true);

        // 35
        yield return GoToBar(35);
        stars.Spawn(v2(.8f, 2f), true);
        spawnCloud(0);

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
        stars.Spawn(v2(-.6f, 2f), true);

        // 41
        yield return GoToBar(41);
        spawnCloud(.8f);
        yield return GoToBar(41.5f);
        stars.Spawn(v2(.9f, 2), true);

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

        // Star rain
        yield return GoToBar(53.5f);
        stars.Spawn(v2(-.95f, 30), true);
        stars.Spawn(v2(.7f, 44), true);
        yield return GoToBar(54);
        stars.Spawn(v2(-.3f, 31), true);
        //stars.Spawn(v2(-.9f, 2), true);
        yield return GoToBar(55);
        stars.Spawn(v2(.65f, 34), true);
        yield return GoToBar(55.5f);
        stars.Spawn(v2(-.3f, 29), true);
        yield return GoToBar(55.75f);
        stars.Spawn(v2(.5f, 38), true);

        // 56
        yield return GoToBar(56);
        StartFlood(5f, 29f, false);

        // Star Rain
        yield return GoToBar(56);
        stars.Spawn(v2(-.95f, 34), true);
        yield return GoToBar(56.25f);
        stars.Spawn(v2(.75f, 32), true);
        yield return GoToBar(56.5f);
        stars.Spawn(v2(-.2f, 30), true);
        yield return GoToBar(56.75f);
        stars.Spawn(v2(.85f, 39), true);
        stars.Spawn(v2(-.65f, 31), true);
        stars.Spawn(v2(.1f, 48), true);
        stars.Spawn(v2(-.85f, 44), true);
        yield return GoToBar(57);
        stars.Spawn(v2(.25f, 28), true);
        stars.Spawn(v2(-.45f, 38), true);
        stars.Spawn(v2(.65f, 40), true);
        stars.Spawn(v2(-.75f, 45), true);
        yield return GoToBar(57.5f);
        stars.Spawn(v2(.8f, 35), true);
        //yield return GoToBar(57.75f);
        //stars.Spawn(v2(-.4f, 2.5f), true);
        yield return GoToBar(58f);
        //stars.Spawn(v2(.6f, 1.5f), true);
        yield return GoToBar(58.25f);
        stars.Spawn(v2(-.6f, 20), true);
        yield return GoToBar(58.5f);
        stars.Spawn(v2(.88f, 31), true);
        yield return GoToBar(58.75f);
        stars.Spawn(v2(.1f, 35f), true);
        //yield return GoToBar(59);
        //stars.Spawn(v2(.6f, 1.5f), true);
        yield return GoToBar(59.25f);
        stars.Spawn(v2(-.7f, 29f), true);
        yield return GoToBar(59.275f);
        stars.Spawn(v2(.9f, 30), true);
        yield return GoToBar(59.5f);
        stars.Spawn(v2(.9f, 32f), true);
        //stars.Spawn(v2(-.9f, 1.5f), true);
        //yield return GoToBar(59.75f);
        //stars.Spawn(v2(-.1f, 3f), true);
        yield return GoToBar(60);
        stars.Spawn(v2(.3f, 42f), true);
        stars.Spawn(v2(-.5f, 62f), true);

        // 64
        yield return GoToBar(64);
        spawnCloud(-0.3f);

        // 65
        yield return GoToBar(65);
        spawnCloud(.3f);

        // 67
        yield return GoToBar(67);
        spawnBomb(.5f, 0.05f, 2.5f);

        // 69
        yield return GoToBar(69);
        stars.Spawn(v2(.3f, 2), true);


        //------------------------
        // Stage 3: Climax

        // Moving clouds intro
        // 74
        yield return GoToBar(74);
        spawnBomb(-.7f, .05f, 3);
        spawnCloud(.95f, 1f, -.7f);
        stars.Spawn(v2(-.8f, 2f), true);
        yield return GoToBar(74.5f);
        stars.Spawn(v2(.8f, 2f), true);

        // 75
        yield return GoToBar(75);
        StartFlood(5f, 30f, false);

        // 77
        yield return GoToBar(77);
        spawnCloud(0);
        stars.Spawn(v2(-.2f, 1), true);
        stars.Spawn(v2(.2f, 3), true);

        // Approaching storm on sea
        // 78
        yield return GoToBar(78);
        stars.Spawn(v2(.8f, 2), false);
        stars.Spawn(v2(-.8f, 3.5f), false);

        // 81
        yield return GoToBar(81);
        spawnBomb(.7f, .05f, 4f);
        spawnCloud(-.9f, 1, 1);

        // 82
        yield return GoToBar(82);
        stars.Spawn(v2(.3f, 2), true);

        // 83
        yield return GoToBar(83);
        spawnBomb(-.7f, .05f, 4f);
        spawnCloud(-.9f, 1, 1);
        stars.Spawn(v2(-.3f, 2), true);

        // 85
        yield return GoToBar(85);
        spawnCloud(-.9f, 1, 1);
        stars.Spawn(v2(.3f, 2), true);

        // 86
        yield return GoToBar(86);
        stars.Spawn(v2(-.4f, 2), true);

        // 87
        yield return GoToBar(87);
        stars.Spawn(v2(.4f, 2), true);


        // Sandwiched by storms
        // 87
        yield return GoToBar(87);
        spawnBomb(0, .05f, 3);
        // 89
        yield return GoToBar(89);
        spawnCloud(.85f, 1, -1);
        spawnCloud(-.85f, 1, 1);

        // 91
        yield return GoToBar(91);
        stars.Spawn(v2(-.3f, 2), true);
        stars.Spawn(v2(.3f, 2), true);
        spawnCloud(.85f);
        spawnCloud(-.85f);

        yield return GoToBar(111f);
        yield return WaitTick(4);
        yield return base.LevelScript();
    }
}
