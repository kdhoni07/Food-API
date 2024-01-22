 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace TokenApi.services
{
    public class OrderDelete
    {
       
        dbServices ds = new dbServices();
      
        IConfiguration appsettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        
        public async Task<responseData> DeleteOrder(requestData req)
        {
            responseData resData= new responseData();
            resData.rData["rCode"]=0;
           
            try
            {
               

                MySqlParameter[] myParams = new MySqlParameter[] {
                new MySqlParameter("@U_FID",req.addInfo["U_FID"]),
                 new MySqlParameter("@txt",req.addInfo["txt"]),
                new MySqlParameter("@ID",req.addInfo["ID"]),
                new MySqlParameter("@Status", 0)
                };
                var sq = $"UPDATE Food_FinalCart SET Status=@Status WHERE ID=@ID and U_FID=@U_FID and txt=@txt";
                var data = ds.executeSQL(sq, myParams);
                
                if (data==null)
                {
                    resData.rData["rCode"] = 1;
                    resData.rData["rMessage"] = "Error in Payload";
                }
                else
                {
                 resData.eventID=resData.eventID;
                   resData.rData["rCode"] = 0;
                     resData.rData["rMessage"] = "Account Deleted Sucessfully";
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


    








    


    
