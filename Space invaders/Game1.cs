using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;


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
        Texture2D ufo;
        Rectangle ufopo;
        Texture2D bomb;
        Rectangle bombpo;
        SpriteFont score;
        Vector2 scorepo;
        Texture2D bang;
        Rectangle bangpo;
        Texture2D button;
        Rectangle buttonpo;
        string num = " ";
        int points = 0;
        int menu = 0;
        int f = 5;
        int at = 3;
        Texture2D extra;
        Texture2D backGameOver;
        Rectangle backGameOverpo;
        Dictionary<string, int> settings = new Dictionary<string, int>();
        

        MouseState mouse = Mouse.GetState();
        MouseState gammalMus = Mouse.GetState();

        KeyboardState tangentbord = Keyboard.GetState();
        int missp = 3;

        KeyboardState gammaltTangentbord = Keyboard.GetState();
        int windowWidth = 800;
        int windowHeight = 480;
        //480 800
        bool jump = false;
        bool drop = true;
        List<Rectangle> ufos = new List<Rectangle>();
        List<Rectangle> extrap = new List<Rectangle>();



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

            settings["planespeed"] = 10;
            FullScreen();
            for (int i = 0; i < 10; i++)
            {
                ufos.Add(new Rectangle((100 + (i * 150)), 100, 60, 30));
                ufos.Add(new Rectangle((100 + (i * 150)), 200, 60, 30));
                ufos.Add(new Rectangle((100 + (i * 150)), 300, 60, 30));
            }
            for (int i = 0; i < 3; i++)
            {
                extrap.Add(new Rectangle((1500 + (i * 150)), 25, 30, 60));
            }

            Random rnd = new Random();
            int r = rnd.Next(0, ufos.Count - 1);
            Rectangle tem = ufos[r];
            bombpo = new Rectangle(tem.X, 100, 25, 40);

        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            space = Content.Load<Texture2D>("spaceRockets_003");
            planes = new Rectangle(200, 1050, 50, 100);
            extra = Content.Load<Texture2D>("spaceRockets_003");
            //planes = new Rectangle(200, 1050, 50, 100);

            missile = Content.Load<Texture2D>("spaceMissiles_002");
            mispo = new Rectangle(190, 1050, 25, 40);
            ufo = Content.Load<Texture2D>("al");
            bomb = Content.Load<Texture2D>("bomb");
            score = Content.Load<SpriteFont>("File");
            scorepo = new Vector2(10, 10);
            bang = Content.Load<Texture2D>("explosion");
            bangpo = new Rectangle(100, 100, 400, 400);
            button = Content.Load<Texture2D>("button");
            buttonpo = new Rectangle(100, 100, 100, 100);
            backGameOverpo = new Rectangle(0, 0, windowWidth, windowHeight);
            //1920 1200
            backGameOver = Content.Load<Texture2D>("gameover1");
            // ufopo = new Rectangle(200, 500, 100, 100);
            // TODO: use this.Content to load your game content here

            if (jump)
            {
                mispo.Y -= 3;


            }
            if (drop)
            {
                bombpo.Y += 3;
            }
        }
        protected void FullScreen()
        {
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.IsFullScreen = true;

           /* windowWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            windowHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;*/
            windowWidth = graphics.PreferredBackBufferWidth;
            windowHeight = graphics.PreferredBackBufferHeight;
            graphics.ApplyChanges();

        }
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            tangentbord = Keyboard.GetState();
            gammaltTangentbord = tangentbord;
            gammalMus = mouse;
            mouse = Mouse.GetState();
            

            {  /*  if (tangentbord.IsKeyDown(Keys.Left))
              {
                  planes.X -= 5;
              }
              if (tangentbord.IsKeyDown(Keys.Right))
              {
                  planes.X += 5;
              }*/

                /* if (tangentbord.IsKeyDown(Keys.Space) && gammaltTangentbord.IsKeyUp(Keys.Space))
                 {

                  }*/
                /* if (!jump) { 
                 if (tangentbord.IsKeyDown(Keys.Left))
                 {
                     mispo.X -= 5;
                 }
                 if (tangentbord.IsKeyDown(Keys.Right))
                 {
                     mispo.X += 5;
                 }
                 }*/

                /* if (mispo.Y > 0)
             { 
                 if (tangentbord.IsKeyDown(Keys.Space) )
                 {
                     jump = true;
                 }
                 if (jump)
                 {
                     mispo.Y -= 30;
                 }
             }
             else
             {
                 mispo.Y = 1050;
                 jump = false;
                 mispo.X = planes.X;
             } */

                /* for (int i = 0; i < ufos.Count; i++)
                 {
                     Rectangle nu = ufos[i];

                if (mispo.Intersects(nu))
                 {
                         ufos.Remove(nu);
                         mispo.Y = planes.Y;
                         mispo.X = planes.X;
                         jump = false;
                 } 

                 }*/
                // TODO: Add your update logic here
            };
           /* flyttaMissilX();
            bombDrop();
            missilTräff();
            flyttaMissilY();
            gammalMus = mouse;
            num = $"score {points}";
            mouse = Mouse.GetState();
            flyttaPlan();
            moveUfoY();*/
            
            switch (menu)
            {
                case 0:
                    uppdateMeny();
                    break;

                case 1:
                    uppdateGame();
                    break;
                
                case 2:
                    uppdateGameOver();
                    break;

            }

            

           

            base.Update(gameTime);
        }
        void BytScen(int nyscen)
        {
            menu = nyscen;

            
        }
        void uppdateMeny() {
            if (VänsterMusTryckt() && buttonpo.Contains(mouse.Position))
            {
                BytScen(1);
            }
        }
        bool VänsterMusTryckt()
        {
            if (mouse.LeftButton == ButtonState.Pressed && gammalMus.LeftButton == ButtonState.Released)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        void uppdateGame()
        {
            
            flyttaMissilX();
           bombDrop();
           missilTräff();
           flyttaMissilY();
           gammalMus = mouse;
           num = $"score {points}";
           mouse = Mouse.GetState();
           flyttaPlan();
           moveUfoY();
            träff();
           
            if (at == 0)
            {
                BytScen(2);
            }
        }
        void missilTräff()
        {
            for (int i = 0; i < ufos.Count; i++)
            {
                Rectangle nu = ufos[i];

                if (mispo.Intersects(nu))
                {
                    ufos.Remove(nu);
                    mispo.Y = planes.Y;
                    mispo.X = planes.X;
                    jump = false;
                    points += 10;
                }

            }
        }
        void flyttaMissilY()
        {
            if (mispo.Y > 0)
            {
                if (tangentbord.IsKeyDown(Keys.Space))
                {
                    jump = true;
                }
                if (jump)
                {
                    mispo.Y -= 30;
                }
            }
            else
            {
                mispo.Y = 1050;
                jump = false;
                mispo.X = planes.X;
            }
        }
        void flyttaMissilX()
        {
            if (!jump)
            {
                if (tangentbord.IsKeyDown(Keys.Left))
                {
                    mispo.X -= settings["planespeed"];
                }
                if (tangentbord.IsKeyDown(Keys.Right))
                {
                    mispo.X += settings["planespeed"];
                }
            }
        }
        void flyttaPlan()
        {
            if (tangentbord.IsKeyDown(Keys.Left))
            {
                planes.X -= settings["planespeed"];
            }
            if (tangentbord.IsKeyDown(Keys.Right))
            {
                planes.X += settings["planespeed"];
            }
        }

        void moveUfoY()
        {
            for (int i = 0; i < ufos.Count; i++)
            {
                Rectangle temp = ufos[i];

                if (temp.X > 0 || temp.X < (windowWidth - temp.Width))
                {
                    temp.X += f;
                    ufos[i] = temp;
                }
                if (temp.X > (windowWidth - temp.Width) || temp.X < 0)
                {
                    f *= -1;
                }
                /* if (temp.X < windowWidth)
                  {
                      temp.X *= -2;
                      ufos[i] = temp;
                  }*/

                /*else
                {
                    temp.X += 10;
                }*/
            }


        }
        void bombDrop()
        {



            if (drop)
            {
                bombpo.Y += 30;
            }
            if (bombpo.Y > 1200)
            {
               if (ufos.Count > 0) { 
                Random rnd = new Random();
                int r = rnd.Next(0, ufos.Count - 1);
                Rectangle tem = ufos[r];
                bombpo.Y = 150;
                bombpo.X = tem.X;
                }
            }

            


        }
        void träff()
            {
            
            if (bombpo.Intersects(planes))
            {
                    at--;
                    extrap.RemoveAt(at);
                Random rnd = new Random();
                int r = rnd.Next(0, ufos.Count - 1);
                Rectangle tem = ufos[r];
                bombpo.Y = 150;
                bombpo.X = tem.X;


            }
            }

        void uppdateGameOver()
        {
            
        }

        protected override void Draw(GameTime gameTime)
        {

            switch (menu)
            {
                case 0:
                    Drawmeny();

                    break;

                case 1:
                    Drawspel();
                    break;

                case 2:
                    DrawGameOver();
                    break;

            }


            /* GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(space, planes, Color.White);
            spriteBatch.Draw(missile, mispo, Color.White);
            spriteBatch.Draw(bomb, bombpo, Color.White);
            spriteBatch.DrawString(score, num, scorepo, Color.White);
            spriteBatch.Draw(bang, bangpo, Color.White);

            // spriteBatch.Draw(ufo, ufopo, Color.White);
            foreach (Rectangle b in ufos)
            {
                spriteBatch.Draw(ufo, b, Color.White);
            }
            spriteBatch.End();*/

            // TODO: Add your drawing code here

            base.Draw(gameTime);


        }

        void Drawmeny()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
           // spriteBatch.DrawString(arial, välkomstText, välkomstPosition, Color.White);
            spriteBatch.Draw(button, buttonpo, Color.White);
            spriteBatch.End();
        }
        void Drawspel()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(space, planes, Color.White);
            spriteBatch.Draw(missile, mispo, Color.White);
            spriteBatch.Draw(bomb, bombpo, Color.White);
            spriteBatch.DrawString(score, num, scorepo, Color.White);
           // spriteBatch.Draw(bang, bangpo, Color.White);

            // spriteBatch.Draw(ufo, ufopo, Color.White);
            foreach (Rectangle b in ufos)
            {
                spriteBatch.Draw(ufo, b, Color.White);
            }
            foreach (Rectangle b in extrap)
            {
                spriteBatch.Draw(extra, b, Color.White);
            }
            spriteBatch.End();

            // TODO: Add your drawing code here

           
        }

        void DrawGameOver()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            // spriteBatch.DrawString(arial, välkomstText, välkomstPosition, Color.White);
            spriteBatch.Draw(backGameOver, backGameOverpo, Color.White);
         
            spriteBatch.End();
        }

        //  Du luktar bajs mohahahahahhahaha
    }
}
