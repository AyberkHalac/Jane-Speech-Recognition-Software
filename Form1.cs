using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace Jane
{   
    public partial class panel : Form
    {

        public SpeechRecognitionEngine sRecognizeGetSet
        {
            get
            {
                return sRecognize;
            }

        }


        public panel()
        {
            InitializeComponent();
        }


        private void read(string s)
        {
            pBuilder.ClearContent();
            pBuilder.AppendText(s);
            sSynth.Speak(pBuilder);
        }


        private void panel_Load(object sender, EventArgs e)
        {
            IO io = new IO();

            string[] list = new string[io.IoSCaller().Count];
            Choices sList = new Choices();
            for (int i = 0; i < io.IoSCaller().Count; i++)
            {
                list[i] = (io.IoSCaller()[i].ToString()).Substring(0, io.IoSCaller()[i].ToString().IndexOf('|'));
            }

            sList.Add(list);
            Grammar gr = new Grammar(new GrammarBuilder(sList));

            try
            {
                sRecognize.RequestRecognizerUpdate();
                sRecognize.LoadGrammar(gr);
                sRecognize.SpeechRecognized += sRecognize_SpeechRecognized;
                sRecognize.SetInputToDefaultAudioDevice();
                sRecognize.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch
            {
                return;
            }
        }

        [STAThread]
        private void sRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
         
            IO io = new IO();
            int c = 0;
            foreach (String s in io.IoSCaller())
            {
                if (e.Result.Text.ToString().Equals(s.Substring(0, io.IoSCaller()[c].ToString().IndexOf('|'))))
                {
                    int index2 = io.IoSCaller()[c].ToString().IndexOf('&');
                    int index1 = io.IoSCaller()[c].ToString().IndexOf('|');
                    String s1 = s.Substring((index1 + 1), (index2 - index1 - 1));
                    read(s1);
                    if (s.Substring(index2 + 1).Length != 0)
                    {
                        switch (e.Result.Text.ToString())
                        {
                            case "Go Hide":
                                Hide();
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
                            case "new tab":
                                textPrint("^t");
                                break;
                            case "page down":
                                textPrint("{PGDN}");
                                break;
                            case "page up":
                                textPrint("{PGUP}");
                                break;
                            case "close tab":
                                textPrint("^w");
                                break;
                            case "change tab":
                                textPrint("^{TAB}");
                                break;
                            case "switch window":
                                break;
                            case "close program":
                                Application.Exit();
                                Application.ExitThread();
                                break;
                            case "close chrome":
                                ProcWindow = "chrome";
                                StopWindow();
                                break;
                            case "close notepad":
                                ProcWindow = "notepad";
                                StopWindow();
                                break;
                            case "close internet explorer":
                                ProcWindow = "iexplore";
                                StopWindow();
                                break;
                            case "open commands":
                                Process.Start("notepad.exe", @s.Substring(index2 + 1));
                                break;
                            case "write mode":
                                sRecognize.RecognizeAsyncStop();
                                writeModeDictation wMD = new writeModeDictation();     
                                break;
                            case"programmer mode":
                                sRecognize.RecognizeAsyncStop();
                                programmerModeDictation pMD = new programmerModeDictation();
                                break;
                            case "search":
                                break;//             <============
                            case "what time is it":
                                DateTime now = DateTime.Now;
                                string time = now.GetDateTimeFormats('t')[0];
                                pBuilder.ClearContent();
                                pBuilder.AppendText(time);
                                sSynth.Speak(pBuilder);
                                break;
                            case "what day is it":
                                pBuilder.ClearContent();
                                pBuilder.AppendText(DateTime.Today.ToString("dddd"));
                                sSynth.Speak(pBuilder);
                                break;
                            case "whats the date":
                            case "whats todays date":
                                pBuilder.ClearContent();
                                pBuilder.AppendText(DateTime.Today.ToString("dd-MM-yyyy"));
                                sSynth.Speak(pBuilder);
                                break;

                            case "go away":
                                if (WindowState == FormWindowState.Normal || WindowState == FormWindowState.Maximized)
                                {
                                    WindowState = FormWindowState.Minimized;
                                }
                                break;
                            case "come back":
                                this.Visible = true;
                                if (WindowState == FormWindowState.Minimized)
                                {
                                    WindowState = FormWindowState.Normal;
                                }
                                break;
                         
                            default:
                                Process.Start(s.Substring(index2 + 1));
                                break;
                        }


                    }
                    break;
                }
                c++;
            }

        }


        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);
        private void textPrint(String text)
        {
            SendKeys.SendWait(text);
        }


        private void StopWindow()
        {
            System.Diagnostics.Process[] procs = System.Diagnostics.Process.GetProcessesByName(ProcWindow);
            foreach (System.Diagnostics.Process proc in procs)
            {
                proc.CloseMainWindow();
            }
        }


        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
          
        }


        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {    
        }  


        private void showJaneTool_Click(object sender, EventArgs e)
        {
            this.Show();
        }


        private void exitTool_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private String ProcWindow = "";
        private SpeechSynthesizer sSynth = new SpeechSynthesizer();
        private PromptBuilder pBuilder = new PromptBuilder();
        private SpeechRecognitionEngine sRecognize = new SpeechRecognitionEngine();


    }
}