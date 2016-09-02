using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;
using System.Drawing;
using METCommon.Resources;

namespace METCommon
{
    public class ResourceAccess
    {
        public static Bitmap GetIcon(string Source, string IconName)
        {
            ResourceManager resourceManager, temp;

            switch (Source)
            {
                case "Black32":
                    temp = new ResourceManager("METCommon.Resources.Black32", typeof(Black32).Assembly);
                    break;

                case "Black64":
                    temp = new ResourceManager("METCommon.Resources.Black64", typeof(Black64).Assembly);
                    break;

                case "White32":
                    temp = new ResourceManager("METCommon.Resources.White32", typeof(White32).Assembly);
                    break;

                case "White64":
                    temp = new ResourceManager("METCommon.Resources.White64", typeof(White64).Assembly);
                    break;

                default:
                    return null;
            }

            resourceManager = temp;

            object obj = resourceManager.GetObject("icon" + IconName);
            return ((System.Drawing.Bitmap)(obj));
        }
    }
}
