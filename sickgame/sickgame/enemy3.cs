
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
    class enemy3
    {
        bool move;
        bool move2;
        bool um;
        bool dm;
        Texture2D bad;
        Point position;

        public enemy3(ContentManager content)
        {
            bad = content.Load<Texture2D>("player");
            position.X = 10;
            position.Y = 300;
            dm = true;
            move = true;
        }
        public void update()
        {
            if (position.X > 500)
            {
                move = false;
                move2 = true;
            }
            if (position.X < 10)
            {
                move = true;
                move2 = false;
            }



            //////////////////////
            if (position.Y < 200)
            {
                dm = true;
                um = false;
            }
            if (position.Y > 400)
            {
                dm = false;
                um = true;
            }

    



            //move left to right
            if (move2 == true)
            {
                position.X -= 2;
            }
            if (move == true)
            {
                position.X += 2;
            }
            ///////////////////
            if (um == true)
            {
                position.Y -= 2;
            }
            if (dm == true)
            {
                position.Y += 2;
            }
            ////////////////////////
        }

        public void draw(SpriteBatch batch)
        {
            batch.Draw(bad, new Rectangle(position.X, position.Y, 70, 70), Color.White);
        }
    }
}
