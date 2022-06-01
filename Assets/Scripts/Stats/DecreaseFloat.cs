namespace FallingDamage
{
    public struct DecreaseFloat : IStatModifier<float>
    {
        public float DecreaseAmount { get; private set; }

        public DecreaseFloat(float decreaseAmount)
        {
            DecreaseAmount = decreaseAmount;
        }

        public float Modify(in float value)
        {
            return value - DecreaseAmount;
        }
    }
}
