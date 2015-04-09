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
    class Background
    {
        Texture2D texture;
        Rectangle bgpos;

        public Background()
        {
            texture = Game1.content.Load<Texture2D>("bg");
            bgpos.X = -250;
        }
        public void update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                bgpos.X -= 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                bgpos.X += 1;
            }
        }

        public void draw()
        {
            //Game1.spriteBatch.Draw(texture, new Rectangle(bgpos.X, 0, 1680, 720), Color.White);
        }
    }
}
