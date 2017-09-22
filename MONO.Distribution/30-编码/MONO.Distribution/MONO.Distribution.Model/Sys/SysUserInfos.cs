namespace MONO.Distribution.Model.Sys
{
    public class SysUserInfos : ModelBase
    {
        public SysUserInfos()
        {

        }
        public virtual int UserInfoKey { get; set; }
        public virtual int SysUserKey { get; set; }
        public virtual string Name { get; set; }
        public virtual string WorkNumber { get; set; }
        public virtual string Sex { get; set; }
        public virtual string IDNumber { get; set; }
        public virtual string Mobile { get; set; }
        public virtual string CompanyTelephone { get; set; }
        public virtual string Post { get; set; }
        public virtual string Mail { get; set; }
        public virtual string Remark { get; set; }


        // public virtual FB_Enumeration EnumSex { get; set; }
    }
}

