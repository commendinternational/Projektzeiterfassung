﻿//Copyright © 2015 by Commend International GmbH.All rights reserved.

//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU Affero General Public License, version 3,
//as published by the Free Software Foundation.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//GNU Affero General Public License for more details.

//You should have received a copy of the GNU Affero General Public License
//along with this program.If not, see<http://www.gnu.org/licenses/>.

using System;

namespace com.commend.tools.PZE.Misc.TTConnection.TTFilters
{
    /// <summary>
    /// TestTrack-Filter of booked last week
    /// </summary>
    public class FilterLastWeek:TtFilter
    {
        public FilterLastWeek(TtFilterType _filterType = TtFilterType.entry)
        {
            FilterType = _filterType;
        }

        /// <summary>
        /// returns the identifikation string of the TestTrack-Filter
        /// </summary>
        /// <returns>identifikation string</returns>
        override
        public String getFilterName(TtFilterType FilterType = TtFilterType.entry)
        {
            if (FilterType == TtFilterType.entry)
            {
                return "_booked last Week";
            }
            return "_enter work last Week";
        }

        /// <summary>
        /// get the start date of the Filter
        /// </summary>
        override
        public DateTime StartDate
        {
            get { return EndDate.AddDays(-7); }
        }

        /// <summary>
        /// get the end date of the Filter
        /// </summary>
        override
        public DateTime EndDate
        {
            get
            {
                double offset = 0;
                switch (System.DateTime.Today.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        offset = 0;
                        break;
                    case DayOfWeek.Tuesday:
                        offset = -1;
                        break;
                    case DayOfWeek.Wednesday:
                        offset = -2;
                        break;
                    case DayOfWeek.Thursday:
                        offset = -3;
                        break;
                    case DayOfWeek.Friday:
                        offset = -4;
                        break;
                    case DayOfWeek.Saturday:
                        offset = -5;
                        break;
                    case DayOfWeek.Sunday:
                        offset = -6;
                        break;
                }
                return DateTime.Today.AddDays(offset);
            }
        }
    }
}
