﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryVO
{
    public class ReleaseVO
    {
        public int release_no { get; set; }
        public int release_seq { get; set; }
        public int product_id { get; set; }
        public DateTime release_plan_date { get; set; }
        public DateTime release_date { get; set; }
        public int order_request_quantity { get; set; }
        public int release_quantity { get; set; }
        public string release_status { get; set; }

        public int company_id { get; set; }
        public DateTime first_regist_time { get; set; }
        public string first_regist_employee { get; set; }
        public DateTime final_regist_time { get; set; }
        public string final_regist_employee { get; set; }
    }
}