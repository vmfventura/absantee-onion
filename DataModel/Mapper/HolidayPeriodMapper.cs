using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel.Model;
using Domain.Factory;
using Domain.Model;

namespace DataModel.Mapper
{
    public class HolidayPeriodMapper
    {
        private IHolidayPeriodFactory _holidayPeriodFactory;
        
        public HolidayPeriodMapper(IHolidayPeriodFactory holidayPeriodFactory)
        {
            _holidayPeriodFactory = holidayPeriodFactory;
        }

        public HolidayPeriod ToDomain(HolidayPeriodDataModel holidayPeriodDataModel)
        {
            HolidayPeriod holidayPeriodDomain = _holidayPeriodFactory.NewHolidayPeriod(holidayPeriodDataModel.StartDate, holidayPeriodDataModel.EndDate);

            holidayPeriodDomain.Id = holidayPeriodDataModel.Id;
            return holidayPeriodDomain;
        }

        public IEnumerable<HolidayPeriod> ToDomain(IEnumerable<HolidayPeriodDataModel> holidayPeriodDataModels)
        {
            List<HolidayPeriod> holidayPeriodsDomain = new List<HolidayPeriod>();

            foreach (HolidayPeriodDataModel holidayPeriodDataModel in holidayPeriodDataModels)
            {
                HolidayPeriod holidayPeriodDomain = ToDomain(holidayPeriodDataModel);
                holidayPeriodsDomain.Add(holidayPeriodDomain);
            }
            return holidayPeriodsDomain.AsEnumerable();
        }

        public HolidayPeriodDataModel ToDataModel(HolidayPeriod holidayPeriod)
        {
            HolidayPeriodDataModel holidayPeriodDataModel = new HolidayPeriodDataModel(holidayPeriod);
            
            return holidayPeriodDataModel;
        }
    }
}