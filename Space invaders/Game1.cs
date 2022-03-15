using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Space_invaders
{
    public class Game1 : Game
    {
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D space;
        Rectangle planes;
        Texture2D missile;
        Rectangle mispo;
        KeyboardState tangentbord = Keyboard.GetState();
        int missp = 3;
        KeyboardState gammaltTangentbord = Keyboard.GetState();
        int windowWidth;
        int windowHeight;

        bool jump = false;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
         }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            FullScreen();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            space = Content.Load<Texture2D>("spaceRockets_003");
            planes = new Rectangle(200, 1050, 50, 100);
            missile = Content.Load<Texture2D>("spaceMissiles_002");
            mispo = new Rectangle(190, 1050, 25, 40);

            // TODO: use this.Content to load your game content here

            if (jump)
            {
                mispo.Y -= 3;

                
            }
        }
        protected void FullScreen()
        {
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.IsFullScreen = true;

            windowWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            windowHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            graphics.ApplyChanges();
        }
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            tangentbord = Keyboard.GetState();
            gammaltTangentbord = tangentbord;

            if (tangentbord.IsKeyDown(Keys.Left))
            {
                planes.X -= 5;
            }
            if (tangentbord.IsKeyDown(Keys.Right))
            {
                planes.X += 5;
            }
            /* if (tangentbord.IsKeyDown(Keys.Space) && gammaltTangentbord.IsKeyUp(Keys.Space))
             {

              }*/
            if (tangentbord.IsKeyDown(Keys.Space) /*&& gammaltTangentbord.IsKeyUp(Keys.Space)*/) 
            {
                jump = true;
              }
            if (jump)
            {
                mispo.Y -= 10;
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(space, planes, Color.White);
            spriteBatch.Draw(missile, mispo, Color.White);


            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
