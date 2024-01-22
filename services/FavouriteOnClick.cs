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
    public class Favourite
    {
        dbServices ds = new dbServices();
         public async Task<responseData> AddToFavourite(requestData req)
        {
            responseData resData = new responseData();
            MySqlParameter[] items = new MySqlParameter[]{
                 new MySqlParameter("@U_FID",req.addInfo["U_FID"]),
                 new MySqlParameter("@ID",req.addInfo["ID"]),
                  new MySqlParameter("@txt",req.addInfo["txt"]),
                 new MySqlParameter("@Status",2)
            };
            try
            {
            var result = new ArrayList();
var query1 = $"Update Food_FinalCart set Status=@Status where ID=@ID and U_FID=@U_FID and txt=@txt";
                var checkData1 = ds.executeSQL(query1, items);
               if(checkData1==null){
                    resData.rData["rCode"] = 1;
                    resData.rData["rMessage"] = "You have no data in the favourites";
               }
               else{
                  
                     resData.rData["rMessage"] = "displayed data";
                        resData.rData["rMessage"] = "Sucessfully added to favourites";
                    }
               
            }
            catch (Exception e)
            {
                resData.rData["rCode"] = 1;
                resData.rData["rMessage"] = e.Message;
            }
            return resData;
        }
         public async Task<responseData> AddToFavouritePizza(requestData req)
        {
            responseData resData = new responseData();
            MySqlParameter[] items = new MySqlParameter[]{
                 new MySqlParameter("@U_FID",req.addInfo["U_FID"]),
                 new MySqlParameter("@ID",req.addInfo["ID"]),
                  new MySqlParameter("@txt",req.addInfo["txt"]),
                 new MySqlParameter("@Status",2)
            };
            try
            {
            var result = new ArrayList();
var query1 = $"Update Food_FinalCart set Status=@Status where ID=@ID and U_FID=@U_FID and txt=@txt";
                var checkData1 = ds.executeSQL(query1, items);
               if(checkData1==null){
                    resData.rData["rCode"] = 1;
                    resData.rData["rMessage"] = "You have no data in the favourites";
               }
               else{
                  
                     resData.rData["rMessage"] = "displayed data";
                        resData.rData["rMessage"] = "Sucessfully added to favourites";
                    }
               
            }
            catch (Exception e)
            {
                resData.rData["rCode"] = 1;
                resData.rData["rMessage"] = e.Message;
            }
            return resData;
        }
         public async Task<responseData> AddToFavouritePasta(requestData req)
        {
            responseData resData = new responseData();
            MySqlParameter[] items = new MySqlParameter[]{
                 new MySqlParameter("@U_FID",req.addInfo["U_FID"]),
                 new MySqlParameter("@ID",req.addInfo["ID"]),
                  new MySqlParameter("@txt",req.addInfo["txt"]),
                 new MySqlParameter("@Status",2)
            };
            try
            {
            var result = new ArrayList();
var query1 = $"Update Food_FinalCart set Status=@Status where ID=@ID and U_FID=@U_FID and txt=@txt";
                var checkData1 = ds.executeSQL(query1, items);
               if(checkData1==null){
                    resData.rData["rCode"] = 1;
                    resData.rData["rMessage"] = "You have no data in the favourites";
               }
               else{
                  
                     resData.rData["rMessage"] = "displayed data";
                        resData.rData["rMessage"] = "Sucessfully added to favourites";
                    }
               
            }
            catch (Exception e)
            {
                resData.rData["rCode"] = 1;
                resData.rData["rMessage"] = e.Message;
            }
            return resData;
        }
         public async Task<responseData> AddToFavouriteSalad(requestData req)
        {
            responseData resData = new responseData();
            MySqlParameter[] items = new MySqlParameter[]{
                 new MySqlParameter("@U_FID",req.addInfo["U_FID"]),
                 new MySqlParameter("@ID",req.addInfo["ID"]),
                  new MySqlParameter("@txt",req.addInfo["txt"]),
                 new MySqlParameter("@Status",2)
            };
            try
            {
            var result = new ArrayList();
var query1 = $"Update Food_FinalCart set Status=@Status where ID=@ID and U_FID=@U_FID and txt=@txt";
                var checkData1 = ds.executeSQL(query1, items);
               if(checkData1==null){
                    resData.rData["rCode"] = 1;
                    resData.rData["rMessage"] = "You have no data in the favourites";
               }
               else{
                  
                     resData.rData["rMessage"] = "displayed data";
                        resData.rData["rMessage"] = "Sucessfully added to favourites";
                    }
               
            }
            catch (Exception e)
            {
                resData.rData["rCode"] = 1;
                resData.rData["rMessage"] = e.Message;
            }
            return resData;
        }
         public async Task<responseData> AddToFavouriteBurger(requestData req)
        {
            responseData resData = new responseData();
            MySqlParameter[] items = new MySqlParameter[]{
                 new MySqlParameter("@U_FID",req.addInfo["U_FID"]),
                 new MySqlParameter("@ID",req.addInfo["ID"]),
                  new MySqlParameter("@txt",req.addInfo["txt"]),
                 new MySqlParameter("@Status",2)
            };
            try
            {
            var result = new ArrayList();
var query1 = $"Update Food_FinalCart set Status=@Status where ID=@ID and U_FID=@U_FID and txt=@txt";
                var checkData1 = ds.executeSQL(query1, items);
               if(checkData1==null){
                    resData.rData["rCode"] = 1;
                    resData.rData["rMessage"] = "You have no data in the favourites";
               }
               else{
                  
                     resData.rData["rMessage"] = "displayed data";
                        resData.rData["rMessage"] = "Sucessfully added to favourites";
                    }
               
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


    
