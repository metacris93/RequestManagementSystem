using System.Linq;
using RequestService.Models;

namespace RequestService.Data;

public class RequestRepository : IRequestRepository
{
    private readonly AppDbContext _context;
    public RequestRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Request> GetAllRequests()
    {
        return _context.Requests.ToList();
    }

    public Request GetRequestById(long id)
    {
        return _context.Requests.FirstOrDefault(p => p.Id == id);
    }

    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }
}
