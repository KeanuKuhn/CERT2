#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

#endregion

namespace sickgame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        public static ContentManager content;

        enum state
        {
            menustate,
            gamestate,
        }
        static state curentstate;


        player p1;
        ground g1;
        Texture2D menu;
        Bulletmanager m_pbulletmanager;
        //enemy e1;
        //enemy2 e2;
        //enemy3 e3;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            content = Content;
            base.Initialize();
            menu = Content.Load<Texture2D>("floor");

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            m_pbulletmanager = new Bulletmanager();
            p1 = new player(m_pbulletmanager);
            g1 = new ground();
            //e1 = new enemy(Content);
            //e2 = new enemy2(Content);
            //e3 = new enemy3(Content);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            switch (curentstate)
            {   //menu and game states
                case state.menustate:
                    {
                        //update the menu 
                        updatemenu();
                        break;
                    }
                case state.gamestate:
                    {
                        //update the menu

                        updategame();
                        break;
                    }
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }
        void updatemenu()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                curentstate = state.gamestate;
            }
        }
        void updategame()
        {
            p1.update();
            //e1.update();
            //e2.update();
            //e3.update();
            m_pbulletmanager.update();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            switch (curentstate)
            {   //menu and game states
                case state.menustate:
                    {
                        //update the menu 
                        drawmenu();
                        break;
                    }
                case state.gamestate:
                    {
                        //update the menu

                        drawgame();
                        break;
                    }
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
        void drawmenu()
        {
            spriteBatch.Draw(menu, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
        }
        void drawgame()
        {
            p1.draw();
            g1.draw();
            m_pbulletmanager.draw();
            //e1.draw(spriteBatch);
            //e2.draw(spriteBatch);
            //e3.draw(spriteBatch);

        }
    }
}
