using Raylib_cs;
using System.Numerics;

namespace Rectangle_Button
{
    internal class Button
    {
        int positionX;
        int positionY;
        int width;
        int height;
        bool isOn;
        Color selectColor = color;
        private static Color color;

        public Button(int posX, int posY, int w, int h, Color color)
        {
            positionX = posX;
            positionY = posY;
            width = w;
            height = h;
            selectColor = color;

        }

        public bool ButtonPressed()
        {
            bool buttonPressed = IsInsideButton() && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT);
            return buttonPressed;
        }

        public bool IsInsideButton()
        {
            Vector2 mousePosition = Raylib.GetMousePosition();

            int leftEdge = positionX;
            int rightEdge = positionX + width;
            int topEdge = positionY;
            int bottomEdge = positionY + height;

            bool isInsideLeft = mousePosition.X >= leftEdge;
            bool isInsideRight = mousePosition.X <= rightEdge;
            bool isInsideTop = mousePosition.Y >= topEdge;
            bool inInsideBottom = mousePosition.Y <= bottomEdge;

            bool isInsideButton = isInsideLeft && isInsideRight && isInsideTop && inInsideBottom;
            return isInsideButton;
        }


        public void CheckIsPressed()
        {
            if (ButtonPressed())
            {
                // Toggle state of button
                if (isOn)
                {
                    isOn = false;
                }
                else // isOff
                {
                    isOn = true;
                }
            }
        }

        public void Draw()
        {
            if (isOn)
            {
                Raylib.DrawRectangle(positionX, positionY, width, height, selectColor);
            }
            else // isOff
            {
                // Hovering
                if (IsInsideButton())
                {
                    Raylib.DrawRectangle(positionX, positionY, width, height, Color.DARKGRAY);
                    Raylib.DrawRectangleLines(positionX, positionY, width, height, Color.YELLOW);
                }
                // Not hovering
                else
                {
                    Raylib.DrawRectangle(positionX, positionY, width, height, Color.GRAY);
                    Raylib.DrawRectangleLines(positionX, positionY, width, height, Color.YELLOW);
                }
            }
        }

    }
}
