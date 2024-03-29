﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using System.Threading;


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
        
        //bomb
        Texture2D bomb;
        Rectangle bombpo;
        
        //score
        SpriteFont score;
        Vector2 scorepo;
        
        //play button
        Texture2D button;
        Rectangle buttonpo;
        
        string num = " ";
        int points = 0;
        int menu = 0;
        int f = 5;
        int at = 3;
        int timer = 0;

        Texture2D extra;
        
        //gameover scene
        Texture2D backGameOver;
        Rectangle backGameOverpo;
        
        //settings planes speed
        Dictionary<string, int> settings = new Dictionary<string, int>();


        Texture2D yesbutton;
        Rectangle yesbuttonpo;
        Texture2D nobutton;
        Rectangle nobuttonpo;
        MouseState mouse = Mouse.GetState();
        MouseState gammalMus = Mouse.GetState();
        
        SpriteFont playAgain;
        Vector2 playAgainPo;
        string playagstr = "play again";
        
        
        KeyboardState tangentbord = Keyboard.GetState();
        int missp = 3;

        KeyboardState gammaltTangentbord = Keyboard.GetState();
        int windowWidth = 800;
        int windowHeight = 480;
       
        bool jump = false;
        bool drop = true;
        
       // backgrundwinn
        Texture2D win;
        Rectangle winnerpo;

        //backgrund
        Texture2D spaceinvaders;
        Rectangle spaceinvaderspo;


        //list of ufos 
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
            
            button = Content.Load<Texture2D>("button");
            buttonpo = new Rectangle(900, 500, 100, 100);
            backGameOverpo = new Rectangle(0, 0, 1920, 1200);
            
            backGameOver = Content.Load<Texture2D>("gameover1");
            yesbutton = Content.Load<Texture2D>("yes button");
            yesbuttonpo = new Rectangle(1200, 500, 100, 100);
            nobutton = Content.Load<Texture2D>("no button");
            nobuttonpo = new Rectangle(700, 500, 100, 100);
            playAgain = Content.Load<SpriteFont>("File");
            playAgainPo = new Vector2(1100, 300);
            
            //win secen
            win = Content.Load<Texture2D>("winer");
            winnerpo = new Rectangle(0, 1200, 1920, 1200);
            
            //beggineng scene
            spaceinvaders = Content.Load<Texture2D>("sapceinvaders");
            spaceinvaderspo = new Rectangle(0, 0, 1920, 1200);
            
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
                    at = 3;
                    reset();
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
            congrat();
           
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
        void congrat()
        {
            if (points == 300)
            {
             
                winnerpo.Y = 0;

                
                
            }
            if (winnerpo.Y == 0)
            {
                timer++;
                if (timer >= 600)
                {
                    Exit();

                }
            }
        }
        void uppdateGameOver()
        {
            if (VänsterMusTryckt() && yesbuttonpo.Contains(mouse.Position))
            {
                BytScen(1);
                at = 3;

            }
            if (VänsterMusTryckt() && nobuttonpo.Contains(mouse.Position))
            {
                Exit();
                

            }


        }

        void reset()
        {
            ufos.Clear();
            extrap.Clear();
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
           
            spriteBatch.Draw(spaceinvaders, spaceinvaderspo, Color.White);
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
            spriteBatch.Draw(win, winnerpo, Color.White);
            spriteBatch.DrawString(score, num, scorepo, Color.White);
           

            // DRAW UFOS 
            foreach (Rectangle b in ufos)
            {
                spriteBatch.Draw(ufo, b, Color.White);
            }
            // DRAW LIV
            foreach (Rectangle b in extrap)
            {
                spriteBatch.Draw(extra, b, Color.White);
            }
            spriteBatch.End();

            

           
        }

        void DrawGameOver()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
           
            spriteBatch.Draw(backGameOver, backGameOverpo, Color.White);
            spriteBatch.Draw(yesbutton, yesbuttonpo, Color.White);
            spriteBatch.Draw(nobutton, nobuttonpo, Color.White);
            spriteBatch.DrawString(playAgain, playagstr, playAgainPo, Color.White);
            spriteBatch.End();
        }

        
    }
}
