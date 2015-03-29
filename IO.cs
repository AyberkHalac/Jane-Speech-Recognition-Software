using System;
using System.IO;
using System.Collections;
using System.Windows.Forms;
namespace Jane
{
    class IO
    {
        public Boolean IoCCaller(String path)
        {
            return IoChecker(path);
        }
        public ArrayList IoSCaller()
        {
            return IoS();
        }

        private Boolean IoChecker(string path)
        {
            if (!File.Exists(path))
            {
                return false;
            }
            else
                return true;
        }
        private ArrayList IoS()
        {

            ArrayList returner = new ArrayList();     
            string commandDict = @"../../documents/dictionary_C.txt";
            if (IoChecker(commandDict) == false)
                MessageBox.Show("ERROR PATH");
            using (StreamReader sr = File.OpenText(commandDict))
            {
                string checker = "";
                while ((checker = sr.ReadLine()) != null)
                {
                    returner.Add(checker);
                }
            }
            return returner;
        }
    }
}
