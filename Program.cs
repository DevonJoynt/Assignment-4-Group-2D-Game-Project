using Raylib_cs;
using System;
using System.Numerics;
//using static Raylib_cs.Raylib;

namespace Enemy_Animation_Jake_deVos


{
    internal class Program
    {
        // If you need variables in the Program class (outside functions), you must mark them as static
        static string title = "Enemy 1";
        static Texture2D enemy;

        static void Main(string[] args)
        {
            // Create a window to draw to. The arguments define width and height
            Raylib.InitWindow(1200, 800, title);
            // Set the target frames-per-second (FPS)
            Raylib.SetTargetFPS(60);

            // Setup your game. This is a function YOU define.
            Setup();

            // Loop so long as window should not close
            while (!Raylib.WindowShouldClose())
            {
                // Enable drawing to the canvas (window)
                Raylib.BeginDrawing();
                // Clear the canvas with one color
                Raylib.ClearBackground(Color.WHITE);

                // Your game code here. This is a function YOU define.
                Update();

                // Stop drawing to the canvas, begin displaying the frame
                Raylib.EndDrawing();
            }
            // Close the window
            Raylib.CloseWindow();
        }

        static void Setup()
        {
            enemy = LoadTexture2D("Enemy Design 1 - Jake deVos");
         
        }

        static void Update()
        {
            Raylib.DrawTexture(enemy, -600, -400, Color.WHITE);
        }

        static Texture2D LoadTexture2D(string filename)
        {
            Image image = Raylib.LoadImage("Enemy Design 1 - Jake deVos.png");
            Texture2D texture = Raylib.LoadTextureFromImage(image);
            return texture;
        }
    }


}







