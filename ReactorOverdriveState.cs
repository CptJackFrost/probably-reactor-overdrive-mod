public static class ReactorOverdriveState
{
    private const string OverdriveTag = "REACTOR_OVERDRIVE_BOOL";

    public static bool IsOverdriveEnabled(GameItem reactor)
    {
        return reactor.GetTagReadonly(OverdriveTag).GetBool();
    }

    public static void SetOverdrive(GameItem reactor, bool enabled)
    {
        reactor.ModifyTag(OverdriveTag, state =>
        {
            state.Enable().SetBool(enabled);
        });
    }
}