using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#region Using Statements
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
#endregion
namespace sickgame
{
    class block
    {
        public Texture2D texture;
        public Rectangle blockpos;
        public int width = 70;
        public int height = 70;



        public block( ContentManager content)
        {
            texture = content.Load<Texture2D>("pstill");
            blockpos.X = 400;
            blockpos.Y = 450;
        }

        public void update()
        {
           
        }

        public void draw()
        {
            Game1.spriteBatch.Draw(texture, new Rectangle(blockpos.X, blockpos.Y, 70, 70), Color.White);
        }
    }
}