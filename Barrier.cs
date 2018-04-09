using System;
using SplashKitSDK;
public abstract class Barrier
{

    public double X {get; set;}
    public double Y {get; set;}
    public Color MainColor{get; set;}
    public Vector2D Velocity {get; set;}


    public int Width
    {
        get { return 50;}
    }

    public int Height
    {
        get { return 50;}
    }

    public Circle CollisionCircle
    {

        get
        {
            return SplashKit.CircleAt(X + Width/2, Y + Height/2 ,20);
        }
    }

    public Barrier(Window gameWindow, Player player)
    {
        
    }
    public void Update()
    {

        X += Velocity.X;
        Y += Velocity.Y;

    }
    public abstract void Draw(Window window);
    public bool IsOffscreen(Window screen)
    {

        if(X < -Width || X > screen.Width || Y < -Height || Y> screen.Height) return true;
        
        return false;
    }
}