using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gipton
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// 
    public enum directions { up, right, down, left}

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D image;
        Texture2D playerimg;
        Texture2D red;
        MapGenerator gmap;
        PlayerCharacter player;
        List<Creep> creeps;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            //graphics.IsFullScreen = true;
            Window.Position = new Point(0, 0);
            Window.IsBorderless = true;
            graphics.ApplyChanges();
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
            image = Content.Load<Texture2D>("Terrain/GStone");
            playerimg = Content.Load<Texture2D>("Models/RandomGuy");
            red = Content.Load<Texture2D>("Cont/red");
            gmap = new MapGenerator(image,100);
            player = new PlayerCharacter(playerimg, gmap, new Vector2(500,500));
            gmap.AddPlayer(player);
            creeps = new List<Creep>();
            creeps.Add(new Creep(playerimg, gmap, new Vector2(200,200)));
            creeps.Add(new Creep(playerimg, gmap, new Vector2(1000, 1000)));

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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

            // TODO: Add your update logic here

            player.Move();
            creeps[0].Move(directions.down, 1);
            creeps[0].Move(directions.right, 1);

            //if(player.spr.Intersects(new Rectangle(new Point(-1, -1), new Point(10, 10))))
            //{
            //    this.Exit();
            //}
            if(creeps[0].spr.Intersects(creeps[1].spr))
                this.Exit();


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightBlue);

            spriteBatch.Begin();
            
            gmap.Draw(spriteBatch);
            player.Draw(spriteBatch);
            creeps[0].Draw(spriteBatch);
            creeps[1].Draw(spriteBatch);
            spriteBatch.Draw(red,creeps[0].spr,Color.White);
            spriteBatch.Draw(red, creeps[1].spr, Color.White);
            spriteBatch.Draw(red, player.spr, Color.White);

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
