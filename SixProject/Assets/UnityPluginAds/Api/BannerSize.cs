using System;

namespace UnityPluginAds.Api {

    public class BannerSize {

        public const int FULL_WIDTH = -1;

        public const int AUTO_HEIGHT = -2;

        public static readonly BannerSize BANNER = new BannerSize(320, 50);

        private int width;

        private int height;

        public BannerSize(int width, int height) {
            this.width = width;
            this.height = height;
        }

        public int Width {
            get { return width; }
        }

        public int Height {
            get { return height; }
        }
    }

}
