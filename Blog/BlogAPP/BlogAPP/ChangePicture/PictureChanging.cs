using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BlogAPP.ChangePicture
{
    public static class ChangePicture
    {
        public static BitmapImage ChangePic(this BitmapImage t, string path)
        {

            if (path != null)
            {
                t.BeginInit();
                t.UriSource = new Uri(path, UriKind.RelativeOrAbsolute);
                t.EndInit();
            }



            return t;
        }
    }
}
