namespace OrganikV1.Common
{
    public class ServiceResponseLoginRegister
    {
        public bool? EmailConfirm { get; set; }
        public int? LoginStatus { get; set; }

        public bool? SignOutStatus { get; set; }

        public int? RoleStatus { get; set; }

        public int? RegisterStatus { get; set; }

        //login
        //false Emailconfirm için gelir
        //1 başarılı
        //2 giriş yapılamadı
        //3 böyle bir kullanıcı yok

        //register
        //1 başarılı
        //2  role status ten gelir role oluşturulamadıgı için
        //3 aynı email ile kayıtlı kullanıcı var


        //SignOutStatus
        //true çıkış başarılı
        //false başarısız
        public static ServiceResponseLoginRegister GetStatus(bool? EmailConfirm, int? LoginStatus, bool? SignOutStatus, int? RoleStatus, int? RegisterStatus)
        {
            return new ServiceResponseLoginRegister
            {
              EmailConfirm=EmailConfirm,
              LoginStatus=LoginStatus,
              SignOutStatus=SignOutStatus,
              RegisterStatus=RegisterStatus,
              RoleStatus=RoleStatus,
            };
        }
    }
}
