namespace TableBooker
{
    public class TableBookerProcessor
    {
        public TableBooker BookTable(TableBooker request)
        {
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
