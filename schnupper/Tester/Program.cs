using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class GameWindow : Game
{
        private GraphicsDeviceManager _gdm;
        private SpriteBatch _sb;
        private GraphicsDevice _gd;

        
        public GameWindow()
        {
            _gdm = new GraphicsDeviceManager(this);
            _gdm.PreferredBackBufferWidth = 144 * 3;
            _gdm.PreferredBackBufferHeight = 256 * 3;
            _gdm.SynchronizeWithVerticalRetrace = true;

            IsFixedTimeStep = true;

            _gdm.ApplyChanges();

            _gd = _gdm.GraphicsDevice;

            _sb = new SpriteBatch(_gd);
        }

        protected override void Update(GameTime delta)
        {
            base.Update(delta);
        }

        protected override void Draw(GameTime delta)
        {
            base.Draw(delta);

            
        }
}