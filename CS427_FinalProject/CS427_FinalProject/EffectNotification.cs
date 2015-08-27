using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS427_FinalProject
{
    class EffectNotification : VisibleGameEntity
    {
        private int duration = 0;
        private string effectString;
        private float left, bottom;

        public void Show(SpecialEffect effect,Vector4 boundingBox)
        {
            effectString = GetEffectString(effect);
            duration = 30;
            left = boundingBox.X;
            bottom = boundingBox.Y;
        }

        private string GetEffectString(SpecialEffect effect)
        {
            string result="";
            if (effect == SpecialEffect.DoubleJump)
                result = "Super Jump";
            else if (effect == SpecialEffect.Haste)
                result = "Haste";
            else if (effect == SpecialEffect.NoJump)
                result = "No Jump";
            else if (effect == SpecialEffect.Reverse)
                result = "Reverse";
            result += "!!!";
            while (result.Length < 13)
                result = " " + result + " ";
            return result;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            duration--;
            bottom-=2;
            if (duration < 0)
                duration = 0;
        }

        public override void Draw(GameTime gameTime, object param)
        {
            base.Draw(gameTime, param);
            if (duration > 0)
                (param as SpriteBatch).DrawString(Global.gDefaultMediumFont, effectString, new Vector2(left - 100, bottom - 10), Color.Black, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
        }
    }
}
