using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace ADO
{
    public class San
    {
        private string id;
        private string name, status;


        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public San(string id, string name, string status)
        {
            this.ID = id;
            this.Name = name;
            this.Status = status;
        }

        public San(DataRow row)
        {
            this.ID = row["MaSan"].ToString();
            this.Name = row["TenSan"].ToString();
            this.Status = row["Status"].ToString();
        }
    }
}
