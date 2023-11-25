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
            Vector2 GravityBasic = new Vector2(0, 15);

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
            if (PlayerPosition.X - PlayerWidth < 0 || PlayerPosition.X + PlayerWidth > 10000000)
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
            //pg1 floor 1st level
            Rectangle FloorBrick = new Rectangle(0, 550, 1250, 50);
            Raylib.DrawRectangleRec(FloorBrick, Color.GREEN);
            //pg1 floor 2nd level
            Rectangle FloorBrick2 = new Rectangle(0, 500, 1150, 50);
            Raylib.DrawRectangleRec(FloorBrick2, Color.GREEN);
            //pg1 ceiling
            Rectangle FloorBrick3 = new Rectangle(0, 0, 700, 50);
            Raylib.DrawRectangleRec(FloorBrick3, Color.GREEN);
            
            //pg1 soacebar
            Rectangle FloorBrick4 = new Rectangle(520, 250, 110, 50);
            Raylib.DrawRectangleRec(FloorBrick4, Color.VIOLET);
            Raylib.DrawRectangleLinesEx(FloorBrick4, 2, Color.YELLOW);

            //pg1 safety net
            Rectangle FloorBrick5 = new Rectangle(490, 320, 170, 20);
            Raylib.DrawRectangleRec(FloorBrick5, Color.VIOLET);

            //pg1 safety net
            Rectangle FloorBrick6 = new Rectangle(490, 320, 20, 50);
            Raylib.DrawRectangleRec(FloorBrick6, Color.VIOLET);

            //pg1 safety net
            Rectangle FloorBrick7 = new Rectangle(640, 320, 20, 50);
            Raylib.DrawRectangleRec(FloorBrick7, Color.VIOLET);

            //pg2 floor large block level 5
            Rectangle FloorBrick8 = new Rectangle(1250, 350, 450, 50);
            Raylib.DrawRectangleRec(FloorBrick8, Color.GREEN);

            //pg2 floor large block level 4
            Rectangle FloorBrick9 = new Rectangle(1250, 400, 450, 50);
            Raylib.DrawRectangleRec(FloorBrick9, Color.GREEN);

            //pg2 floor large block level 3
            Rectangle FloorBrick10 = new Rectangle(1250, 450, 450, 50);
            Raylib.DrawRectangleRec(FloorBrick10, Color.GREEN);

            //pg2 floor large block level 1
            Rectangle FloorBrick11 = new Rectangle(1250, 550, 550, 50);
            Raylib.DrawRectangleRec(FloorBrick11, Color.GREEN);

            //pg2 floor large block level 2
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

            //page3 ceiling 3 blocks
            Rectangle FloorBrick19 = new Rectangle(1900, 0, 150, 50);
            Raylib.DrawRectangleRec(FloorBrick19, Color.GREEN);

            //pg3 floor 1 block
            Rectangle FloorBrick20 = new Rectangle(2150, 550, 50, 50);
            Raylib.DrawRectangleRec(FloorBrick20, Color.GREEN);

            //pg3/4 floor 11 block
            Rectangle FloorBrick21 = new Rectangle(2300, 550, 550, 50);
            Raylib.DrawRectangleRec(FloorBrick21, Color.GREEN);

            //page4 ceiling 9 blocks level 1
            Rectangle FloorBrick22 = new Rectangle(2400, 0, 450, 50);
            Raylib.DrawRectangleRec(FloorBrick22, Color.GREEN);

            //page4 ceiling 7 blocks level 2
            Rectangle FloorBrick23 = new Rectangle(2400, 50, 350, 50);
            Raylib.DrawRectangleRec(FloorBrick23, Color.GREEN);

            //page4 ceiling 2 blocks level 3
            Rectangle FloorBrick24 = new Rectangle(2400, 100, 100, 50);
            Raylib.DrawRectangleRec(FloorBrick24, Color.GREEN);

            //page4 ceiling 2 blocks level 3
            Rectangle FloorBrick25 = new Rectangle(2650, 100, 100, 50);
            Raylib.DrawRectangleRec(FloorBrick25, Color.GREEN);

            //page4 ceiling 1 block 
            Rectangle FloorBrick26 = new Rectangle(2900, 0, 50, 50);
            Raylib.DrawRectangleRec(FloorBrick26, Color.GREEN);

            //page4 ceiling 2 blocks 
            Rectangle FloorBrick27 = new Rectangle(3000, 0, 100, 50);
            Raylib.DrawRectangleRec(FloorBrick27, Color.GREEN);

            //pg4 floor 9 blocks level 2
            Rectangle FloorBrick28 = new Rectangle(2400, 500, 450, 50);
            Raylib.DrawRectangleRec(FloorBrick28, Color.GREEN);

            //pg4 floor 8 blocks level 3
            Rectangle FloorBrick29 = new Rectangle(2400, 450, 400, 50);
            Raylib.DrawRectangleRec(FloorBrick29, Color.GREEN);

            //pg4 floor 9 blocks level 4
            Rectangle FloorBrick30 = new Rectangle(2400, 400, 450, 50);
            Raylib.DrawRectangleRec(FloorBrick30, Color.GREEN);

            //pg4/5/6 floor 23 blocks level 1
            Rectangle FloorBrick31 = new Rectangle(2950, 550, 1150, 50);
            Raylib.DrawRectangleRec(FloorBrick31, Color.GREEN);

            //pg4/5 floor 23 blocks level 2
            Rectangle FloorBrick32 = new Rectangle(2950, 500, 300, 50);
            Raylib.DrawRectangleRec(FloorBrick32, Color.GREEN);



            // pg4 middle blocks
            Rectangle FloorBrick33 = new Rectangle(2800, 350, 100, 50);
            Raylib.DrawRectangleRec(FloorBrick33, Color.GREEN);

            Rectangle FloorBrick34 = new Rectangle(2850, 150, 50, 200);
            Raylib.DrawRectangleRec(FloorBrick34, Color.GREEN);

            Rectangle FloorBrick35 = new Rectangle(2900, 200, 50, 50);
            Raylib.DrawRectangleRec(FloorBrick35, Color.GREEN);

            Rectangle FloorBrick36 = new Rectangle(2950, 150, 50, 200);
            Raylib.DrawRectangleRec(FloorBrick36, Color.GREEN);

            //pg4/5 ceiling 2blk wide 8blk down
            Rectangle FloorBrick37 = new Rectangle(3150, 0, 100, 400);
            Raylib.DrawRectangleRec(FloorBrick37, Color.GREEN);

            //pg4 "HAD ENOUGH" block
            Rectangle FloorBrick38 = new Rectangle(2450, 450, 300, 100);
            Raylib.DrawRectangleRec(FloorBrick38, Color.YELLOW);

            //pg2 "RECHARGE" block
            Rectangle FloorBrick39 = new Rectangle(1300, 400, 250, 150);
            Raylib.DrawRectangleRec(FloorBrick39, Color.YELLOW);

            //---Page 5

            //pg5 floor 5blocks  level 2
            Rectangle FloorBrick40 = new Rectangle(3300, 500, 250, 50);
            Raylib.DrawRectangleRec(FloorBrick40, Color.GREEN);

            //pg5 floor 3blocks  level 3
            Rectangle FloorBrick41 = new Rectangle(3350, 450, 150, 50);
            Raylib.DrawRectangleRec(FloorBrick41, Color.GREEN);

            //pg5 floor 1blocks  level 4
            Rectangle FloorBrick42 = new Rectangle(3400, 400, 50, 50);
            Raylib.DrawRectangleRec(FloorBrick42, Color.GREEN);

            //pg5 floor 2blocks  level 2
            Rectangle FloorBrick43 = new Rectangle(3600, 500, 100, 50);
            Raylib.DrawRectangleRec(FloorBrick43, Color.GREEN);

            //pg5 middle 7 vertblocks  level 4
            Rectangle FloorBrick44 = new Rectangle(3650, 150, 50, 350);
            Raylib.DrawRectangleRec(FloorBrick44, Color.GREEN);

            //pg5 ceiling 15blocks  level 1
            Rectangle FloorBrick45 = new Rectangle(3250, 0, 750, 50);
            Raylib.DrawRectangleRec(FloorBrick45, Color.GREEN);

            //pg5 ceiling 2blocks  level 2
            Rectangle FloorBrick46 = new Rectangle(3250, 50, 100, 50);
            Raylib.DrawRectangleRec(FloorBrick46, Color.GREEN);

            //pg5 ceiling 1blocks  level 3
            Rectangle FloorBrick47 = new Rectangle(3250, 100, 50, 50);
            Raylib.DrawRectangleRec(FloorBrick47, Color.GREEN);

            //pg5 ceiling 2blocks  level 2
            Rectangle FloorBrick48 = new Rectangle(3450, 50, 100, 50);
            Raylib.DrawRectangleRec(FloorBrick48, Color.GREEN);

            //pg5 ceiling 1blocks  level 3
            Rectangle FloorBrick49 = new Rectangle(3500, 100, 50, 50);
            Raylib.DrawRectangleRec(FloorBrick49, Color.GREEN);

            //pg5 floor 1blocks  level 3
            Rectangle FloorBrick50 = new Rectangle(3750, 450, 50, 50);
            Raylib.DrawRectangleRec(FloorBrick50, Color.GREEN);

            //pg5 floor 1blocks  level 3
            Rectangle FloorBrick51 = new Rectangle(3900, 450, 50, 50);
            Raylib.DrawRectangleRec(FloorBrick51, Color.GREEN);

            //pg5 floor 5blocks  level 4
            Rectangle FloorBrick52 = new Rectangle(3750, 400, 250, 50);
            Raylib.DrawRectangleRec(FloorBrick52, Color.GREEN);

            //pg5 middle 2vertblocks  
            Rectangle FloorBrick53 = new Rectangle(3800, 300, 50, 100);
            Raylib.DrawRectangleRec(FloorBrick53, Color.GREEN);

            //pg5 ceiling 3vertblocks  level 2
            Rectangle FloorBrick54 = new Rectangle(3950, 50, 50, 150);
            Raylib.DrawRectangleRec(FloorBrick54, Color.GREEN);


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
                //page 3 floor
                int spikerow4 = 7;
                int spikecolm4 = 1;
                int spikeheight4 = 50;
                int spikewidth4 = 50;

                Rectangle[,] spikes4 = new Rectangle[spikeheight4, spikewidth4];
                for (int i = 0; i < spikerow4; i++)
                {
                    for (int j = 0; j < spikecolm4; j++)
                    {
                        // The 90 and 30 Determines the spacing. The +10 and +20 Determines its reach 
                        spikes4[i, j] = new Rectangle(i * 50 + 1800, j * 0 + 550, 50, 50);
                    }
                }
                for (int i = 0; i < spikerow4; i++)
                {
                    for (int j = 0; j < spikecolm4; j++)
                    {
                        if (spikes4[i, j].Width > 0)
                        {
                            Raylib.DrawRectangleRec(spikes4[i, j], Color.RED);

                            Raylib.DrawRectangleLinesEx(spikes4[i, j], 2, Color.DARKPURPLE);
                        }
                    }
                }
                //page3 floor 1 block
                int spikerow5 = 2;
                int spikecolm5 = 1;
                int spikeheight5 = 50;
                int spikewidth5 = 50;

                Rectangle[,] spikes5 = new Rectangle[spikeheight5, spikewidth5];
                for (int i = 0; i < spikerow5; i++)
                {
                    for (int j = 0; j < spikecolm5; j++)
                    {
                        // The 90 and 30 Determines the spacing. The +10 and +20 Determines its reach 
                        spikes5[i, j] = new Rectangle(i * 50 + 2200, j * 0 + 550, 50, 50);
                    }
                }
                for (int i = 0; i < spikerow5; i++)
                {
                    for (int j = 0; j < spikecolm5; j++)
                    {
                        if (spikes5[i, j].Width > 0)
                        {
                            Raylib.DrawRectangleRec(spikes5[i, j], Color.RED);

                            Raylib.DrawRectangleLinesEx(spikes5[i, j], 2, Color.DARKPURPLE);
                        }
                    }
                }
                //page3 ceiling 4 blocks
                int spikerow6 = 4;
                int spikecolm6 = 1;
                int spikeheight6 = 50;
                int spikewidth6 = 50;

                Rectangle[,] spikes6 = new Rectangle[spikeheight6, spikewidth6];
                for (int i = 0; i < spikerow6; i++)
                {
                    for (int j = 0; j < spikecolm6; j++)
                    {
                        // The 90 and 30 Determines the spacing. The +10 and +20 Determines its reach 
                        spikes6[i, j] = new Rectangle(i * 50 + 1700, j * 0 + 0, 50, 50);
                    }
                }
                for (int i = 0; i < spikerow6; i++)
                {
                    for (int j = 0; j < spikecolm6; j++)
                    {
                        if (spikes6[i, j].Width > 0)
                        {
                            Raylib.DrawRectangleRec(spikes6[i, j], Color.RED);

                            Raylib.DrawRectangleLinesEx(spikes6[i, j], 2, Color.DARKPURPLE);
                        }
                    }
                }
                //page3 ceiling 7 blocks
                int spikerow7 = 7;
                int spikecolm7 = 1;
                int spikeheight7 = 50;
                int spikewidth7 = 50;

                Rectangle[,] spikes7 = new Rectangle[spikeheight7, spikewidth7];
                for (int i = 0; i < spikerow7; i++)
                {
                    for (int j = 0; j < spikecolm7; j++)
                    {
                        // The 90 and 30 Determines the spacing. The +10 and +20 Determines its reach 
                        spikes7[i, j] = new Rectangle(i * 50 + 2050, j * 0 + 0, 50, 50);
                    }
                }
                for (int i = 0; i < spikerow7; i++)
                {
                    for (int j = 0; j < spikecolm7; j++)
                    {
                        if (spikes7[i, j].Width > 0)
                        {
                            Raylib.DrawRectangleRec(spikes7[i, j], Color.RED);

                            Raylib.DrawRectangleLinesEx(spikes7[i, j], 2, Color.DARKPURPLE);
                        }
                    }
                }
                //page4 ceiling 3blocks level 3
                int spikerow8 = 3;
                int spikecolm8 = 1;
                int spikeheight8 = 50;
                int spikewidth8 = 50;

                Rectangle[,] spikes8 = new Rectangle[spikeheight8, spikewidth8];
                for (int i = 0; i < spikerow8; i++)
                {
                    for (int j = 0; j < spikecolm8; j++)
                    {
                        // The 90 and 30 Determines the spacing. The +10 and +20 Determines its reach 
                        spikes8[i, j] = new Rectangle(i * 50 + 2500, j * 0 + 100, 50, 50);
                    }
                }
                for (int i = 0; i < spikerow8; i++)
                {
                    for (int j = 0; j < spikecolm8; j++)
                    {
                        if (spikes8[i, j].Width > 0)
                        {
                            Raylib.DrawRectangleRec(spikes8[i, j], Color.RED);

                            Raylib.DrawRectangleLinesEx(spikes8[i, j], 2, Color.DARKPURPLE);
                        }
                    }
                }
                //page4 ceiling 1 block level 1
                int spikerow9 = 1;
                int spikecolm9 = 1;
                int spikeheight9 = 50;
                int spikewidth9 = 50;

                Rectangle[,] spikes9 = new Rectangle[spikeheight9, spikewidth9];
                for (int i = 0; i < spikerow9; i++)
                {
                    for (int j = 0; j < spikecolm9; j++)
                    {
                        // The 90 and 30 Determines the spacing. The +10 and +20 Determines its reach 
                        spikes9[i, j] = new Rectangle(i * 50 + 2850, j * 0 + 0, 50, 50);
                    }
                }
                for (int i = 0; i < spikerow9; i++)
                {
                    for (int j = 0; j < spikecolm9; j++)
                    {
                        if (spikes9[i, j].Width > 0)
                        {
                            Raylib.DrawRectangleRec(spikes9[i, j], Color.RED);

                            Raylib.DrawRectangleLinesEx(spikes9[i, j], 2, Color.DARKPURPLE);
                        }
                    }
                }
                //page4 ceiling 1 block level 1
                int spikerow10 = 1;
                int spikecolm10 = 1;
                int spikeheight10 = 50;
                int spikewidth10 = 50;

                Rectangle[,] spikes10 = new Rectangle[spikeheight10, spikewidth10];
                for (int i = 0; i < spikerow10; i++)
                {
                    for (int j = 0; j < spikecolm10; j++)
                    {
                        // The 90 and 30 Determines the spacing. The +10 and +20 Determines its reach 
                        spikes10[i, j] = new Rectangle(i * 50 + 2950, j * 0 + 0, 50, 50);
                    }
                }
                for (int i = 0; i < spikerow10; i++)
                {
                    for (int j = 0; j < spikecolm10; j++)
                    {
                        if (spikes10[i, j].Width > 0)
                        {
                            Raylib.DrawRectangleRec(spikes10[i, j], Color.RED);

                            Raylib.DrawRectangleLinesEx(spikes10[i, j], 2, Color.DARKPURPLE);
                        }
                    }
                }

                //page4 middle 1spike level 4
                int spikerow11 = 1;
                int spikecolm11 = 1;
                int spikeheight11 = 50;
                int spikewidth11 = 50;

                Rectangle[,] spikes11 = new Rectangle[spikeheight11, spikewidth11];
                for (int i = 0; i < spikerow11; i++)
                {
                    for (int j = 0; j < spikecolm11; j++)
                    {
                        spikes11[i, j] = new Rectangle(i * 50 + 2900, j * 0 + 150, 50, 50);
                    }
                }
                for (int i = 0; i < spikerow11; i++)
                {
                    for (int j = 0; j < spikecolm11; j++)
                    {
                        if (spikes11[i, j].Width > 0)
                        {
                            Raylib.DrawRectangleRec(spikes11[i, j], Color.RED);

                            Raylib.DrawRectangleLinesEx(spikes11[i, j], 2, Color.DARKPURPLE);
                        }
                    }
                }
                //page4 bottom 2spikes level 0
                int spikerow12 = 2;
                int spikecolm12 = 1;
                int spikeheight12 = 50;
                int spikewidth12 = 50;

                Rectangle[,] spikes12 = new Rectangle[spikeheight12, spikewidth12];
                for (int i = 0; i < spikerow12; i++)
                {
                    for (int j = 0; j < spikecolm12; j++)
                    {
                        spikes12[i, j] = new Rectangle(i * 50 + 2850, j * 0 + 550, 50, 50);
                    }
                }
                for (int i = 0; i < spikerow12; i++)
                {
                    for (int j = 0; j < spikecolm12; j++)
                    {
                        if (spikes12[i, j].Width > 0)
                        {
                            Raylib.DrawRectangleRec(spikes12[i, j], Color.RED);

                            Raylib.DrawRectangleLinesEx(spikes12[i, j], 2, Color.DARKPURPLE);
                        }
                    }
                }
                //page4 middle 1 spike level 6
                int spikerow13 = 1;
                int spikecolm13 = 1;
                int spikeheight13 = 50;
                int spikewidth13 = 50;

                Rectangle[,] spikes13 = new Rectangle[spikeheight13, spikewidth13];
                for (int i = 0; i < spikerow13; i++)
                {
                    for (int j = 0; j < spikecolm13; j++)
                    {
                        spikes13[i, j] = new Rectangle(i * 50 + 3100, j * 0 + 250, 50, 50);
                    }
                }
                for (int i = 0; i < spikerow13; i++)
                {
                    for (int j = 0; j < spikecolm13; j++)
                    {
                        if (spikes13[i, j].Width > 0)
                        {
                            Raylib.DrawRectangleRec(spikes13[i, j], Color.RED);

                            Raylib.DrawRectangleLinesEx(spikes13[i, j], 2, Color.DARKPURPLE);
                        }
                    }
                }
                //page4 middle 1 spike level 4
                int spikerow14 = 1;
                int spikecolm14 = 1;
                int spikeheight14 = 50;
                int spikewidth14 = 50;

                Rectangle[,] spikes14 = new Rectangle[spikeheight14, spikewidth14];
                for (int i = 0; i < spikerow14; i++)
                {
                    for (int j = 0; j < spikecolm14; j++)
                    {
                        spikes14[i, j] = new Rectangle(i * 50 + 3000, j * 0 + 150, 50, 50);
                    }
                }
                for (int i = 0; i < spikerow14; i++)
                {
                    for (int j = 0; j < spikecolm14; j++)
                    {
                        if (spikes14[i, j].Width > 0)
                        {
                            Raylib.DrawRectangleRec(spikes14[i, j], Color.RED);

                            Raylib.DrawRectangleLinesEx(spikes14[i, j], 2, Color.DARKPURPLE);
                        }
                    }
                }
                //---Page 5

                //page5 bottom 1 spike level 2
                int spikerow15 = 1;
                int spikecolm15 = 1;
                int spikeheight15 = 50;
                int spikewidth15 = 50;

                Rectangle[,] spikes15 = new Rectangle[spikeheight15, spikewidth15];
                for (int i = 0; i < spikerow15; i++)
                {
                    for (int j = 0; j < spikecolm15; j++)
                    {
                        spikes15[i, j] = new Rectangle(i * 50 + 3250, j * 0 + 500, 50, 50);
                    }
                }
                for (int i = 0; i < spikerow15; i++)
                {
                    for (int j = 0; j < spikecolm15; j++)
                    {
                        if (spikes15[i, j].Width > 0)
                        {
                            Raylib.DrawRectangleRec(spikes15[i, j], Color.RED);

                            Raylib.DrawRectangleLinesEx(spikes15[i, j], 2, Color.DARKPURPLE);
                        }
                    }
                }
                //page5 bottom 1 spike level 2
                int spikerow16 = 1;
                int spikecolm16 = 1;
                int spikeheight16 = 50;
                int spikewidth16 = 50;

                Rectangle[,] spikes16 = new Rectangle[spikeheight16, spikewidth16];
                for (int i = 0; i < spikerow16; i++)
                {
                    for (int j = 0; j < spikecolm16; j++)
                    {
                        spikes16[i, j] = new Rectangle(i * 50 + 3550, j * 0 + 500, 50, 50);
                    }
                }
                for (int i = 0; i < spikerow16; i++)
                {
                    for (int j = 0; j < spikecolm16; j++)
                    {
                        if (spikes16[i, j].Width > 0)
                        {
                            Raylib.DrawRectangleRec(spikes16[i, j], Color.RED);

                            Raylib.DrawRectangleLinesEx(spikes16[i, j], 2, Color.DARKPURPLE);
                        }
                    }
                }
                //page5 middle 1 spike 
                int spikerow17 = 1;
                int spikecolm17 = 1;
                int spikeheight17 = 50;
                int spikewidth17 = 50;

                Rectangle[,] spikes17 = new Rectangle[spikeheight17, spikewidth17];
                for (int i = 0; i < spikerow17; i++)
                {
                    for (int j = 0; j < spikecolm17; j++)
                    {
                        spikes17[i, j] = new Rectangle(i * 50 + 3600, j * 0 + 250, 50, 50);
                    }
                }
                for (int i = 0; i < spikerow17; i++)
                {
                    for (int j = 0; j < spikecolm17; j++)
                    {
                        if (spikes17[i, j].Width > 0)
                        {
                            Raylib.DrawRectangleRec(spikes17[i, j], Color.RED);

                            Raylib.DrawRectangleLinesEx(spikes17[i, j], 2, Color.DARKPURPLE);
                        }
                    }
                }
                //page5 middle 1 spike 
                int spikerow18 = 1;
                int spikecolm18 = 1;
                int spikeheight18 = 50;
                int spikewidth18 = 50;

                Rectangle[,] spikes18 = new Rectangle[spikeheight18, spikewidth18];
                for (int i = 0; i < spikerow18; i++)
                {
                    for (int j = 0; j < spikecolm18; j++)
                    {
                        spikes18[i, j] = new Rectangle(i * 50 + 3750, j * 0 + 300, 50, 50);
                    }
                }
                for (int i = 0; i < spikerow18; i++)
                {
                    for (int j = 0; j < spikecolm18; j++)
                    {
                        if (spikes18[i, j].Width > 0)
                        {
                            Raylib.DrawRectangleRec(spikes18[i, j], Color.RED);

                            Raylib.DrawRectangleLinesEx(spikes18[i, j], 2, Color.DARKPURPLE);
                        }
                    }
                }
                //page5 middle 4 vertspike 
                int spikerow19 = 1;
                int spikecolm19 = 4;
                int spikeheight19 = 50;
                int spikewidth19 = 50;

                Rectangle[,] spikes19 = new Rectangle[spikeheight19, spikewidth19];
                for (int i = 0; i < spikerow19; i++)
                {
                    for (int j = 0; j < spikecolm19; j++)
                    {
                        spikes19[i, j] = new Rectangle(i * 50 + 3950, j * 50 + 200, 50, 50);
                    }
                }
                for (int i = 0; i < spikerow19; i++)
                {
                    for (int j = 0; j < spikecolm19; j++)
                    {
                        if (spikes19[i, j].Width > 0)
                        {
                            Raylib.DrawRectangleRec(spikes19[i, j], Color.RED);

                            Raylib.DrawRectangleLinesEx(spikes19[i, j], 2, Color.DARKPURPLE);
                        }
                    }
                }


            }

        }
    }
}