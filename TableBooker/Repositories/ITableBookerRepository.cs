namespace TableBooker.Repositories
{
    public interface ITableBookerRepository
    {
        TableBooking Save(TableBooking tableBooker);
    }
}
