using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InstituteMVC.DAL
{
    public class DAO
    {
        public DAO()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //public bool AuthenticateUser(string userid, string pass)
        //{
        //    MIS4BOSEntities dbents = new MIS4BOSEntities();

        //    try
        //    {
        //        //string userpwd = (from u in dbents.UserAccounts
        //        //                  where (u.userid == userid && u.isaccactivated == true)
        //        //                  select u.password).Single();
        //        //dbents.Dispose();
        //        //if (userpwd == pass)
        //        //    return true;
        //        //else
        //        //    return false;
        //    }
        //    catch (InvalidOperationException)
        //    {
        //        dbents.Dispose();
        //        return false;
        //    }

        //}
        public void UpdateTableAgainstNewRollNo(List<string> parameter, string sqlText)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["JMCConnectionString"].ToString());
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlText, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cr", parameter[0].ToString());
                cmd.Parameters.AddWithValue("@prevCr", parameter[1].ToString());
                cmd.Parameters.AddWithValue("@sdate", parameter[2].ToString());
                cmd.ExecuteNonQuery();

            }
            catch
            {

            }
            finally { conn.Close(); }
        }



        public DataTable ParaMeterizedStoreProcedure(string sqlText)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["JMCConnectionString"].ToString());
            try
            {
                DataTable dt = new DataTable();
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlText, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { conn.Close(); }
        }

        public int QueryWithParameter(List<string> parameter, string sqlText)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["JMCConnectionString"].ToString());
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlText, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@classId", parameter[0].ToString());
                cmd.Parameters.AddWithValue("@classNameOrClassCode", parameter[1].ToString());
                cmd.Parameters.AddWithValue("@time", parameter[2].ToString());
                cmd.Parameters.AddWithValue("@sdate", parameter[3].ToString());
                cmd.Parameters.AddWithValue("@status", parameter[4].ToString());
                int ii = cmd.ExecuteNonQuery();
                return ii;
            }
            catch
            {
                return 0;
            }
            finally { conn.Close(); }
        }



        public int UpdateDB(string sqlText)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["JMCConnectionString"].ToString());
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlText, conn);
                int ii = cmd.ExecuteNonQuery();
                return ii;
            }
            catch
            {
                return 0;
            }
            finally { conn.Close(); }
        }




        public string GetSingle(string sql)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["JMCConnectionString"].ToString());
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);

                string strValue = null;
                if ((strValue = cmd.ExecuteScalar().ToString()) != null)
                    return strValue;
                else
                    return null;
            }
            catch
            {
                return null;
            }
            finally
            { conn.Close(); }
        }

        public List<string> GetRow(string sql)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["JMCConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            List<string> vals = new List<string>();
            while (rdr.Read())
            {
                for (int i = 0; i < rdr.FieldCount; i++)
                    vals.Add(rdr[i].ToString());

                break;
            }

            return vals;
        }

        public DataSet FillGrid(string sql)
        {
            DataSet subjects = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["JMCConnectionString"].ToString()))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    adapter.Fill(subjects);
                    return subjects;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataTable getdataTable(string sql)
        {
            DataTable subjects = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["JMCConnectionString"].ToString()))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    adapter.Fill(subjects);
                    return subjects;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        //public void FillDropDown(string sql, DropDownList ddl, string disp, string val)
        //{
        //    DataTable subjects = new DataTable();
        //    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString()))
        //    {
        //        try
        //        {
        //            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
        //            adapter.Fill(subjects);
        //            ddl.DataSource = subjects;
        //            ddl.DataTextField = disp;
        //            ddl.DataValueField = val;
        //            ddl.DataBind();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}

        public string GetStationName(string uid)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
            try
            {
                conn.Open();
                string sql = "Select stationname from Station Where stationid=(Select "
                + "userstationid from UserAccount Where userid='" + uid + "')";
                SqlCommand cmd = new SqlCommand(sql, conn);
                string strValue = null;
                if ((strValue = cmd.ExecuteScalar().ToString()) != null)
                    return strValue;
                else
                    return null;
            }
            catch
            {
                return null;
            }
            finally
            { conn.Close(); }
        }
        public bool DoTrans(List<string> sqlz)
        {
            int successcount = 0;
            bool rv = false;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MIS4BOSConnectionString"].ToString());
            SqlCommand cmd;
            SqlTransaction transaction;
            conn.Open();
            transaction = conn.BeginTransaction();
            foreach (string qry in sqlz)
            {
                cmd = new SqlCommand(qry, conn, transaction);
                cmd.ExecuteNonQuery();
                successcount++;
            }

            if (successcount == sqlz.Count)
            {
                transaction.Commit();
                rv = true;
            }
            else
            {
                transaction.Rollback();
                rv = false;
            }

            return rv;
        }
        //public bool IsUserNameAvailable(string username)
        //{
        //    misbosco_DBEntities dbents = new misbosco_DBEntities();
        //    var usernamefromDB = (from u in dbents.UserAccounts
        //                          where u.userid == username
        //                          select u.userid).SingleOrDefault();

        //    if (usernamefromDB == null)
        //        return true;
        //    else
        //        return false;
        //}

    } // Class end
}