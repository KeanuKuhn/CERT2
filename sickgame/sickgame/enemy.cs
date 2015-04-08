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
    class enemy
    {
        bool move;
        bool move2;
        Texture2D bad;
        Point position;

        public enemy(ContentManager content)
        {
            bad = content.Load<Texture2D>("player");
            position.X = 100;
            position.Y = 650;
            move = true;
        }
        public void update()
        {
            if (position.X > 200)
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
                position.X -= 2;
            }
            if (move == true)
            {
                position.X += 2;
            }
        }

        public void draw(SpriteBatch batch)
        {
            batch.Draw(bad, new Rectangle(position.X, position.Y, 70, 70), Color.White);
        }
    }
}
