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
        int bg_playerposX;
        bool edgescreen;

        public ground()
        {
            texture = Game1.content.Load<Texture2D>("ground");
            edgescreen = false;
        }
        public void update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D)
                && Keyboard.GetState().IsKeyUp(Keys.Space)
                && edgescreen == false)
            {
                bg_playerposX += 7;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A)
                && Keyboard.GetState().IsKeyUp(Keys.Space)
                && edgescreen == false)
            {
                bg_playerposX -= 3;
            }
            if (bg_playerposX > 1280)
            {
                edgescreen = true;
            }
            if (edgescreen == true)
            {
                groundpos.X -= 10;
                bg_playerposX -= 10;
            }
            if (bg_playerposX <= 100)
            {
                edgescreen = false;
            }
        }

        public void draw()
        {
            Game1.spriteBatch.Draw(texture, new Rectangle(groundpos.X, 582, 1280, 138), Color.White);
        }
    }
}
