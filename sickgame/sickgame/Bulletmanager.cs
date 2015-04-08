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
    class Bulletmanager
    {
        List<bullet> m_bulletList;

        public Bulletmanager()
        {
            m_bulletList = new List<bullet>();
        }
        public void update()
        {
            for (int i = 0; i < m_bulletList.Count; i++)
            {
                m_bulletList[i].update();
            }
            for (int i = 0; i < m_bulletList.Count; i++)
            {
                if (m_bulletList[i].rect.Y < -10)
                {
                    m_bulletList.Remove(m_bulletList[i]);
                }
            }
        }
        public void draw()
        {
            for (int i = 0; i < m_bulletList.Count; i++)
            {
                m_bulletList[i].draw();
            }
        }
        public List<bullet> bulletList
        {
            get { return m_bulletList; }
        }

        public void AddBullet(Point point)
        {
            m_bulletList.Add(new bullet(point));
        }
    }
}
