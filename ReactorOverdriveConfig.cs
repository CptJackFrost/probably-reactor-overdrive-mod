public static class ReactorOverdriveConfig
{
    public static ConfigEntry<int> PowerMultiplier { get; private set; }
    public static ConfigEntry<int> PowerBonus { get; private set; }
    public static ConfigEntry<int> ExtraDecay { get; private set; }

    public static void RegisterSettings (string modId)
    {
        ModConfig config = ModHelper.GetConfig(modId);

        PowerMultiplier = config.Define(
            "power_multiplier",
            2,
            "Reactor",
            () => ModHelper.GetLocalized("makeshift_reactor_overdrive", "config_power_multiplier"),
            min: 1,
            max: 5
        );

        PowerBonus = config.Define(
            "power_bonus",
            0,
            "Reactor",
            () => ModHelper.GetLocalized("makeshift_reactor_overdrive", "config_power_bonus"),
            min: 0,
            max: 10
        );

        ExtraDecay = config.Define(
            "extra_decay",
            10,
            "Reactor",
            () => ModHelper.GetLocalized("makeshift_reactor_overdrive", "config_extra_decay"),
            min: 0,
            max: 40
        );
    } 
}