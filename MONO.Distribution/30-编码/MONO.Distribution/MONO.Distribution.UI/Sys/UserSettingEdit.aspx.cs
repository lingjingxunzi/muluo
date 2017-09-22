using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.BaseInfo;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.BLL.Interface.BaseInfo;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Model.BaseInfo;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.UIProcess;

namespace MONO.Distribution.UI.Sys
{
    public partial class UserSettingEdit : EditPageBase
    {
        public UserSettingEdit()
        {
            _systemUsersService = new SystemUsersService();
            _flowBaseInfoService = new FlowBaseInfoService();
            _messageTemplateService = new MessageTemplateService();
            _sysUserGroupsService = new SysUserGroupsService();
            _discountsService = new DiscountsService();
            _systemFlowPacketsService = new SystemFlowPacketsService();
            _systemSettingService = new SystemSettingService();
            _systemnTemplatesService = new SystemMsgTemplatesService();
            _systemAccountService = new SystemAccountService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUserGroup();
                BindFlowInfo();
                BindMessageTemplete();
                BindDiscountInfo();
            }
        }

        private void BindDiscountInfo()
        {
            var list = _discountsService.FindAll(new Discounts());
            this.ddlCTDis.DataSource = list;
            this.ddlCTDis.DataTextField = "Deduction";
            this.ddlCTDis.DataValueField = "DiscountKey";
            this.ddlCTDis.DataBind();


            this.ddlCMDis.DataSource = list;
            this.ddlCMDis.DataTextField = "Deduction";
            this.ddlCMDis.DataValueField = "DiscountKey";
            this.ddlCMDis.DataBind();

            this.ddlCUDis.DataSource = list;
            this.ddlCUDis.DataTextField = "Deduction";
            this.ddlCUDis.DataValueField = "DiscountKey";
            this.ddlCUDis.DataBind();


        }

        protected override void SetInsert()
        {
            base.SetInsert();

        }

