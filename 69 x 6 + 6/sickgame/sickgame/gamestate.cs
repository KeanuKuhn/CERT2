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
        CollisionManager m_collsionManager;
        
        //enemy e1;
        //enemy2 e2;
        //enemy3 e3;

<<<<<<< HEAD
        //public gamestate(ContentManager content, CollisionManager block)
        public gamestate(ContentManager content)    
=======
        public gamestate()
>>>>>>> 4b934022421c14ad506cc631d4eb97a7cdc52ca4
        {
            m_pbulletmanager = new Bulletmanager();
            p1 = new player(m_pbulletmanager);

            m_collsionManager = new CollisionManager(p1);

            g1 = new ground(p1);
            bg = new Background();
<<<<<<< HEAD
            b1 = new block(content);
            m_collsionManager.AddBlock(b1);
=======
>>>>>>> 4b934022421c14ad506cc631d4eb97a7cdc52ca4
            //e1 = new enemy(Content);
            //e2 = new enemy2(Content);
            //e3 = new enemy3(Content);
        }
        public void update(GameTime a_gametime)
        {
            p1.update();
            bg.update();
            g1.update(p1);
            //e1.update();
            //e2.update();
            //e3.update();
            m_pbulletmanager.update();
            m_collsionManager.update();
            
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
