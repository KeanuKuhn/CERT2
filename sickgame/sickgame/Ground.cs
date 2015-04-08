using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
namespace sickgame
{
    class ground
    {
        Texture2D texture;
        Point groundpos;

        public ground()
        {
            texture = Game1.content.Load<Texture2D>("floor");
        }
        public void update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                groundpos.X -= 7;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                groundpos.X += 7;
            }
        }

        public void draw()
        {
            Game1.spriteBatch.Draw(texture, new Rectangle(groundpos.X, 583, 1280, 200), Color.White);
        }
    }
}
