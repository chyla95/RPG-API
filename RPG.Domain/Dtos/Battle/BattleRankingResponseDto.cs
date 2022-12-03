namespace RPG.Domain.Dtos.Battle
{
#pragma warning disable CS8618
    public class BattleRankingResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PvpFightCount { get; set; }
        public int PvpWinCount { get; set; }
        public int PvpLoseCount { get; set; }
    }
#pragma warning restore CS8618
}
