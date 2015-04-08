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
    class movingplatform
    {
        bool move;
        bool move2;
        Texture2D bad;
        Point position;

        public movingplatform(ContentManager content)
        {
            bad = content.Load<Texture2D>("mp");
            position.X = 100;
            position.Y = 630;
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
            if (move2 == true)
            {
                position.X -= 3;
            }
            if (move == true)
            {
                position.X += 3;
            }

        }

        public void draw(SpriteBatch batch)
        {
            batch.Draw(bad, new Rectangle(position.X, position.Y, 90, 22), Color.White);
        }
    }
}
