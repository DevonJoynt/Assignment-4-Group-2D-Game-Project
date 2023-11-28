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
        static Texture2D spike1;
        static Texture2D spike2;
        static Texture2D spike3;
        static Texture2D spike4;
        static Texture2D background;
        static Texture2D enemy2;
        static Texture2D enemy3;
        static Texture2D maincharacter;
        static bool Polarity { get; set; } = true;
        static int PolarityPressed;
        static Vector2 PlayerPosition { get; set; } = new Vector2(-900, 250);
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
                Console.WriteLine(PlayerPosition);
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

                Background();
                Update();
                Player();
                Floor();
                Spikes();
                CheckCollision();

                Raylib.EndDrawing();  // Stop drawing to the canvas, begin displaying the frame 
            }
            Raylib.CloseWindow(); // Close the window 
        }
        static void Setup() // Your one-time setup code here 
        {

            spike1 = LoadTexture2D("../../../Assets/Spike (Pointing Upwards).png");
            spike2 = LoadTexture2D("../../../Assets/Spike (Pointing Downwards).png");
            spike3 = LoadTexture2D("../../../Assets/Spike (Pointing Left).png");
            spike4 = LoadTexture2D("../../../Assets/Spike (Pointing Right).png");
            background = LoadTexture2D("../../../Assets/Screen Background - Jake deVos.png");
            enemy2 = LoadTexture2D("../../../Assets/Enemy Design 2 - Jake deVos.png");
            enemy3 = LoadTexture2D("../../../Assets/Enemy Design 2 (Opposite) - Jake deVos.png");
            maincharacter = LoadTexture2D("../../../Assets/Main Character-neutral.png");
        }
        static Texture2D LoadTexture2D(string filename)
        {
            Image image = Raylib.LoadImage(filename);
            Texture2D texture = Raylib.LoadTextureFromImage(image);
            return texture;
        }
        static void CheckCollision()
        {
            // Spike Collision
            if (PlayerPosition.X >= 1125 && PlayerPosition.X <= 1200 && PlayerPosition.Y >= 450)
            {
                PlayerPosition = new Vector2(-900, 200);
            }

            if (PlayerPosition.X >= 675 && PlayerPosition.X <= 925 && PlayerPosition.Y <= 50)
            {
                PlayerPosition = new Vector2(-900, 200);
            }
            // First Level

            Vector2 Move = new Vector2(-5, 0);
            Vector2 GravityBasic = new Vector2(0, 10);
            bool hitRWall = false;
            bool hitLWall = false;

            // Spike Collision
            if (PlayerPosition.X >= 1125 && PlayerPosition.X <= 1200 && PlayerPosition.Y >= 450)
            {
                PlayerPosition = new Vector2(-900, 250);
            }

            if (PlayerPosition.X >= 675 && PlayerPosition.X <= 925 && PlayerPosition.Y <= 50)
            {
                PlayerPosition = new Vector2(-900, 250);
            }

            // Obstacle Collision From Spawn
            // First object 
            if (PlayerPosition.X > -625 && PlayerPosition.X <= -470 && PlayerPosition.Y <= 399)
            {
                // LEFT Side
                hitRWall = true;
                if (hitRWall && Raylib.IsKeyDown(KeyboardKey.KEY_D) || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                {
                    PlayerPosition = PlayerPosition + Move;
                }

                // Top Side
                if (PlayerPosition.Y < 400 && PlayerPosition.X > -625)
                {
                    PlayerPosition = PlayerPosition + GravityBasic;
                    hitRWall = false;
                    if (!hitRWall && Raylib.IsKeyDown(KeyboardKey.KEY_D) || Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                    {
                        PlayerPosition = PlayerPosition - Move;
                    }
                }

                // Right Side
                if (PlayerPosition.X <= -465 && PlayerPosition.Y < 400)
                {
                    hitLWall = true;
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_A) || Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                    {
                        PlayerPosition = PlayerPosition - Move;
                    }
                }

            }

            // 2nd object 
            if (PlayerPosition.X > -375 && PlayerPosition.X <= -220 && PlayerPosition.Y >= 145)
            {
                // LEFT Side
                hitRWall = true;
                if (hitRWall && Raylib.IsKeyDown(KeyboardKey.KEY_D) || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                {
                    PlayerPosition = PlayerPosition + Move;
                }

                // Top Side
                if (PlayerPosition.Y > 149 && PlayerPosition.X > -373)
                {
                    PlayerPosition = PlayerPosition - GravityBasic;
                    hitRWall = false;
                    if (!hitRWall && Raylib.IsKeyDown(KeyboardKey.KEY_D) || Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                    {
                        PlayerPosition = PlayerPosition - Move;
                    }
                }

                // Right Side
                if (PlayerPosition.X <= -200 && PlayerPosition.Y > 150)
                {
                    hitLWall = true;
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_A) || Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                    {
                        PlayerPosition = PlayerPosition - Move;
                    }
                }
            }

            // Small Sqaure up top

            if (PlayerPosition.X > -125 && PlayerPosition.X <= -15 && PlayerPosition.Y <= 100)
            {
                // LEFT Side
                hitRWall = true;
                if (hitRWall && Raylib.IsKeyDown(KeyboardKey.KEY_D) || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                {
                    PlayerPosition = PlayerPosition + Move;
                }

                // Top Side
                if (PlayerPosition.Y < 100 && PlayerPosition.X > -125)
                {
                    PlayerPosition = PlayerPosition + GravityBasic;
                    hitRWall = false;
                    if (!hitRWall && Raylib.IsKeyDown(KeyboardKey.KEY_D) || Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                    {
                        PlayerPosition = PlayerPosition - Move;
                    }
                }

                // Right Side
                if (PlayerPosition.X < -15 && PlayerPosition.Y < 100)
                {
                    hitLWall = true;
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_A) || Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                    {
                        PlayerPosition = PlayerPosition - Move;
                    }
                }
            }
        }
        static void Player()
        {
            Vector2 Move = new Vector2(-5, 0);
            Vector2 GravityBasic = new Vector2(0, 10);

            //Bottom of cube 
            float PlayerBottomCorner = PlayerPosition.X + PlayerPosition.Y;

            //Draws Player 
            Raylib.DrawTexture(maincharacter, (int)PlayerPosition.X - 500, (int)PlayerPosition.Y - 400, Color.WHITE);

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

            // Side Wall and Telportation Collision 
            if (PlayerPosition.X - PlayerWidth > -1980 && PlayerPosition.X - PlayerWidth < -805 || PlayerPosition.X + PlayerWidth > 10000000)
            {

                GravityBasic = new Vector2(0, 0);
                if (PlayerPosition.X >= -900 && PlayerPosition.X < 750)
                {
                    Vector2 Move2 = new Vector2(5, 0);
                    PlayerPosition = PlayerPosition + Move2;
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_A) || Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                    {
                        PlayerPosition = PlayerPosition + Move;
                    }
                }

                if (PlayerPosition.X <= -920 && PlayerPosition.X >= -930)
                {
                    PlayerPosition = new Vector2(-1750, 250);
                    Polarity = true;
                }

                if (PlayerPosition.X <= -1750 && PlayerPosition.X > -1970)
                {
                    PlayerPosition = PlayerPosition + Move;
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_D) || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                    {
                        PlayerPosition = PlayerPosition - Move;
                    }
                }
                if (PlayerPosition.X >= -1740 && PlayerPosition.X < -1500)
                {
                    PlayerPosition = new Vector2(-900, 250);
                    Polarity = false;
                }

            }

            // Top Collisiom 
            if (PlayerPosition.Y - 5 < 50)
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
            if (PlayerPosition.Y + 5 > FloorBrickHeight && PlayerPosition.X < 1345)
            {
                GravityBasic = new Vector2(0, 0);
                BottomWall = true;

                if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && BottomWall)
                {
                    GravityBasic = new Vector2(0, 10);
                    PlayerPosition = PlayerPosition - GravityBasic;
                }
            }
            bool HitRWall = false;
            bool HitLWall = false;
            // Map Collision

            // The First Block the player hits
            if (PlayerPosition.X > 1200 && PlayerPosition.X < 1700)
            {
                HitRWall = true;
                Move = new Vector2(5, 0);

                // Prevents the Player from phasing FloorBlock8-10 from the left
                if (PlayerPosition.X <= 1700)
                {
                    HitLWall = true;
                }

                // Allows the player to still move after hitting wall
                if (PlayerPosition.Y <= 305)
                {
                    Move = new Vector2(-1, 0);
                    HitRWall = false;
                }

                // Prevents the Player from phasing FloorBlock8 from the top
                if (PlayerPosition.Y > 295)
                {
                    GravityBasic = new Vector2(0, 0);
                    BottomWall = true;

                    // To still be able to press Space
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && BottomWall)
                    {
                        GravityBasic = new Vector2(0, 10);
                        PlayerPosition = PlayerPosition - GravityBasic;
                    }

                }

                // This prevents phasing through the blocks Right and Left
                if (HitRWall && Raylib.IsKeyDown(KeyboardKey.KEY_D) || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                {
                    PlayerPosition = PlayerPosition - Move;
                }

                if (HitLWall && Raylib.IsKeyDown(KeyboardKey.KEY_A) || Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                {
                    PlayerPosition = PlayerPosition + Move;
                }
            }

            // Floor Collison (Making it easier for myself)
            if (PlayerPosition.X >= 1700)
            {
                if (PlayerPosition.Y >= 500)
                {
                    GravityBasic = new Vector2(0, 0);
                    BottomWall = true;

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && BottomWall)
                    {
                        GravityBasic = new Vector2(0, 10);
                        PlayerPosition = PlayerPosition - GravityBasic;
                    }
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
        static void Update() // Your game code run each frame here 
        {


        }

        static void Floor()
        {
            // Brick Size 
            int brickheight = 80;
            int brickwidth = 80;

            //---Page 00

            //bottom 13 blocks 2 rows
            Rectangle FloorBrick0 = new Rectangle(-2400, 500, 650, 100);
            Raylib.DrawRectangleRec(FloorBrick0, Color.GRAY);

            //ceiling 13 blocks 2 rows
            Rectangle FloorBrick2 = new Rectangle(-2400, 0, 650, 100);
            Raylib.DrawRectangleRec(FloorBrick2, Color.GRAY);

            Rectangle FloorBrick3 = new Rectangle(-1760, 150, 10, 300);
            Raylib.DrawRectangleRec(FloorBrick3, Color.GRAY);

            //top to bottom 8 blocks 3 rows
            Rectangle FloorBrick4 = new Rectangle(-2400, 100, 150, 400);
            Raylib.DrawRectangleRec(FloorBrick4, Color.GRAY);

            //top to bottom 8 blocks 3 rows
            Rectangle FloorBrick5 = new Rectangle(-1750, 0, 100, 600);
            Raylib.DrawRectangleRec(FloorBrick5, Color.GRAY);

            //middle
            Rectangle FloorBrick6 = new Rectangle(-2150, 250, 300, 150);
            Raylib.DrawRectangleRec(FloorBrick6, Color.GRAY);


            //---Page 0

            //bottom 16 blocks 2 rows
            Rectangle FloorBrick8 = new Rectangle(-850, 500, 850, 100);
            Raylib.DrawRectangleRec(FloorBrick8, Color.GRAY);

            //ceiling 16 blocks
            Rectangle FloorBrick10 = new Rectangle(-850, 0, 850, 50);
            Raylib.DrawRectangleRec(FloorBrick10, Color.GRAY);

            //ceiling 1 block
            Rectangle FloorBrick12 = new Rectangle(-50, 50, 50, 50);
            Raylib.DrawRectangleRec(FloorBrick12, Color.GRAY);

            //middle vert blocks attached to bottom
            Rectangle FloorBrick14 = new Rectangle(-300, 200, 100, 300);
            Raylib.DrawRectangleRec(FloorBrick14, Color.GRAY);

            //middle vert blocks attached to ceiling
            Rectangle FloorBrick16 = new Rectangle(-550, 50, 100, 350);
            Raylib.DrawRectangleRec(FloorBrick16, Color.GRAY);

            //spacebar
            Rectangle FloorBrick18 = new Rectangle(-430, 200, 110, 50);
            Raylib.DrawRectangleRec(FloorBrick18, Color.VIOLET);
            Raylib.DrawRectangleLinesEx(FloorBrick18, 2, Color.YELLOW);

            //Arrow Key
            Rectangle FloorBrick20 = new Rectangle(-750, 200, 50, 50);
            Raylib.DrawRectangleRec(FloorBrick20, Color.VIOLET);
            Raylib.DrawRectangleLinesEx(FloorBrick20, 2, Color.YELLOW);

            //Arrow Key
            Rectangle FloorBrick22 = new Rectangle(-650, 200, 50, 50);
            Raylib.DrawRectangleRec(FloorBrick22, Color.VIOLET);
            Raylib.DrawRectangleLinesEx(FloorBrick22, 2, Color.YELLOW);

            //top to bottom vert blocks - beginning of maze
            Rectangle FloorBrick24 = new Rectangle(-950, 0, 100, 600);
            Raylib.DrawRectangleRec(FloorBrick24, Color.GRAY);

            //beginning of maze
            Rectangle FloorBrick26 = new Rectangle(-850, 100, 10, 350);
            Raylib.DrawRectangleRec(FloorBrick26, Color.GRAY);

            //---Page 1

            Rectangle FloorBrick28 = new Rectangle(0, 550, 1250, 50);
            Raylib.DrawRectangleRec(FloorBrick28, Color.GRAY);

            Rectangle FloorBrick30 = new Rectangle(0, 500, 1150, 50);
            Raylib.DrawRectangleRec(FloorBrick30, Color.GRAY);

            Rectangle FloorBrick32 = new Rectangle(0, 0, 700, 50);
            Raylib.DrawRectangleRec(FloorBrick32, Color.GRAY);

            //spacebar
            Rectangle FloorBrick34 = new Rectangle(520, 250, 110, 50);
            Raylib.DrawRectangleRec(FloorBrick34, Color.VIOLET);
            Raylib.DrawRectangleLinesEx(FloorBrick34, 2, Color.YELLOW);

            //pg1
            Rectangle FloorBrick36 = new Rectangle(490, 320, 170, 20);
            Raylib.DrawRectangleRec(FloorBrick36, Color.VIOLET);
            //pg1
            Rectangle FloorBrick38 = new Rectangle(490, 320, 20, 50);
            Raylib.DrawRectangleRec(FloorBrick38, Color.VIOLET);
            //pg1
            Rectangle FloorBrick40 = new Rectangle(640, 320, 20, 50);
            Raylib.DrawRectangleRec(FloorBrick40, Color.VIOLET);

            //---Page 2

            //pg2 large block
            Rectangle FloorBrick42 = new Rectangle(1250, 350, 450, 50);
            Raylib.DrawRectangleRec(FloorBrick42, Color.GRAY);

            //pg2 large block
            Rectangle FloorBrick44 = new Rectangle(1250, 400, 450, 50);
            Raylib.DrawRectangleRec(FloorBrick44, Color.GRAY);

            //pg2
            Rectangle FloorBrick46 = new Rectangle(1250, 450, 450, 50);
            Raylib.DrawRectangleRec(FloorBrick46, Color.GRAY);

            //pg2
            Rectangle FloorBrick48 = new Rectangle(1250, 550, 550, 50);
            Raylib.DrawRectangleRec(FloorBrick48, Color.GRAY);

            //pg2
            Rectangle FloorBrick50 = new Rectangle(1250, 500, 450, 50);
            Raylib.DrawRectangleRec(FloorBrick50, Color.GRAY);

            //pg2 ceiling
            Rectangle FloorBrick52 = new Rectangle(950, 0, 550, 50);
            Raylib.DrawRectangleRec(FloorBrick52, Color.GRAY);

            //pg2 ceiling blocks
            Rectangle FloorBrick54 = new Rectangle(1250, 50, 100, 50);
            Raylib.DrawRectangleRec(FloorBrick54, Color.GRAY);

            //pg2 ceiling blocks
            Rectangle FloorBrick56 = new Rectangle(1300, 100, 50, 50);
            Raylib.DrawRectangleRec(FloorBrick56, Color.GRAY);

            //pg2 ceiling blocks
            Rectangle FloorBrick58 = new Rectangle(1550, 0, 150, 50);
            Raylib.DrawRectangleRec(FloorBrick58, Color.GRAY);

            //pg2 ceiling blocks second level
            Rectangle FloorBrick60 = new Rectangle(1550, 50, 100, 50);
            Raylib.DrawRectangleRec(FloorBrick60, Color.GRAY);

            //pg2 ceiling blocks third level
            Rectangle FloorBrick62 = new Rectangle(1450, 100, 200, 50);
            Raylib.DrawRectangleRec(FloorBrick62, Color.GRAY);

            //---Page 3

            //page3 ceiling 3 blocks
            Rectangle FloorBrick64 = new Rectangle(1900, 0, 150, 50);
            Raylib.DrawRectangleRec(FloorBrick64, Color.GRAY);

            //pg3 floor 1 block
            Rectangle FloorBrick66 = new Rectangle(2150, 550, 50, 50);
            Raylib.DrawRectangleRec(FloorBrick66, Color.GRAY);

            //pg3/4 floor 11 block
            Rectangle FloorBrick68 = new Rectangle(2300, 550, 550, 50);
            Raylib.DrawRectangleRec(FloorBrick68, Color.GRAY);

            //---Page 4

            //page4 ceiling 9 blocks level 1
            Rectangle FloorBrick70 = new Rectangle(2400, 0, 450, 50);
            Raylib.DrawRectangleRec(FloorBrick70, Color.GRAY);

            //page4 ceiling 7 blocks level 2
            Rectangle FloorBrick72 = new Rectangle(2400, 50, 350, 50);
            Raylib.DrawRectangleRec(FloorBrick72, Color.GRAY);

            //page4 ceiling 2 blocks level 3
            Rectangle FloorBrick74 = new Rectangle(2400, 100, 100, 50);
            Raylib.DrawRectangleRec(FloorBrick74, Color.GRAY);

            //page4 ceiling 2 blocks level 3
            Rectangle FloorBrick76 = new Rectangle(2650, 100, 100, 50);
            Raylib.DrawRectangleRec(FloorBrick76, Color.GRAY);

            //page4 ceiling 1 block 
            Rectangle FloorBrick78 = new Rectangle(2900, 0, 50, 50);
            Raylib.DrawRectangleRec(FloorBrick78, Color.GRAY);

            //page4 ceiling 2 blocks 
            Rectangle FloorBrick80 = new Rectangle(3000, 0, 100, 50);
            Raylib.DrawRectangleRec(FloorBrick80, Color.GRAY);

            //pg4 floor 9 blocks level 2
            Rectangle FloorBrick82 = new Rectangle(2400, 500, 450, 50);
            Raylib.DrawRectangleRec(FloorBrick82, Color.GRAY);

            //pg4 floor 8 blocks level 3
            Rectangle FloorBrick84 = new Rectangle(2400, 450, 400, 50);
            Raylib.DrawRectangleRec(FloorBrick84, Color.GRAY);

            //pg4 floor 9 blocks level 4
            Rectangle FloorBrick86 = new Rectangle(2400, 400, 450, 50);
            Raylib.DrawRectangleRec(FloorBrick86, Color.GRAY);

            //pg4/5/6 floor 23 blocks level 1
            Rectangle FloorBrick88 = new Rectangle(2950, 550, 1150, 50);
            Raylib.DrawRectangleRec(FloorBrick88, Color.GRAY);

            //pg4/5 floor 23 blocks level 2
            Rectangle FloorBrick90 = new Rectangle(2950, 500, 300, 50);
            Raylib.DrawRectangleRec(FloorBrick90, Color.GRAY);

            //-----------

            // pg4 middle blocks
            Rectangle FloorBrick92 = new Rectangle(2800, 350, 100, 50);
            Raylib.DrawRectangleRec(FloorBrick92, Color.GRAY);

            Rectangle FloorBrick94 = new Rectangle(2850, 150, 50, 200);
            Raylib.DrawRectangleRec(FloorBrick94, Color.GRAY);

            Rectangle FloorBrick96 = new Rectangle(2900, 200, 50, 50);
            Raylib.DrawRectangleRec(FloorBrick96, Color.GRAY);

            Rectangle FloorBrick98 = new Rectangle(2950, 150, 50, 200);
            Raylib.DrawRectangleRec(FloorBrick98, Color.GRAY);

            //pg4/5 ceiling 2blk wide 8blk down
            Rectangle FloorBrick100 = new Rectangle(3150, 0, 100, 400);
            Raylib.DrawRectangleRec(FloorBrick100, Color.GRAY);

            //pg4 "HAD ENOUGH" block
            Rectangle FloorBrick102 = new Rectangle(2450, 450, 300, 100);
            Raylib.DrawRectangleRec(FloorBrick102, Color.YELLOW);

            //pg2 "RECHARGE" block
            Rectangle FloorBrick104 = new Rectangle(1300, 400, 250, 150);
            Raylib.DrawRectangleRec(FloorBrick104, Color.YELLOW);

            //---Page 5

            //pg5 floor 5blocks  level 2
            Rectangle FloorBrick106 = new Rectangle(3300, 500, 250, 50);
            Raylib.DrawRectangleRec(FloorBrick106, Color.GRAY);

            //pg5 floor 3blocks  level 3
            Rectangle FloorBrick108 = new Rectangle(3350, 450, 150, 50);
            Raylib.DrawRectangleRec(FloorBrick108, Color.GRAY);

            //pg5 floor 1blocks  level 4
            Rectangle FloorBrick110 = new Rectangle(3400, 400, 50, 50);
            Raylib.DrawRectangleRec(FloorBrick110, Color.GRAY);

            //pg5 floor 2blocks  level 2
            Rectangle FloorBrick112 = new Rectangle(3600, 500, 100, 50);
            Raylib.DrawRectangleRec(FloorBrick112, Color.GRAY);

            //pg5 middle 7 vertblocks  level 4
            Rectangle FloorBrick114 = new Rectangle(3650, 150, 50, 350);
            Raylib.DrawRectangleRec(FloorBrick114, Color.GRAY);

            //pg5 ceiling 15blocks  level 1
            Rectangle FloorBrick116 = new Rectangle(3250, 0, 750, 50);
            Raylib.DrawRectangleRec(FloorBrick116, Color.GRAY);

            //pg5 ceiling 2blocks  level 2
            Rectangle FloorBrick118 = new Rectangle(3250, 50, 100, 50);
            Raylib.DrawRectangleRec(FloorBrick118, Color.GRAY);

            //pg5 ceiling 1blocks  level 3
            Rectangle FloorBrick120 = new Rectangle(3250, 100, 50, 50);
            Raylib.DrawRectangleRec(FloorBrick120, Color.GRAY);

            //pg5 ceiling 2blocks  level 2
            Rectangle FloorBrick122 = new Rectangle(3450, 50, 100, 50);
            Raylib.DrawRectangleRec(FloorBrick122, Color.GRAY);

            //pg5 ceiling 1blocks  level 3
            Rectangle FloorBrick124 = new Rectangle(3500, 100, 50, 50);
            Raylib.DrawRectangleRec(FloorBrick124, Color.GRAY);

            //pg5 floor 1blocks  level 3
            Rectangle FloorBrick126 = new Rectangle(3750, 450, 50, 50);
            Raylib.DrawRectangleRec(FloorBrick126, Color.GRAY);

            //pg5 floor 1blocks  level 3
            Rectangle FloorBrick128 = new Rectangle(3900, 450, 50, 50);
            Raylib.DrawRectangleRec(FloorBrick128, Color.GRAY);

            //pg5 floor 5blocks  level 4
            Rectangle FloorBrick130 = new Rectangle(3750, 400, 250, 50);
            Raylib.DrawRectangleRec(FloorBrick130, Color.GRAY);

            //pg5 middle 2vertblocks  
            Rectangle FloorBrick132 = new Rectangle(3800, 300, 50, 100);
            Raylib.DrawRectangleRec(FloorBrick132, Color.GRAY);

            //pg5 ceiling 3vertblocks  level 2
            Rectangle FloorBrick134 = new Rectangle(3950, 50, 50, 150);
            Raylib.DrawRectangleRec(FloorBrick134, Color.GRAY);

            //---Page 6

            //pg6 ceiling 13blocks  level 1
            Rectangle FloorBrick136 = new Rectangle(4150, 0, 650, 50);
            Raylib.DrawRectangleRec(FloorBrick136, Color.GRAY);

            //pg6 middle 16blocks  
            Rectangle FloorBrick138 = new Rectangle(4000, 300, 800, 50);
            Raylib.DrawRectangleRec(FloorBrick138, Color.GRAY);

            //pg6 bottom 1.3blocks  level 1
            Rectangle FloorBrick140 = new Rectangle(4150, 534, 50, 100);
            Raylib.DrawRectangleRec(FloorBrick140, Color.GRAY);

            //pg6 bottom 1blocks  level 1
            Rectangle FloorBrick142 = new Rectangle(4250, 550, 50, 50);
            Raylib.DrawRectangleRec(FloorBrick142, Color.GRAY);

            //pg6 bottom 1.3blocks  level 1
            Rectangle FloorBrick144 = new Rectangle(4350, 534, 50, 100);
            Raylib.DrawRectangleRec(FloorBrick144, Color.GRAY);

            //pg6 bottom 7blocks  level 1
            Rectangle FloorBrick146 = new Rectangle(4450, 550, 350, 50);
            Raylib.DrawRectangleRec(FloorBrick146, Color.GRAY);

            //pg6 bottom 2vertblocks  level 3
            Rectangle FloorBrick148 = new Rectangle(4450, 450, 50, 100);
            Raylib.DrawRectangleRec(FloorBrick148, Color.GRAY);

            //pg6 bottom 2vertblocks  level 3
            Rectangle FloorBrick150 = new Rectangle(4650, 450, 50, 100);
            Raylib.DrawRectangleRec(FloorBrick150, Color.GRAY);

            //pg6 middle 2vertblocks  
            Rectangle FloorBrick152 = new Rectangle(4550, 350, 50, 100);
            Raylib.DrawRectangleRec(FloorBrick152, Color.GRAY);

            //---Page 7

            //pg7 ceiling 16blocks  level 1
            Rectangle FloorBrick154 = new Rectangle(4800, 0, 800, 50);
            Raylib.DrawRectangleRec(FloorBrick154, Color.GRAY);

            //pg7 ceiling 3blocks  level 2
            Rectangle FloorBrick156 = new Rectangle(5450, 50, 150, 50);
            Raylib.DrawRectangleRec(FloorBrick156, Color.GRAY);

            //pg7 ceiling 3blocks  level 3and4
            Rectangle FloorBrick158 = new Rectangle(5500, 100, 100, 100);
            Raylib.DrawRectangleRec(FloorBrick158, Color.GRAY);

            //pg7 middle 6blocks  
            Rectangle FloorBrick160 = new Rectangle(4800, 300, 300, 50);
            Raylib.DrawRectangleRec(FloorBrick160, Color.GRAY);

            //pg7 middle 2vertblocks  
            Rectangle FloorBrick162 = new Rectangle(5050, 350, 50, 100);
            Raylib.DrawRectangleRec(FloorBrick162, Color.GRAY);

            //pg7 middle 4vertblocks  
            Rectangle FloorBrick164 = new Rectangle(5575, 200, 25, 200);
            Raylib.DrawRectangleRec(FloorBrick164, Color.GRAY);

            //pg7 bottom 16blocks  level 1
            Rectangle FloorBrick166 = new Rectangle(4800, 550, 800, 50);
            Raylib.DrawRectangleRec(FloorBrick166, Color.GRAY);

            //pg7 bottom 2blocks  level 2
            Rectangle FloorBrick168 = new Rectangle(4900, 500, 100, 50);
            Raylib.DrawRectangleRec(FloorBrick168, Color.GRAY);

            //pg7 bottom 1blocks  level 3
            Rectangle FloorBrick170 = new Rectangle(4950, 450, 50, 50);
            Raylib.DrawRectangleRec(FloorBrick170, Color.GRAY);

            //pg7 bottom 3blocks  level 2
            Rectangle FloorBrick172 = new Rectangle(5450, 500, 150, 50);
            Raylib.DrawRectangleRec(FloorBrick172, Color.GRAY);

            //pg7 bottom 2blocks  level 3and4
            Rectangle FloorBrick174 = new Rectangle(5500, 400, 100, 100);
            Raylib.DrawRectangleRec(FloorBrick174, Color.GRAY);
        }

        static void Spikes()
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
                        Raylib.DrawTexture(spike1, i + 230, j + 20, Color.BLUE);
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
                        Raylib.DrawTexture(spike2, i - 25, j - 550, Color.ORANGE);
                        Raylib.DrawTexture(spike2, i - 75, j - 550, Color.ORANGE);
                        Raylib.DrawTexture(spike2, i - 127, j - 550, Color.ORANGE);
                        Raylib.DrawTexture(spike2, i - 180, j - 550, Color.ORANGE);
                        Raylib.DrawTexture(spike2, i - 230, j - 550, Color.ORANGE);

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
                        Raylib.DrawTexture(spike2, i + 567, j - 550, Color.ORANGE);
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
                        Raylib.DrawTexture(spike1, i + 1010, j + 80, Color.BLUE);
                        Raylib.DrawTexture(spike1, i + 1060, j + 80, Color.BLUE);
                        Raylib.DrawTexture(spike1, i + 1110, j + 80, Color.BLUE);
                        Raylib.DrawTexture(spike1, i + 960, j + 80, Color.BLUE);
                        Raylib.DrawTexture(spike1, i + 910, j + 80, Color.BLUE);
                        Raylib.DrawTexture(spike1, i + 860, j + 80, Color.BLUE);
                        Raylib.DrawTexture(spike1, i + 1160, j + 80, Color.BLUE);
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
                        Raylib.DrawTexture(spike1, i + 1310, j + 80, Color.BLUE);
                        Raylib.DrawTexture(spike1, i + 1260, j + 80, Color.BLUE);
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
                        Raylib.DrawTexture(spike2, i + 765, j - 550, Color.ORANGE);
                        Raylib.DrawTexture(spike2, i + 815, j - 550, Color.ORANGE);
                        Raylib.DrawTexture(spike2, i + 865, j - 550, Color.ORANGE);
                        Raylib.DrawTexture(spike2, i + 915, j - 550, Color.ORANGE);
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
                        Raylib.DrawTexture(spike2, i + 1117, j - 550, Color.ORANGE);
                        Raylib.DrawTexture(spike2, i + 1167, j - 550, Color.ORANGE);
                        Raylib.DrawTexture(spike2, i + 1217, j - 550, Color.ORANGE);
                        Raylib.DrawTexture(spike2, i + 1267, j - 550, Color.ORANGE);
                        Raylib.DrawTexture(spike2, i + 1317, j - 550, Color.ORANGE);
                        Raylib.DrawTexture(spike2, i + 1367, j - 550, Color.ORANGE);
                        Raylib.DrawTexture(spike2, i + 1417, j - 550, Color.ORANGE);
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
                        Raylib.DrawTexture(spike2, i + 1565, j - 450, Color.ORANGE);
                        Raylib.DrawTexture(spike2, i + 1615, j - 450, Color.ORANGE);
                        Raylib.DrawTexture(spike2, i + 1665, j - 450, Color.ORANGE);
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
                        Raylib.DrawTexture(spike2, i + 1665, j - 450, Color.ORANGE);
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
                        Raylib.DrawTexture(spike2, i + 1915, j - 570, Color.ORANGE);
                        Raylib.DrawTexture(spike2, i + 2015, j - 570, Color.ORANGE);
                        Raylib.DrawTexture(spike2, i + 2165, j - 570, Color.ORANGE);
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
                        Raylib.DrawTexture(spike1, i + 1960, j - 350, Color.BLUE);
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
                        Raylib.DrawTexture(spike1, i + 1960, j + 80, Color.BLUE);
                        Raylib.DrawTexture(spike1, i + 1910, j + 80, Color.BLUE);
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
                        Raylib.DrawTexture(spike3, i + 2180, j - 270, Color.BLUE);
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
                        Raylib.DrawTexture(spike4, i + 2040, j - 360, Color.BLUE);
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
                        Raylib.DrawTexture(spike1, i + 2310, j + 40, Color.BLUE);
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
                        Raylib.DrawTexture(spike1, i + 2610, j + 40, Color.BLUE);
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
                        Raylib.DrawTexture(spike3, i + 2675, j - 270, Color.BLUE);
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
                        Raylib.DrawTexture(spike3, i + 2840, j - 220, Color.BLUE);
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
                        Raylib.DrawTexture(spike3, i + 2990, j - 265, Color.ORANGE);
                        Raylib.DrawTexture(spike3, i + 2990, j - 315, Color.ORANGE);
                        Raylib.DrawTexture(spike3, i + 2990, j - 215, Color.BLUE);
                        Raylib.DrawTexture(spike3, i + 2990, j - 165, Color.BLUE);


                    }
                }
            }
            //---Page 6

            //page6 bottom 1 spike 
            int spikerow20 = 1;
            int spikecolm20 = 1;
            int spikeheight20 = 50;
            int spikewidth20 = 50;

            Rectangle[,] spikes20 = new Rectangle[spikeheight20, spikewidth20];
            for (int i = 0; i < spikerow20; i++)
            {
                for (int j = 0; j < spikecolm20; j++)
                {
                    spikes20[i, j] = new Rectangle(i * 50 + 4100, j * 0 + 550, 50, 50);
                }
            }
            for (int i = 0; i < spikerow20; i++)
            {
                for (int j = 0; j < spikecolm20; j++)
                {
                    if (spikes20[i, j].Width > 0)
                    {
                        Raylib.DrawTexture(spike1, i + 3160, j + 80, Color.BLUE);
                    }
                }
            }
            //page6 bottom 1 spike
            int spikerow21 = 1;
            int spikecolm21 = 1;
            int spikeheight21 = 50;
            int spikewidth21 = 50;

            Rectangle[,] spikes21 = new Rectangle[spikeheight21, spikewidth21];
            for (int i = 0; i < spikerow21; i++)
            {
                for (int j = 0; j < spikecolm21; j++)
                {
                    spikes21[i, j] = new Rectangle(i * 50 + 4200, j * 0 + 550, 50, 50);
                }
            }
            for (int i = 0; i < spikerow21; i++)
            {
                for (int j = 0; j < spikecolm21; j++)
                {
                    if (spikes21[i, j].Width > 0)
                    {
                        Raylib.DrawTexture(spike1, i + 3260, j + 80, Color.BLUE);
                    }
                }
            }
            //page6 bottom 1 spike
            int spikerow22 = 1;
            int spikecolm22 = 1;
            int spikeheight22 = 50;
            int spikewidth22 = 50;

            Rectangle[,] spikes22 = new Rectangle[spikeheight22, spikewidth22];
            for (int i = 0; i < spikerow22; i++)
            {
                for (int j = 0; j < spikecolm22; j++)
                {
                    spikes22[i, j] = new Rectangle(i * 50 + 4300, j * 0 + 550, 50, 50);
                }
            }
            for (int i = 0; i < spikerow22; i++)
            {
                for (int j = 0; j < spikecolm22; j++)
                {
                    if (spikes22[i, j].Width > 0)
                    {
                        Raylib.DrawTexture(spike1, i + 3360, j + 80, Color.BLUE);
                    }
                }
            }
            //page6 bottom 1 spike level 4
            int spikerow23 = 1;
            int spikecolm23 = 1;
            int spikeheight23 = 50;
            int spikewidth23 = 50;

            Rectangle[,] spikes23 = new Rectangle[spikeheight23, spikewidth23];
            for (int i = 0; i < spikerow23; i++)
            {
                for (int j = 0; j < spikecolm23; j++)
                {
                    spikes23[i, j] = new Rectangle(i * 50 + 4450, j * 0 + 400, 50, 50);
                }
            }
            for (int i = 0; i < spikerow23; i++)
            {
                for (int j = 0; j < spikecolm23; j++)
                {
                    if (spikes23[i, j].Width > 0)
                    {
                        Raylib.DrawTexture(enemy2, i + 3587, j - 130, Color.WHITE);
                    }
                }
            }
            //page6 bottom 1 spike level 3
            int spikerow24 = 1;
            int spikecolm24 = 1;
            int spikeheight24 = 50;
            int spikewidth24 = 50;

            Rectangle[,] spikes24 = new Rectangle[spikeheight24, spikewidth24];
            for (int i = 0; i < spikerow24; i++)
            {
                for (int j = 0; j < spikecolm24; j++)
                {
                    spikes24[i, j] = new Rectangle(i * 50 + 4550, j * 0 + 450, 50, 50);
                }
            }
            for (int i = 0; i < spikerow24; i++)
            {
                for (int j = 0; j < spikecolm24; j++)
                {
                    if (spikes24[i, j].Width > 0)
                    {
                        Raylib.DrawTexture(enemy3, i + 3650, j - 150, Color.WHITE);
                    }
                }
            }
            //page6 bottom 1 spike level 4
            int spikerow25 = 1;
            int spikecolm25 = 1;
            int spikeheight25 = 50;
            int spikewidth25 = 50;

            Rectangle[,] spikes25 = new Rectangle[spikeheight25, spikewidth25];
            for (int i = 0; i < spikerow25; i++)
            {
                for (int j = 0; j < spikecolm25; j++)
                {
                    spikes25[i, j] = new Rectangle(i * 50 + 4650, j * 0 + 400, 50, 50);
                }
            }
            for (int i = 0; i < spikerow25; i++)
            {
                for (int j = 0; j < spikecolm25; j++)
                {
                    if (spikes25[i, j].Width > 0)
                    {
                        Raylib.DrawTexture(enemy2, i + 3785, j - 130, Color.WHITE);
                    }
                }
            }
        }
        static void Background()
        {
            Raylib.DrawTexture(background, 0, 0, Color.RAYWHITE);
            Raylib.DrawTexture(background, -1400, 5, Color.RAYWHITE);
            Raylib.DrawTexture(background, 1600, 5, Color.RAYWHITE);
            Raylib.DrawTexture(background, 3180, 5, Color.RAYWHITE);
            Raylib.DrawTexture(background, 4780, 5, Color.RAYWHITE);
        }
    }
}

