using UnityEditor;

namespace Wsh.Sfx {

    public class SfxConfigEditor : UnityEditor.Editor {
        
        private SfxConfig sfxConfig;
        private SerializedProperty sfxConfigDefine;

        private void OnEnable() {
            sfxConfigDefine = serializedObject.FindProperty("SfxConfigDefine");
            sfxConfig = (SfxConfig)target;
        }

        public override void OnInspectorGUI() {
            serializedObject.Update();
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(sfxConfigDefine, true);
            if(EditorGUI.EndChangeCheck()) {
                serializedObject.ApplyModifiedProperties();
                EditorUtility.SetDirty(sfxConfig);
            }
        }
    }

}