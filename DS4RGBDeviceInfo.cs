using RGB.NET.Core;
using System;

namespace RGB.NET.Devices.DS4
{
    /// <inheritdoc />
    /// <summary>
    /// Represents a generic information for a DS4-<see cref="T:RGB.NET.Core.IRGBDevice" />.
    /// </summary>
    public class DS4RGBDeviceInfo : IRGBDeviceInfo
    {

        #region Properties & Fields

        /// <inheritdoc />
        public RGBDeviceType DeviceType => RGBDeviceType.Keypad;

        /// <inheritdoc />
        public string DeviceName => "DualShock 4 (PS4)";

        /// <inheritdoc />
        public string Manufacturer => "Sony";

        /// <inheritdoc />
        public string Model => "DualShock 4(PS4)";

        /// <inheritdoc />
        public Uri Image { get; set; }

        /// <inheritdoc />
        public RGBDeviceLighting Lighting => RGBDeviceLighting.Device;

        public bool SupportsSyncBack => false;

        /// <inheritdoc />

        #endregion


    }
}