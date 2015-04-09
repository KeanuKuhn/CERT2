using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
namespace sickgame
{
    class menustate
    {
        public bool m_switch;
        Texture2D title;

        public menustate()
        {
            m_switch = true;
            title = Game1.content.Load<Texture2D>("titleBig");


            
        }
        public void update(GameTime a_gametime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Game1.m_state = Game1.states.game;
                m_switch = true;
            }

        }
        public void draw()
        {
            Game1.spriteBatch.Draw(title, new Rectangle(360, 10, 560, 144), Color.White);
        }
    }
}
