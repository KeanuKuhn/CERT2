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
    class bullet
    {
        Texture2D bulltexture;
        Point bullpos;
        Rectangle bulletrect;

        
        public bullet(Point a_bullpoint)
        {
            bulltexture = Game1.content.Load<Texture2D>("bullet");
            bullpos.X = a_bullpoint.X;
            bullpos.Y = a_bullpoint.Y;
            bulletrect.Width = 40;
            bulletrect.Height = 40;
        }

        public void update()
        {
            bullpos.X += 10;
        }

        public void draw()
        {
            Game1.spriteBatch.Draw(bulltexture, new Rectangle(bullpos.X, bullpos.Y, bulletrect.Width, bulletrect.Height), Color.White);
        }

        public void initialize()
        {

        }
        public Rectangle rect
        {
            get { return new Rectangle(bullpos.X, bullpos.Y, bulletrect.Width, bulletrect.Height); }
        }
    }
}