using MongoDB.Bson;

namespace DLA.Services
{
    public class IsValidObjectId
    {
        public static bool IsValidId(string id)
        {
            return ObjectId.TryParse(id, out _);
        }
    }
}
