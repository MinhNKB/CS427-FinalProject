﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS427_FinalProject
{
    class Cat : Character
    {
        public Cat()
        {
            LoadSprites(CharacterTexture.Cat);
            this.CurrentState = CharacterState.None;
            this.keyUp = Keys.Up;
            this.keyLeft = Keys.Left;
            this.keyRight = Keys.Right;
            this.keyDown = Keys.Down;
        }
    }
}
