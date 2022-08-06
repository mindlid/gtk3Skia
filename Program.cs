using System;
using Gtk;
using SkiaSharp;
using SkiaSharp.Views.Gtk;

namespace gtk3Skia
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.Init();

            var app = new Application("org.gtk3Skia.gtk3Skia", GLib.ApplicationFlags.None);
            app.Register(GLib.Cancellable.Current);

            var win = new Window(WindowType.Toplevel)
            {
                Title = "SkiaSharp on .NET Core with GTK#",
                WindowPosition = WindowPosition.CenterOnParent,
                DefaultWidth = 640,
                DefaultHeight = 480,
            };

            win.DeleteEvent += (sender, a) =>
            {
                Application.Quit();
                a.RetVal = true;
            };

            SKDrawingArea skiaDraw = new SKDrawingArea();
            skiaDraw.PaintSurface += (sender, e) =>
            {
                var canvas = e.Surface.Canvas;
                var info = e.Info;

                canvas.Clear(SKColors.Azure);

                var paint = new SKPaint
                {
                    Color = SKColors.Orange,
                    IsAntialias = true,
                    Style = SKPaintStyle.Fill,
                    TextAlign = SKTextAlign.Center,
                    TextSize = 32
                };

                canvas.DrawText(
                    "SkiaSharp on .NET Core with GTK#",
                    info.Width / 2,
                    (info.Height + paint.TextSize) / 2,
                    paint
                );
            };

            win.Add(skiaDraw);
            win.Child.ShowAll();
            win.Show();
            Application.Run();
        }
    }
}
