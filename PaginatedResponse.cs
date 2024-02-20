using System;
namespace dashboard_api
{
    public class PaginatedResponse<T>
    {
        public int Total { get; set; }
        public IEnumerable<T> Data { get; set; }


        public PaginatedResponse(IEnumerable<T> data, int i, int len)
        {
            //LINQ's Skip and Take methods. It skips (i - 1) * len elements from the beginning
            //and takes len elements, effectively selecting the items for the current page

            Data = data.Skip((i - 1) * len).Take(len).ToList();
            Total = data.Count();
        }

    }

}



//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace dashboard_api
//{
//    public class PaginatedResponse<T>
//    {
//        public readonly int Total;
//        public readonly IEnumerable<T> Data;

//        public PaginatedResponse(IEnumerable<T> data, int i, int len)
//        {
//            Data = GetPaginatedData(data, i, len);
//            Total = data.Count();
//        }

//        private IEnumerable<T> GetPaginatedData(IEnumerable<T> data, int pageIndex, int pageSize)
//        {
//            return data.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
//        }
//    }
//}

