using QDTSCZ_ADT_2023241.Models;
using QDTSCZ_ADT_2023241.Repository;

namespace QDTSCZ_ADT_2023241.Logic
{
    public class ManufacturerLogic: IManufacturerLogic
    {
        protected ManufacturerRepository manufacturerRepository;
        IManufacturerRepository @object;
        public ManufacturerLogic(IManufacturerRepository @object)
        {
            this.@object = @object;
        }
        public void AddNew(Manufacturer manufacturer)
        {
            if (manufacturer == null) 
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
            if (manufacturer == null)
            {
                throw new ArgumentNullException("No manufacturer added");
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

    }
}