## using Magick.NET mostly, or inner libraries
### <ins>*_File Name_*</ins> - using Path.GetFileNameWithoutExtension(file) from inner library;
### <ins>*_File Exstension_*</ins> - using Path.GetExtension(file).ToLower() from inner library;
### <ins>*_File Size_*</ins> - using Width and Height from ImageMagick library and BitmapImage class;
### <ins>*_File Resolution_*</ins> - for .pcx: image.Density.X and image.Density.Y from ImageMagick; for others: DpiX and DpiY from BitmapImage class;
### <ins>*_File Color Depth_*</ins> - using GetColorDepth() from inner library;
### <ins>*_File Compression_*</ins> - 
### <ins>*_File containing Alpha Channel_*<ins/> - 
### <ins>*_File using Interlace_*</ins> - 
### <ins>*_File containing Animation_*</ins> -
