using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URl_Project.Interfaces;
using URl_Project.Models;

namespace URl_Project.Service
{
    public class SummaryDataRepositiry
    {
        private IRepository<LongUrl> longUrls;
        private IRepository<ShortUrl> shortUrls;

        public SummaryDataRepositiry(IRepository<LongUrl> longUrls, IRepository<ShortUrl> shortUrls)
        {
            this.longUrls = longUrls;
            this.shortUrls = shortUrls;
        }

        public IEnumerable<SummaryData> GetSummary()
        {
            IEnumerable<LongUrl> longs = longUrls.GetAll();
            IEnumerable<ShortUrl> shorts = shortUrls.GetAll();

            var resultJoin = shorts.Join(longs, s => s.ID_Url, l => l.ID, (s, l) => new SummaryData() { ID = l.ID, LongUrl = l.Url, ShortUrl = s.Url, NumberClick = s.NumberClick });

            try
            {
                return shorts.Join(longs, s => s.ID_Url, l => l.ID, (s, l) => new SummaryData() { ID = l.ID, LongUrl = l.Url, ShortUrl = s.Url, NumberClick = s.NumberClick });
            }
            catch
            {
                return null;
            }
        }
    }
}
