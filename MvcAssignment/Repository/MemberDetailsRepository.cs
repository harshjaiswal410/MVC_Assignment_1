using MvcAssignment.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAssignment.Repository
{
    public class MemberDetailsRepository
    {
        string Address = "Data Source = DESKTOP-8T78S35; Initial Catalog = MembarData; Integrated Security = SSPI";
        public void getUserData(RegistrationModel objRegistrationModel)
        {
            
            try
            {
                SqlConnection connect = new SqlConnection(Address);
                connect.Open();

                SqlCommand cmd = new SqlCommand("SP_FormData", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FName", objRegistrationModel.FirstName);
                cmd.Parameters.AddWithValue("@LName", objRegistrationModel.LastName);
                cmd.Parameters.AddWithValue("@EMail", objRegistrationModel.Email);
                cmd.Parameters.AddWithValue("@RollNo", objRegistrationModel.RollNo);



                int x = cmd.ExecuteNonQuery();

                connect.Close();
            }
            catch (Exception ex)
            {

            }
        }
        public List<GenderModel> GetGender()
        {
            List<GenderModel> GenderNameList = new List<GenderModel>();
            SqlConnection connect = new SqlConnection(Address);
            connect.Open();

            SqlCommand cmd = new SqlCommand("Sp_Gender", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader read1 = cmd.ExecuteReader();

            while(read1.Read())
            {
                GenderModel objGenderModel = new GenderModel();

                objGenderModel.ID = Convert.ToInt32(read1["ID"]);
                objGenderModel.Gender = read1["G_Type"].ToString();
                GenderNameList.Add(objGenderModel);
            }
            return GenderNameList;
        }

        public List<CourceModel> GetCource()
        {
            List<CourceModel> CourceNameList = new List<CourceModel>();
            SqlConnection connect = new SqlConnection(Address);
            connect.Open();

            SqlCommand cmd = new SqlCommand("Sp_Cources", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader read2 = cmd.ExecuteReader();

            while (read2.Read())
            {
                CourceModel objCourceModel = new CourceModel();

                objCourceModel.Cource_id = Convert.ToInt32(read2["C_id"]);
                objCourceModel.Cource_name = read2["C_name"].ToString();
                CourceNameList.Add(objCourceModel);
            }
            return CourceNameList;
        }
        public List<StateModel> GetState()
        {
            List<StateModel> StateNameList = new List<StateModel>();
            SqlConnection connect = new SqlConnection(Address);
            connect.Open();

            SqlCommand cmd = new SqlCommand("SP_StateName", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader read3 = cmd.ExecuteReader();

            while (read3.Read())
            {
                StateModel objStateModel = new StateModel();

                objStateModel.State_id = Convert.ToInt32(read3["S_id"]);
                objStateModel.State_name = read3["S_Name"].ToString();
                StateNameList.Add(objStateModel);
            }
            return StateNameList;
        }
        public List<SelectListItem> GetCity(int NewStateid)
        {
            List<SelectListItem> CityNameList = new List<SelectListItem>();
            try
            {
                SqlConnection connect = new SqlConnection(Address);
                SqlCommand cmd = new SqlCommand("SP_CityName", connect);
                connect.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@state_ID", NewStateid);
                SqlDataReader read4 = cmd.ExecuteReader();

                while (read4.Read())
                {
                    CityNameList.Add(new SelectListItem()
                    { 
                        Text = read4["C_Name"].ToString(),
                        Value = read4["C_id"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {

            }
            
            return CityNameList;

        }
    }
}