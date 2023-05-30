
using FanControl.Plugins;
using System;

namespace Battery_Plugin;


public class Battery_plugin : IPlugin2
{
    public string Name => "AC status";
    
    private BatterySensor[] sensors = Array.Empty<BatterySensor>();
    
    public void Initialize()
    {
    }

    public void Close()
    {
        sensors = Array.Empty<BatterySensor>();
    }

    public void Load(IPluginSensorsContainer container)
    {
        sensors = BatterySensor.GetBatterySensors();
        foreach (var sensor in sensors)
        {
            sensor.Value = BatterySensor.get_status();
            container.TempSensors.Add(sensor);

        }
    }

    public void Update()
    {
        foreach (var sensor in sensors)
        {
            sensor.Value = BatterySensor.get_status();
        }
    }
}


