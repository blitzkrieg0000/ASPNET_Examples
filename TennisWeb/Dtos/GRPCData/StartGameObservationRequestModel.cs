namespace Dtos.GRPCData {
    public class StartGameObservationRequestModel {
        public int StreamId { get; set; }
        public int PlayerId { get; set; }
        public int AOSTypeId {get; set;}
        public int CourtId { get; set; }
        public int Limit {get; set;}
    }
}