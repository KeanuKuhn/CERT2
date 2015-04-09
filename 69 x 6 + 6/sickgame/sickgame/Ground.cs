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

        player currentPlayer;

        public ground(player a_currentPlayer)
        {
            texture = Game1.content.Load<Texture2D>("ground2");
            currentPlayer = a_currentPlayer;
        }
        public void update(player a_currentPlayer)
        {
            if (a_currentPlayer.playeredgescreen == true)
            {
                groundpos.X -= 10;
            }
        }

        public void draw()
        {
            Game1.spriteBatch.Draw(texture, new Rectangle(groundpos.X, 582, 3840, 138), Color.White);
        }
    }
}
