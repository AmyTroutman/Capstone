using LibraryApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Core.Services
{
    public class SeriesService : ISeriesService
    {
        private readonly ISeriesRepository _seriesRepository;

        public SeriesService(ISeriesRepository seriesRepository)
        {
            _seriesRepository = seriesRepository;
        }

        public Series Add(Series series)
        {
            return _seriesRepository.Add(series);
        }

        public Series Update(Series series)
        {
            return _seriesRepository.Update(series);
        }

        public Series Get(int id)
        {
            return _seriesRepository.Get(id);
        }

        public IEnumerable<Series> GetAll()
        {
            return _seriesRepository.GetAll();
        }

        //Included in case I need it, if I can't use Book's method
        /*public IEnumerable<Series> GetBooksForSeries(int seriesId)
        {
            return _seriesRepository.GetBooksForSeries(seriesId);
        }
*/
        public void Remove(int id)
        {
            var series = _seriesRepository.Get(id);
            _seriesRepository.Remove(series);
        }
    }
}
