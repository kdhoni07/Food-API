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
    public class DeleteAccount
    {
        dbServices ds = new dbServices();
      
        IConfiguration appsettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        
       
        public async Task<responseData> DeleteDocument(requestData req)
        {
            responseData resData= new responseData();
            resData.rData["rCode"]=0;
           
            try
            {
               

                MySqlParameter[] myParams = new MySqlParameter[] {
                new MySqlParameter("@ID",req.addInfo["ID"]),
                
                new MySqlParameter("@U_Status", 0)
                };
                var sq = $"UPDATE Food_Table SET U_Status=@U_Status WHERE ID=@ID ";
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
                     resData.rData["rMessage"] = "Document  Deleted";
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

