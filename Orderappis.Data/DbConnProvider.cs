using Npgsql;
using System.Data;
using System.Net;

namespace Orderis.Data
{
    internal class DbConnSettingsModel
    { 
        public String ConnStr { get; set; } = "";
    }

    internal class DbConnSettings
    {
        public static DbConnSettingsModel? LoadModel() {
            try
            {
                byte[] asciiBytes = new byte[]
                {
                    72,111,115,116,61,108,111,99,97,108,104,111,115,116,59,
                    68,97,116,97,98,97,115,101,61,111,114,100,101,114,97,
                    112,112,105,115,59,85,115,101,114,110,97,109,101,61,
                    111,114,100,101,114,97,112,112,105,115,95,99,108,105,
                    101,110,116,59,80,97,115,115,119,111,114,100,61,65,115,
                    97,49,50,51,113,121,120,33
                };
                string constrDat = System.Text.Encoding.ASCII.GetString(asciiBytes);

                var model = new DbConnSettingsModel();
                model.ConnStr = constrDat;
                return model;
            } 
            catch 
            {
                return null; 
            }
        }
    }

    public class DbConnConfig
    {
        private static DbConnConfig? _instance;
        public static DbConnConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DbConnConfig();
                }
                return _instance;
            }
        }

        public string Host { get; set; } = "localhost";
    }

    public class DbConnProvider
    {
        private readonly DbConnSettingsModel? _connSettingsModel;
        private static DbConnProvider? _instance;
        private readonly NpgsqlConnection _conn;

        private DbConnProvider()
        {
            var model = DbConnSettings.LoadModel();
            string conn_str = "";
            if (model != null)
            {
                _connSettingsModel = model;
                conn_str = _connSettingsModel.ConnStr;
            }
            string host = DbConnConfig.Instance.Host;
            if (host != "localhost")
            {
                if (IPAddress.TryParse(host, out IPAddress? ipv4))
                {
                    conn_str = conn_str.Replace("localhost", host);
                }
            }
            _conn = new NpgsqlConnection(conn_str);
        }

        public static void ResetInstance()
        {
            _instance = null;
        }

        public static DbConnProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DbConnProvider();
                }
                return _instance;
            }
        }

        public NpgsqlConnection Conn
        {
            get
            {
                if (_conn.State != ConnectionState.Open)
                    _conn.Open();

                return _conn;
            }
        }

        public void ConnClose()
        {
            if (_conn.State != ConnectionState.Closed)
                _conn.Close();
        }

    }
}
