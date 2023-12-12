using Microsoft.Data.SqlClient.Server;
using NewWeb.DataModel;
using NewWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NewWeb.DataAccess
{
    public class DAUser
    {
        private readonly TestContext db;
        private VMResponse response = new VMResponse();
        public DAUser(TestContext _db)
        {
            db = _db;
            VMResponse response = new VMResponse();
        }
        public VMTblUser? FindById(int id)
        {
            return (
                from u in db.TblUsers
                where u.Id == id
                select new VMTblUser
                {
                    Id = u.Id,
                    nama_lengkap = u.NamaLengkap,
                    username = u.Username,
                    password = u.Password,
                    status = u.Status,
                }
                ).FirstOrDefault();
        }
        public VMResponse GetAll()
        {
            try
            {
                List<VMTblUser> data = (
                    from u in db.TblUsers
                    select new VMTblUser
                    {
                        Id = u.Id,
                        nama_lengkap = u.NamaLengkap,
                        username = u.Username,
                        password = u.Password,
                        status = u.Status,
                    }
                    ).ToList();

                response.data = data;
                response.message = (data.Count > 0)
                    ? $"Data ditemukan"
                    : $"Data tidak ada";
                response.statusCode = (data.Count > 0)
                    ? HttpStatusCode.OK
                    : HttpStatusCode.NoContent;
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
            }
            return response;
        }
        public VMResponse Create(VMTblUser formData)
        {
            try
            {
                TblUser data = new TblUser();

                data.NamaLengkap = formData.nama_lengkap;
                data.Username = formData.username;
                data.Password = formData.password;
                data.Status = "A";

                db.Add(data);
                db.SaveChanges();
                response.statusCode = HttpStatusCode.Created;
                response.message = "Data Berhasil dibuat";
                response.data = data;
            }
            catch(Exception ex)
            {
                response.message = ex.Message;
            }
            finally { db.Dispose(); }
            return response;
        }
        public VMResponse Update(VMTblUser formData)
        {
            try
            {
                TblUser data = new TblUser();
                VMTblUser? existingData = FindById(formData.Id);

                data.Id = existingData.Id;
                data.NamaLengkap = formData.nama_lengkap;
                data.Username = formData.username;
                data.Password = formData.password;
                data.Status = "U";

                db.Update(data);
                db.SaveChanges();
                response.statusCode = HttpStatusCode.OK;
                response.message = "Data berhasil diubah";
                response.data = data;
            }
            catch(Exception ex)
            {
                response.message = ex.Message + "data gagal diubah";
                response.statusCode = HttpStatusCode.NoContent;
            }
            finally { db.Dispose(); }
            return response;
        }
        public VMResponse Delete(int id)
        {
            try
            {
                VMTblUser existingData = FindById(id);

                if (existingData != null)
                {
                    TblUser data = new TblUser();

                    data.Id = existingData.Id;
                    data.NamaLengkap = existingData.nama_lengkap;
                    data.Username = existingData.username;
                    data.Password = existingData.password;
                    data.Status = "D";

                    db.Update(data);
                    db.SaveChanges();

                    response.data = data;
                    response.message = "Data User Berhasil dihapus";
                    response.statusCode = HttpStatusCode.OK;
                }
                else
                {
                    throw new Exception("Data User tidak ada");
                }
            }
            catch (Exception ex)
            {
                response.message += $"{ex.Message}";
            }
            return response;
        }
    }
}
