using Ejer2_4Michelle.Models;
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace Ejer2_4Michelle.Controller
{
    public class DataBase
    {
        readonly SQLiteAsyncConnection dbase;

        public DataBase(string path)
        {
            dbase = new SQLiteAsyncConnection(path);

            dbase.CreateTableAsync<grabar>();
        }

        public DataBase()
        {
        }

        #region OperacionesVideo
        //Metodos CRUD - CREATE
        public Task<int> insertUpdateVideo(grabar video)
        {
            if (video.Id != 0)
            {
                return dbase.UpdateAsync(video);
            }
            else
            {
                return dbase.InsertAsync(video);
            }
        }

        //Metodos CRUD - READ
        public Task<List<grabar>> getListVideo()
        {
            return dbase.Table<grabar>().ToListAsync();
        }

        public Task<grabar> getVideo(int id)
        {
            return dbase.Table<grabar>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        //Metodos CRUD - DELETE
        public Task<int> deleteVideo(grabar video)
        {
            return dbase.DeleteAsync(video);
        }

        #endregion OperacionesVideo

    }
}
