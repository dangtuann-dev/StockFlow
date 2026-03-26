using System.Data.SqlClient;

public class DBConnect
{
    private string connStr = "Data Source=LAPTOP-GTRAV33O\\SQLEXPRESS;Initial Catalog=StockFlowDB;Integrated Security=True";

    public SqlConnection GetConnection()
    {
        return new SqlConnection(connStr);
    }
}