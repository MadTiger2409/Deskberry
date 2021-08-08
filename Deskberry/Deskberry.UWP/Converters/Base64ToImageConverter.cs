using System;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace Deskberry.Tools.Converters
{
    public class Base64ToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var imageBytes = (byte[])value;
            return BytesToImageAsync(imageBytes).Result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) => throw new NotImplementedException();

        private async Task<BitmapImage> BytesToImageAsync(byte[] imageBytes)
        {
            var image = new BitmapImage();
            using (var randomAccessStream = new InMemoryRandomAccessStream())
            {
                using (var writer = new DataWriter(randomAccessStream.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes(imageBytes);
                    await writer.StoreAsync();

                    //! Don't await this!
                    //! If you do that, it will cause exception!
                    image.SetSourceAsync(randomAccessStream);
                }
            }
            return image;
        }
    }
}