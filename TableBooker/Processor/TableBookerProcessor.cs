using System;

namespace TableBooker
{
    public class TableBookerProcessor
    {
        public TableBooker BookTable(TableBooker request)
        {
            if (request == null) throw new ArgumentNullException("request");

            return new TableBooker
            {
                Name = request.Name,
                LastName = request.LastName,
                Email = request.Email,
                BookerDate = request.BookerDate
            };
        }
    }
}
