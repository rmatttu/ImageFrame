using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFrame
{
    [Serializable()]
    public record SaveData(List<DisplayInfo> images, string version)
    {
        public static SaveData GenerateSample()
        {
            var images = new List<DisplayInfo>();
            images.Add(new DisplayInfo(
                new Rectangle(10, 20, 200, 100),
                "dummy.jpg",
                new Point(0, 0), 1.0));
            return new SaveData(images, "0.0.1");
        }

    }
}
