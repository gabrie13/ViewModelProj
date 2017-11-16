using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViewModelEx.Models;
using System.Data.Entity;
namespace ViewModelEx.Services
{
    public class PositionService : IPositionService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<PositionViewModel> GetAll()
        {
            var positionList = db.Positions.ToList();
            return positionList.Select(pos => PosDto(pos)).ToList();
        }

        private static PositionViewModel PosDto(Position pos)
        {
            return new PositionViewModel
            {
                PositionId = pos.PositionId,
                Title = pos.Title
            };
        }

        public PositionViewModel FindById(int id)
        {
            var position = db.Positions.Find(id);
            return position != null ? PosDto(position) : null;
        }

        public PositionViewModel Create(PositionViewModel position)
        {
            var pos = FromPos(position);
            db.Positions.Add(pos);
            db.SaveChanges();

            pos.PositionId = position.PositionId;
            return PosDto(pos);

        }

        private static Position FromPos(PositionViewModel position)
        {
            var pos = new Position
            {
                PositionId = position.PositionId,
                Title = position.Title
            };
            return pos;
        }

        public PositionViewModel Save(PositionViewModel position)
        {
            var pos = FromPos(position);
            db.Entry(pos).State = EntityState.Modified;
            db.SaveChanges();

            return PosDto(pos);
        }

        public void Delete(int id)
        {
            Position position = db.Positions.Find(id);
            db.Positions.Remove(position);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}