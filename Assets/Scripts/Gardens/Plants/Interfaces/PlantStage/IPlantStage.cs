
/// <summary>
/// Helps a plant in one stage of life advance to the next stage of maturity
/// </summary>
/// <author>Lisette Peck, Nicholas Gliserman</author>
public enum StageType { SEED, SPROUT, FLOWERING, DYING, YOUNGWEED, MATUREWEED }

public interface IPlantStage
{
    public int DaysToNextStage { get; set; }
    public int CutDifficulty { get; }
    public StageType CurrentStage { get; }
    public IReproductionBehavior Reproduction { get; }

    public void DecrementDaysToNextStage(bool wilting);
    public bool IsReadyForNextStage();
    public IPlantStage GetNextStage();
}
