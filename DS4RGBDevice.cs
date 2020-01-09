using DS4Windows;
using RGB.NET.Core;
using System.Collections.Generic;
using System.Linq;

namespace RGB.NET.Devices.DS4
{
    public class DS4RGBDevice : AbstractRGBDevice<DS4RGBDeviceInfo>, IDS4RGBDevice
    {
        public override DS4RGBDeviceInfo DeviceInfo { get; }

        DS4Device device;
        DS4Color ds4color;

        public DS4RGBDevice(DS4RGBDeviceInfo info)
        {
            this.DeviceInfo = info;
        }

        public void Initialize()
        {
            InitializeLayout();

            try
            {

                DS4Devices.findControllers();
                IEnumerable<DS4Device> devices = DS4Devices.getDS4Controllers();
                device = devices.ElementAt(0);
                device.StartUpdate();

            }
            catch (System.Exception)
            {
                throw;
            }

        }

        protected override object CreateLedCustomData(LedId ledId) => (int)ledId - (int)LedId.Custom1;

        public void InitializeLayout()
        {
            InitializeLed(LedId.Custom1, new Rectangle(0, 0, 10, 10));
        }


        protected override void UpdateLeds(IEnumerable<Led> ledsToUpdate)
        {
            Led led = ledsToUpdate.FirstOrDefault(x => x.Color.A > 0);
            if (led == null) return;
            try
            {
                

                ds4color.green = System.Convert.ToByte(led.Color.G / (led.Color.A / 255));
                ds4color.blue  = System.Convert.ToByte(led.Color.B / (led.Color.A / 255));
                ds4color.red   = System.Convert.ToByte(led.Color.R / (led.Color.A / 255));




                device.LightBarColor = ds4color;
            }
            catch
            {

            }

        }

    }
}

