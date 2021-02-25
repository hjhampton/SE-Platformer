using UnityEditor;
using UnityEngine;
using System.IO;
using System;
using Unity.VersionControl.Git;

namespace GitHub.Unity
{
    [InitializeOnLoad]
    public class UnityAPIWrapper : ScriptableSingleton<UnityAPIWrapper>
    {
        static UnityAPIWrapper()
        {
#if UNITY_2018_2_OR_NEWER
            Editor.finishedDefaultHeaderGUI += editor => {
                UnityShim.Raise_Editor_finishedDefaultHeaderGUI(editor);
            };
#endif
        }
    }
}

namespace Unity.VersionControl.Git
{
    public static class UnityShim
    {
        public static event Action<UnityEditor.Editor> Editor_finishedDefaultHeaderGUI;
        public static void Raise_Editor_finishedDefaultHeaderGUI(UnityEditor.Editor editor)
        {
            if (Editor_finishedDefaultHeaderGUI != null)
                Editor_finishedDefaultHeaderGUI(editor);
        }
    }
}