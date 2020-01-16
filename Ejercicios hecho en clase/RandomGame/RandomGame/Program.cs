using System;
using System.Diagnostics;
using System.Threading;

namespace RandomGame
{
    class Program
    {

        public static Game CurrentGame;

        static Thread inputThread;
        
        
        static void Main(string[] args)
        {
            
            CurrentGame = new Game();
            
            CurrentGame.GameInit();

            inputThread = new Thread(Input);
            
            inputThread.Start();
            
            Console.Write(CurrentGame.ReadScores());
            

            //Iniciamos un while que se estara ejecutando hasta que el juego acabe esto pasa cuando el estado sea cambiado a Over
            while (CurrentGame.CurrentState != Game.eGameState.Over)
            {
                // Creamos un switch case y lo trabajamos con el enum creado en la clase Game
                switch (CurrentGame.CurrentState)
                {
                    case Game.eGameState.Starting :
                        Console.WriteLine("Digite un valor entre 1 y 1000: ");
                        CurrentGame.CurrentState = Game.eGameState.Playing;
                        break;
                    
                    
                    case Game.eGameState.Playing:
                        if (CurrentGame.LastTry == 0)
                        {
                            continue;
                        }
                        

                        switch (CurrentGame.CheckIfGuessed())
                        {
                            case Game.AttemptResult.Greater:
                                Console.WriteLine("El numero secreto es menor. ");
                                break;
                         
                            
                            case Game.AttemptResult.Lower:
                                Console.WriteLine("El numero secreto es mayor. ");
                                break;
                            
                            
                            default:
                                Console.WriteLine("Ha adivinado! ");
                                CurrentGame.CurrentState = Game.eGameState.Over;
                                break;
                        }

                        if (CurrentGame.CurrentState != Game.eGameState.Over)
                        {
                            Console.WriteLine("Digite otro valor");
                        }
                        

                        CurrentGame.LastTry = 0;
                        break;
                }

            }
            
            
            //inputThread.Abort();
            //inputThread.Join();
            
            CurrentGame.SaveState();
            
            Console.WriteLine($"Ha adivinado en {CurrentGame.Attempts} intentos.");
            Console.WriteLine($"Ha tomado {CurrentGame.TimeSpent.TotalSeconds} segundos.");
            Console.WriteLine("Gracias por jugar");
            //Console.ReadKey();
        }

        static void Input()
        {
            int currentValue = 0;
            
            while(CurrentGame.CurrentState != Game.eGameState.Over)
            {
                currentValue = Convert.ToInt32(Console.ReadLine());
                CurrentGame.LastTry = currentValue;

            }
        }
        
    }
}