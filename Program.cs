using Raylib_cs;
using System.Numerics;


namespace Assignment_4_Group_2D_Game_Project
{
    
    

    internal class Program
    {
        static int WindowWidth = 1200;
        static int WindowHeight = 800;

        static Vector2 PlayerPosition { get; set; } = new Vector2();
        static Vector2 PlayerSize = new Vector2(50,50);

        static void Main(string[] args)
        {
            // Create a window to draw to. The arguments define width and height
            Raylib.InitWindow(WindowWidth, WindowHeight, "Assignment-2D-Game-Project");
            
            Raylib.SetTargetFPS(60);

            
            Setup();

            
            while (!Raylib.WindowShouldClose())
            {
                // Enable drawing to the canvas (window)
                Raylib.BeginDrawing();
                // Clear the canvas with one color
                Raylib.ClearBackground(Color.WHITE);

                //this is a code comment
                Console.WriteLine("Hello");
                Update();
                Player();


                Raylib.EndDrawing();  // Stop drawing to the canvas, begin displaying the frame
            }
            
            Raylib.CloseWindow(); // Close the window
        }

        static void Setup() // Your one-time setup code here
        {
            
        }


        static void Player()
        {
            Vector2 MoveLeft = new Vector2(-5, 0);
            Vector2 MoveRight = new Vector2(5, 0);
            Vector2 GravityBasic = new Vector2(0, 5);
            float PlayerBottomCorner = PlayerPosition.X + PlayerPosition.Y;

            //Draws Player
            Raylib.DrawRectangle((int)PlayerPosition.X, (int)PlayerPosition.Y, (int)PlayerSize.X, (int)PlayerSize.Y, Color.BLUE);
        
            // Controls

            if (Raylib.IsKeyDown(KeyboardKey.KEY_A) || Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                PlayerPosition = PlayerPosition + MoveLeft;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D) || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                PlayerPosition = PlayerPosition + MoveRight;
            }


            //Collison with Bottom (BASIC)
            if (PlayerBottomCorner < WindowHeight || PlayerBottomCorner == WindowHeight)
            {
                PlayerPosition = PlayerPosition + GravityBasic;
            }
           

        }

        static void Update() // Your game code run each frame here
        {
            
        }
    }
}