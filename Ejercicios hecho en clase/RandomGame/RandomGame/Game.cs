using System;
using System.IO;

namespace RandomGame
{
    public class Game
    {

        #region "Enums"

        public enum eGameState
        {
            Starting,
            Playing,
            Over    
        }
        
        
        public enum AttemptResult
        {
            Guessed,
            Lower,
            Greater
        }
        
        #endregion
        
        
        #region "Attributes"
        
        const int MIN = 1, MAX = 1001;
        
        const string DEFAULTPATH = "score.txt";

        public int SecretNumber { get; set; }

        public eGameState CurrentState { get; set; }

        public int LastTry { get; set; }

        public int Attempts { get; set; }

        public DateTime StartTime { get; set; }
        
        public DateTime EndTime { get; set; }
        
        public TimeSpan TimeSpent
        {
            get { return EndTime.Subtract(StartTime); }
        }

        public String ScorePath { get; set; }

        #endregion

        
        #region "Behaviours"

        public void GameInit()
        {
            ScorePath = DEFAULTPATH;

            SecretNumber = GenerateNumber(MIN,MAX);

            CurrentState = eGameState.Starting;

            Attempts = 0;
            
            StartTime = DateTime.Now;
        }

        private int GenerateNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        
        public AttemptResult CheckIfGuessed()
        {
            Attempts++;
            
            if (LastTry == SecretNumber)
            {
                EndTime = DateTime.Now;
                return AttemptResult.Guessed;
            }
            

            if (LastTry > SecretNumber)
            {
                return AttemptResult.Greater;
            }
            

            else
            {
                return AttemptResult.Lower;
            }
            
        }
        
        public void SaveState()
        {
            /* Forma complicada de guardar archivos en c#
             
             using (FileStream fstream = File.Open(ScorePath, FileMode.Append))
            {
                UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
                unicodeEncoding.GetBytes($"Tiempo: {TimeSpent.TotalSeconds} - Intentos: {Attempts}");
     
                fstream.Write(Buffer,0,Buffer.Length);
            }*/
            

            //forma mas conveniente de guardar archivos en c#
            var streamWriter = File.AppendText(ScorePath);
            
            streamWriter.Write($"Tiempo: {TimeSpent.TotalSeconds} - Intentos: {Attempts} \n");
            
            streamWriter.Flush();
            streamWriter.Close();
        }
        
        
        //Funcion que retorna el texto que hay en un archivo
        public string ReadScores()
        {

            return File.ReadAllText(ScorePath);
        }

        #endregion
        
    }
}