        protected override void SetUpdate()
        {
            base.SetUpdate();
        }




        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (ValidateInfo()) return;
            var systemUser = new SystemUsers();
            GetUserInfo(systemUser);
            var systemUserResult = _systemUsersService.Insert(systemUser);
            if (systemUserResult.IsOk)
            {
                _systemAccountService.Insert(new SystemAccount { SysUserKey = systemUserResult.Id, LeftAccount = 0, TotalAccount = 0 });
                foreach (var fp in systemUser.SystemFlowPacketses)
                {
                    fp.SysUserKey = systemUserResult.Id;
                    _systemFlowPacketsService.Insert(fp);
                }
                systemUser.SystemSetting.SysUserKey = systemUserResult.Id;
                _systemSettingService.Insert(systemUser.SystemSetting);
                foreach (var temp in systemUser.SysterMsgTemplateses)
                {
                    temp.SysUserKey = systemUserResult.Id;
                    _systemnTemplatesService.Insert(temp);
                }
            }
            ResultMessage = systemUserResult;
            OperationEnd("系统用户管理", "新增账户-" + txtAccounts.Text);
        }

        private bool ValidateInfo()
        {

            if (string.IsNullOrEmpty(txtAccounts.Text.Trim()))
            {
                lblErrorBase.Text = "*账户名不能为空！";
                lblErrorBase.Visible = true;
                return true;
            }
            if (string.IsNullOrEmpty(txtScrect.Text.Trim()))
            {
                lblErrorBase.Text = "*密码不能为空！";
                lblErrorBase.Visible = true;
                return true;
            }

            if (ddlGroup.SelectedValue.Equals("0"))
            {
                lblErrorBase.Text = "*用户分组未选择！";
                lblErrorBase.Visible = true;
                return true;
            }
            return false;
        }



        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }





        private void BindFlowInfo()
        {
            var flowList = _flowBaseInfoService.FindAll(new FlowBaseInfo());
            this.repFlowList.DataSource = flowList;
            this.repFlowList.DataBind();
        }


        private void GetUserInfo(SystemUsers systemUser)
        {
            systemUser.Account = txtAccounts.Text;
            systemUser.PWD = txtScrect.Text;
            systemUser.Status = ddlStatus.SelectedValue;
            systemUser.GroupKey = int.Parse(ddlGroup.SelectedValue);
            systemUser.CurrentUserId = this.CurrentUser.SysUserKey;
            systemUser.ParentKey = CurrentUser.SysUserKey;
            GetSystemSettingInfo(systemUser);
            GetFlowSettingInfo(systemUser);
            GetMsgTempSetting(systemUser);
        }




        private void GetFlowSettingInfo(SystemUsers systemUser)
        {
            var systemFlowPacketses = new List<SystemFlowPackets>();
            if (radAll.Checked)
            {
                GetAllFlowSetting(systemFlowPacketses);
            }
            if (radSome.Checked)
            {
                GetSomeFlowSetting(systemFlowPacketses);
            }
            systemUser.SystemFlowPacketses = systemFlowPacketses;
        }

        private void GetSomeFlowSetting(List<SystemFlowPackets> systemFlowPacketses)
        {
            var flowIdStr = flowSomeId.Value;
            var flowStrArr = flowIdStr.Split('|');
            foreach (var s in flowStrArr)
            {
                var sArr = s.Split('_');
                if (sArr.Length == 3)
                {
                    var flowInfo = _flowBaseInfoService.FindById(int.Parse(sArr[1]));
                    var disInfo = _discountsService.SelectDiscountsByDeduction(int.Parse(sArr[2]));
                    var systemFlowPackets = new SystemFlowPackets
                    {
                        FlowPacketKey = int.Parse(sArr[1]),
                        DiscountKey = disInfo.DiscountKey,
                        Price = (disInfo.Deduction * flowInfo.StandardPrice) / 100,
                        Status = "Y"
                    };
                    systemFlowPacketses.Add(systemFlowPackets);
                }
            }
        }

        private void GetMsgTempSetting(SystemUsers systemUser)
        {
            IList<SystemMsgTemplates> systemMsgTemplateses = new List<SystemMsgTemplates>();
            var msgList = _messageTemplateService.FindAll(new MessageTemplate());
            GetSuccessTempSetting(msgList, systemMsgTemplateses);
            //GetFaildTempSetting(msgList, systemMsgTemplateses);
            GetTemporaryTempSetting(msgList, systemMsgTemplateses);
            systemUser.SysterMsgTemplateses = systemMsgTemplateses;
        }

        private void GetTemporaryTempSetting(IList<MessageTemplate> msgList, IList<SystemMsgTemplates> systemMsgTemplateses)
        {
            var hidStr = TemporaryStrs.Value;
            if (!string.IsNullOrEmpty(hidStr))
            {
                var strList = hidStr.Split('|');
                foreach (var s in strList)
                {
                    var str = s.Split('_');
                    if (str.Length == 2)
                    {
                        var temp = new SystemMsgTemplates
                        {
                            MessageTemplateKey = int.Parse(str[1])
                        };
                        systemMsgTemplateses.Add(temp);
                    }
                }
            }
        }

        private void GetFaildTempSetting(IList<MessageTemplate> msgList, IList<SystemMsgTemplates> systemMsgTemplateses)
        {
            var hidStr = faildStrs.Value;
            if (!string.IsNullOrEmpty(hidStr))
            {
                var strList = hidStr.Split('|');
                foreach (var s in strList)
                {
                    var str = s.Split('_');
                    if (str.Length == 2)
                    {
                        var temp = new SystemMsgTemplates
                        {
                            MessageTemplateKey = int.Parse(str[1])
                        };
                        systemMsgTemplateses.Add(temp);
                    }
                }
            }
        }

        private void GetSuccessTempSetting(IList<MessageTemplate> msgList, IList<SystemMsgTemplates> systemMsgTemplateses)
        {
            if (ckbIsSend.Checked)
            {
                var hidStr = SuccStrs.Value;
                if (!string.IsNullOrEmpty(hidStr))
                {
                    var strList = hidStr.Split('|');
                    foreach (var s in strList)
                    {
                        var str = s.Split('_');
                        if (str.Length == 2)
                        {
                            var temp = new SystemMsgTemplates
                            {
                                MessageTemplateKey = int.Parse(str[1])
                            };
                            systemMsgTemplateses.Add(temp);
                        }
                    }
                }
            }
        }


        private void GetAllFlowSetting(List<SystemFlowPackets> systemFlowPacketses)
        {
            var flowAll = _flowBaseInfoService.FindAll(new FlowBaseInfo());
            foreach (var flowInfo in flowAll)
            {
                var systemFlowPackets = new SystemFlowPackets { FlowPacketKey = flowInfo.FlowKey };
                switch (flowInfo.From)
                {
                    case "CM":
                        systemFlowPackets.DiscountKey = int.Parse(ddlCMDis.SelectedValue);
                        systemFlowPackets.Price = (int.Parse(ddlCMDis.SelectedItem.Text) * flowInfo.StandardPrice) / 100;
                        break;
                    case "CU":
                        systemFlowPackets.DiscountKey = int.Parse(ddlCUDis.SelectedValue);
                        systemFlowPackets.Price = (int.Parse(ddlCUDis.SelectedItem.Text) * flowInfo.StandardPrice) / 100;
                        break;
                    case "CT":
                        systemFlowPackets.DiscountKey = int.Parse(ddlCTDis.SelectedValue);
                        systemFlowPackets.Price = (int.Parse(ddlCTDis.SelectedItem.Text) * flowInfo.StandardPrice) / 100;
                        break;
                }
                systemFlowPackets.Status = "Y";
                systemFlowPacketses.Add(systemFlowPackets);
            }
        }

        private void GetSystemSettingInfo(SystemUsers systemUser)
        {
            var setting = new SystemSetting
            {
                IsAfterFaildToSave = ckbIsFaildSaved.Checked ? "Y" : "N",
                IsDefaultProvnice = ckbIsProvice.Checked ? "Y" : "N",
                IsSendMsg = ckbIsSend.Checked ? "Y" : "N"
            };
            systemUser.SystemSetting = setting;
        }

        private void BindUserGroup()
        {
            try
            {
                var groups = _sysUserGroupsService.FindAll(new SysUserGroups { IsJurisdiction = "Y", Levels = CurrentUser.SysUserGroups.Levels });
                ddlGroup.DataTextField = "Name";
                ddlGroup.DataValueField = "GroupKey";
                ddlGroup.DataSource = groups;
                ddlGroup.DataBind();
                ddlGroup.Items.Insert(0, new ListItem("请选择", "0"));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void BindMessageTemplete()
        {
            var msgList = _messageTemplateService.FindAll(new MessageTemplate());
            var successMsg = from m in msgList
                             where m.MsgType.Equals("success")
                             select m;
            var failedMsg = from m in msgList
                            where m.MsgType.Equals("failed")
                            select m;
            this.rep_Success.DataSource = successMsg;
            this.rep_Success.DataBind();
            this.rep_faild_turn.DataSource = failedMsg;
            this.rep_faild_turn.DataBind();
        }



        private ISystemUsersService _systemUsersService;
        private IFlowBaseInfoService _flowBaseInfoService;
        private IMessageTemplateService _messageTemplateService;
        private ISysUserGroupsService _sysUserGroupsService;
        private IDiscountsService _discountsService;
        private ISystemFlowPacketsService _systemFlowPacketsService;
        private ISystemSettingService _systemSettingService;
        private ISystemMsgTemplatesService _systemnTemplatesService;
        private ISystemAccountService _systemAccountService;
    }
}