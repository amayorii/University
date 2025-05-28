using Laba4Sem2.Model;
namespace Laba4Sem2.DTOs
{
    record class RoomDTO(int RoomId, RoomType RoomType, int Size, int CleaningCost, List<AccUnit> Animals);
}
