using RequestService.Models;

namespace RequestService.Data;

public interface IRequestRepository
{
  bool SaveChanges();
  IEnumerable<Request> GetAllRequests();
  Request GetRequestById(long id);
}
