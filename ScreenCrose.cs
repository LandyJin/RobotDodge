using System;
using SplashKitSDK;
using System.Collections.Generic;

public class ScreenCross
{
    private Player _Player;
    private Window _GameWindow;
    private List<Barrier> _Barriers = new List<Barrier>();
    public bool Quit
    {
        get
        {
            return _Player.Quit;
        }
    }

    public ScreenCross(Window gameWindow)
    {
        _GameWindow = gameWindow;
        _Player = new Player(_GameWindow);
    }
     public void HandleInput() 
    {
        _Player.HandleInput();
        _Player.StayOnWindow(_GameWindow);
    }
    public bool Win()
    {

        return _Player.Win();
    }
    public bool Lose()
    {
        return _Player.Lose();
    }
    public void Draw()
    {
        _GameWindow.Clear(Color.White);
        foreach (Barrier barrier in _Barriers)
        {
            barrier.Draw(_GameWindow);
        }
        // foreach(Bullet bullet in _Bullets){

        //     bullet.Draw(_GameWindow);
        // }
        _Player.Draw();
        _GameWindow.Refresh(60);
    }


    public void Update()
    {
        
        foreach(Barrier barrier in _Barriers)
        {

            barrier.Update();
        }
        if(SplashKit.Rnd()<0.05) _Barriers.Add(ReleaseBarrier());
        CheckCollisions();

    }

    public Barrier ReleaseBarrier()
    {
        if(SplashKit.Rnd()<0.33)
        {
            Box box = new Box(_GameWindow, _Player);
            return box;
        }
        else if(SplashKit.Rnd()<0.66)
        {
            Train train = new Train(_GameWindow, _Player);
            return train;
        }
        else
        {
            Bus bus = new Bus(_GameWindow, _Player);
            return bus;
        }
    }

    private void CheckCollisions()
    {

        List<Barrier> barriersToRemove = new List<Barrier>();

        foreach(Barrier barrier in _Barriers)
        {
            
            if(_Player.CollidedWith(barrier))
            {
                _Player.LoseLive();
                _Player.X  = (_GameWindow.Width - 37) / 2;
                _Player.Y = _GameWindow.Height - 50;
                

            }
            if(barrier.IsOffscreen(_GameWindow))
            {
                barriersToRemove.Add(barrier);
                
            }
        }
        foreach(Barrier barrier in barriersToRemove)
        {

            _Barriers.Remove(barrier);
        }
        
    }
}