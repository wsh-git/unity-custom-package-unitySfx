using System;
using System.Collections.Generic;
using UnityEngine;

namespace Wsh.Sfx {

    [Serializable]
    public class SfxConfigDataClass {
        public string sfxName;
        public float minimumInterval;
    }

    //Assets > Create > 2D > ScriptableObject > SfxConfig 来创建数据对象
    [CreateAssetMenu(fileName = "SfxConfig", menuName = "Custom/ScriptableObject/SfxConfig")]
    public class SfxConfig : ScriptableObject {
        public List<SfxConfigDataClass> SfxConfigDefine = new List<SfxConfigDataClass>();
    }

}