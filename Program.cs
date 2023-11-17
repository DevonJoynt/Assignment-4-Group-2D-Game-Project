using Raylib_cs;
using System.Diagnostics;
using System.Numerics;


namespace Assignment_4_Group_2D_Game_Project
{
    
    

    internal class Program
    {
        static int WindowWidth = 1200;
        static int WindowHeight = 800;
        static bool Polarity{ get; set; } = true;
        static int PolarityPressed;
        static Vector2 PlayerPosition { get; set; } = new Vector2(WindowWidth/2,WindowHeight/2);
        static Vector2 PlayerSize = new Vector2(50,50);

       
        static void Main(string[] args)
        {
            // Create a window to draw to. The arguments define width and height
            Raylib.InitWindow(WindowWidth, WindowHeight, "Assignment-2D-Game-Project");
            
            Raylib.SetTargetFPS(60);
            PolarityPressed = 0;

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
            Vector2 Move = new Vector2(-5, 0);
            Vector2 GravityBasic = new Vector2(0, 10);

            



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
                    Polarity= false;
                    PolarityPressed = 0;
                }

            }
            Console.WriteLine($"{PolarityPressed}");

            if (Polarity == true)
            {
                PlayerPosition = PlayerPosition - GravityBasic;
            }
            else
            {
                PlayerPosition = PlayerPosition + GravityBasic;
            }



        }

        static void Update() // Your game code run each frame here
        {
            
        }
    }
}