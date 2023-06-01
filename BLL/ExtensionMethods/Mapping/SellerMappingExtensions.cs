using BLL.Dto.Users;
using DataAccess.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ExtensionMethods.Mapping
{
    public static class SellerMappingExtensions
    {
        public static Seller ToSeller(this SellerLoginDto sellerDto)
        {
            return new Seller
            {
                UserName = sellerDto.Login
            };
        }
        public static Seller ToSeller(this SellerRegistrationDto sellerDto)
        {
            return new Seller {
                UserName = sellerDto.Login,
                Email = sellerDto.Email
            };
        }
    }
}
