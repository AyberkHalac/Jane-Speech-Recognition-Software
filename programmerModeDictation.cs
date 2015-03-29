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
    class programmerModeDictation
    {

        public programmerModeDictation()
        {
            programmerMode();
        }


        private void programmerMode()
        {
            Choices sList = new Choices();
            sList.Add(new String[] { 
                "double","integer","float","string","char","object",
                "new double","new integer","new float","new string","new char","new object",
                "java","C","C sharp","python",
                "for loop","if loop",
                "system.out.print",
                "page up", "page down","delete", 
                "backspace", "enter", "com", "dot", 
                "question mark","tabulate", 
                "space", "down line",
                "left","right","down","up","close mode" });
            Grammar gr = new Grammar(sList);
            
            try
            {
                testRecog.RequestRecognizerUpdate();
                testRecog.LoadGrammar(gr);
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
                    testRecog.RecognizeAsyncStop();
                    read("programmer mode off");
                    p.sRecognizeGetSet.RecognizeAsync(RecognizeMode.Multiple);
                    break;
                case "double":
                    textPrint("double");
                    break;
                case "integer":
                    textPrint("int");
                    break;
                case "string":
                    textPrint("string");
                    break;
                case "float":
                    textPrint("float");
                    break;
                case "object":
                    textPrint("object");
                    break;
                case "char":
                    textPrint("char");
                    break;
                case "new double":
                    String d = doubleCounter.ToString();
                    textPrint("Double d_"+d+" +0 0+,");
                    ++doubleCounter;
                    break;
                case "new integer":
                    String i = integerCounter.ToString();
                    textPrint("int i_" + i + " +0 0+,");
                    ++integerCounter;
                    break;
                case "new float":
                    String f = floatCounter.ToString();
                    textPrint("float f_"+f+" +0 0+,");
                    ++floatCounter;
                    break;
                case "new string":
                    String s = stringCounter.ToString();
                    textPrint("String s_" + s + " +0 \"\"+,");
                    ++stringCounter;
                    break;
                case "new char":
                    String c = charCounter.ToString();
                    textPrint("char c_"+c+"+0 +2+2+,");
                    ++charCounter;
                    break;
                case "new object":
                    String o = objectCounter.ToString();
                    textPrint("object o_" + o + " +0 null+,");
                    ++objectCounter;
                    break;
                case "system.out.print":
                    textPrint("system.out.println+8+9+,");
                    break;
                case "tabulate":
                    textPrint("{TAB}");
                    break;
                case "delete":
                    textPrint("{DELETE}");
                    break;
                case "left":
                    textPrint("{LEFT}");
                    break;
                case "right":
                    textPrint("{RIGHT}");
                    break;
                case "up":
                    textPrint("{UP}");
                    break;
                case "down":
                    textPrint("{DOWN}");
                    break;
                case "key" :
                    textPrint("^{BREAK}");
                    break;
                case "for loop":
                    textPrint("for+8int i=0; i< ; i{ADD}{ADD}+9^%7{ENTER}^%0");
                    break;
                case "if loop":
                    textPrint("if+8+9^%7{ENTER}^%0");
                    break;
                case "space":
                    textPrint(" ");
                    break;
                case "question mark":
                    textPrint("?");
                    break;
                case "dot":
                    textPrint(".");
                    break;
                case "com":
                    textPrint("com");
                    break;
                case "enter":
                    textPrint("{ENTER}");
                    break;
                case "backspace":
                    textPrint("{bs}");
                    break;
                case "page down":
                    textPrint("{PGDN}");
                    break;
                case "page up":
                    textPrint("{PGUP}");
                    break;
                case "down line":
                    textPrint("+{ENTER}");
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


        private byte stringCounter = 0;
        private byte doubleCounter = 0;
        private byte charCounter = 0;
        private byte integerCounter = 0;
        private byte objectCounter = 0;
        private byte floatCounter = 0;
        private SpeechSynthesizer sSynth = new SpeechSynthesizer();
        private PromptBuilder pBuilder = new PromptBuilder();
        private SpeechRecognitionEngine testRecog = new SpeechRecognitionEngine();
        private panel p = new panel();
        
    }
}
