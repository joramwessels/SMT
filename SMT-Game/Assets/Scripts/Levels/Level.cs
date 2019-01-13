using UnityEngine;
using System.Collections;

public enum SoundMode
{
    None, Sounds, All
}

public class Level : MonoBehaviour {

    protected ObjectPool bombs, clouds, stars, rafts;
    protected WaterScript water;
    protected MusicController music;

    [SerializeField]
    //protected SoundMode soundMode = SoundMode.Generated;
    protected SoundMode soundMode = SoundMode.All;
    protected static float tickDuration = 1f; // 1 = 120bpm, 0.944889764 = 127bpm
    protected float nextTick;

    protected static float barLength = 0.944889764f * 2; // 1 bar at 127bpm
    protected static float barSeconds = 1.88976377952755905511811f; // 1 bar at 127bpm in seconds

    bool finished = false;
    public static float getTickDuration() {
        return tickDuration;
        }
    public static float getBarLength()
    {
        return barLength;
    }

    System.DateTime startTimeOfBackgroundMusic;

    // Use this for initialization
    void Start () {
        bombs = GameObject.Find("bomb pool").GetComponent<ObjectPool>();
        clouds = GameObject.Find("cloud pool").GetComponent<ObjectPool>();
        stars = GameObject.Find("star pool").GetComponent<ObjectPool>();
        rafts = GameObject.Find("raft pool").GetComponent<ObjectPool>();
        water = GameObject.Find("water").GetComponent<WaterScript>();
        music = GameObject.Find("MusicController").GetComponent<MusicController>();
        nextTick = Time.time + tickDuration;
        soundMode = Log.CurrentMode;
        Log.StartLevel(Time.time);
       
        StartCoroutine(LevelScript());
	}

    void Update()
    {
        if(finished)
        {
            FindObjectOfType<LevelController>().Finish();
        }
    }

    protected GameObject spawnBomb(float x, float y = 0.05f, float? radius = 4, float explosionDelay = 8, float? teleDuration = 6)
    {
        if (soundMode == SoundMode.All || soundMode == SoundMode.Sounds)
            music.StartBombCue(-1, x);

        var bomb = bombs.Spawn(v2(x, y), false);
        float delay = explosionDelay * (barLength * .5f);
        bomb.GetComponent<BombControllerScript>().SetProperties(radius, delay, teleDuration * (barLength * .5f));
        bomb.gameObject.SetActive(true);

        
        return bomb;
    }

    protected GameObject spawnCloud(float x, float y = 1f, float? size = 1f, float? startWaitDuration = 4f, float? thunderDuration = 1f, float? waitDuration = 3f, float? endWaitDuration = 3f, bool halfDuration = false)
    {
        // The option of 'halfDuration' has been disabled
        if (soundMode == SoundMode.All || soundMode == SoundMode.Sounds)
            music.StartCloudCue(16 * barLength, x);
        
        var cloud = clouds.Spawn(v2(x, y), true);
        float? waitTime = waitDuration * (barLength * .5f);
        float? thunderTime = thunderDuration * (barLength * .5f);
        float? startWaitTime = startWaitDuration * (barLength * .5f);
        float? endWaitTime = endWaitDuration * (barLength * .5f);
        cloud.GetComponent<CloudScript>().SetProperties(1, waitTime, thunderTime, startWaitTime, endWaitTime);
        cloud.gameObject.SetActive(true);
        
        return cloud;
    }

    //protected GameObject spawnStar(float x, float y, float duration)
    //{
    //    if (soundMode == SoundMode.Generated)
    //        music.PlayStarCue(duration * tickDuration);
    //
    //    var star = stars.Spawn(v2(x, y), true);
    //    //star.GetComponent<StarScript>.SetProperties();
    //    return star;
    //}

    // Calling a flood by only specifying the start and duration
    protected void StartFlood(float delay, float duration, bool fadeOut)
    {
        StartCoroutine(Flood(delay, duration, fadeOut));
    }

    IEnumerator Flood(float delay, float duration, bool fadeOut)
    {
        if (soundMode == SoundMode.All || soundMode == SoundMode.Sounds)
        {
            //music.FadeInFloodMusic();
            music.StartFloodCue(duration * barLength, fadeOut);
            //music.FadeOutBGMusic();
        }
        water.GetComponent<WaterScript>().SetProperties(delay * barLength);
        water.GetComponent<WaterScript>().SetStartTime(Time.time);
        water.State = WaterState.Flood;
        yield return new WaitForSecondsRealtime(duration);
        EndFlood();
    }

    // Calling and ending a flood manually
    protected void StartFlood()
    {
        if (soundMode == SoundMode.All || soundMode == SoundMode.Sounds)
        {
            //music.FadeInFloodMusic();
            music.StartFloodCue(8f * barLength, false);
            //music.FadeOutBGMusic();
        }
        water.State = WaterState.Flood;
    }

    protected void EndFlood()
    {
        water.State = WaterState.Ebb;
        if (soundMode == SoundMode.All || soundMode == SoundMode.Sounds)
        {
            //music.FadeOutFloodMusic();
            ////music.EndFloodCue();
            //music.FadeInBGMusic();
        }
    }

    protected void PlayBackground()
    {
        startTimeOfBackgroundMusic = System.DateTime.Now; // logs the exact time within the frame
        if (soundMode == SoundMode.All)
            music.PlayBackground();
    }


    private bool hasNextTickPassed()
    {
        if(Time.time >= nextTick)
        {
            nextTick += tickDuration;
            return true;
        }
        return false;
    }

    protected IEnumerator WaitTick(int amount = 1)
    {
        for (int i = 0; i < amount; i++)
        {
            yield return new WaitUntil(hasNextTickPassed);
            Log.NextTick();
        }
    }

    protected IEnumerator WaitBars(float bars)
    {
        //yield return new WaitForSecondsRealtime(bars * barLength);
        yield return new WaitForSecondsRealtime(0);
    }

    protected IEnumerator GoToBar(float bar)
    {
        System.DateTime sleepUntil = startTimeOfBackgroundMusic + new System.TimeSpan(0, 0, 0, 0, (int)((bar-1) * barSeconds * 1000));
        System.TimeSpan duration = sleepUntil - System.DateTime.Now;
        yield return new WaitForSecondsRealtime((float)duration.Seconds + (float)duration.Milliseconds / 1000.0f);
    }

    public static Vector2 v2(float x, float y)
    {
        //left floor = -6.38, -0.44
        //right floor = 6.38, -0.44
        //ebb level = -4
        //cloud height is around 3.
        //This provides a scaling method so everything on the screen can be defined from -1 to 1.
        return new Vector2(x * 6.38f, y * 3.56f - 0.44f);
    }

    protected virtual IEnumerator LevelScript()
    {
        finished = true;
        yield return null;
    }

}
