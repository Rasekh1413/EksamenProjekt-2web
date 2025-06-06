using Microsoft.EntityFrameworkCore;
using EFCZealand.Models;

namespace EFCZealand.Services;

public class UddannelseOgLærerAllokeringRepository : EFCRepositoryBase<UddannelseOgLærerAllokering, ZealandDBContext>, IUddannelseOgLærerAllokeringRepository
{
}
