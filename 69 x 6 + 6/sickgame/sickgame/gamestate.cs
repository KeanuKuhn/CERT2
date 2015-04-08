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
using Microsoft.Xna.Framework.Audio;
namespace sickgame
{
    class gamestate
    {
        player p1;
        ground g1;
        Background bg;
        Bulletmanager m_pbulletmanager;
        //enemy e1;
        //enemy2 e2;
        //enemy3 e3;

        public gamestate()
        {
            m_pbulletmanager = new Bulletmanager();
            p1 = new player(m_pbulletmanager);
            g1 = new ground();
            bg = new Background();
            //e1 = new enemy(Content);
            //e2 = new enemy2(Content);
            //e3 = new enemy3(Content);
        }
        public void update(GameTime a_gametime)
        {
            p1.update();
            bg.update();
            g1.update();
            //e1.update();
            //e2.update();
            //e3.update();
            m_pbulletmanager.update();
        }
        public void draw()
        {
            bg.draw();
            p1.draw();
            g1.draw();
            m_pbulletmanager.draw();
            //e1.draw(spriteBatch);
            //e2.draw(spriteBatch);
            //e3.draw(spriteBatch);
        }
    }
}
