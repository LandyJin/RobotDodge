using System;
using SplashKitSDK;
public class Box : Barrier
{
    public Box(Window gameWindow, Player player) : base ( gameWindow, player )
    {
        X = -10;
        Y = gameWindow.Height - 240;
        MainColor = Color.RandomRGB(200);
        const int SPEED = 3;

        Point2D fromPt = new Point2D()
        {
            X = X, Y = Y
        };

        Point2D toPt = new Point2D()
        {
            X = gameWindow.Width, Y = Y
        };

        Vector2D dir;
        dir = SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPt, toPt));

        Velocity = SplashKit.VectorMultiply(dir, SPEED);
    }
    public override void Draw(Window gameWindow)
    {

        double leftX, rightX, eyeY, mouthY;
        leftX = X + 12;
        rightX = X + 27;
        eyeY = Y + 10;
        mouthY = Y + 30;
        gameWindow.FillRectangle(Color.Green, X, Y, 50, 50);

        

    }
}