using System.IO;
using System.Windows;
using Ookii.Dialogs.Wpf;
using System.Windows;
using System.Windows.Media.Imaging;
using ImageMagick;
using System.Windows.Media;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectFolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new VistaFolderBrowserDialog();
            if (dialog.ShowDialog() == true)
            {
                string folderPath = dialog.SelectedPath;
                LoadImages(folderPath);
            }
        }

        private void LoadImages(string folderPath)
        {
            List<ImageInfo> imageInfos = new List<ImageInfo>();

            var files = Directory.GetFiles(folderPath);


            foreach (var file in files)
            {
                string extension = Path.GetExtension(file).ToLower();

                if (IsImageFile(extension))
                {
                    if (extension == ".pcx")
                    {
                        using (MagickImage image = new MagickImage(file))
                        {
                            imageInfos.Add(new ImageInfo
                            {

                                FileName = Path.GetFileNameWithoutExtension(file),
                                FileExtension = extension.Substring(1),
                                Size = $"{image.Width} x {image.Height}",
                                Resolution = $"{image.Density.X} x {image.Density.Y} dpi",
                                ColorDepth = $"{image.ChannelCount * image.Depth}",
                                Compression = image.Compression.ToString()
                            });
                        }
                    } else
                    {
                        var image_ = new BitmapImage(new Uri(file));
                        using (MagickImage image = new MagickImage(file))
                        {
                            imageInfos.Add(new ImageInfo
                            {

                                FileName = Path.GetFileNameWithoutExtension(file),
                                FileExtension = extension.Substring(1),
                                Size = $"{image_.Width} x {image_.Height}",
                                Resolution = $"{image_.DpiX} x {image_.DpiY} dpi",
                                ColorDepth = GetColorDepth(image_.Format),
                                Compression = image.Compression.ToString()
                            });
                        }
                    }
                }
            }

            dataGrid.ItemsSource = imageInfos;
        }

        private bool IsImageFile(string extension)
        {
            string[] validExtensions = { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".tiff", ".pcx" };
            return Array.Exists(validExtensions, e => e.Equals(extension, StringComparison.OrdinalIgnoreCase));
        }

        private string GetColorDepth(PixelFormat format)
        {
            if (format == PixelFormats.Indexed8)
            {
                return "8";
            }
            else if (format == PixelFormats.Bgr32)
            {
                return "32";
            }
            else if (format == PixelFormats.Bgr24)
            {
                return "24";
            }
            return "Unknown";
        }
    }

    public class ImageInfo
    {
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string Size { get; set; }
        public string Resolution { get; set; }
        public string ColorDepth { get; set; }
        public string Compression { get; set; }
    }
}
