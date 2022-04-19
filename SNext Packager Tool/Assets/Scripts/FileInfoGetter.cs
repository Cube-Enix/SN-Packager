using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFB;
using System.IO;
using TMPro;

public class FileInfoGetter : MonoBehaviour
{

    string HTMLPath, pngPath, mainPath, appName;
    public bool isUnityTest;
    public TMP_Text debugger;

    public void Start()
    {
        mainPath = Application.dataPath + "/Games";
        if (!Directory.Exists(mainPath))
        {
            AddToDebugger("Wait! We're setting up application for the first time.", "Log");
            Directory.CreateDirectory(mainPath + "/Game Folders (Not Compressed Yet)/");
            Directory.CreateDirectory(mainPath + "/SNTs (Compressed SNext Files)/");

        }
        else
        {
            AddToDebugger("Found path! Started App.", "Log");
        }
    }

    void AddToDebugger(string debugMessage, string messageType)
    {
        debugger.text = debugMessage;
        if(messageType == "Log")
        {
            debugger.color = Color.white;
        }

        if (messageType == "Warning")
        {
            debugger.color = Color.yellow;
        }

        if (messageType == "Error")
        {
            debugger.color = Color.red;
        }
    }

    public void GameName(TMP_InputField textField)
    {
        appName = textField.text;
        if(!Directory.Exists(mainPath + "/Game Folders (Not Compressed Yet)/" + appName))
        {
            Directory.CreateDirectory(mainPath + "/Game Folders (Not Compressed Yet)/" + appName);
            AddToDebugger("Created a new directory for this game!", "Log");

        } else
        {
            AddToDebugger("This directory exists already. Please delete the existing one or choose a new Directory Name.", "Warning");
        }
    }

    public void OpenHTMLFile()
    {
        SaveResult(StandaloneFileBrowser.OpenFilePanel("Open File", "", "html", true), "HTML");
    }

    public void OpenImageFile()
    {
        SaveResult(StandaloneFileBrowser.OpenFilePanel("Open File", "", "png", true), "PNG");
    }

    public void Compress()
    {
        string GameDirectory = mainPath + "/Game Folders (Not Compressed Yet)/" + appName;
        string OutputDirectory = mainPath + "/SNTs (Compressed SNext Files)/" + appName + ".zip";

        AddToDebugger("Compressing into a .SNT!", "Log");
        SNTPackager.instance.compressDirectory(GameDirectory, OutputDirectory, 9);
        File.Move(OutputDirectory, mainPath + "/SNTs (Compressed SNext Files)/" + appName + ".snt");
        AddToDebugger("Done!", "Warn");

    }

    public void SaveResult(string[] paths, string methodType)
    {
        if(methodType == "HTML")
        {
            if (paths.Length == 0)
            {
                return;
            }

            //only uses the first result of the path.
            HTMLPath = paths[0];
            File.Copy(HTMLPath, mainPath + "/Game Folders (Not Compressed Yet)/" + appName + "/" + appName + ".html");
            AddToDebugger("Added .html game file to the game's folder!", "Log");

        } else if(methodType == "PNG")
        {
            if (paths.Length == 0)
            {
                return;
            }

            //only uses the first result of the path.
            pngPath = paths[0];
            File.Copy(pngPath, mainPath + "/Game Folders (Not Compressed Yet)/" + appName + "/" + appName + ".png");
            AddToDebugger("Added .png cover image to the game's folder!", "Log");

        } else
        {
            AddToDebugger("An unknown error occured.", "Error");
        }
    } 

}
