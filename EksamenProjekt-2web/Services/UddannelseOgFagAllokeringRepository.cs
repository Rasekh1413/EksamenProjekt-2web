using Microsoft.EntityFrameworkCore;
using EFCZealand.Models;

namespace EFCZealand.Services;

public class UddannelseOgFagAllokeringRepository : EFCRepositoryBase<UddannelseOgFagAllokering, ZealandDBContext>, IUddannelseOgFagAllokeringRepository
{
}
