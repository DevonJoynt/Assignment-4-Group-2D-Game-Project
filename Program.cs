using Raylib_cs;
using System.Diagnostics;
using System.Numerics;


namespace Assignment_4_Group_2D_Game_Project
{



    internal class Program
    {
        static int WindowWidth = 1200;
        static int WindowHeight = 800;
        static int FloorBrickHeight = 700;
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
<<<<<<< Updated upstream
            {
                // Enable drawing to the canvas (window)
                Raylib.BeginDrawing();
                // Clear the canvas with one color
                Raylib.ClearBackground(Color.WHITE);

                
                
=======
            { 
                // Camera Dimension
                Vector2 CameraOffset = new Vector2(WindowWidth / 2, WindowHeight / 2);
                Vector2 CameraYLock = new Vector2(PlayerPosition.X, WindowHeight / 2);
                Camera2D Camera = new Camera2D(CameraOffset, CameraYLock, 0, 1);

                // Enable drawing to the canvas (window)
                Raylib.BeginDrawing();

                // Draw Camera
                Raylib.BeginMode2D(Camera);

                // Clear the canvas with one color
                Raylib.ClearBackground(Color.WHITE);



>>>>>>> Stashed changes
                Update();
                Player();
                Floor();


<<<<<<< Updated upstream
=======
                Console.WriteLine($"{PlayerPosition}");

                Raylib.EndMode2D();
>>>>>>> Stashed changes
                Raylib.EndDrawing();  // Stop drawing to the canvas, begin displaying the frame
            }

            Raylib.CloseWindow(); // Close the window
        }

        static void Setup() // Your one-time setup code here
        {

<<<<<<< Updated upstream
=======
        }


>>>>>>> Stashed changes
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
                PlayerPosition = PlayerPosition - Move;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D) || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                PlayerPosition = PlayerPosition + Move;
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
            if (PlayerPosition.X - PlayerWidth < 0 || PlayerPosition.X + PlayerWidth > WindowWidth)
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
                PlayerPosition = PlayerPosition - GravityBasic;
            }
            else
            {
                PlayerPosition = PlayerPosition + GravityBasic;
            }



        }
       
        static void Floor()
        {
            // Brick Size
            int brickheight = 80;
            int brickwidth = 80;
            Rectangle FloorBrick = new Rectangle(0, 750, 1200, 50);
            Raylib.DrawRectangleRec(FloorBrick, Color.BLUE);
            Raylib.DrawRectangleLinesEx(FloorBrick, 2, Color.ORANGE);
        }

        static void Update() // Your game code run each frame here
        {
            
        }
    }
}
