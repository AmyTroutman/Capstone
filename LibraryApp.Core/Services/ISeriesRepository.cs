using LibraryApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Core.Services
{
    public interface ISeriesRepository
    {
        Series Add(Series series);
        Series Update(Series series);
        Series Get(int id);
        IEnumerable<Series> GetAll();
        void Remove(Series series);
    }
}
