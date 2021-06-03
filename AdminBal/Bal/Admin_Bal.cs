using AdminEntity.AdminModel;
using CompanyDal;
using FormBot.BAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBal.Bal
{
    public class Admin_Bal
    {
        SqlConnection con = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString));
        public Admin GetLoginDetails(Admin ObjAdmin)
        {
            String spName = "[admin_login]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            sqlParameters.Add(DBClient.AddParameters("Email", SqlDbType.VarChar, ObjAdmin.Email));
            sqlParameters.Add(DBClient.AddParameters("Password", SqlDbType.VarChar, ObjAdmin.Password));

            Admin LoginData = CommonDal.SelectObject<Admin>(spName, sqlParameters.ToArray());

            return LoginData;
        }

        public Admin GetAllCount()
        {
            string spName = "[admin_GetAllCount]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            Admin jobData = CommonDal.SelectObject<Admin>(spName, sqlParameters.ToArray());
            
            return jobData;
        }

        public List<Company> GetCompany()
        {
            string spName = "[admin_GetCompany]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            List<Company> companyData = CommonDal.ExecuteProcedure<Company>(spName, sqlParameters.ToArray()).ToList();

            return companyData;
        }

        public List<Users> GetUser()
        {
            string spName = "[admin_GetUser]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            List<Users> userData = CommonDal.ExecuteProcedure<Users>(spName, sqlParameters.ToArray()).ToList();

            return userData;
        }

        public Admin GetAdmminDataById(int Admin_id)
        {
            string spName = "[admin_FetchData]";

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("Admin_id", SqlDbType.Int, Admin_id));
            Admin adminData = CommonDal.SelectObject<Admin>(spName, sqlParameters.ToArray());

            return adminData;
        }

        public Admin Update_AdminInfo(Admin ObjAdmin)
        {
            string spName = "[admin_updateAdmin_info]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            sqlParameters.Add(DBClient.AddParameters("Admin_id", SqlDbType.Int, ObjAdmin.Admin_id));
            sqlParameters.Add(DBClient.AddParameters("Email", SqlDbType.VarChar, ObjAdmin.Email));
            sqlParameters.Add(DBClient.AddParameters("Mobileno", SqlDbType.VarChar, ObjAdmin.Mobileno));
            Admin AdminData = CommonDal.SelectObject<Admin>(spName, sqlParameters.ToArray());

            return AdminData;
        }

        public Admin ChangePassword(string Password, int Admin_id)
        {
            string spName = "[admin_ChangePassword]";
            
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("Admin_id", SqlDbType.Int, Admin_id));
            sqlParameters.Add(DBClient.AddParameters("Password", SqlDbType.VarChar, Password));
            Admin jobData = CommonDal.SelectObject<Admin>(spName, sqlParameters.ToArray());
            
            return jobData;
        }

        public void CompanyInctive(int Cmp_id)
        {
            string spName = "[admin_companyDisable]";

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("Cmp_id", SqlDbType.Int, Cmp_id));
            CommonDal.Crud(spName, sqlParameters.ToArray());
        }

        public List<JobPost> GetPostjobData()
        {
            string spName = "[admin_FetchJobData]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            List<JobPost> jobData = CommonDal.ExecuteProcedure<JobPost>(spName, sqlParameters.ToArray()).ToList();

            return jobData;
        }

        public JobPost GetPostedJobDetailsById(int job_id)
        {
            string spName = "[admin_FetchJobDataByID]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("job_id", SqlDbType.Int, job_id));
            JobPost jobData = CommonDal.SelectObject<JobPost>(spName, sqlParameters.ToArray());
            return jobData;
        }

        public List<Category> GetCategory()
        {
            string spName = "[admin_GetCategory]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            List<Category> jobData = CommonDal.ExecuteProcedure<Category>(spName, sqlParameters.ToArray()).ToList();
            return jobData;
        }

        public int AddCategory(Category ObjCategory)
        {
            try
            {
                string spName = "[admin_addCategory]";
                SqlCommand cmd = new SqlCommand(spName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cat_name", ObjCategory.cat_name);

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    cmd.Dispose();
                    con.Close();

                    return 1;
                }
                else
                {
                    cmd.Dispose();
                    con.Close();
                    return 0;
                }
            }
            catch
            {
                con.Close();
                throw;
            }
        }

        public Category GetCategoryDetailsById(int cat_id)
        {
            string spName = "[admin_GetCategoryById]";

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("cat_id", SqlDbType.Int, cat_id));
            Category cat = CommonDal.SelectObject<Category>(spName, sqlParameters.ToArray());

            return cat;
        }



        public City GetCityDetailsById(int City_id)
        {
            string spName = "[admin_GetCityById]";
            
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("City_id", SqlDbType.Int, City_id));
            City city = CommonDal.SelectObject<City>(spName, sqlParameters.ToArray());
            
            return city;
        }

        public Category EditCategory(Category ObjCategory) // passing Bussiness object Here  
        {
            string SpName = "[admin_UpdateCategory]";

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("cat_id", SqlDbType.VarChar, ObjCategory.cat_id));
            sqlParameters.Add(DBClient.AddParameters("cat_name", SqlDbType.VarChar, ObjCategory.cat_name));
            Category categoryData = CommonDal.SelectObject<Category>(SpName, sqlParameters.ToArray());

            return categoryData;
        }

        public City EditCity(City ObjCity) // passing Bussiness object Here  
        {
            string SpName = "[admin_UpdateCategory]";

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("cat_id", SqlDbType.VarChar, ObjCity.City_id));
            sqlParameters.Add(DBClient.AddParameters("cat_name", SqlDbType.VarChar, ObjCity.City_name));
            City cityData = CommonDal.SelectObject<City>(SpName, sqlParameters.ToArray());

            return cityData;
        }


        public void CategoryInactive(int cat_id)
        {
            string spName = "[admin_categoryDisable]";

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("cat_id", SqlDbType.Int, cat_id));
            CommonDal.Crud(spName, sqlParameters.ToArray());
        }

        public void UserInactive(int User_id)
        {
            string spName = "[admin_userDisable]";

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("User_id", SqlDbType.Int, User_id));
            CommonDal.Crud(spName, sqlParameters.ToArray());
        }

        public List<State> GetState()
        {
            string spName = "[admin_GetState]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            List<State> stateData = CommonDal.ExecuteProcedure<State>(spName, sqlParameters.ToArray()).ToList();

            return stateData;
        }

        public int AddState(State ObjState)
        {
            try
            {
                string spName = "[admin_addState]";
                SqlCommand cmd = new SqlCommand(spName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("State_name", ObjState.State_name);

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    cmd.Dispose();
                    con.Close();

                    return 1;
                }
                else
                {
                    cmd.Dispose();
                    con.Close();
                    return 0;
                }
            }
            catch
            {
                con.Close();
                throw;
            }
        }

        public State GetStateDetailsById(int State_id)
        {
            string spName = "[admin_GetStateById]";

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("State_id", SqlDbType.Int, State_id));
            State state = CommonDal.SelectObject<State>(spName, sqlParameters.ToArray());

            return state;
        }

        public State EditState(State ObjState)
        {
            string SpName = "[admin_UpdateState]";

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("State_id", SqlDbType.VarChar, ObjState.State_id));
            sqlParameters.Add(DBClient.AddParameters("State_name", SqlDbType.VarChar, ObjState.State_name));
            State stateData = CommonDal.SelectObject<State>(SpName, sqlParameters.ToArray());

            return stateData;
        }

        public List<City> GetCity()
        {
            string spName = "[admin_FetchCityData]";

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            List<City> cityData = CommonDal.ExecuteProcedure<City>(spName, sqlParameters.ToArray()).ToList();
            
            return cityData;
        }

        public List<Industry> GetIndustry()
        {
            string spName = "[admin_GetIndustry]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            List<Industry> industryData = CommonDal.ExecuteProcedure<Industry>(spName, sqlParameters.ToArray()).ToList();
            return industryData;
        }

        public int AddIndustry(Industry ObjIndustry)
        {
            try
            {
                string spName = "[admin_addIndustry]";
                SqlCommand cmd = new SqlCommand(spName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("industry_name", ObjIndustry.industry_name);

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    cmd.Dispose();
                    con.Close();

                    return 1;
                }
                else
                {
                    cmd.Dispose();
                    con.Close();
                    return 0;
                }
            }
            catch
            {
                con.Close();
                throw;
            }
        }

        public void IndustryInactive(int ind_id)
        {
            string spName = "[admin_industryDisable]";

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("ind_id", SqlDbType.Int, ind_id));
            CommonDal.Crud(spName, sqlParameters.ToArray());
        }

        public Industry GetIndustryDetailsById(int ind_id)
        {
            string spName = "[admin_GetIndustryById]";

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("ind_id", SqlDbType.Int, ind_id));
            Industry ind = CommonDal.SelectObject<Industry>(spName, sqlParameters.ToArray());

            return ind;
        }

        public Industry EditIndustry(Industry ObjIndustry)
        {
            string SpName = "[admin_UpdateIndustry]";

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("ind_id", SqlDbType.VarChar, ObjIndustry.ind_id));
            sqlParameters.Add(DBClient.AddParameters("industry_name", SqlDbType.VarChar, ObjIndustry.industry_name));
            Industry industryData = CommonDal.SelectObject<Industry>(SpName, sqlParameters.ToArray());

            return industryData;
        }

        public void AddCity(City ObjCity)
        {
            string spName = "[admin_AddCity]";

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("State_id", SqlDbType.Int, ObjCity.State_id));
            sqlParameters.Add(DBClient.AddParameters("City_name", SqlDbType.VarChar, ObjCity.City_name));
           
            CommonDal.Crud(spName, sqlParameters.ToArray());
        }

        public Admin GetForgotPassword(Admin ObjAdmin)
        {
            string spName = "[admin_ForgotPassword]";
            
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("Email", SqlDbType.VarChar, ObjAdmin.Email));
            Admin adminData = CommonDal.SelectObject<Admin>(spName, sqlParameters.ToArray());
            
            return adminData;
        }

        public void JobpostInactive(int job_id)
        {
            string spName = "[admin_JobpostDisable]";

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("job_id", SqlDbType.Int, job_id));
            CommonDal.Crud(spName, sqlParameters.ToArray());
        }

    }
}
