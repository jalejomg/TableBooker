using System;
using TableBooker.Repositories;

namespace TableBooker
{
    public class TableBookerProcessor
    {
        public ITableBookerRepository _tableBookerRepository { get; }
        public TableBookerProcessor(ITableBookerRepository tableBookerRepository)
        {
            _tableBookerRepository = tableBookerRepository;
        }
        public TableBooking BookTable(TableBooking request)
        {
            if (request == null) throw new ArgumentNullException("request");

            _tableBookerRepository.Save(request);

            return new TableBooking
            {
                Name = request.Name,
                LastName = request.LastName,
                Email = request.Email,
                BookerDate = request.BookerDate
            };
        }
    }
}
