using RGB.NET.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RGB.NET.Devices.DS4
{
    public class DS4DeviceProvider : IRGBDeviceProvider
    {

        #region Properties & Fields

        private static DS4DeviceProvider _instance;
        /// <summary>
        /// Gets the singleton <see cref=""/> instance.
        /// </summary>
        public static DS4DeviceProvider Instance => _instance ?? new DS4DeviceProvider();

        public bool HasExclusiveAccess => false; 


        public bool IsInitialized { get; private set; }

        public IEnumerable<IRGBDevice> Devices { get; private set; }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="DS4DeviceProvider"/> class.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if this constructor is called even if there is already an instance of this class.</exception>
        public DS4DeviceProvider()
        {
            if (_instance != null) throw new InvalidOperationException($"There can be only one instanc of type {nameof(DS4DeviceProvider)}");
            _instance = this;
        }

        public bool Initialize(RGBDeviceType loadFilter = RGBDeviceType.All, bool exclusiveAccessIfPossible = false, bool throwExceptions = false)
        {
            IsInitialized = false;
            try
            {

                IList<IRGBDevice> devices = new List<IRGBDevice>();
                IDS4RGBDevice device = new DS4RGBDevice(new DS4RGBDeviceInfo());
                device.Initialize();
                devices.Add(device);
                Devices = new ReadOnlyCollection<IRGBDevice>(devices);

            }
            catch
            {
                if (throwExceptions)
                    throw;
                else
                    return false;
            }

            IsInitialized = true;
            return true;
        }

        public void ResetDevices()
        {
            
        }

        public void Dispose()
        {

        }
    }
}


