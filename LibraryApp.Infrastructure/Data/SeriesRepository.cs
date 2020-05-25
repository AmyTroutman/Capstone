using LibraryApp.Core.Models;
using LibraryApp.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryApp.Infrastructure.Data
{
    public class SeriesRepository : ISeriesRepository
    {
        private readonly AppDbContext _appDbContext;

        public SeriesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Series Add(Series series)
        {
            _appDbContext.Series.Add(series);
            _appDbContext.SaveChanges();
            return series;
        }

        public Series Get(int id)
        {
            return _appDbContext.Series
                .Include(s => s.Books)
                .ThenInclude(s => s.Author)
                .SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<Series> GetAll()
        {
            return _appDbContext.Series
                .Include(s => s.Books)
                .ThenInclude(s=>s.Author)
                .ToList();
        }

        public void Remove(Series series)
        {
            _appDbContext.Series.Remove(series);
            _appDbContext.SaveChanges();
        }

        public Series Update(Series updateSeries)
        {
            var currentSeries = _appDbContext.Series.Find(updateSeries.Id);
            if (currentSeries == null) return null;
            _appDbContext.Entry(currentSeries)
                .CurrentValues
                .SetValues(updateSeries);

            _appDbContext.Series.Update(currentSeries);
            _appDbContext.SaveChanges();
            return currentSeries;
        }
    }
}
