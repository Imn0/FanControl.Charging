
using FanControl.Plugins;
using System;

namespace Battery_Plugin;


public class Battery_plugin : IPlugin2
{
    public string Name => "AC status";
    private BatterySensor[] _sensor = Array.Empty<BatterySensor>();

    public void Initialize()
    {
    }

    public void Close()
    {
        _sensor = Array.Empty<BatterySensor>();
    }

    public void Load(IPluginSensorsContainer container)
    {
        _sensor = BatterySensor.GetBatterySensors();
        foreach (var sensor in _sensor)
        {
            sensor.Value = BatterySensor.Get_status();
            container.TempSensors.Add(sensor);

        }
    }

    public void Update()
    {
        foreach (var sensor in _sensor)
        {
            sensor.Value = BatterySensor.Get_status();
        }
    }
}


