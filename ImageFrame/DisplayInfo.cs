using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFrame
{
    public record DisplayInfo(Rectangle location, string path, Point offset, double zoom);
}
