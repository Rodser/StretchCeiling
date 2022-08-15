namespace StretchCeiling.Model
{
    internal class StandartAngles
    {
        public List<Angle> Angles { get; set; }

        public StandartAngles()
        {
            Angles = new List<Angle>
            {
                new Angle(45),
                new Angle(90),
                new Angle(135),
                new Angle(225),
                new Angle(270),
                new Angle(315),
            };
        }
    }
}
