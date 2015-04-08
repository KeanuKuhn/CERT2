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
    class enemy2
    {
        Texture2D bad;
        Point position;
        int jump;
        int timer;

        public enemy2(ContentManager content)
        {
            bad = content.Load<Texture2D>("player");
            position.X = 300;
            position.Y = 650;
            jump = 27;
        }
        public void update()
        {
            timer += 1;
            if (timer > 40)
            {
                jump = 27;
                timer = 0;
            }
            position.Y -= jump;
            if (position.Y < 500)
            {
                position.Y += 10;
            }
            if (jump > 0)
            {
                jump -= 1;
            }
            if (jump == 0
                && position.Y > 499)
            {
                position.Y = 500;
            }

        }
        public void draw(SpriteBatch batch)
        {
            batch.Draw(bad, new Rectangle(position.X, position.Y, 70, 70), Color.White);
        }
    }
}
