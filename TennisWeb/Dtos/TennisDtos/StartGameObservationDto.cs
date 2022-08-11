namespace Dtos.TennisDtos {
    public class StartGameObservationDto {
        public int Score { get; set; }
        public float[,] FallPoints { get; set; }
        public string Frame { get; set; }
    }
}