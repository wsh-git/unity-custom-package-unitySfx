using UnityEditor;

namespace Wsh.Sound {

    public class SfxConfigEditor : UnityEditor.Editor {
        
        private SoundConfig soundConfig;
        private SerializedProperty bgmConfigDefine;
        private SerializedProperty sfxConfigDefine;

        private void OnEnable() {
            bgmConfigDefine = serializedObject.FindProperty("BgmConfigDataClass");
            sfxConfigDefine = serializedObject.FindProperty("SfxConfigDefine");
            soundConfig = (SoundConfig)target;
        }

        public override void OnInspectorGUI() {
            serializedObject.Update();
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(bgmConfigDefine, true);
            EditorGUILayout.PropertyField(sfxConfigDefine, true);
            if(EditorGUI.EndChangeCheck()) {
                serializedObject.ApplyModifiedProperties();
                EditorUtility.SetDirty(soundConfig);
            }
        }
    }

}