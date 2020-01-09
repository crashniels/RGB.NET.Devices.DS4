using RGB.NET.Core;

namespace RGB.NET.Devices.DS4
{
    /// <summary>
    /// Represents a DS4 RGB-device.
    /// </summary>
    internal interface IDS4RGBDevice : IRGBDevice
    {
        void Initialize();
    }
}