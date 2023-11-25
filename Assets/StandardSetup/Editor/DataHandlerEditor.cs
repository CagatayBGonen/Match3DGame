using System;
using System.IO;
using StandardSetup.Runtime.Handlers;
using UnityEditor;
using UnityEngine;

namespace StandardSetup.Editor
{
    public class DataHandlerEditor : EditorWindow
    {
        [MenuItem("StandardSetup/Data Window")]
        public static void ShowWidow()
        {
            GetWindow<DataHandlerEditor>("Data Handler");
        }

        private void OnGUI()
        {
            GUILayout.Label("Data Window", EditorStyles.wordWrappedLabel);
            if (GUILayout.Button("Open Save Path"))
            {
                OpenSaveDataPath();
            } 
            if (GUILayout.Button("Clear Data"))
            {
                ClearData();
            }
        }

        private void OpenSaveDataPath()
        {
            var saveSavePath = Application.persistentDataPath;
            if (Directory.Exists(saveSavePath))
            {
                Debug.Log(saveSavePath);
                EditorUtility.RevealInFinder(saveSavePath);
            }
            else
            {
                Debug.LogWarning($"There is no save path like {saveSavePath}");
            }
        }

        private void ClearData()
        {
            DataHandler.ClearAll();
        }
    }
}
