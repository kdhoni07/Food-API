using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
  using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
namespace TokenApi.services
{
    public class ForgetPassword
    {
         

        dbServices ds = new dbServices();
        IConfiguration appsettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        
        public async Task<responseData> PasswordForget(requestData req)
        {
            responseData resData= new responseData();
            resData.rData["rCode"]=0;
            try
            {
            MySqlParameter[] para = new MySqlParameter[] {
                // new MySqlParameter("@ID", req.addInfo["ID"]),
                new MySqlParameter("@U_Mobile",req.addInfo["U_Mobile"].ToString()),
                new MySqlParameter("@New_Password",req.addInfo["New_Password"].ToString())

                };
                var sql=$"select * from Food_Table where U_Mobile=@U_Mobile;";
                var check = ds.ExecuteSQLName(sql, para);

                if(check!=null && check[0].Count()>0)
                {
                    var query1=$"update Food_Table set U_Password=@New_Password where U_Mobile=@U_Mobile";
                    var update = ds.executeSQL(query1, para);


                    if(update!=null)
                    {
                        resData.eventID = req.eventID;
                         resData.rData["rCode"] = 0;
                        resData.rData["rMessage"] = " New Password created Successfully";
                    }
                    else
                    {

                        resData.rData["rCode"] = 1;
                        resData.rData["rMessage"] = "Enter valid new password ";

                    }
                }
                else
                {
                   
                    resData.rData["rCode"] = 1;
                    resData.rData["rMessage"]=" Oops... Error in Mobile Number ";
                   
                }
                
            }
            catch (Exception ex)
            {
                resData.rData["rCode"]=1;
                resData.rData["rMessage"]=ex.Message;
            }
            return resData;
        }
    }
}
    

