using Raylib_cs;
using System.Numerics;


namespace Assignment_4_Group_2D_Game_Project
{


    internal class Program
    {
        
        static string title = "Game Title";

        static void Main(string[] args)
        {
            // Create a window to draw to. The arguments define width and height
            Raylib.InitWindow(800, 600, title);
            
            Raylib.SetTargetFPS(60);

            
            Setup();

            
            while (!Raylib.WindowShouldClose())
            {
                // Enable drawing to the canvas (window)
                Raylib.BeginDrawing();
                // Clear the canvas with one color
                Raylib.ClearBackground(Color.WHITE);

                
                Update();

               
                Raylib.EndDrawing();  // Stop drawing to the canvas, begin displaying the frame
            }
            
            Raylib.CloseWindow(); // Close the window
        }

        static void Setup() // Your one-time setup code here
        {
            
        }

        static void Update() // Your game code run each frame here
        {
            
        }
    }
}