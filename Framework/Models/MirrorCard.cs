namespace Framework.Models
{
    public class MirrorCard : BaseCard
    {
        public override string CardName { get; set; } = "Mirror";
        public override string CardDescription { get; set; } = "Mirrors your last card played for +1 Elixir. Does not appear in your starting hand.";
    }
}