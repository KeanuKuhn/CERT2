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
    class player
    {
        Texture2D texture;
        Rectangle playerpos;
        Bulletmanager m_manRef;
        int jump;
        bool btimer;


        public player(Bulletmanager a_manRef)
        {
            m_manRef = a_manRef;
            playerpos.X = 312;
            playerpos.Y = 920;
            playerpos = new Rectangle(playerpos.X, playerpos.Y, 90, 90);
            texture = Game1.content.Load<Texture2D>("player");
            btimer = false;
        }

        public void update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space)
                && btimer == false)
            {
                m_manRef.AddBullet(new Point(playerpos.X + 32, playerpos.Y + 30));
                btimer = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Space)
                && btimer == true)
            {
                btimer = false;
            }


            if (Keyboard.GetState().IsKeyDown(Keys.D)
            && playerpos.X < 990)
            {
                playerpos.X += 7;

            }
            if (playerpos.X < 991)
            {
             

            }
            if (Keyboard.GetState().IsKeyDown(Keys.A)
                && playerpos.X > 200)
            {
                playerpos.X -= 4;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.W)
                && jump == 0
                && playerpos.Y > 499)
            {
                jump = 27;
            }
            playerpos.Y -= jump;
            if (playerpos.Y < 500)
            {
                playerpos.Y += 10;
            }
            if (jump > 0)
            {
                jump -= 1;
            }
            if (jump == 0
                && playerpos.Y > 499)
            {
                playerpos.Y = 500 ;
            }

            
        }

        public void draw()
        {
            Game1.spriteBatch.Draw(texture, new Rectangle(playerpos.X, playerpos.Y, 90, 90), Color.White);
        }
    }
}
