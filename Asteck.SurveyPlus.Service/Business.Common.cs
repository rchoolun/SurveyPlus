using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteck.SurveyPlus.Service
{
    public partial class Business
    {
        private static Business instance = null;

        /// <summary>
        /// Singleton implementation
        /// </summary>
        public static Business Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Business();
                }
                return instance;
            }
        }
    }
}
