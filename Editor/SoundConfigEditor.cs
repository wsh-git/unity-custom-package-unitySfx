using System.Text;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Wsh.Sound {

    [CustomEditor(typeof(SoundConfig))]
    public class SoundConfigEditor : Editor {
        
        private SoundConfig soundConfig;
        private SerializedProperty generateCSharpPath;
        private SerializedProperty bgmConfigDefine;
        private SerializedProperty sfxConfigDefine;

        private void OnEnable() {
            generateCSharpPath = serializedObject.FindProperty("GenerateCSharpPath");
            bgmConfigDefine = serializedObject.FindProperty("BgmConfigDefine");
            sfxConfigDefine = serializedObject.FindProperty("SfxConfigDefine");
            soundConfig = (SoundConfig)target;
        }

        public override void OnInspectorGUI() {
            serializedObject.Update();
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(generateCSharpPath);
            EditorGUILayout.PropertyField(bgmConfigDefine, true);
            EditorGUILayout.PropertyField(sfxConfigDefine, true);
            if(EditorGUI.EndChangeCheck()) {
                serializedObject.ApplyModifiedProperties();
                EditorUtility.SetDirty(soundConfig);
            }

            if(GUILayout.Button("Auto Generate (SoundId) CSharp Script")) {
                Generate();
            }
        }

        private void Generate() {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("//Automatically generated, do not manually modify it!!!\n\n");
            stringBuilder.Append("namespace Wsh.Sound {\n\n");
            stringBuilder.Append("    public class SoundPath {\n");
            
            for(int i = 0; i < soundConfig.BgmConfigDefine.Count; i++) {
                GenerateVar(stringBuilder, soundConfig.BgmConfigDefine[i].bgmName, soundConfig.BgmConfigDefine[i].path);
            }
            for(int i = 0; i < soundConfig.SfxConfigDefine.Count; i++) {
                GenerateVar(stringBuilder, soundConfig.SfxConfigDefine[i].sfxName, soundConfig.SfxConfigDefine[i].path);
            }
            stringBuilder.Append("    }\n\n");
            stringBuilder.Append("}");
            string path = Path.Combine(Application.dataPath, soundConfig.GenerateCSharpPath, "SoundPath.cs");
            File.WriteAllText(path, stringBuilder.ToString());
            AssetDatabase.Refresh();
        }

        private void GenerateVar(StringBuilder stringBuilder, string varName, string varValue) {
            stringBuilder.Append("        ");
            stringBuilder.Append("public const string ");
            stringBuilder.Append(varName.ToUpper());
            stringBuilder.Append(" = ");
            stringBuilder.Append("\"");
            stringBuilder.Append(varValue);
            stringBuilder.Append("\"");
            stringBuilder.Append(";");
            stringBuilder.Append("\n");
        }
    }

}