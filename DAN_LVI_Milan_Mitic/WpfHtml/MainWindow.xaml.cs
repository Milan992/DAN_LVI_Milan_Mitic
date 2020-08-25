using System.IO;
using System.Net;
using System.Windows;
using System.IO.Compression;

namespace WpfHtml
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnHtml_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox2.Text != null)
            {
                if (TextBox2.Text.Length > 0)
                {
                    WebClient wc = new WebClient();
                    string html = "";
                    try
                    {
                        // get html from web site.
                        html = wc.DownloadString(TextBox1.Text);
                        // check if file with name from txt box already exists.
                        if (!File.Exists(@"..\..\htmlFiles\" + TextBox2.Text + ".html"))
                        {
                            using (StreamWriter sw = new StreamWriter(@"..\..\htmlFiles\" + TextBox2.Text + ".html", false))
                            {
                                // write html to file.
                                sw.Write(html);
                            }
                            MessageBox.Show("Html file saved.");
                        }
                        else
                        {
                            MessageBox.Show("File " + TextBox2.Text + " already exist");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Invalid adress.");
                    }
                }
                else
                {
                    MessageBox.Show("File name must be at least one character long.");
                }
            }
            else
            {
                MessageBox.Show("File name must be at least one character long.");
            }
        }

        private void btnZip_Click(object sender, RoutedEventArgs e)
        {
            string startPath = @"..\..\htmlFiles";
            string zipPath = @"..\..\zippedFiles\htmlFiles.zip";

            int counter = 1;
            while (File.Exists(zipPath))
            {
                zipPath = @"..\..\zippedFiles\htmlFiles" + counter.ToString() + ".zip";
                counter++;
            }
            ZipFile.CreateFromDirectory(startPath, zipPath);
            MessageBox.Show("All html files are zipped.");
        }
    }
}

