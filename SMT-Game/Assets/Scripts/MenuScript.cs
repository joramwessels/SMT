/*
The MIT License (MIT)

Copyright (c) 2018 Twan Veldhuis, Ivar Troost

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class MenuScript : MonoBehaviour {

    [SerializeField]
    GameObject explain;
    public static string state = "";
    public static int QuestionsAnswered = 0;
    public static int levelID = 0;
    public static string[] levelNames = new string[] { "MusicLevel", "Level1", "Cloudtopia" , "Bombmania" };
    public static SoundMode[][] soundOrders = new SoundMode[][]
    {
        new SoundMode[] { SoundMode.None, SoundMode.Sounds, SoundMode.All },
        new SoundMode[] { SoundMode.All, SoundMode.Sounds, SoundMode.None },
        new SoundMode[] { SoundMode.Sounds, SoundMode.None, SoundMode.All },
        new SoundMode[] { SoundMode.Sounds, SoundMode.All, SoundMode.None },
        new SoundMode[] { SoundMode.All, SoundMode.None, SoundMode.Sounds },
        new SoundMode[] { SoundMode.None, SoundMode.All, SoundMode.Sounds }
    };
    

	public void OnButton()
    {
        InputField codeField = FindObjectOfType<InputField>();
        int code;
        code = int.Parse(codeField.text);
        UserGroup group;
        try
        {
            group = codeDict[code];
        }
        catch
        {
            return;
        }

        Log.Initialize(System.DateTime.Now.ToString("yyyyMMdd HHmmss", System.Globalization.CultureInfo.InvariantCulture) + ".txt");
        Log.StartSession(group, code);
        Log.SetLevel(soundOrders[(int)group][0], levelNames[0]);
        SceneManager.LoadScene("main");
        state = "game";
    }

    public void OnNext()
    {
        if (!Log.IsSessionInProgress)
            throw new Exception("only valid when session in progress");

        if(state == "game")
        {
            Log.EndAttempt();
            if (Log.Attempt < 5)
                SceneManager.LoadScene("main");
            else
            {
                if (Log.IsSessionInProgress)
                {
                    Log.EndLevel();
                }
                state = levelID < 2 ? "midQ" : "endQ";
                SceneManager.LoadScene("question");
            }
            return;
        }
        else if (state == "midQ")
        {
            //go to the next level
            state = "game";
            levelID++;
            Log.SetLevel(soundOrders[(int)Log.UserGroup][levelID], levelNames[levelID]);
            SceneManager.LoadScene("main");
        }
       
        else if (state == "finished")
        {
            state = "";

            Log.EndSession();
            Log.Close();
            SceneManager.LoadScene("exit");
        }
    }

    public void OnClearLogs()
    {
        Log.ClearLogs();
    }

    Dictionary<int, UserGroup> codeDict = new Dictionary<int, UserGroup>()
    {
        { 1, UserGroup.A },
        { 2, UserGroup.B },
        { 3, UserGroup.C },
        { 4, UserGroup.D },
        { 5, UserGroup.E },
        { 6, UserGroup.F }
    };
}
