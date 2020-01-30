using System;
using Terminal.Gui;

namespace Bingo
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.Init();
            var top = Application.Top;

            var win = new Window("Bingo")
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            var menu = new MenuBar(new MenuBarItem[]
            {
                new MenuBarItem("_Game", new MenuItem[]
                {
                    new MenuItem("_New","Creates a new Bingo Board", NewGame),
                    new MenuItem("_Exit","Exit the app", () => { top.Running = false; })
                })
            });
            top.Add(win);
            top.Add(menu);
            var label = new Label("BINGO");
            var button = new Button("10")
            {
                X = label.X,
                Y = Pos.Bottom(label) + 2
            };
            win.Add(label,button);
            Application.Run();
        }

        private static void NewGame()
        {
            throw new NotImplementedException();
        }
    }
}
