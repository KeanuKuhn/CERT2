
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
namespace Game4
{
    class platform
    {
        Texture2D bad;
        Point position;

        public platform(ContentManager content)
        {
            bad = content.Load<Texture2D>("pstill");
            position.X = 40;
            position.Y = 40;
        }
        public void update()
        {

        }

        public void draw(SpriteBatch batch)
        {
            batch.Draw(bad, new Rectangle(position.X, position.Y, 120, 25), Color.White);
        }
    }
}
