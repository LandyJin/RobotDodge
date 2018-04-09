using System;
using SplashKitSDK;

public class Program
{
    public static void Main(string[] args)
    {
        Window window;
        window = new Window("ScreenCross", 500, 500);
        ScreenCross screenCross = new ScreenCross(window);
        Timer myTimer = new Timer("My Timer");
        myTimer.Start();
        uint score = 10000; 
        while(!window.CloseRequested && screenCross.Quit == false && score>=1)
        {
            score = 10000 - myTimer.Ticks/1000;
            
            if(!screenCross.Win()&&!screenCross.Lose())
            {
                
                SplashKit.ProcessEvents();
                screenCross.HandleInput();
                screenCross.Update();
                screenCross.Draw();
                window.DrawText($"Scores: {score}",Color.Gray,380,20);
                window.Refresh(1000);

            }
            else if(screenCross.Lose())
            {
                myTimer.Pause();
                window.Clear(Color.White);
                window.DrawText($"Mission failed, your has lost all your lives",Color.Gray,100,380);
                window.Refresh(60);
                SplashKit.Delay(1000);
            }
            else{
                myTimer.Pause();
                window.Clear(Color.White);
                window.DrawText($"Mission completed, your scores is: {score}",Color.Gray,100,380);
                window.Refresh(60);
                SplashKit.Delay(1000);
                
                
            }
        }
        
        
    }
}
