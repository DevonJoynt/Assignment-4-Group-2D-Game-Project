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
        static Texture2D enemy1;
        static Texture2D enemy2;
        static Texture2D enemy3;
        static Texture2D enemy4;

        static void Main(string[] args)
        {
            // Create a window to draw to. The arguments define width and height
            Raylib.InitWindow(1200, 800, title);
            // Set the target frames-per-second (FPS)
            Raylib.SetTargetFPS(60);

            // Setup your game. This is a function YOU define.
            Setup();
            Setup2();
            Setup3();
            Setup4();

            // Loop so long as window should not close
            while (!Raylib.WindowShouldClose())
            {
                // Enable drawing to the canvas (window)
                Raylib.BeginDrawing();
                // Clear the canvas with one color
                Raylib.ClearBackground(Color.WHITE);

                // Your game code here. This is a function YOU define.
                Update();
                Update2();
                Update3();
                Update4();

                // Stop drawing to the canvas, begin displaying the frame
                Raylib.EndDrawing();
            }
            // Close the window
            Raylib.CloseWindow();
        }

        // ENEMY NUMBER ONE (REGULAR ENEMY TYPE)
        static void Setup()
        {
            enemy1 = LoadTexture2D("Enemy Design 1 - Jake deVos.png");

        }

        static void Update()
        {
            Raylib.DrawTexture(enemy1, -600, -200, Color.WHITE);
        }

        static Texture2D LoadTexture2D(string filename)
        {
            Image image = Raylib.LoadImage(filename);
            Texture2D texture = Raylib.LoadTextureFromImage(image);
            return texture;
        }
    

    

        // ENEMY NUMBER TWO (SPIKY HEAD)
        static void Setup2()
        {
            enemy2 = LoadTexture2D("Enemy Design 2 - Jake deVos.png");

        }

        static void Update2()
        {
            Raylib.DrawTexture(enemy3, -400, -50, Color.WHITE);
        }

        // ENEMY NUMBER TWO (SPIKY BOTTOM)
        static void Setup3()
        {
            enemy3 = LoadTexture2D("Enemy Design 2 (Opposite) - Jake deVos.png");

        }

        static void Update3()
        {
            Raylib.DrawTexture(enemy2, -500, -50, Color.WHITE);
        }

        // ENEMY NUMBER 3 (8 SPIKES)
        static void Setup4()
        {
            enemy4 = LoadTexture2D("Enemy Design 3 - Jake deVos.png");

        }

        static void Update4()
        {
            Raylib.DrawTexture(enemy4, -250, -50, Color.WHITE);
        }



    }
}









