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
        public enum states
        {
            menu,
            game,
            gameover
        };

        public static states m_state;
        menustate m_ms;
        gamestate m_gs;
        gameoverstate m_gos;



        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        public static ContentManager content;

        

        public Game1()
            : base()
        {

            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";
            this.Window.Title = "69 x 6 + 6";
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

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);



            m_ms = new menustate();
            //m_gs = new gamestate(content, CollisionManager a_block);
            m_gs = new gamestate(content);           
            m_gos = new gameoverstate();
            m_state = states.menu;






        }
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

            switch (m_state)
            {
                case states.menu:
                    {
                        m_ms.update(gameTime);
                        if (m_ms.m_switch == true)
                        {
                            m_state = states.game;
                        }
                        break;
                    }
                case states.game:
                    {
                        m_gs.update(gameTime);
                        break;
                    }
                case states.gameover:
                    {
                        m_gos.update(gameTime);
                        break;
                    }
            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            switch (m_state)
            {
                case states.menu:
                    {
                        m_ms.draw();
                        break;
                    }
                case states.game:
                    {
                        m_gs.draw();
                        break;
                    }
                case states.gameover:
                    {
                        m_gos.draw();
                        break;
                    }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
