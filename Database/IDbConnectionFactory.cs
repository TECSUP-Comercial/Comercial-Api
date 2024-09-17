using System.Data.Common;

namespace Comercial.Api.Database;

public interface IDbConnectionFactory
{
    ValueTask<DbConnection> OpenConnectionAsync();
}
