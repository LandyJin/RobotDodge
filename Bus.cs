using System;
using SplashKitSDK;
public class Bus : Barrier
{
    public Bus(Window gameWindow, Player player) : base ( gameWindow, player )
    {
        X = gameWindow.Width;
        Y = gameWindow.Height - 110;
        MainColor = Color.RandomRGB(200);
        const int SPEED = 3;

        // Get a Point for the Robot
        Point2D fromPt = new Point2D()
        {
            X = X, Y = Y
        };

        //Get a Point for the Player
        Point2D toPt = new Point2D()
        {
            X = 0, Y = Y
        };

        //Calculate the direction to head.
        Vector2D dir;
        dir = SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPt, toPt));

        //Set the speed and assign to the Velocity
        Velocity = SplashKit.VectorMultiply(dir, SPEED);
    }
    public override void Draw(Window gameWindow)
    {

        double leftX, rightX, tyreY, mouthY;
        leftX = X+ 20;
        rightX = X + 80;
        tyreY = Y + 40;
        mouthY = Y + 30;
        gameWindow.FillRectangle(Color.Gray, X, Y, 100, 40);
        gameWindow.FillRectangle(Color.White, X+10, Y+10, 10, 10);
        gameWindow.FillRectangle(Color.White, X+30, Y+10, 10, 10);
        gameWindow.FillRectangle(Color.White, X+50, Y+10, 10, 10);
        gameWindow.FillRectangle(Color.White, X+70, Y+10, 10, 10);
        gameWindow.FillCircle(MainColor,leftX, tyreY, 10);
        gameWindow.FillCircle(MainColor,rightX, tyreY, 10);

        

    }
}