using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VangDeVolger
{
    class SoundPlayer
    {
        public static void Player(String path, Boolean win)
        {
            //make a new player for the sounds
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();

            //use the path that has been given
            player.SoundLocation = path;
            //play the sound on a loop
            player.PlayLooping();

            if (win)
                player.Stop();
        }

        //start effect player
        public static void Effect(String path)
        {
            //create new mediaplayer
            var player2 = new System.Windows.Media.MediaPlayer();
            //open the path
            player2.Open(new Uri(path, UriKind.Relative));
            //play the sound
            player2.Play();
        }
    }
}
