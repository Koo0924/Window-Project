using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;


namespace MP3_Player
{
    class MP3Player
    {
        public bool loop { get; set; }
        public bool isOpened = false;

        private StringBuilder returnData;

        [DllImport("winmm.dll")]
        private static extern long mciSendString
            (string _command, StringBuilder _returnData, int _returnLength, IntPtr _hwndCallBack);

        public MP3Player()
        {
            returnData = new StringBuilder(128);
        }

        public void Open(string fileName)
        {
            if (isOpened)
            {
                Close();
            }

            string command = "open \"" + fileName + "\" type mpegviedeo alias MediaFile";
            mciSendString(command, null, 0, IntPtr.Zero);

            isOpened = true;
        }

        public void Close()
        {
            if (isOpened)
            {
                string command = "close MediaFile";
                mciSendString(command, null, 0, IntPtr.Zero);
                loop = false;
                isOpened = false;
            }
        }
        public void Play()
        {
            if (isOpened)
            {
                string command = "play MediaFile";

                if (loop)
                    command += "REPEAT";
                mciSendString(command, null, 0, IntPtr.Zero);
            }
        }
        public void Pause()
        {
            if (isOpened)
            {
                string command = "pause MediaFile";
                mciSendString(command, null, 0, IntPtr.Zero);
            }
        }

        public void Stop()
        {
            if (isOpened) Seek(0);
        }

        public void Seek(int time)
        {
            string command = "seek MediaFile to" + time.ToString();
            mciSendString(command, null, 0, IntPtr.Zero);
        }

        public string GetStatus()
        {
            returnData.Clear();

            string command = "status MediaFile mode";
            mciSendString(command, returnData, returnData.Capacity, IntPtr.Zero);

            return returnData.ToString();
        }

        public int GetLength()
        {
            returnData.Clear();

            if (isOpened)
            {
                string command = "status MediaFile length";
                mciSendString(command, returnData, returnData.Capacity, IntPtr.Zero);

                int length = int.Parse(returnData.ToString());

                return length;
            }
            else
                return 0;
        }

        public int GetPosition()
        {
            if (isOpened)
            {
                string command = "status MediaFile position";
                mciSendString(command, returnData, returnData.Capacity, IntPtr.Zero);

                int position = int.Parse(returnData.ToString());

                return position;
            }
            else
                return 0;
        }
    }
}

