using UnityEngine;
using UnityEngine.EventSystems;

namespace Wsh.Sfx {

    public class UIClickSoundPlayer : MonoBehaviour, IPointerClickHandler {
    
        [SerializeField]
        private AudioClip clip;
        [SerializeField]
        private float volumeScale = 1;
        private static SfxManager m_sfxManager;

        public void OnPointerClick(PointerEventData eventData) {
            if(clip != null && m_sfxManager != null) {
                m_sfxManager.Play(clip, volumeScale);
            }
        }

        public static void SetSfxManager(SfxManager sfxManager) {
            m_sfxManager = sfxManager;
        }

    }

}