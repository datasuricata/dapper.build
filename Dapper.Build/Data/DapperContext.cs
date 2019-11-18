using System;
using System.Data;
using System.Diagnostics;
using Microsoft.Data.SqlClient;

namespace Dapper.Build.Data {
    public class DapperContext : IDisposable {

        private Lazy<IDbConnection> _connectionLazy;
        public IDbConnection Connection => _connectionLazy.Value;

        public DapperContext () {
            _connectionLazy = new Lazy<IDbConnection> (() => {
                var conn = new SqlConnection ("Server=.\\sqlexpress;Database=dapper-local;Trusted_Connection=True;");
                OpenConnectionService ();
                return conn;
            });
        }
        private bool OpenConnectionService () {
            try {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open ();
                return true;
            } catch (Exception ex) {
                Debug.WriteLine (ex.Message);
                return false;
            }
        }
        public void Dispose () {
            if (_connectionLazy.IsValueCreated) {
                Connection.Dispose ();
            }
        }
    }
}