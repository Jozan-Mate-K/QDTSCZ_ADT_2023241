using QDTSCZ_ADT_2023241.Models;
using QDTSCZ_ADT_2023241.Repository;

namespace QDTSCZ_ADT_2023241.Logic
{
    public class InstrumentLogic: IInstrumentLogic
    {
        protected IInstrumentRepository instrumentRepository;
        protected IManufacturerRepository manufacturerRepository;
        protected IBandRepository bandRepository;

        public InstrumentLogic(
            IInstrumentRepository @instrumentR,
            IManufacturerRepository @manufacturerR,
            IBandRepository @bandR)
        {
            instrumentRepository = instrumentR;
            manufacturerRepository = manufacturerR;
            bandRepository = bandR; //Thats what im gonna go on
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
        public void Update(Instrument instrument)
        {
            if (instrument == null)
            {
                throw new ArgumentNullException("No instrument changed");
            }
            if (Get(instrument.Id).Band != instrument.Band)
            {
                instrumentRepository.UpdateBand(instrument.Id, instrument.BandId);
            }
            if (Get(instrument.Id).Manufacturer != instrument.Manufacturer)
            {
                instrumentRepository.UpdateManufacturer(instrument.Id, instrument.BandId);
            }
        }
        public void Delete(int Id)
        {
            if(instrumentRepository.GetSingle(Id) == null)
            {
                throw new ArgumentException("There is no instrument with that id");
            }
            instrumentRepository.Remove(instrumentRepository.GetSingle(Id));
        }


        public Manufacturer GetManufacturer(int Id)
        {
            return manufacturerRepository.GetSingle(instrumentRepository.GetSingle(Id).ManufacturerId);
        }
        public Band GetBand(int Id)
        {
            return bandRepository.GetSingle(instrumentRepository.GetSingle(Id).BandId);
        }
    }
}