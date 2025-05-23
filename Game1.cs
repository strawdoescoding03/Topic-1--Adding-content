﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Topic_1__Adding_content
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D dinoTexture, steveFishTexture, sandTexture, seaweedTextureOne,
            seaweedTextureTwo, cliffTexture, cliffTextureTwo, bubbleTexture;

        static Random rnd = new();



        List<Vector2> bubblePositions = new();

        Vector2 bubbleSpeed;








        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();
            for (int i = 0; i < 30; i++)
            {
                bubblePositions.Add(new Vector2(rnd.Next(125, 650), rnd.Next(600)));
            }

            bubbleSpeed = new Vector2(0, -1);

            this.Window.Title = "mY fIRST wINDOW!!!!!!!1";

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            dinoTexture = Content.Load<Texture2D>("dino");

            steveFishTexture = Content.Load<Texture2D>("steve");

            sandTexture = Content.Load<Texture2D>("sand_real");

            seaweedTextureOne = Content.Load<Texture2D>("seaweedOne");

            seaweedTextureTwo = Content.Load<Texture2D>("seaweedTwo");

            cliffTexture = Content.Load<Texture2D>("cliffSuper");

            cliffTextureTwo = Content.Load<Texture2D>("cliffTwo");


            //I made this bubble

            bubbleTexture = Content.Load<Texture2D>("bubble");


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here


            
            for (int i = 0; i < bubblePositions.Count; i++)
            {
                bubblePositions[i] = bubblePositions[i] + bubbleSpeed;
                if (bubblePositions[i].Y < -50)
                {
                    bubblePositions[i] = new Vector2(bubblePositions[i].X, 650f);
                }
            }
             


            base.Update(gameTime);
            
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DodgerBlue);

            _spriteBatch.Begin();


            _spriteBatch.Draw(cliffTexture, new Vector2(0, 50), Color.White);

            _spriteBatch.Draw(cliffTextureTwo, new Vector2(600, 50), Color.White);

            _spriteBatch.Draw(sandTexture, new Vector2(0, 410), Color.Wheat);
                                    
            _spriteBatch.Draw(seaweedTextureTwo, new Vector2(15, 305), Color.White);

            _spriteBatch.Draw(seaweedTextureOne, new Vector2(25, 325), Color.White);

            _spriteBatch.Draw(seaweedTextureOne, new Vector2(600, 325), Color.White);

            _spriteBatch.Draw(seaweedTextureOne, new Vector2(450, 250), Color.White);

            _spriteBatch.Draw(seaweedTextureTwo, new Vector2(585, 305), Color.White);
                    

            for (int i = 0; i < bubblePositions.Count; i++)
            {
                _spriteBatch.Draw(steveFishTexture, new Rectangle((int)bubblePositions[i].X, (int)bubblePositions[i].Y, bubbleTexture.Width, bubbleTexture.Height), Color.White);
                _spriteBatch.Draw(bubbleTexture, bubblePositions[i], Color.White * 0.5f);
               
            }

            _spriteBatch.Draw(steveFishTexture, new Vector2(300, 300), Color.White);



            _spriteBatch.End();



            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
