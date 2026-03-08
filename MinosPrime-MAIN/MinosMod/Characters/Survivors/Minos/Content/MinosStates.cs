using MinosMod.Survivors.Minos.SkillStates;

namespace MinosMod.Survivors.Minos
{
    public static class MinosStates
    {
        public static void Init()
        {
            Modules.Content.AddEntityState(typeof(PunchCombo));

            Modules.Content.AddEntityState(typeof(KickCombo));

            Modules.Content.AddEntityState(typeof(Roll));

            Modules.Content.AddEntityState(typeof(ThrowBomb));
        }
    }
}
