using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Ocsp;

namespace TokenApi.services
{
    public class FoodOnFavourite
    {
        dbServices ds = new dbServices();
         public async Task<responseData> ShowOnFavourite(requestData req)
        {
            responseData resData = new responseData();
            MySqlParameter[] items = new MySqlParameter[]{
                                  new MySqlParameter("@ID",req.addInfo["ID"]),
                                    new MySqlParameter("@Status",2)

            };
            try
            {
                  var result = new ArrayList();
// use for favourite to display data that has been added // no use if he needs will provide
                var query = $"Select * from Food_FinalCart where ID=@ID and Status=@Status ";
                var data = ds.ExecuteSQLName(query, items);
                if (data == null)
                {
                     resData.rData["rCode"] = 0;
                    resData.rData["rMessage"] = "You have added no data in the cart";
                }
                else
                {
 var list = new List<Dictionary<string, object>>();
                    for (var i = 0; i < data.Count(); i++)
                    {
                      foreach (var row in data[i])
                        {
                            Dictionary<string, object> myDict = new Dictionary<string, object>();

                            foreach (var field in row.Keys)
                            {
                                myDict[field] = row[field].ToString();
                            }

                            result.Add(myDict);
                        } 
                    }
                   resData.rData["rData"] =result;
                        resData.rData["rCode"] = 0;
                        resData.rData["rMessage"] = "The  favourite data has been displayed!!!";
                    }
                resData.rData["rCode"] = 0;
            
            }
            catch (Exception e)
            {
                resData.rData["rCode"] = 1;
                resData.rData["rMessage"] = e.Message;
            }
            return resData;
        }
    }
}















    


    
