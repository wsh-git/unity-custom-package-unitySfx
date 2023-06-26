using UnityEngine;
using UnityEngine.EventSystems;

namespace Wsh.Sound {

    public class UIClickSoundPlayer : MonoBehaviour, IPointerClickHandler {
    
        [SerializeField]
        private AudioClip clip;
        [SerializeField]
        private float volumeScale = 0;
        private static SoundManager m_soundManager;

        public void OnPointerClick(PointerEventData eventData) {
            if(clip != null && m_soundManager != null) {
                if(volumeScale != 0) {
                    m_soundManager.PlaySfx(clip, volumeScale);
                } else {
                    m_soundManager.PlaySfx(clip);
                }
            }
        }

        public static void SetSoundManager(SoundManager soundManager) {
            m_soundManager = soundManager;
        }

    }

}