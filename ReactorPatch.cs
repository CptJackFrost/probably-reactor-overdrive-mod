using HarmonyLib;

[HarmonyPatch(
    typeof(ReactorHelper),
    nameof(ReactorHelper.GetChargePerNight)
)]
public static class ReactorOverdrivePower
{
    static void Postfix(GameItem reactor, ref int __result)
    {
        if (ReactorOverdriveState.IsOverdriveEnabled(reactor))
        {
            int powerMultiplier = ReactorOverdriveConfig.PowerMultiplier.Value;
            int powerBonus = ReactorOverdriveConfig.PowerBonus.Value;

            __result = __result * powerMultiplier + powerBonus;
        }
    }
}

[HarmonyPatch(
    typeof(ReactorHelper),
    nameof(ReactorHelper.GetDecay)
)]
public static class ReactorOverdriveDecay
{
    static void Postfix(GameItem reactor, ref int __result)
    {   
        if (ReactorOverdriveState.IsOverdriveEnabled(reactor))
        {
            int extraDecay = ReactorOverdriveConfig.ExtraDecay.Value;
            __result = __result + extraDecay;
        }
    }
}

[HarmonyPatch(
    typeof(ReactorHelper),
    nameof(ReactorHelper.CreateReactor)
)]
public static class ReactorOverdriveConfigure
{
    static void Postfix(GameItem  __result)
    {
        __result.EnableTag("CONFIGURE_TAG");
        __result.onConfigureSlotItemFunc += (GameItem self, GameInventory _, SlotMarker _) =>
        {
            ReactorOverdriveUI.OpenOverdriveWindow(self);
        };
        __result.onSlotAddItemFunc += (GameItem self, GameInventory _, SlotMarker _) =>
        {
            self.EnableTag("CONFIGURE_TAG");
        };

    }
}
