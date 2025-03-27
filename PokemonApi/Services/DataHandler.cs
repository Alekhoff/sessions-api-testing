using System.Data;
using Microsoft.Data.SqlClient;

namespace PokemonApi.Services;

public class DataHandler
{
    private const string ConnectionString = "Server=localhost;Database=TechSessions;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;";

    public async Task<DataTable> GetDataAsync<T>(SqlCommand pCommand, CancellationToken ct)
    {
        await using var vConn = GetConnection();
        try
        {
            await vConn.OpenAsync(ct);
            pCommand.Connection = vConn;
            var vAdapter  = new SqlDataAdapter(pCommand);
            var vDataTable = new DataTable();
            
            vAdapter.Fill(vDataTable);

            return vDataTable;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            await vConn.CloseAsync();
        }
    } 
    public async Task<int> PostDataAsync<T>(SqlCommand pCommand, CancellationToken ct)
    {
        await using var vConn = GetConnection();
        try
        {
            await vConn.OpenAsync(ct);
            pCommand.Connection = vConn;

            var vInsertedRows = await pCommand.ExecuteNonQueryAsync(ct);

            return vInsertedRows;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            await vConn.CloseAsync();
            
        }
    }
    public async Task<int> PostDataAsync(DataTable pTable, string pDestionationTable, CancellationToken ct)
    {
        await using var vConn = GetConnection();
        try
        {
            await vConn.OpenAsync(ct);

            var vColumnNames = pTable.Columns.Cast<DataColumn>().Select(pCol => pCol.ColumnName).ToArray();
            
            var vCommand = new SqlCommand();
            vCommand.Connection = vConn;
            vCommand.CommandText = $"INSERT INTO {pDestionationTable} ({string.Join(",", vColumnNames)}) VALUES ({string.Join(",", Enumerable.Repeat("@", vColumnNames.Length))})";
            
            var vInsertedRows = await vCommand.ExecuteNonQueryAsync(ct);
            return vInsertedRows;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            await vConn.CloseAsync();
            
        }
    }
    private static SqlConnection GetConnection() =>
        new SqlConnection(ConnectionString);
}