using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jane
{
    class writeModeDictation
    {
        public writeModeDictation()
        {
            writeMode();
        }

        private void writeMode()
        {
            DictationGrammar dG = new DictationGrammar();
            try
            {
                testRecog.RequestRecognizerUpdate();
                testRecog.LoadGrammar(dG);
                testRecog.SpeechRecognized += writeModeSyn;
                testRecog.SetInputToDefaultAudioDevice();
                testRecog.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch
            {
                return;
            }
        }


        private void writeModeSyn(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text.ToString())
            {
                case "close mode":
                    //p.sRecognizeGetSet.RecognizeAsync(RecognizeMode.Multiple);
                    testRecog.RecognizeAsyncStop();
                    read("writing mode off");
                    break;
                case "jane tabulate":
                    textPrint("{TAB}");
                    break;
                case "jane delete":
                    textPrint("{DELETE}");
                    break;
                case "jane left":
                    textPrint("{LEFT}");
                    break;
                case "jane right":
                    textPrint("{RIGHT}");
                    break;
                case "jane up":
                    textPrint("{UP}");
                    break;
                case "jane down":
                    textPrint("{DOWN}");
                    break;
                case "jane space":
                    textPrint(" ");
                    break;
                case "jane question mark":
                    textPrint("?");
                    break;
                case "jane enter":
                    textPrint("{ENTER}");
                    break;
                case "jane backspace":
                    textPrint("{bs}");
                    break;
                case "jane down line":
                    textPrint("+{ENTER}");
                    break;
                case "jane point":
                    textPrint(".");
                    break;
                default:
                    textPrint(e.Result.Text.ToString() + " ");
                    break;
            }
        }


        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);
        private void textPrint(String text)
        {
            SendKeys.SendWait(text);
        }


        private void read(string s)
        {
            pBuilder.ClearContent();
            pBuilder.AppendText(s);
            sSynth.Speak(pBuilder);
        }


        private SpeechSynthesizer sSynth = new SpeechSynthesizer();
        private PromptBuilder pBuilder = new PromptBuilder();
        private SpeechRecognitionEngine testRecog = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        private panel p = new panel();
    }
}
