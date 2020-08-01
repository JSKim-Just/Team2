﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryVO
{
    public class OrderVO
    {
        public int order_no { get; set; }
        public int company_id { get; set; }
        public string company_name { get; set; }
        public DateTime first_regist_time { get; set; }
        public string first_regist_employee { get; set; }
        public DateTime final_regist_time { get; set; }
        public string final_regist_employee { get; set; }

        public int order_seq { get; set; }
        public int item_id { get; set; }
        public DateTime order_request_date { get; set; }
        public int order_request_quantity { get; set; }
        public string order_status { get; set; }

    }
}