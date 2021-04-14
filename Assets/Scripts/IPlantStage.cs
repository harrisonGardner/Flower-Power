public interface IPlantStage
{
    public int DaysToNextStage;
    public int CutDifficulty;
    public bool MustBeHealthyToProgress;

    public void DecrementDaysToNextStage();

    public bool IsReadyForNextStage();

    public IPlantStage GetNextStage();

    public void GetReproductionBehavior();
}
