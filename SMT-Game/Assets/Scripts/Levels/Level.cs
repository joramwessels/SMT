using UnityEngine;
using System.Collections;

public enum SoundMode
{
    None, Beat, Generated
}

public class Level : MonoBehaviour {

    protected ObjectPool bombs, clouds, stars, rafts;
    protected WaterScript water;
    protected MusicController music;

    [SerializeField]
    //protected SoundMode soundMode = SoundMode.Generated;
    protected SoundMode soundMode = SoundMode.Generated;
    protected static float tickDuration = 1f; // 1 = 120bpm, 0.944889764 = 127bpm
    protected float nextTick;

    bool finished = false;
    public static float getTickDuration() {
        return tickDuration;
        }
    

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

    protected GameObject spawnBomb(float x, float y = 0.05f, float? radius = 4, float explosionDelay = 4, float? teleDuration = 2)
    {
        if (soundMode == SoundMode.Generated)
            music.StartBombCue(0, x);

        var bomb = bombs.Spawn(v2(x, y), false);
        float delay = explosionDelay * tickDuration;
        bomb.GetComponent<BombControllerScript>().SetProperties(radius, delay, teleDuration * tickDuration);
        bomb.gameObject.SetActive(true);

        
        return bomb;
    }

    protected GameObject spawnCloud(float x, float y = 1f, float? size = 1f, float? startWaitDuration = 2f, float? thunderDuration = 2f, float? waitDuration = 2f, float? endWaitDuration = 2f, bool halfDuration = false)
    {
        // The option of 'halfDuration' has been disabled
        if (soundMode == SoundMode.Generated)
            music.StartCloudCue(16 * tickDuration, x);
        
        var cloud = clouds.Spawn(v2(x, y), true);
        float? waitTime = waitDuration * tickDuration;
        float? thunderTime = thunderDuration * tickDuration;
        float? startWaitTime = startWaitDuration * tickDuration;
        float? endWaitTime = endWaitDuration * tickDuration;
        cloud.GetComponent<CloudScript>().SetProperties(1, waitTime, thunderTime, startWaitTime, endWaitTime);
        cloud.gameObject.SetActive(true);
        
        return cloud;
    }

    protected void StartFlood()
    {
        water.State = WaterState.Flood;
        if (soundMode == SoundMode.Generated)
        {
            music.FadeInFloodMusic();
            music.StartFloodCue();
            //music.FadeOutBGMusic();
        }
    }

    protected void EndFlood()
    {
        water.State = WaterState.Ebb;
        if (soundMode == SoundMode.Generated)
        {
            music.FadeOutFloodMusic();
            ////music.EndFloodCue();
            //music.FadeInBGMusic();
        }
    }

    protected void PlayBeep()
    {
        music.PlayBeep();
    }

    protected void PlayBackground()
    {
        if (soundMode == SoundMode.Generated)
            music.PlayBackground();
        if (soundMode == SoundMode.Beat)
            music.PlayBeat();
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
