using QDTSCZ_ADT_2023241.Models;
using QDTSCZ_ADT_2023241.Repository;

namespace QDTSCZ_ADT_2023241.Logic
{
    public class InstrumentLogic: IInstrumentLogic
    {
        protected InstrumentRepository instrumentRepository;
        public InstrumentLogic(IInstrumentRepository @object)
        {
            instrumentRepository = (InstrumentRepository?)@object;
        }
        public void AddNew(Instrument instrument)
        {
            if (instrument == null ||
                instrument.Name == "" ||
                instrument.Name == null) 
            {
                throw new ArgumentNullException("No instrument added"); 
            }
            instrumentRepository.Add(instrument);
        }
        public IEnumerable<Instrument> GetAll()
        {
            return instrumentRepository.GetAll();
        }
        public Instrument Get(int Id)
        {
            if(instrumentRepository.GetSingle(Id) == null)
            {
                throw new ArgumentException("There is no instrument with that id");
            }
            return instrumentRepository.GetSingle(Id);
        }
        public void UpdateBand(Instrument instrument)
        {
            if (instrument == null)
            {
                throw new ArgumentNullException("No instrument changed");
            }
            instrumentRepository.UpdateBand(instrument.Id, instrument.BandId);
        }

        public void Delete(int Id)
        {
            if(instrumentRepository.GetSingle(Id) == null)
            {
                throw new ArgumentException("There is no instrument with that id");
            }
            instrumentRepository.Remove(instrumentRepository.GetSingle(Id));
        }

    }
}