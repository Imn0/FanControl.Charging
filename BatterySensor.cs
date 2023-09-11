using FanControl.Plugins;
using System.Windows.Forms;
namespace Battery_Plugin;

public class BatterySensor : IPluginSensor
{
    internal BatterySensor(int index, string type, string id, string name)
    {
        Index = index;
        Type = type;
        Id = id;
        Name = name;
    }
    /// <summary>
    /// Converts battery charging status to temperature. 
    ///
    /// </summary>
    /// <returns>
    /// 0, charger is not connected
    /// 50, charger is connected, however battery is not charging
    /// 100, charger is connected and battery is charging
    /// </returns>
    static public float Get_status()
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
        var _sensor = new BatterySensor(1, "Temperature", "bat_Temperature", "ac status");

        

        list.Add(_sensor);
        return list.ToArray();

    }
    internal string Type { get; }
    internal int Index { get; set; }
    public string Name { get; }

    public float? Value { get; internal set; }

    public string Id { get; }

    public void Update() { }

};