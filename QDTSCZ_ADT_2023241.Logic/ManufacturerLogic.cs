using QDTSCZ_ADT_2023241.Models;
using QDTSCZ_ADT_2023241.Repository;

namespace QDTSCZ_ADT_2023241.Logic
{
    public class ManufacturerLogic: IManufacturerLogic
    {
        protected IManufacturerRepository manufacturerRepository;

        public ManufacturerLogic(
            IManufacturerRepository mRepo)
        {
            manufacturerRepository = mRepo;
        }
        public void AddNew(Manufacturer manufacturer)
        {
            if (manufacturer == null ||
                manufacturer.Name == ""||
                manufacturer.Name == null) 
            {
                throw new ArgumentNullException("No manufacturer added"); 
            }
            manufacturerRepository.Add(manufacturer);
        }
        public IEnumerable<Manufacturer> GetAll()
        {
            return manufacturerRepository.GetAll();
        }
        public Manufacturer Get(int Id)
        {
            if(manufacturerRepository.GetSingle(Id) == null)
            {
                throw new ArgumentException("There is no manufacturer with that id");
            }
            return manufacturerRepository.GetSingle(Id);
        }
        public void UpdateName(Manufacturer manufacturer)
        {
            if (manufacturer == null || manufacturerRepository.GetSingle(manufacturer.Id) == null)
            {
                throw new ArgumentNullException("No manufacturer changed");
            }
            manufacturerRepository.UpdateName(manufacturer.Id, manufacturer.Name);
        }

        public void Delete(int Id)
        {
            if(manufacturerRepository.GetSingle(Id) == null)
            {
                throw new ArgumentException("There is no manufacturer with that id");
            }
            manufacturerRepository.Remove(manufacturerRepository.GetSingle(Id));
        }

        //Non-crud

        public IEnumerable<Instrument> GetInstrumentsByManufacturers(int Id)
        {
            return manufacturerRepository.GetSingle(Id).Instruments;
            
        }
    }
}