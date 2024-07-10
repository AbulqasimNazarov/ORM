using System.Data.SqlClient;
using Dapper;
using InkHouse.Models;
using InkHouse.Repositories.Base;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace InkHouse.Repositories
{
    public class PaintingDapperRepository : IPaintingRepository
    {
        private readonly string connectionString;
        System.Data.SqlClient.SqlConnection? connection;

        public PaintingDapperRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("MsSqlServer");
            this.connection = new SqlConnection(this.connectionString);
        }

        public async Task CreateAsync(Painting obj, IFormFile image)
        {
            obj.PaintingId = Guid.NewGuid();

            var extension = Path.GetExtension(image.FileName)[1..];
            obj.Image = $"Assets/PaintingImg/{obj.PaintingId}.{extension}";

            using var newFileStream = System.IO.File.Create(obj.Image);
            await image.CopyToAsync(newFileStream);


            //using var connection = new SqlConnection(this.connectionString);
            var sql = @"INSERT INTO Paintings (PaintingId, Image, Name, Title, Price, PainterId)
                VALUES (@PaintingId, @Image, @Name, @Title, @Price, @PainterId)";
            await this.connection.ExecuteAsync(sql, new
            {
                obj.PaintingId,
                obj.Image,
                obj.Name,
                obj.Title,
                obj.Price,
                obj.PainterId
            });
        }


        public async Task DeleteByIdAsync(Guid id)
        {
            //using var connection = new SqlConnection(this.connectionString);
            var sql = "DELETE FROM Paintings WHERE PaintingId = @Id";
            await this.connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<Painting>> GetAllAsync()
        {
            //using var connection = new SqlConnection(this.connectionString);
            var sql = @"
                        SELECT 
                            p.PaintingId, p.Image, p.Name, p.Title, p.Price, p.PainterId, 
                            pa.Id, pa.Name, pa.Surname
                        FROM Paintings p
                        INNER JOIN Painters pa ON p.PainterId = pa.Id";

            var paintings = await this.connection.QueryAsync<Painting, Painter, Painting>(
                sql,
                (painting, painter) =>
                {
                    painting.Painter = painter;
                    return painting;
                },
                splitOn: "PainterId"
            );

            return paintings;
        }




        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            //using var connection = new SqlConnection(this.connectionString);
            return await this.connection.QueryAsync<Country>("SELECT * FROM Countries");
        }

        public async Task<IEnumerable<Painter>> GetAllPaintersAsync()
        {
            //using var connection = new SqlConnection(this.connectionString);
            return await this.connection.QueryAsync<Painter>("SELECT * FROM Painters");
        }

        public async Task<Painting> GetByIdAsync(Guid id)
        {
            //using var connection = new SqlConnection(this.connectionString);
            var sql = "SELECT * FROM Paintings WHERE PaintingId = @Id";
            return await this.connection.QueryFirstOrDefaultAsync<Painting>(sql, new { Id = id });
        }

        public async Task UpdateAsync(Painting painting)
        {
            //using var connection = new SqlConnection(this.connectionString);
            var sql = "UPDATE Paintings SET Name = @Name, Title = @Title, PainterId = @PainterId, Price = @Price WHERE PaintingId = @PaintingId";
            await this.connection.ExecuteAsync(sql, new
            {
                painting.Name,
                painting.Title,
                painting.PainterId,
                painting.Price,
                painting.PaintingId
            });
        }
    }
}
