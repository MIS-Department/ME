using System;
using System.Data;

namespace Shared.DataLayer.Interfaces
{
    public interface IDapperContext : IDisposable
    {
       IDbConnection Connection { get; }
    }
}
