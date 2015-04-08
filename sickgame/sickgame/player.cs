using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace sickgame
{
    class player
    {
        Texture2D texture;
        Texture2D ammop;
        Rectangle playerpos;
        Bulletmanager m_manRef;
        int jump;
        bool btimer;
        int runtimer;
        int momentum;
        int ammo;
        int m_timer;


        public player(Bulletmanager a_manRef)
        {
            m_manRef = a_manRef;
            playerpos.X = 312;
            playerpos.Y = 920;
            playerpos = new Rectangle(playerpos.X, playerpos.Y, 90, 90);
            texture = Game1.content.Load<Texture2D>("P.idle");
            ammop = Game1.content.Load<Texture2D>("pstill");
            btimer = false;
            m_timer = 0;
            ammo = 50;
        }

        public void update()
        {

            //momentum / player maintains momentum in air

            m_timer += 1;
            playerpos.X += momentum;
            
            if (momentum > 0
                && momentum < 0
                && m_timer > 20)
            {
                momentum -= 1;
                m_timer = 0;
            }

            if (playerpos.Y > 489
                && Keyboard.GetState().IsKeyUp(Keys.D)
                && Keyboard.GetState().IsKeyUp(Keys.A))
            {
                momentum = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D)
                && Keyboard.GetState().IsKeyUp(Keys.Space)
                && momentum < 7)
            {
                momentum += 1;

            }

            if (Keyboard.GetState().IsKeyDown(Keys.A)
                && Keyboard.GetState().IsKeyUp(Keys.Space)
                && momentum > -3)
            {
                momentum -= 1;

            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space)
                && playerpos.Y > 489)
            {
                momentum = 0;
            }

            //movement and running animation

            if (runtimer > 40)
            {
                runtimer = 0;
            }

            if (runtimer > 20)
            {
                texture = Game1.content.Load<Texture2D>("P.run");
            }

            if (runtimer < 20)
            {
                texture = Game1.content.Load<Texture2D>("P.idle");
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                texture = Game1.content.Load<Texture2D>("P.shoot");
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space)
                && btimer == false
                && ammo >= 1)
            {
                ammo -= 1;
                m_manRef.AddBullet(new Point(playerpos.X + 32, playerpos.Y + 35));
                btimer = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Space)
                && btimer == true)
            {
                btimer = false;
                texture = Game1.content.Load<Texture2D>("P.idle");
            }


            if (Keyboard.GetState().IsKeyDown(Keys.D)
                && Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                runtimer += 2;
            }
            
            if (Keyboard.GetState().IsKeyDown(Keys.A)
                && Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                runtimer += 1;

            }
            
            if (Keyboard.GetState().IsKeyDown(Keys.W)
                && jump == 0
                && playerpos.Y > 489)
            {
                jump = 27;
            }
            playerpos.Y -= jump;
            if (playerpos.Y < 490)
            {
                playerpos.Y += 10;
            }
            if (jump > 0)
            {
                jump -= 1;
            }
            if (jump == 0
                && playerpos.Y > 489)
            {
                playerpos.Y = 490;
            }


        }

        public void draw()
        {
            Game1.spriteBatch.Draw(texture, new Rectangle(playerpos.X, playerpos.Y, 72, 92), Color.White);
            Game1.spriteBatch.Draw(ammop, new Rectangle(10, 10, ammo * 4, 30), Color.White);
        }
    }
}
