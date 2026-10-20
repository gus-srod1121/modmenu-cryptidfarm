using MelonLoader;

[assembly: MelonInfo(typeof(PlantingRange.Core), "PlantingRange", "1.0.0", "Author", null)]
[assembly: MelonGame(null, null)]

namespace PlantingRange
{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initializing PlantingRange");
        }
    }
}