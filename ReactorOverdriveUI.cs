public static class ReactorOverdriveUI
{
    public static void OpenOverdriveWindow(GameItem reactor)
    {
        bool isOverdriveOn = ReactorOverdriveState.IsOverdriveEnabled(reactor);

        if (CustomUIManager.Instance != null)
        {
            CustomUIManager.Window("makeshift_reactor_overdrive.settings",
                ModHelper.GetLocalized(
                    "makeshift_reactor_overdrive",
                    "overdrive_window_title"), 
                CustomUIManager.LAYER_PAPER)
                .UseMachineryStyle()
                .SetSize(350, 100)
                .SetDraggable(true)
                .AddToggle(ModHelper.GetLocalized(
                    "makeshift_reactor_overdrive",
                    "overdrive_enable"), 
                    isOverdriveOn, v => ReactorOverdriveState.SetOverdrive(reactor, v))
                .Show();
        }
        
    }
}