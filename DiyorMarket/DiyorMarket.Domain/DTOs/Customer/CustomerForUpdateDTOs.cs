using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyorMarket.Domain.DTOs.Customer
{
    public record CustomerForUpdateDTOs(
        int Id,
        string FirstName,
        string LastName,
        DateTime DateOfBirth,
        string Email,
        string PhoneNumber
        );
}
