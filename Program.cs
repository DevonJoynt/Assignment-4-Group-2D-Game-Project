using Raylib_cs;
using System.Diagnostics;
using System.Numerics;

namespace Assignment_4_Group_2D_Game_Project
{
    internal class Program
    {
        static int WindowWidth = 800;
        static int WindowHeight = 600;
        static int FloorBrickHeight = 450;

        static bool Polarity { get; set; } = true;
        static int PolarityPressed;

        static Vector2 PlayerPosition { get; set; } = new Vector2(WindowWidth / 2, WindowHeight / 2);
        static Vector2 PlayerSize = new Vector2(50, 50);
        static Rectangle FloorBricks = new Rectangle(800, 0, 100, 100);

        static void Main(string[] args)
        {
            // Create a window to draw to. The arguments define width and height 
            Raylib.InitWindow(WindowWidth, WindowHeight, "Assignment-2D-Game-Project");
            Raylib.SetTargetFPS(60);

            PolarityPressed = 0;

            Setup();

            while (!Raylib.WindowShouldClose())
            {
                // Camera Dimensions 
                Vector2 CameraOffset = new Vector2(WindowWidth / 2, WindowHeight / 2);
                Vector2 CameraYLock = new Vector2(PlayerPosition.X, WindowHeight / 2);

                Camera2D Camera = new Camera2D(CameraOffset, CameraYLock, 0, 1);

                // Enable drawing to the canvas (window) 
                Raylib.BeginDrawing();

                // Draw Camera 
                Raylib.BeginMode2D(Camera);

                // Clear the canvas with one color 
                Raylib.ClearBackground(Color.WHITE);

                Update();
                Player();
                Floor();
                Raylib.EndDrawing();  // Stop drawing to the canvas, begin displaying the frame 
            }
            Raylib.CloseWindow(); // Close the window 
        }
        static void Setup() // Your one-time setup code here 

