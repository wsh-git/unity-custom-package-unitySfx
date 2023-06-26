using System;
using System.Collections.Generic;
using UnityEngine;

namespace Wsh.Sound {

    [Serializable]
    public class BgmConfigDataClass {
        public string bgmName;
        public float defaultVolume;
        public string path;
    }

    [Serializable]
    public class SfxConfigDataClass {
        public string sfxName;
        public float defaultVolume;
        public float minimumInterval;
        public string path;
    }

    //Assets > Create > 2D > ScriptableObject > SoundConfig 来创建数据对象
    [CreateAssetMenu(fileName = "SoundConfig", menuName = "Custom/ScriptableObject/SoundConfig")]
    public class SoundConfig : ScriptableObject {
        public string GenerateCSharpPath;
        public List<BgmConfigDataClass> BgmConfigDefine = new List<BgmConfigDataClass>();
        public List<SfxConfigDataClass> SfxConfigDefine = new List<SfxConfigDataClass>();
    }

}