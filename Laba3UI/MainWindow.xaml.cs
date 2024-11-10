using Microsoft.Win32;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
namespace Laba3UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly static string src = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent!.Parent!.Parent!.FullName;
        public MainWindow()
        {
            Icon = BitmapFrame.Create(new Uri($"{src}\\mirrorIcon.ico", UriKind.RelativeOrAbsolute));
            InitializeComponent();
            ClearFiles();
        }
        static void ClearFiles()
        {
            string[] files = Directory.GetFiles($@"{src}\MirroredGifs\");
            foreach (var item in files) File.Delete(item);
        }
        private void selectFileBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Multiselect = true;
            fd.InitialDirectory = @$"{src}\images\";
            fd.Filter = "Image Files | *.jpg; *.jpeg; *.png; *.tiff; *.tif; *.svg; *.bmp; *.gif; *.ico; *.avif; *.webp";
            if (fd.ShowDialog() == true)
            {
                foreach (var image in fd.FileNames)
                {
                    if (!this.PictureList.Items.Contains(image)) this.PictureList.Items.Add(image);
                }
            }
            else
            {
                MessageBox.Show("File wasn't selected");
            }
        }

        private void mirrorFilesBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string image in PictureList.SelectedItems)
            {
                var path = $@"{src}\MirroredGifs\{Path.GetFileNameWithoutExtension(image)}-mirrored.gif";
                try
                {
                    Image img = Image.FromFile(image);
                    img.RotateFlip(RotateFlipType.Rotate180FlipX);
                    img.Save(path);
                    img.Dispose();
                    if (!this.ReflectedList.Items.Contains(path)) this.ReflectedList.Items.Add(path);
                }
                catch (Exception ex)
                {
                    stringBuilder.AppendLine(ex.Message + "\nError in " + Path.GetFileNameWithoutExtension(image) + "\n");
                }
            }
            if (stringBuilder.Length > 0) MessageBox.Show(stringBuilder.ToString());
        }
        private void ReflectedList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Process photoViewer = new Process();
            photoViewer.StartInfo.FileName = "explorer.exe";
            photoViewer.StartInfo.Arguments = ReflectedList.SelectedItem.ToString();
            photoViewer.Start();
        }

        private void PictureList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Process photoViewer = new Process();
            photoViewer.StartInfo.FileName = "explorer.exe";
            photoViewer.StartInfo.Arguments = PictureList.SelectedItem.ToString();
            photoViewer.Start();
        }
    }
}