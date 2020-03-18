using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCS.Common.Enums.Sys
{
    /// <summary>
    /// 登录类型
    /// </summary>
    public enum eUserLogInattempts
    {
        Success=1,
        InvalidUserNameOrEmailAddress=2,
        InvalidPassword=3,
        UserIsNoActive=4,
        InvalidTenancyName=5,
        TenantIsNotActive=6,
        UserEmailIsNotConfirmed=7,
        UnknownExternalLogin=8,
        LockedOut=9,
        UserPhoneNumberIsNotConfirmed=10
    }
}
