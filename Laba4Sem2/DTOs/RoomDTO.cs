using System.ComponentModel.DataAnnotations;
using Laba4Sem2.Model;
namespace Laba4Sem2.DTOs
{
    record class RoomDTO
    {
        [Range(0, int.MaxValue)]
        public int RoomId { get; set; }
        public RoomType RoomType { get; set; }
        public List<AccUnit> Animals { get; set; }
    }
}
