﻿using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryDAC
{
    public class OrderDAC : ConnectionAccess
    {

        /// <summary>
        /// SELECT 발주업체 
        /// </summary>
        /// <returns></returns>
        public List<OrderVO> GetCompanyList()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"SELECT company_id, company_name FROM TBL_COMPANY
                                   WHERE company_type = 'Cop'";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        return SqlHelper.DataReaderMapToList<OrderVO>(cmd.ExecuteReader());
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        /// <summary>
        /// SELECT 수불현황 (입출고 현황)
        /// </summary>
        /// <returns></returns>
        public DataTable GetInOutList()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand("SP_INOUT_SELECT", con);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;

                        DataTable dt = new DataTable();
                        con.Open();
                        da.Fill(dt);
                        con.Close();

                        return dt;
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        /// <summary>
        /// 입출고 BINDING
        /// </summary>
        /// <returns></returns>
        public List<InOutVO> GetInOutListBinding()
        {
            try
            {
                List<InOutVO> list = null;

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_INOUT_SELECT";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = SqlHelper.DataReaderMapToList<InOutVO>(reader);
                    cmd.Connection.Close();

                    return list;
                }               
            }
            catch (Exception err)
            {
                throw err;
            }
        }




        /// <summary>
        /// SELECT 발주 제안 리스트
        /// </summary>
        /// <returns></returns>
        public DataTable GetOrderPlanList()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand("SP_ORDERPLAN_SELECT", con);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;

                        DataTable dt = new DataTable();
                        con.Open();
                        da.Fill(dt);
                        con.Close();

                        return dt;
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        /// <summary>
        /// SELECT 발주 LIST
        /// </summary>
        /// <returns></returns>
        public DataTable GetOrderList()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand("SP_ORDER_SELECT", con);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;

                        DataTable dt = new DataTable();
                        con.Open();
                        da.Fill(dt);
                        con.Close();

                        return dt;
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        /// <summary>
        /// SELECT 입고 대기 리스트
        /// </summary>
        /// <returns></returns>
        public DataTable GetWareHouseList()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand("SP_WAREHOUSE_SELECT", con);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;

                        DataTable dt = new DataTable();
                        con.Open();
                        da.Fill(dt);
                        con.Close();

                        return dt;
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        /// <summary>
        /// SELECT 입고 DETAIL LIST
        /// </summary>
        /// <returns></returns>
        public DataTable GetWareHouseDetail(int order_no, int product_id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand("SP_WAREHOUSEDETAIL_SELECT", con);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.AddWithValue("@order_no", order_no);
                        da.SelectCommand.Parameters.AddWithValue("@product_id", product_id);
                        DataTable dt = new DataTable();
                        con.Open();
                        da.Fill(dt);
                        con.Close();

                        return dt;
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

            /// <summary>
            /// 발주 등록
            /// </summary>
            /// <param name="order"></param>
            /// <returns></returns>
            public bool InsertOrder(OrderVO order)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.Connection.Open();
                SqlTransaction tran = cmd.Connection.BeginTransaction();

                try
                {
                    cmd.CommandText = "SP_ORDER_INSERT";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tran;

                    cmd.Parameters.AddWithValue("@company_id", order.company_id);
                    cmd.Parameters.AddWithValue("@first_regist_employee", order.first_regist_employee);
                    cmd.Parameters.AddWithValue("@final_regist_employee", order.final_regist_employee);

                    int num = Convert.ToInt32(cmd.ExecuteScalar());

                    cmd.CommandText = "SP_ORDERDETAIL_INSERT";
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@order_no", num);
                    cmd.Parameters.AddWithValue("@product_id", order.product_id);
                    cmd.Parameters.AddWithValue("@order_request_quantity", order.order_request_quantity);
                    cmd.Parameters.AddWithValue("@order_status", order.order_status);

                    cmd.ExecuteNonQuery();
                    tran.Commit();

                    return true;
                }
                catch (Exception err)
                {
                    tran.Rollback();
                    throw err;
                }
            }
        }


        /// <summary>
        /// 입고 처리
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        public bool InsertWareHouse(WareHouseVO vo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.Connection.Open();
                SqlTransaction tran = cmd.Connection.BeginTransaction();

                try
                {
                    cmd.CommandText = "SP_WAREHOUSE_INSERT";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tran;

                    cmd.Parameters.AddWithValue("@order_no", vo.order_no);
                    cmd.Parameters.AddWithValue("@order_seq", vo.order_seq);
                    cmd.Parameters.AddWithValue("@warehouse_date", vo.warehouse_date);
                    cmd.Parameters.AddWithValue("@warehouse_quantity", vo.warehouse_quantity);
                    cmd.Parameters.AddWithValue("@storage_id", vo.storage_id);

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "SP_STOCK_UPDATE";
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@order_no", vo.order_no);
                    cmd.Parameters.AddWithValue("@product_id",vo.product_id);
                    cmd.Parameters.AddWithValue("@stock_quantity", vo.warehouse_quantity);

                    cmd.ExecuteNonQuery();
                    tran.Commit();

                    return true;
                }
                catch (Exception err)
                {
                    tran.Rollback();
                    throw err;
                }
            }
        }



        /// <summary>
        /// 납기일 변경
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool UpdateOrderDate(DateTime dt, int release_no)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.Connection.Open();
                SqlTransaction tran = cmd.Connection.BeginTransaction();

                try
                {
                    cmd.CommandText = @"UPDATE TBL_RELEASE_DETAIL
                                       SET release_plan_date = @release_plan_date
                                       WHERE release_no = @release_no";
                    cmd.Transaction = tran;

                    cmd.Parameters.AddWithValue("@release_plan_date", dt);
                    cmd.Parameters.AddWithValue("@release_no", release_no);

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"UPDATE TBL_RELEASE
                                       SET final_regist_employee = @final_regist_employee
                                         , final_regist_time = @final_regist_time
                                       WHERE release_no = @release_no";
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@final_regist_employee", "최종사원명");
                    cmd.Parameters.AddWithValue("@final_regist_time", DateTime.Now.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@release_no", release_no);

                    cmd.ExecuteNonQuery();
                    tran.Commit();

                    return true;
                }
                catch (Exception err)
                {
                    tran.Rollback();
                    throw err;
                }
            }
        }

    }
}
