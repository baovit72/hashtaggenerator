using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Generator;
using CsvHelper;
using System.Threading;
using System.IO;
using System.Globalization;

namespace Hashtag_Generator_From_Title
{

    public partial class MainForm : Form
    {
        #region Properties
        String InputFilePath;
        HashTagGenerator hashTagGenerator;
        Thread mainThread;
        ThreadStart mainThreadStart;
        #endregion 
        public MainForm()
        {
            InitializeComponent();
            hashTagGenerator = new HashTagGenerator();
            int currentProgress = 0;
            MethodInvoker updateProgressBar = delegate
            {
                progressBar.Value = currentProgress;
            };
            mainThreadStart = new ThreadStart(() =>
           {
               if (!File.Exists(InputFilePath))
               {
                   MessageBox.Show("Please select a valid file");
                   return;
               }
               List<Input> records = new List<Input>();
               using (var reader = new StreamReader(InputFilePath))
               using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
               {
                   csv.Configuration.RegisterClassMap<InputMap>();
                   records = csv.GetRecords<Input>().ToList();
               }
               for (int i = 0; i < records.Count; i++)
               {
                   Input r = records[i];
                   List<string> tags = generateHashtag(r.Title);
                   r.Tag1 = tags[0];
                   r.Tag2 = tags[1];
                   r.Tag3 = tags[2];
                   r.AllTag = tags[3];
                   currentProgress = (int)((float)(i + 1) / records.Count * 100);
                   this.Invoke(updateProgressBar);
               }
               using (var writer = new StreamWriter(Path.GetDirectoryName(InputFilePath) + "\\output.csv"))
               using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
               {
                   csv.WriteRecords(records);
               }
               MessageBox.Show("Exported to output.csv in the same folder as input file's");
           });
        }

        List<string> generateHashtag(string title)
        {
            List<string> results = new List<string>();
            var tags = hashTagGenerator.generate(title, tbKeyword.Text, tbRelevantKeywords.Text.Split('\n').ToList(), tbInsertedKeywords.Text.Split('\n').ToList());
            results.Add(tags[0]);
            results.Add((tags[1].Length > 0 ? tags[1] + ";" : "") + tags[2]);
            results.Add((tags[3].Length > 0 ? tags[3] + ";" : "") + (tags[4].Length > 0 ? tags[4] + ";" : "") + tags[5]);
            string resultString = "";

            foreach (string r in tags)
            {
                resultString += r.Length > 0 ? r + ";" : "";
            }
            results.Add(resultString);
            return results;
        }
        private void btnBegin_Click(object sender, EventArgs e)
        {
            mainThread?.Abort();
            mainThread = new Thread(mainThreadStart);
            mainThread.Start();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                InputFilePath = openFileDialog.FileName;
                lbFileInfo.Text = InputFilePath;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            mainThread?.Abort();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainThread?.Abort();
        }
    }
}
