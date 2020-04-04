using System;
using System.Threading;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using NAudio.Wave;

namespace Morze
{
    public class ABCMorze : INotifyPropertyChanged
    {
        private UInt32 frequency;
        public UInt32 Frequency
        {
            get => frequency;
            set
            {
                frequency = value;
                OnPropertyChanged("Frequency");
            }
        }
        private int speed;
        public int Speed
        {
            get => speed;
            set
            {
                speed = value;
                OnPropertyChanged("Speed");
            }
        }
        private UInt32 noise;
        public UInt32 Noise
        {
            get => noise;
            set
            {
                noise = value;
                OnPropertyChanged("Noise");
            }
        }
        private string text; 
        public string Text
        {
            get => text;
            set
            {
                text = value;
                OnPropertyChanged("DecodingText");
                OnPropertyChanged("Text");
            }
        }
        private string decodingText;//перекодированный текст
        public string DecodingText
        {
            get
            {
                decodingText = decoding();
                return decodingText;
            }
            set
            { 
                decodingText = decoding();
                OnPropertyChanged("DecodingText");
            }
        }
        public ABCMorze()
        {
            Frequency = 1000;
            Speed = 60;
            Noise = 0;
            Text = "";
        }

        public ABCMorze(UInt32 _Frequency, int _Speed, UInt32 _Noise, string _text)
        {
            Frequency = _Frequency;
            Speed = _Speed;
            Noise = _Noise;
            Text = _text;
        }

        public async Task Reproduce()
        { 
        }

        private string decoding()
        {
            string result = "";
            text = text.ToLower();
            if (text.Length != 0)
            {
                foreach(char ch in text)
                {
                    switch (ch)
                    {
                        case 'а':
                            result += "01";
                            break;
                        case 'б':
                            result += "1000";
                            break;
                        case 'в':
                            result += "011";
                            break;
                        case 'г':
                            result += "110";
                            break;
                        case 'д':
                            result += "100";
                            break;
                        case 'е':
                            result += "0";
                            break;
                        case 'ё':
                            result += "0";
                            break;
                        case 'ж':
                            result += "0001";
                            break;
                        case 'з':
                            result += "1100";
                            break;
                        case 'и':
                            result += "00";
                            break;
                        case 'й':
                            result += "0111";
                            break;
                        case 'к':
                            result += "101";
                            break;
                        case 'л':
                            result += "0100";
                            break;
                        case 'м':
                            result += "11";
                            break;
                        case 'н':
                            result += "10";
                            break;
                        case 'о':
                            result += "111";
                            break;
                        case 'п':
                            result += "0110";
                            break;
                        case 'р':
                            result += "010";
                            break;
                        case 'с':
                            result += "000";
                            break;
                        case 'т':
                            result += "1";
                            break;
                        case 'у':
                            result += "001";
                            break;
                        case 'ф':
                            result += "0010";
                            break;
                        case 'х':
                            result += "0000";
                            break;
                        case 'ц':
                            result += "1010";
                            break;
                        case 'ч':
                            result += "1110";
                            break;
                        case 'ш':
                            result += "1111";
                            break;
                        case 'щ':
                            result += "1101";
                            break;
                        case 'ь':
                            result += "1001";
                            break;
                        case 'ы':
                            result += "1011";
                            break;
                        case 'ъ':
                            result += "11011";
                            break;
                        case 'э':
                            result += "00100";
                            break;
                        case 'ю':
                            result += "0011";
                            break;
                        case 'я':
                            result += "0101";
                            break;
                        case '1':
                            result += "01111";
                            break;
                        case '2':
                            result += "00111";
                            break;
                        case '3':
                            result += "00011";
                            break;
                        case '4':
                            result += "00001";
                            break;
                        case '5':
                            result += "00000";
                            break;
                        case '6':
                            result += "10000";
                            break;
                        case '7':
                            result += "11000";
                            break;
                        case '8':
                            result += "11100";
                            break;
                        case '9':
                            result += "11110";
                            break;
                        case '0':
                            result += "11111";
                            break;
                        case ' ':
                            result += "3";
                            break;
                        default:
                            result += "";
                            break;
                    }
                    result += "2";
                }
            }
            return result;
        }

        public void Test()
        {
            WaveOut waveOut;
            int speeds = 30 + (150 - Speed);
            var sineWaveProvider = new SineWaveProvider32(); 
            sineWaveProvider.SetWaveFormat(16000, 1);  
            sineWaveProvider.Frequency = Frequency;             //задали частоту звука
            sineWaveProvider.Amplitude = 1f;                    //амплитуда
            waveOut = new WaveOut();
            waveOut.Init(sineWaveProvider); 

            foreach (char ch in decodingText)
            { 
                switch (ch)
                {
                    case '0':
                        waveOut.Play();
                        Thread.Sleep(speeds);
                        waveOut.Stop();
                        Thread.Sleep(speeds);
                        break;
                    case '1':
                        waveOut.Play();
                        Thread.Sleep(speeds * 3);
                        waveOut.Stop();
                        Thread.Sleep(speeds);
                        break;
                    case '2': 
                        Thread.Sleep(speeds * 2);
                        break;
                    case '3':
                        Thread.Sleep(speeds * 6);
                        break;
                }
            }
        } 
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}
