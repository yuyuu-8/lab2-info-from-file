# The Task:
### Make an app, that makes the table with info about uploaded files (6 image extensions supported).

# To run:
### Download file "mysetup.exe", run it in your computer, choose the directory to download all of the files needed to run the application.

# Used functions and libraries^
### <ins>*_File Name_*</ins> - using Path.GetFileNameWithoutExtension(file) from inner library;
### <ins>*_File Exstension_*</ins> - using Path.GetExtension(file).ToLower() from inner library;
### <ins>*_File Size_*</ins> - using Width and Height from ImageMagick library and BitmapImage class;
### <ins>*_File Resolution_*</ins> - for .pcx: image.Density.X and image.Density.Y from ImageMagick; for others: DpiX and DpiY from BitmapImage class;
### <ins>*_File Color Depth_*</ins> - using GetColorDepth() from inner library;
### <ins>*_File Compression_*</ins> - use ImageMagick's image.Compression.ToString(), which returns the compression type as a string;
### <ins>*_File containing Alpha Channel_*<ins/> - using the ImageMagick image.HasAlpha property. The GetAlphaChannel() function returns "YES" if the alpha channel is present, and "NO" otherwise;
### <ins>*_File using Interlace_*</ins> - using the image.Interlace property. If the property value is Interlace.Line, Interlace.Plane, or Interlace.Partition, the image is considered interlaced;
### <ins>*_File containing Animation_*</ins> - using the MagickImageCollection class, which loads the file as a collection of images. If the number of frames (imageCollection.Count) is greater than 1, the image is considered animated.
