﻿using Microsoft.Win32;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
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
            InitializeComponent();
            //MessageBox.Show(AvgSum().ToString());
            ClearFiles();
        }
        static void ClearFiles()
        {
            string[] files = Directory.GetFiles($@"{src}\InvalidData\");
            foreach (var item in files) File.Delete(item);
            files = Directory.GetFiles($@"{src}\MirroredGifs\");
        }
        static double AvgSum()
        {
            double avg = 0;
            ushort count = 0;
            byte number = 1;
            for (int i = 10; i < 30; i++)
            {
                string path = $@"{src}\txts\{i}.txt";
                try
                {
                    var file = new FileStream(path, FileMode.Open);
                    StreamReader reader = new StreamReader(file);
                    int num1 = int.Parse(reader.ReadLine()!);
                    int num2 = int.Parse(reader.ReadLine()!);
                    file.Close();
                    reader.Close();
                    checked
                    {
                        num1 *= num2;
                    }
                    avg += num1;
                    count++;
                }
                catch (OverflowException)
                {
                    System.Console.WriteLine($"Exception {number}\nReason: numbers are too big and their product cannot exceed {int.MaxValue}/{-int.MaxValue}\nFile name: {Path.GetFileName(path)}\n");
                    AppendLog("overflow", path);
                    number++;
                }
                catch (ArgumentNullException)
                {
                    System.Console.WriteLine($"Exception {number}\nReason: file must contain only 1 integer in first and 1 integer in second lines\nFile name: {Path.GetFileName(path)}\n");
                    AppendLog("bad_data", path);
                    number++;
                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine($"Exception {number}\nReason: {ex.Message.ToLower()}\nFile name: {Path.GetFileName(path)}\n");
                    AppendLog("bad_data", path);
                    number++;
                }
                catch (FileNotFoundException)
                {
                    System.Console.WriteLine($"Exception {number}\nReason: file wasn't found\nFile name: {Path.GetFileName(path)}\n");
                    AppendLog("no_file", path);
                    number++;
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            return avg / count;
        }
        static void AppendLog(string name, string path)
        {
            try
            {
                FileStream creator = new FileStream($@"{src}\InvalidData\{name}.txt", FileMode.Append);
                StreamWriter streamWriter = new StreamWriter(creator);
                streamWriter.WriteLine(Path.GetFileName(path));
                streamWriter.Close();
                creator.Close();
            }
            catch (Exception)
            {
                System.Console.WriteLine($"Couldn't create or update {name}.txt file");
            }
        }
        static void MirroredGifs(string path)
        {
            var images = Directory.GetFiles(path);
            Regex regexExtForImage = new("^((.bmp)|(.gif)|(.tiff?)|(.jpe?g)|(.png)|(.ico)|(.svg)|(.pdf)|(.avif)|(.webp))$", RegexOptions.IgnoreCase);
            foreach (var image in images)
            {
                if (regexExtForImage.IsMatch(Path.GetExtension(image)))
                {
                    try
                    {
                        Bitmap img = new(image);
                        img.RotateFlip(RotateFlipType.Rotate180FlipX);
                        img.Save($@"{src}\MirroredGifs\{Path.GetFileNameWithoutExtension(image)}-mirrored.gif");
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(ex.Message);
                        System.Console.WriteLine("error in " + Path.GetFileNameWithoutExtension(image));
                    }
                }
            }
        }

        private void selectFileBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Multiselect = true;
            fd.InitialDirectory = @$"{src}\images\";
            fd.Filter = "Image Files | *.jpg; *.jpeg; *.png; *.tiff; *.tif; *.svg; *.bmp; *.gif; *.ico; *.avif";
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