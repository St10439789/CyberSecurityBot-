using System.Media;
using System;
using System.IO;

namespace CyberSecurityBot_
{

    //import the system.media

    public class SoundManager
    {

        //constructor 
        public void PlayGreeting()
        {

            // now get where the project is 
            string project_location = AppDomain.CurrentDomain.BaseDirectory;

            //check if it is getting te Directory 
           // Console.WriteLine(project_location);

            //now lets replace the bin\debug\ so it can get the audio
            string update_path = project_location.Replace("bin\\Debug\\","");
            //lets combine the wav name as sound.wav the upadtw path 
            string full_path = Path.Combine(update_path, "sound.wav");

            // now lets pass it to the method play_wav
            Play_wav(full_path);

        }//end of constuctor 

        //method to play the sound 
        private void Play_wav(string full_path)
        {
            //try and catch 
            try
            {
                // or play the sound 
                using (SoundPlayer player = new SoundPlayer (full_path) )
                {
                    // to play the sound till the end use this 
                    player.PlaySync();
                }// end of usinng 

            }  catch ( Exception error)
            {

                //then show the message 
                Console.WriteLine(error.Message);

            }// end of try and catch
        }

    }//end of class

} //end of namespace 