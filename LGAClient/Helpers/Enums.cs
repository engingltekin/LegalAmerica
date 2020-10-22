using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LGAClient.Helpers
{
    public enum RelationShipType
    {
        Spouse = 1,

        Siblings = 2,

        Beneficiary = 3,

        Other = 4
    }

    public enum ClientTypes
    {
        Owner = 1,
        CoOwner,
        ThirdParty
    }
}
