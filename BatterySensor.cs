using FanControl.Plugins;
using System.Windows.Forms;
namespace Battery_Plugin;

public class BatterySensor : IPluginSensor
{
    internal string Type { get; }

    internal int Index { get; set; }

    public string Name { get; }

    public float? Value { get; internal set; }

    public string Id { get; }

    public void Update() { }

    internal BatterySensor(int index, string type, string id, string name)
    {
        Index = index;
        Type = type;
        Id = id;
        Name = name;
    }

    static public float get_status()
    {
        var Charging_status = SystemInformation.PowerStatus.BatteryChargeStatus & BatteryChargeStatus.Charging;
        if (SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Online && Charging_status == BatteryChargeStatus.Charging)
        {
            return 100f;
        }
        else if (SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Online)
        {
            return 50f;
        }
        return 0f;
    }

    static public BatterySensor[] GetBatterySensors()
    {
        var list = new List<BatterySensor>();
        var sensor = new BatterySensor(1, "Temperature", "bat_Temperature", "ac status");

        list.Add(sensor);
        return list.ToArray();
    }
};