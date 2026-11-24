public static class ReactorOverdriveUI
{
    public static void OpenOverdriveWindow(GameItem reactor)
    {
        bool isOverdriveOn = ReactorOverdriveState.IsOverdriveEnabled(reactor);

        if (CustomUIManager.Instance != null)
        {
            CustomUIManager.Window("makeshift_reactor_overdrive.settings", "Overdrive mode", CustomUIManager.LAYER_PAPER)
                .UseMachineryStyle()
                .SetSize(350, 100)
                .SetDraggable(true)
                .AddToggle("Enable overdrive", isOverdriveOn, v => ReactorOverdriveState.SetOverdrive(reactor, v))
                .Show();
        }
        
    }
}