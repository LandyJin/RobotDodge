using System;
using SplashKitSDK;

public class Player
{

    private Bitmap _PlayerBitmap;
    private Bitmap _PlayerLivesBitmap;
    private int _lives = 5;
    public double X {get; set;}
    public double Y {get; set;}
    public bool Quit{get; private set;}
    public Player(Window gameWindow)
    {
        _PlayerBitmap = new Bitmap("Player", "Player.png");
        _PlayerLivesBitmap = new Bitmap("PlayerLives","heart.png");
        Quit = false;
        X = (gameWindow.Width - _PlayerBitmap.Width) / 2;
        Y = gameWindow.Height - _PlayerBitmap.Height;
    }

    public void Draw()
    {
        _PlayerBitmap.Draw(X, Y);

        for(int i=0;i<_lives;i++)
        {
            int livesX = 380 + 20 * i; 
            _PlayerLivesBitmap.Draw(livesX,0);
        }
    }

    public void HandleInput() 
    {
        const int SPEED = 50;

       

        if(SplashKit.KeyTyped(KeyCode.UpKey))
        {

            Y -= SPEED;
        }
        else if(SplashKit.KeyTyped(KeyCode.DownKey))
        {
            Y += SPEED;

        }

        else if(SplashKit.KeyTyped(KeyCode.LeftKey))
        {
            X -= SPEED;
        }
        else if (SplashKit.KeyTyped(KeyCode.RightKey))
        {
            X += SPEED;

        }
        

        if(SplashKit.KeyTyped(KeyCode.EscapeKey))
        {

            Quit = true;
        }

    }

    public void StayOnWindow(Window gameWindow)
    {
        const int GAP = 10;
        if( X < GAP)
        {
            X = GAP;
        }
        if(X  + _PlayerBitmap.Width > gameWindow.Width - GAP)
        {
            X = gameWindow.Width - GAP - _PlayerBitmap.Width;
        }

        if(Y < GAP)
        {
            Y = GAP;

        }
        if(Y  + _PlayerBitmap.Height > gameWindow.Height - GAP)
        {

            Y = gameWindow.Height - GAP - _PlayerBitmap.Height;
        }

    }

    public bool CollidedWith(Barrier barrier)
    {

        return _PlayerBitmap.CircleCollision(X, Y, barrier.CollisionCircle);
    }

    public void LoseLive()
    {
        _lives--;
    }
    public bool Win()
    {

        if(Y<=20)
        {

            return true;
        }
        else
        {

            return false;
        }
    }
    public bool Lose()
    {

        if(_lives<=0)
        {
            return true;
        }
        else{

            return false;
        }
    }
}