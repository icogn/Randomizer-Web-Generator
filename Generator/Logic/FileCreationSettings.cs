namespace TPRandomizer
{
    using TPRandomizer.Util;
    using TPRandomizer.FcSettings.Enums;
    using TPRandomizer.Assets.CLR0;

    public class FileCreationSettings
    {
        public GameRegion gameRegion { get; }
        public bool includeSpoilerLog { get; }
        public RandomizeBgm randomizeBgm { get; }
        public bool randomizeFanfares { get; }
        public bool disableEnemyBgm { get; }

        public Clr0Entry tunicColor { get; }

        public Clr0Entry lanternGlowColor { get; }

        // public int midnaHairColor { get; }
        public Clr0Entry heartColor { get; }

        public Clr0Entry aBtnColor { get; }

        public Clr0Entry bBtnColor { get; }
        public Clr0Entry xBtnColor { get; }
        public Clr0Entry yBtnColor { get; }
        public Clr0Entry zBtnColor { get; }

        private FileCreationSettings(string bits)
        {
            BitsProcessor processor = new BitsProcessor(bits);

            gameRegion = (GameRegion)processor.NextInt(2);
            includeSpoilerLog = processor.NextBool();

            randomizeBgm = (RandomizeBgm)processor.NextInt(2);
            randomizeFanfares = processor.NextBool();
            disableEnemyBgm = processor.NextBool();

            tunicColor = processor.NextClr0Entry(RecolorId.HerosClothes);
            lanternGlowColor = processor.NextClr0Entry(RecolorId.LanternGlow);
            // midnaHairColor = processor.NextInt(1);
            heartColor = processor.NextClr0Entry(RecolorId.Hearts);
            aBtnColor = processor.NextClr0Entry(RecolorId.ABtn);
            bBtnColor = processor.NextClr0Entry(RecolorId.BBtn);
            xBtnColor = processor.NextClr0Entry(RecolorId.XBtn);
            yBtnColor = processor.NextClr0Entry(RecolorId.YBtn);
            zBtnColor = processor.NextClr0Entry(RecolorId.ZBtn);
        }

        public static FileCreationSettings FromString(string fcSettingsString)
        {
            string bits = SettingsEncoder.DecodeToBitString(fcSettingsString);
            return new FileCreationSettings(bits);
        }
    }
}
