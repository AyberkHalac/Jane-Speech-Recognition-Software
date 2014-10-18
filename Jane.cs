using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Threading;
using System.Diagnostics;
namespace JARVIS
{
    public partial class Form1 : Form
    {
        String ProcWindow = "";
        public Form1()
        {
            InitializeComponent();
        }

        SpeechSynthesizer sSynth = new SpeechSynthesizer();
        PromptBuilder pBuilder = new PromptBuilder();
        SpeechRecognitionEngine sRecognize = new SpeechRecognitionEngine();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pBuilder.ClearContent();
            pBuilder.AppendText(textBox1.Text);
            sSynth.Speak(pBuilder);
        }


        private void button2_Click(object sender, EventArgs e)
        {   
            int ListC = 0;
            IO io = new IO();
            
            string[] list = new string[io.IoSCaller(ListC).Count];
            Choices sList = new Choices();
            for (int i = 0; i < io.IoSCaller(ListC).Count; i++)
            {
                list[i] = (io.IoSCaller(ListC)[i].ToString()).Substring(0,io.IoSCaller(ListC)[i].ToString().IndexOf('|'));
            }
            
                sList.Add(list);
            Grammar gr = new Grammar(new GrammarBuilder(sList));
           
            try
            {
                sRecognize.RequestRecognizerUpdate();
                sRecognize.LoadGrammar(gr);
                sRecognize.SpeechRecognized += sRecognize_SpeechRecognized ;
                sRecognize.SetInputToDefaultAudioDevice();
                sRecognize.RecognizeAsync(RecognizeMode.Multiple);
		        sRecognize.Recognize(); 

            }

            catch
            {
                return;
            }
        }


      


        private void sRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            int ListC = 0;
            IO io = new IO();
            int c = 0;
            
            foreach (String s in io.IoSCaller(ListC))
            {
                
                if(e.Result.Text.ToString().Equals(s.Substring(0,io.IoSCaller(ListC)[c].ToString().IndexOf('|')))){
                    int index2 = io.IoSCaller(ListC)[c].ToString().IndexOf('&');
                    int index1 = io.IoSCaller(ListC)[c].ToString().IndexOf('|');  
                  
                    String s1 = s.Substring((index1 + 1), (index2 - index1 - 1));
      
                    pBuilder.ClearContent();
                    pBuilder.AppendText(s1);
                    sSynth.Speak(pBuilder);
                    
                    if (s.Substring(index2+1).Length!=0)
                    {
                        switch(e.Result.Text.ToString()){
                            case "exit":
                                ProcWindow = "JARVIS.vshost32";
                                StopWindow();
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
                            case "show commands":
                                this.textBox1.Text = io.IoSCaller(0)[1].ToString();
                                break;

                            case "write mode":
                                
                                break;
                            case "search":
                                break;
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
      
                            case "out of the way":
                                  if (WindowState == FormWindowState.Normal || WindowState == FormWindowState.Maximized)
                                  {
                                      WindowState = FormWindowState.Minimized;                              
                                  }
                                  break;
                            case "come back":
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
            c++;}

        }

     

        private void StopWindow()
        
        {
            System.Diagnostics.Process[] procs = System.Diagnostics.Process.GetProcessesByName(ProcWindow);
            foreach (System.Diagnostics.Process proc in procs)
            {
                proc.CloseMainWindow();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}








