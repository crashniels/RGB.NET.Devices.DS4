using RGB.NET.Core;

namespace RGB.NET.Devices.DS4
{
    class DS4DeviceProviderLoader : IRGBDeviceProviderLoader
    {
        #region Properties & Fields

        /// <inheritdoc />
        public bool RequiresInitialization => false;

        #endregion

        #region Methods

        /// <inheritdoc />
        public IRGBDeviceProvider GetDeviceProvider() => DS4DeviceProvider.Instance;

        #endregion
    }
}
