using Microsoft.EntityFrameworkCore;
using EFCZealand.Models;

namespace EFCZealand.Services;

public class AkademiRepository : EFCRepositoryBase<Akademi, ZealandDBContext>, IAkademiRepository
{
}
