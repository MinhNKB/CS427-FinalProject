using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS427_FinalProject
{
    class Effects
    {
        public static Dictionary<EffectType, SoundEffect> Data = new Dictionary<EffectType, SoundEffect>();
        public static void Load()
        {
            for (int i = 0; i < 5; i++)
            {
                EffectType s = (EffectType)i;
                Data.Add(s, Global.gContent.Load <SoundEffect>(@"Sound\" + s.ToString()));
            }
        }
    }

    enum EffectType
    {
        Box = 0,
        Cat = 1,
        Click = 2,
        Dog = 3,
        Jump = 4
    }
}
