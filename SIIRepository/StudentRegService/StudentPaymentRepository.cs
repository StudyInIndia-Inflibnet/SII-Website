using SIIModel.StudentRegister;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.StudentRegService
{
    public class StudentPaymentRepository : Base
    {
        public DataSet OPR_STUDENT_PAYMENT(mStudentPayment _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("OPR_STUDENT_PAYMENT", _cn);
                _cmd.Parameters.AddWithValue("@Type", _obj.Type);
                _cmd.Parameters.AddWithValue("@StudentID", _obj.StudentID);
                _cmd.Parameters.AddWithValue("@OrderID", _obj.OrderID);
                _cmd.Parameters.AddWithValue("@Amount", _obj.Amount);
                _cmd.Parameters.AddWithValue("@Currency", _obj.Currency);
                _cmd.Parameters.AddWithValue("@TransactionStatus", _obj.TransactionStatus);
                _cmd.Parameters.AddWithValue("@BankRefNo", _obj.BankRefNo);
                _cmd.Parameters.AddWithValue("@RequestedXMLContent", _obj.RequestedXMLContent);
                _cmd.Parameters.AddWithValue("@ResponseContent", _obj.ResponseContent);
                _cmd.Parameters.AddWithValue("@CreatedIP", _obj.CreatedIP);
                _cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter _adp = new SqlDataAdapter(_cmd);
                DataSet _ds = new DataSet();
                _adp.Fill(_ds);
                _adp.Dispose();
                _cmd.Dispose();
                return _ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _cn.Close();
            }
        }
    }
}
