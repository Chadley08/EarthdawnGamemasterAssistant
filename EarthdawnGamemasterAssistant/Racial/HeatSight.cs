namespace EarthdawnGamemasterAssistant.CharacterGenerator.Racial
{
    public class HeatSight : RacialAbility
    {
        public HeatSight() : base(
            "Heat Sight",
            "Characters with heat sight can see heat radiated by another character or object, which translates into different colors. The colors depend on the relative heat given out by an object. The hottest objects show up as white, with the spectrum dropping through red, orange, yellow, green, blue, and down into violet or even black for the coldest objects. Heat sight tends to fade into the background the more light is present, but it allows the character to tsee in the dark, at the expense of detail.")
        {
        }

        protected override void Apply()
        {
            // No op
        }
    }
}