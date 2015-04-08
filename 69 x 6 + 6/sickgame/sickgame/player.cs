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
        Texture2D portrait;
        Rectangle playerpos;
        Texture2D ammop;
        Texture2D healthp;
        Bulletmanager m_manRef;
        int jump;
        bool btimer;
        int runtimer;
        int momentum;
        int m_timer;
        bool playeredgescreen;
        int ammo;
        int ammotimer;
        int health;


        public player(Bulletmanager a_manRef)
        {
            m_manRef = a_manRef;
            playerpos.X = 0;
            playerpos.Y = 920;
            playerpos = new Rectangle(playerpos.X, playerpos.Y, 90, 90);
            texture = Game1.content.Load<Texture2D>("P.idle");
            ammop = Game1.content.Load<Texture2D>("ammo");
            healthp = Game1.content.Load<Texture2D>("health");
            portrait = Game1.content.Load<Texture2D>("portrait");
            btimer = false;
            m_timer = 0;
            playeredgescreen = false;
            ammo = 50;
            ammotimer = 0;
            health = 4;
        }

        public void update()
        {
            //ammo regen
            if (ammo < 50)
            {
                ammotimer += 1;
            }

            if (ammotimer > 350)
            {
                ammo += 1;
                ammotimer = 0;
            }

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
                && Keyboard.GetState().IsKeyUp(Keys.A)
                && playeredgescreen == false)
            {
                momentum = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D)
                && Keyboard.GetState().IsKeyUp(Keys.Space)
                && playeredgescreen == false)
            {
                momentum = 7;

            }

            if (Keyboard.GetState().IsKeyDown(Keys.A)
                && Keyboard.GetState().IsKeyUp(Keys.Space)
                && playeredgescreen == false)
            {
                momentum = -3;

            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space)
                && playerpos.Y > 489
                && playeredgescreen == false)
            {
                momentum = 0;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.P))
            {
                health -= 1;
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

            if (Keyboard.GetState().IsKeyDown(Keys.Space)
                && playeredgescreen == false)
            {
                texture = Game1.content.Load<Texture2D>("P.shoot");
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space)
                && btimer == false
                && playeredgescreen == false
                && ammo > 10)
            {
                m_manRef.AddBullet(new Point(playerpos.X + 32, playerpos.Y + 35));
                btimer = true;
                ammo -= 1;
                playerpos.X -= 2;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Space)
                && btimer == true
                && playeredgescreen == false)
            {
                btimer = false;
                texture = Game1.content.Load<Texture2D>("P.idle");
            }


            if (Keyboard.GetState().IsKeyDown(Keys.D)
                && Keyboard.GetState().IsKeyUp(Keys.Space)
                && playeredgescreen == false)
            {
                runtimer += 2;
            }
            
            if (Keyboard.GetState().IsKeyDown(Keys.A)
                && Keyboard.GetState().IsKeyUp(Keys.Space)
                && playeredgescreen == false)
            {
                runtimer += 1;

            }
            
            if (Keyboard.GetState().IsKeyDown(Keys.W)
                && jump == 0
                && playerpos.Y > 489
                && playeredgescreen == false)
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
            //edge screen
            if (playerpos.X > 1280)
            {
                playeredgescreen = true;
                momentum = 0;
            }
            if (playeredgescreen == true)
            {
                playerpos.X -= 10;
            }
            if (playerpos.X < 100)
            {
                playeredgescreen = false;
            }

        }

        public void draw()
        {
            Game1.spriteBatch.Draw(texture, new Rectangle(playerpos.X, playerpos.Y, 72, 92), Color.White);
            Game1.spriteBatch.Draw(ammop, new Rectangle(10, 10, ammo * 8, 84), Color.White);
            Game1.spriteBatch.Draw(healthp, new Rectangle(10, 10, health * 101, 84), Color.White);
            Game1.spriteBatch.Draw(portrait, new Rectangle(10, 10, 404, 84), Color.White);
        }
    }
}
