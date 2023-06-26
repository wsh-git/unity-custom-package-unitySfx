using System.Collections.Generic;
using UnityEngine;

namespace Wsh.Sound {

    public class SoundManager : MonoBehaviour {
        
        public bool Enable { get { return m_enable; } }

        private AudioSource m_audioSource;
        private bool m_enable;
        private Dictionary<string, SfxConfigDataClass> m_sfxDic;
        private Dictionary<string, float> m_lastPlayTime = new Dictionary<string, float>();

        public static SoundManager Instantiate(SoundConfig soundConfig) {
            GameObject go = new GameObject("__SfxPlayer");
            SoundManager soundManager = go.AddComponent<SoundManager>();
            soundManager.Init(soundConfig);
            return soundManager;
        }

        private void Init(SoundConfig soundConfig) {
            m_audioSource = gameObject.AddComponent<AudioSource>();
            UIClickSoundPlayer.SetSfxManager(this);
            InitSoundConfig(soundConfig);
            DontDestroyOnLoad(gameObject);
        }

        private void InitSoundConfig(SoundConfig soundConfig) {
            m_sfxDic = new Dictionary<string, SfxConfigDataClass>();
            for(int i = 0; i < soundConfig.SfxConfigDefine.Count; i++) {
                var configData = soundConfig.SfxConfigDefine[i];
                if(!m_sfxDic.ContainsKey(configData.sfxName)) {
                    m_sfxDic.Add(configData.sfxName, configData);
                }
            }
        }

        public void Deinit() {
            UIClickSoundPlayer.SetSfxManager(null);
            Destroy(gameObject);
        }

        public void SetEnable(bool enable) {
            m_enable = enable;
            m_audioSource.mute = !enable;
        }

        public void Play(AudioClip clip) {
            float volume = 1;
            if(m_sfxDic.ContainsKey(clip.name)) {
                volume = m_sfxDic[clip.name].defaultVolume;
            }
            Play(clip, volume);
        }

        private void SetPlayLastTime(string key) {
            float time = Time.realtimeSinceStartup;
            if(!m_lastPlayTime.ContainsKey(key)) {
                m_lastPlayTime.Add(key, time);
            } else {
                m_lastPlayTime[key] = time;
            }
        }

        public void Play(AudioClip clip, float volumeScale) {
            if(m_sfxDic.ContainsKey(clip.name) && m_lastPlayTime.ContainsKey(clip.name)) {
                if(m_lastPlayTime[clip.name] + m_sfxDic[clip.name].minimumInterval > Time.realtimeSinceStartup) {
                    return;
                }
            }
            m_audioSource.PlayOneShot(clip, volumeScale);
            SetPlayLastTime(clip.name);
        }

    }
}