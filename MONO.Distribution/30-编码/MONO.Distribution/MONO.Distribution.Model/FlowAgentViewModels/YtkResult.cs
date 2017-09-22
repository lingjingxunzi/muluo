namespace MONO.Distribution.Model.FlowAgentViewModels
{
    public class YtkResult : VatResultBase
    {
        public string orderId { get; set; }

        public string respCode { get; set; }
        public string transNo { get; set; }
         

        public override string GetMsg()
        {
            switch (respCode)
            {
                case "0":
                case "0000":
                    return "成功";
                case "0001":
                    return "等待处理";
                case "1000":
                    return "系统异常，请尽快联系相关运营人员";
                    break;
                case "1001":
                    return "参数错误";
                    break;
                case "1002":
                    return "数字签名验证失败";
                    break;
                case "1003":
                    return "请求服务不存在";
                    break;
                case "1004":
                    return "此地区产品未开通";
                    break;
                case "1005":
                    return "IP地址错误";
                    break;
                case "1006":
                    return "请求时间错误";
                    break;
                case "1007":
                    return "订购请求重复提交";
                    break;
                case "2001":
                    return "用户不存在";
                    break;
                case "2002":
                    return "用户已停机";
                    break;
                case "2003":
                    return "用户状态异常（欠费）";
                    break;
                case "2004":
                    return "用户是黑名单";
                    break;
                case "2005":
                    return "该笔订单已完成订购";
                    break;
                case "2006":
                    return "订购关系不存在";
                    break;
                case "2007":
                    return "与已订购的其他产品冲突";
                    break;
                case "2008":
                    return "不允许变更的产品";
                    break;
                case "2009":
                    return "参数错误";
                    break;
                case "2010":
                    return "用户套餐不能订购该业务";
                    break;
                case "2011":
                    return "其他原因";
                    break;
                case "2012":
                    return "订购失败";
                    break;
                case "2013":
                    return "该地区暂不支持2G用户订购";
                    break;
                case "2014":
                    return "无更多的产品订购（用户当月订购流量包已到达叠加上限）";
                    break;
                case "2015":
                    return "暂时无产品订购，针对预付用户";
                    break;
                case "2016":
                    return "2G/3G融合用户不允许订购";
                    break;
                case "2017":
                    return "用户状态异常（资料不全）";
                    break;
                case "2018":
                    return "用户状态异常（不在有效期）";
                    break;
                case "2019":
                    return "用户主套餐变更，当月不能订购";
                    break;
                case "2020":
                    return "用户服务密码为初始密码";
                    break;
                case "2021":
                    return "用户有正在处理订单";
                    break;
                case "2022":
                    return "该地区暂不支持 4G 用";
                    break;
                case "2023":
                    return "用户状态异常（未查到用户类型）";
                    break;
                case "3001":
                    return "appkey验证无效";
                    break;
                case "3002":
                    return "账户余额不足，请尽快联系相关运营人员";
                    break;
                case "3003":
                    return "账户余额不足，请尽快联系相关运营人员";
                    break;
                case "3004":
                    return "产品编号无效";
                    break;
                case "3005":
                    return "剩余的订购关系数目不足";
                    break;
                case "3006":
                    return "此地区产品未开通";
                    break;
                case "3007":
                    return "活动信息不存在";
                    break;
                case "3008":
                    return "活动已过期";
                    break;
                case "3009":
                    return "活动不包含此产品";
                    break;
                case "3010":
                    return "没有pkgNo的订购权限";
                    break;
                case "3011":
                    return "订单信息已存在，但未提交订购";
                    break;
                case "3201":
                    return "代理商暂停使用";
                    break;
                case "3211":
                    return "代理商交付能力鉴权失败";
                    break;
                case "3212":
                    return "代理商交付能力暂停使用";
                    break;
                case "3213":
                    return "代理商交付密码无效";
                    break;
                case "3221":
                    return "代理商业务鉴权失败";
                    break;
                case "3222":
                    return "代理商业务暂停服务";
                    break;
                case "3223":
                    return "代理商业务暂停服务";
                    break;
                case "3224":
                    return "代理商产品适用手机号鉴权失败";
                    break;
                case "5201":
                    return "订购能力鉴权失败";
                    break;
                case "5202":
                    return "业务能力鉴权失败";
                    break;
                case "5211":
                    return "业务鉴权失败";
                    break;
                case "5212":
                    return "业务暂停使用";
                    break;
                case "5221":
                    return "产品鉴权失败";
                    break;
                case "5222":
                    return "产品暂停使用";
                    break;
                case "5223":
                    return "产品适用地区不匹配";
                    break;
                case "5231":
                    return "供应商产品地区不匹配";
                    break;
                case "5232":
                    return "供应商产品地区不匹配";
                    break;
                case "5233":
                    return "供应商产品地区不匹配";
                    break;
                case "5241":
                    return "供应商鉴权失败";
                    break;
                case "5242":
                    return "供应商暂停服务";
                    break;
                case "4001":
                    return "客户端流水号请求重复订购";
                    break;
                default:
                    return "未知错误";
            }
        }


        public override string GetResult()
        {
            if (respCode.Equals("0000") || respCode.Equals("0"))
                return "0";
            switch (respCode)
            {
                case "0001":
                case "2002":
                case "2003":
                case "2004":
                case "2005":
                case "2006":
                case "2007":
                case "2008":
                case "2009":
                case "2010":
                case "2011":
                case "2012":
                case "2013":
                case "2014":
                case "2015":
                case "2016":
                case "2017":
                case "2018":
                case "2019":
                case "2020":
                case "2021":
                case "2022":
                case "2023":
                    return respCode;
                default:
                    return respCode;
            }
            return respCode;
        }

        public override string GetOrders()
        {
            return orderId;
        }
    }
}