        {



        }
        static void Player()
        {
            Vector2 Move = new Vector2(-5, 0);
            Vector2 GravityBasic = new Vector2(0, 10);

            //Bottom of cube 
            float PlayerBottomCorner = PlayerPosition.X + PlayerPosition.Y;

            //Draws Player 
            Raylib.DrawRectangle((int)PlayerPosition.X, (int)PlayerPosition.Y, (int)PlayerSize.X, (int)PlayerSize.Y, Color.BLUE);

            // Controls 
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A) || Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                PlayerPosition = PlayerPosition + Move;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D) || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                PlayerPosition = PlayerPosition - Move;
            }
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_W) || Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {

                // Allows button to be toggle-able, swaps Polarity 
                PolarityPressed++;
                if (PolarityPressed == 1)
                {
                    Polarity = true;
                }
                else
                {
                    Polarity = false;
                    PolarityPressed = 0;
                }
            }
            // Need this for the collision 
            float PlayerWidth = 50;
            float PlayerHeight = 50;

            bool TopWall = false;
            bool BottomWall = false;
            bool BottomBrickHit = false;

            // Side Wall Collision 
            if (PlayerPosition.X - PlayerWidth < 0 || PlayerPosition.X + PlayerWidth > 2000)
            {
                GravityBasic = new Vector2(0, 0);
            }
            // Top Collisiom 
            if (PlayerPosition.Y - 5 < 0)
            {
                GravityBasic = new Vector2(0, 0);
                TopWall = true;

                if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && TopWall)
                {
                    GravityBasic = new Vector2(0, 10);
                    PlayerPosition = PlayerPosition + GravityBasic;
                }
            }
            // Bottom Collision 
            if (PlayerPosition.Y + 5 > FloorBrickHeight)
            {
                GravityBasic = new Vector2(0, 0);
                BottomWall = true;

                if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && BottomWall)
                {
                    GravityBasic = new Vector2(0, 10);
                    PlayerPosition = PlayerPosition - GravityBasic;
                }
            }
            // Polarity Swap 
            if (Polarity == true)
            {
                PlayerPosition = PlayerPosition + GravityBasic;
            }
            else
            {
                PlayerPosition = PlayerPosition - GravityBasic;
            }
        }
        static void Floor()
        {
            // Brick Size 
            int brickheight = 80;
            int brickwidth = 80;
            //pg1
            Rectangle FloorBrick = new Rectangle(0, 550, 1250, 50);
            Raylib.DrawRectangleRec(FloorBrick, Color.GREEN);
            //pg1
            Rectangle FloorBrick2 = new Rectangle(0, 500, 1150, 50);
            Raylib.DrawRectangleRec(FloorBrick2, Color.GREEN);
            //pg1 ceiling
            Rectangle FloorBrick3 = new Rectangle(0, 0, 700, 50);
            Raylib.DrawRectangleRec(FloorBrick3, Color.GREEN);
            
            //pg1 soacebar
            Rectangle FloorBrick4 = new Rectangle(520, 250, 110, 50);
            Raylib.DrawRectangleRec(FloorBrick4, Color.VIOLET);
            Raylib.DrawRectangleLinesEx(FloorBrick4, 2, Color.YELLOW);
            //pg1
            Rectangle FloorBrick5 = new Rectangle(490, 320, 170, 20);
            Raylib.DrawRectangleRec(FloorBrick5, Color.VIOLET);
            //pg1
            Rectangle FloorBrick6 = new Rectangle(490, 320, 20, 50);
            Raylib.DrawRectangleRec(FloorBrick6, Color.VIOLET);
            //pg1
            Rectangle FloorBrick7 = new Rectangle(640, 320, 20, 50);
            Raylib.DrawRectangleRec(FloorBrick7, Color.VIOLET);
            //pg2 large block
            Rectangle FloorBrick8 = new Rectangle(1250, 350, 450, 50);
            Raylib.DrawRectangleRec(FloorBrick8, Color.GREEN);
            //pg2 large block
            Rectangle FloorBrick9 = new Rectangle(1250, 400, 450, 50);
            Raylib.DrawRectangleRec(FloorBrick9, Color.GREEN);
            //pg2
            Rectangle FloorBrick10 = new Rectangle(1250, 450, 450, 50);
            Raylib.DrawRectangleRec(FloorBrick10, Color.GREEN);
            //pg2
            Rectangle FloorBrick11 = new Rectangle(1250, 550, 550, 50);
            Raylib.DrawRectangleRec(FloorBrick11, Color.GREEN);
            //pg2
            Rectangle FloorBrick12 = new Rectangle(1250, 500, 450, 50);
            Raylib.DrawRectangleRec(FloorBrick12, Color.GREEN);
            //pg2 ceiling
            Rectangle FloorBrick13 = new Rectangle(950, 0, 550, 50);
            Raylib.DrawRectangleRec(FloorBrick13, Color.GREEN);
           
            //pg2 ceiling blocks
            Rectangle FloorBrick14 = new Rectangle(1250, 50, 100, 50);
            Raylib.DrawRectangleRec(FloorBrick14, Color.GREEN);
           
            //pg2 ceiling blocks
            Rectangle FloorBrick15 = new Rectangle(1300, 100, 50, 50);
            Raylib.DrawRectangleRec(FloorBrick15, Color.GREEN);

            //pg2 ceiling blocks
            Rectangle FloorBrick16 = new Rectangle(1550, 0, 150, 50);
            Raylib.DrawRectangleRec(FloorBrick16, Color.GREEN);

            //pg2 ceiling blocks second level
            Rectangle FloorBrick17 = new Rectangle(1550, 50, 100, 50);
            Raylib.DrawRectangleRec(FloorBrick17, Color.GREEN);

            //pg2 ceiling blocks third level
            Rectangle FloorBrick18 = new Rectangle(1450, 100, 200, 50);
            Raylib.DrawRectangleRec(FloorBrick18, Color.GREEN);


        }
        static void Update() // Your game code run each frame here 
        {
            {
                // MAKING AN ARRAY 
                //page1 floor
                int spikerow = 2;
                int spikecolm = 1;
                int spikeheight = 50;
                int spikewidth = 50;

                Rectangle[,] spikes = new Rectangle[spikeheight, spikewidth];

                for (int i = 0; i < spikerow; i++)
                {
                    for (int j = 0; j < spikecolm; j++)
                    {
                        // The 90 and 30 Determines the spacing. The +10 and +20 Determines its reach 
                        spikes[i, j] = new Rectangle(i * 50 + 1150, j * 800 + 500, 50, 50);
                    }
                }
                for (int i = 0; i < spikerow; i++)
                {
                    for (int j = 0; j < spikecolm; j++)
                    {
                        if (spikes[i, j].Width > 0)
                        {
                            Raylib.DrawRectangleRec(spikes[i, j], Color.RED);
                            Raylib.DrawRectangleLinesEx(spikes[i, j], 2, Color.DARKPURPLE);
                        }
                    }
                }
                //page1 ceiling
                int spikerow2 = 5;
                int spikecolm2 = 1;
                int spikeheight2 = 50;
                int spikewidth2 = 50;

                Rectangle[,] spikes2 = new Rectangle[spikeheight2, spikewidth2];
                for (int i = 0; i < spikerow2; i++)
                {
                    for (int j = 0; j < spikecolm2; j++)
                    {
                        // The 90 and 30 Determines the spacing. The +10 and +20 Determines its reach 
                        spikes2[i, j] = new Rectangle(i * 50 + 700, j * 0 + 0, 50, 50);
                    }
                }
                for (int i = 0; i < spikerow2; i++)
                {
                    for (int j = 0; j < spikecolm2; j++)
                    {
                        if (spikes2[i, j].Width > 0)
                        {
                            Raylib.DrawRectangleRec(spikes2[i, j], Color.RED);

                            Raylib.DrawRectangleLinesEx(spikes2[i, j], 2, Color.DARKPURPLE);
                        }
                    }
                }
                //page2 ceiling
                int spikerow3 = 1;
                int spikecolm3 = 1;
                int spikeheight3 = 50;
                int spikewidth3 = 50;

                Rectangle[,] spikes3 = new Rectangle[spikeheight3, spikewidth3];
                for (int i = 0; i < spikerow3; i++)
                {
                    for (int j = 0; j < spikecolm3; j++)
                    {
                        // The 90 and 30 Determines the spacing. The +10 and +20 Determines its reach 
                        spikes3[i, j] = new Rectangle(i * 50 + 1500, j * 0 + 0, 50, 50);
                    }
                }
                for (int i = 0; i < spikerow3; i++)
                {
                    for (int j = 0; j < spikecolm3; j++)
                    {
                        if (spikes3[i, j].Width > 0)
                        {
                            Raylib.DrawRectangleRec(spikes3[i, j], Color.RED);

                            Raylib.DrawRectangleLinesEx(spikes3[i, j], 2, Color.DARKPURPLE);
                        }
                    }
                }
            }
        }
    }
}