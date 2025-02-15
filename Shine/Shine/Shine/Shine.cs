
using Shine.Engine;

Window shineWindow = new Window(1280, 720, "Shine v.1.0", SFML.Window.Keyboard.Key.Escape);
shineWindow.Init();

while(shineWindow.Running)
{
    shineWindow.Update();
}

shineWindow.End();