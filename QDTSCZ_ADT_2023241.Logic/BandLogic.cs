using QDTSCZ_ADT_2023241.Models;
using QDTSCZ_ADT_2023241.Repository;

namespace QDTSCZ_ADT_2023241.Logic
{
    public class BandLogic
    {
        protected BandRepository bandRepository;
        BandRepository @object;
        public BandLogic(BandRepository @object)
        {
            this.@object = @object;
        }
        public void AddNew(Band band)
        {
            if (band == null) 
            {
                throw new ArgumentNullException("No band added"); 
            }
            bandRepository.Add(band);
        }
        public IEnumerable<Band> GetAll()
        {
            return bandRepository.GetAll();
        }
        public Band Get(int Id)
        {
            if(bandRepository.GetSingle(Id) == null)
            {
                throw new ArgumentException("There is no band with that id");
            }
            return bandRepository.GetSingle(Id);
        }
        public void UpdateBandBalance(Band band)
        {
            if (band == null)
            {
                throw new ArgumentNullException("No band added");
            }
            bandRepository.UpdateBandBalance(band.Id, band.Balance);
        }

        public void Delete(int Id)
        {
            if(bandRepository.GetSingle(Id) == null)
            {
                throw new ArgumentException("There is no band with that id");
            }
            bandRepository.Remove(bandRepository.GetSingle(Id));
        }

    }
}