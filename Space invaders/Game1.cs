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
        int f = 5;
        KeyboardState tangentbord = Keyboard.GetState();
        int missp = 3;

        KeyboardState gammaltTangentbord = Keyboard.GetState();
        int windowWidth; 
        int windowHeight;

        bool jump = false;
        bool drop = true;
        List<Rectangle> ufos = new List<Rectangle>();
        
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
            for (int i = 0; i < 10; i++)
            {
                ufos.Add(new Rectangle((100 + (i * 150)), 100, 60, 30));
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
            missile = Content.Load<Texture2D>("spaceMissiles_002");
            mispo = new Rectangle(190, 1050, 25, 40);
            ufo = Content.Load<Texture2D>("al");
            bomb = Content.Load<Texture2D>("bomb");
            
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

          /*  if (tangentbord.IsKeyDown(Keys.Left))
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
            flyttaMissilX();





            bombDrop();
            missilTräff();
            flyttaMissilY();




            flyttaPlan();
            
            moveUfoY();

            base.Update(gameTime);
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
                    mispo.X -= 5;
                }
                if (tangentbord.IsKeyDown(Keys.Right))
                {
                    mispo.X += 5;
                }
            }
        }
        void flyttaPlan()
        {
            if (tangentbord.IsKeyDown(Keys.Left))
            {
                planes.X -= 5;
            }
            if (tangentbord.IsKeyDown(Keys.Right))
            {
                planes.X += 5;
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
                Random rnd = new Random();
                int r = rnd.Next(0, ufos.Count - 1);
                Rectangle tem = ufos[r];
                bombpo.Y = 150;
                bombpo.X = tem.X;
                     }
                
            
            }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(space, planes, Color.White);
            spriteBatch.Draw(missile, mispo, Color.White);
            spriteBatch.Draw(bomb, bombpo, Color.White);
           // spriteBatch.Draw(ufo, ufopo, Color.White);
            foreach (Rectangle b in ufos)
            {
                spriteBatch.Draw(ufo, b, Color.White);
            }
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
