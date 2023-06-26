using UnityEngine;
using UnityEngine.EventSystems;

namespace Wsh.Sound {

    public class UIClickSoundPlayer : MonoBehaviour, IPointerClickHandler {
    
        [SerializeField]
        private AudioClip clip;
        [SerializeField]
        private float volumeScale = 1;
        private static SoundManager m_soundManager;

        public void OnPointerClick(PointerEventData eventData) {
            if(clip != null && m_soundManager != null) {
                m_soundManager.Play(clip, volumeScale);
            }
        }

        public static void SetSfxManager(SoundManager soundManager) {
            m_soundManager = soundManager;
        }

    }

}