using System;
using System.IO;
using System.Windows.Forms;

namespace newdelete
{
    public partial class Form1 : Form
    {
        // Default folder path
        private string folderPath = @"D:\OneDrive - Cargills Ceylon PLC\Desktop\kk";

        public Form1()
        {
            InitializeComponent();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Calculate the date threshold (30 days ago)
                DateTime thresholdDate = DateTime.Now.AddDays(-5);

                // Get all files in the folder
                string[] files = Directory.GetFiles(folderPath);

                // Delete each image file uploaded more than 30 days ago
                foreach (string file in files)
                {
                    if (IsImage(file))
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        // Check if the file creation date is before the threshold date
                        if (fileInfo.CreationTime < thresholdDate)
                        {
                            File.Delete(file);
                        }
                    }
                }

                MessageBox.Show("Old images have been deleted.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        // Helper method to check if a file has an image extension
        private bool IsImage(string file)
        {
            string extension = Path.GetExtension(file).ToLower();
            return extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif" || extension == ".bmp";
        }
    }
}
