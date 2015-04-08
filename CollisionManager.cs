#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion
namespace sickgame
{
    class CollisionManager
    {
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        public static ContentManager content;

        player p1;
        List<enemy> enemyList;        
        List<block> blockList;
        ///////////////////////////////////batch.Draw(bulltexture, new Vector2(10, 10), null, Color.White, 0.0f, new Vector2(0, 0), SpriteEffects.None, 0.0f);
        public CollisionManager (player a_player)
        {
            p1 = a_player;
            enemyList = new List<enemy>();
            blockList = new List<block>();
        }

        public void AddEnemy(enemy newEnemy)
        {
            enemyList.Add(newEnemy);
        }

        public void AddBlock(block newBlock)
        {
            blockList.Add(newBlock);
        }


        public void update()
        {
            //enemyloop
            for (int i = 0; i < enemyList.Count; i++)
            {
                //AABB

                Rectangle enemyRect = new Rectangle(enemyList[i].position.X,
                                                    enemyList[i].position.Y,
                                                    enemyList[i].width,
                                                    enemyList[i].height);
               
                if (p1.playerpos.Intersects(enemyRect)) 
                {
                    p1.playerpos = 10;
                    return;
                }
            }

            //blockloop
            for (int i = 0; i < blockList.Count; i++)
            {
                Rectangle blockRect = new Rectangle(blockList[i].blockpos.X,
                                                    blockList[i].blockpos.Y,
                                                    blockList[i].width,
                                                    blockList[i].height);


                if (p1.playerpos.Intersects(blockRect))
                {
                    p1.playerpos = 10;
                    return;
                }
            }



        }

        public void draw()
        { 
        
        }
    }
}
