using LibraryApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Core.Services
{
    public interface ISeriesService
    {
        Series Add(Series newSeries);
        Series Update(Series updateSeries);
        Series Get(int id);
        IEnumerable<Series> GetAll();
        //Do I need this here? Could I just use Book's method
        //IEnumerable<Series> GetBooksForSeries(int seriesId);
        void Remove(int id);
    }
}
