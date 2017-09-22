using System.Text.RegularExpressions;

namespace MONO.Distribution.Utility
{
    public class CheckPageVariable
    {
        private int count = 0;
        ResultMessage _result = new ResultMessage();
        private void AddErrorMessage(string key, string value)
        {
            _result.Errors.Add(key, value);
        }

        public ResultMessage GetResultMessage()
        {
            return _result;
        }

        public CheckPageVariable AddErrorMsg(string key,string value)
        {
            AddErrorMessage(key, value);
            return this;
        }

        public CheckPageVariable CheckInputValue(string value, int length, string errorKey, string errorValue)
        {
            if (value.Length > length)
            {
                AddErrorMessage(errorKey, errorValue);
            }
            return this;
        }

        public CheckPageVariable CheckInputValueIsEmpty(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                AddErrorMessage(value + count + "error", value + "不能为空");
                count++;
            }
            return this;
        }
        public CheckPageVariable CheckInputValueIsEmpty(string value, string errorMsg)
        {
            if (string.IsNullOrEmpty(value))
            {
                AddErrorMessage(value + count + "error", errorMsg );
                count++;
            }
            return this;
        }

        public CheckPageVariable CheckInputValue(string value, string compareValue, string errorKey, string errorValue)
        {
            if (value.Equals(compareValue))
            {
                AddErrorMessage(errorKey, errorValue);
            }
            return this;
        }

        public CheckPageVariable CheckInputValueIsCompare(string value, string compareValue, string errorKey, string errorValue)
        {
            if (!value.Equals(compareValue))
            {
                AddErrorMessage(errorKey, errorValue);
            }
            return this;
        }


        public CheckPageVariable CheckUserPhoneFormat(string value, string errorKey, string errorValue)
        {
            if (!Regex.IsMatch(value, suserPhoneReg))
            {
                _result.Errors.Add(errorKey, errorValue);
            }
            return this;
        }

        public CheckPageVariable CheckIsNumber(string value, string errorKey, string errorValue)
        {
            if (!Regex.IsMatch(value, numReg))
            {
                _result.Errors.Add(errorKey, errorValue);
            }
            return this;
        }

        public CheckPageVariable CheckInputLength(string value, int length,string errorKey, string errorValue)
        {
            if (value.Length != length)
            {
                _result.Errors.Add(errorKey, errorValue);
            }
            return this;
        }
        
        private string suserPhoneReg = @"^(0|86|17951)?(13[0-9]|15[012356789]|17[678]|18[0-9]|14[57])[0-9]{8}$";

        private string numReg = "^[0-9]*$";
    }
}
