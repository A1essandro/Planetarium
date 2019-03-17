using System;

namespace PlanetariumWpf
{
    public static class WorldState
    {

        public static event EventHandler ScaleChanged;

        private static double _scale = 1;
        private static int _offset = 0;

        public static double Scale
        {
            get { return _scale; }
            set
            {
                if (value != _scale)
                {
                    _scale = value;
                    ScaleChanged?.Invoke(null, EventArgs.Empty);
                }
            }
        }

        public static int Offset
        {
            get { return _offset; }
            set
            {
                if (value != _offset)
                {
                    _offset = value;
                    ScaleChanged?.Invoke(null, EventArgs.Empty);
                }
            }
        }
    }

}
