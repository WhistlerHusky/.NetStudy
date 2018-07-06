using System;

namespace NetStudy.InDepth.NewLanguageFeatures
{
    class MoreExpressionBodiedMemberTestClass
    {
        private DateTime _birthday;

        /// <summary>
        /// {get;set;} 처럼 사용하지 않아도됨.
        /// </summary>
        public DateTime Birthday
        {
            get => _birthday;
            set => _birthday = value;
        }
    }
}