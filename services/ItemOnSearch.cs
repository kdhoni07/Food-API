using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace TokenApi.services
{
    public class ItemOnSearch
    {

        dbServices ds = new dbServices();
        public async Task<responseData> GetImageOnSearch(requestData req){
            responseData resData = new responseData();
            MySqlParameter[] items = new MySqlParameter[]{
                                    
            };
            try{
                var result= new ArrayList();
        var document = new Dictionary<string,object>();
            var query ="select * from Food_Image";
            var data = ds.ExecuteSQLName(query,items);
            if(data==null){
resData.rData["rCode"]=1;
resData.rData["rMessage"]="Error in payload";
            }
            else{
        
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
                  
                  }
                   
             
               resData.rData["rData"] =result;
                    //  resData.rData["ID"] = data[0][0]["ID"];
                   resData.rData["rCode"]=0;
                     resData.rData["rMessage"] = "displayed data";

            
        }
            catch(Exception e){
             resData.rData["rCode"]=1;
             resData.rData["rMessage"]=e.Message;
            }
            return resData;
        }
    
    }
}