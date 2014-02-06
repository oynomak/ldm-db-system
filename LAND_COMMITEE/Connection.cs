using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace LAND_COMMITEE
{
    class Connection
    {
        private String connectionString;
        private String databaseName;
        private SqlConnection con;
        private SqlCommand SQLcom;
        private SqlDataAdapter SQLda;
        private DataSet ds;
        private DataView dv;
        private SqlDataReader reader;

        public String DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }
        private String serverName;

        public String ServerName
        {
            get { return serverName; }
            set { serverName = value; }
        }

        public DataSet Ds
        {
            get { return ds; }
            set { ds = value; }
        }

        public SqlConnection getCurrentConnection() {
            return con;
        }

        public String ConnectionString
        {
            get { return connectionString; }
            set
            {
                connectionString = value;
                con = new SqlConnection(connectionString);
            }
        }

        public void executeMyQuery(String myQuery)
        {
            try
            {
                //con = new SqlConnection(connectionString);
                con.Open();
                SQLcom = new SqlCommand(myQuery, con);
                SQLcom.ExecuteNonQuery();
                SQLcom.Dispose();
            }
            catch (Exception ex)
            { }
            finally
            {
                con.Close();
            }
        }

        public object executeMyMethod(String myQuery)
        {
            try
            {
                //con = new SqlConnection(connectionString);
                con.Open();
                SQLcom = new SqlCommand(myQuery, con);
                return SQLcom.ExecuteScalar();
            }
            catch (Exception ex)
            {
                return "";
            }
            finally
            {
                con.Close();
            }
        }

        public DataView getDataView(String myQuery, string dataSetTableName)
        {
            try
            {
                con.Open();
                SQLda = new SqlDataAdapter(myQuery, con);
                Ds = new DataSet();
                SQLda.Fill(Ds, dataSetTableName);
                dv = new DataView(Ds.Tables[dataSetTableName]);
                con.Close();
                return dv;
            }
            catch (Exception ex)
            {
                return new DataView();
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet getDataSet(String myQuery, string dataSetTableName)
        {
            try
            {
                con.Open();
                SQLda = new SqlDataAdapter(myQuery, con);
                DataSet ds = new DataSet();
                SQLda.Fill(ds, dataSetTableName);
                con.Close();
                return ds;
            }
            catch (Exception ex)
            {
                return new DataSet();
            }
            finally
            {
                con.Close();
            }
        }

        public List<string> getListOfIdentifier(String myQuery)
        {
            try
            {
                List<string> myList = new List<string>();

                con.Open();
                SQLcom = new SqlCommand(myQuery, con);
                reader = SQLcom.ExecuteReader();

                while (reader.Read())
                {
                    myList.Add(reader.GetValue(0).ToString());
                }

                return myList;
            }
            catch (Exception ex)
            {
                return new List<string>();
            }
            finally
            {
                reader.Close();
                con.Close();
            }
        }
    }
}
