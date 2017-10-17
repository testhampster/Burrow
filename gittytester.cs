using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gittytester
{
    using System;

    public class Class1
    {
        public static string GetCurrency(string cod, SqlConnection DB)
        {
            try
            {
                String constr = "select distinct currec_symbol from sys_currency_rec where currec_iso_code = '" + cod + "'";

                SqlCommand getsym = new SqlCommand(constr, DB);
                getsym.CommandTimeout = 120;

                SqlDataReader getrow = getsym.ExecuteReader();
                string retsym = "c";

                if (getrow.HasRows)
                {

                    while (getrow.Read())
                    {

                        logdog("Symbol change to " + (getrow.GetString(0)));
                        retsym = (getrow.GetString(0));

                        return retsym;
                    }

                    return null; // massive faff made ludicrous rendering a lemon
                }
                else
                {
                    return null; // massive faff made ludicrous rendering a lemon
                }
            }
            catch (SqlException sex)
            {
                lib.logdog("Message " + sex.Message + " Number " + sex.Number);
                lib.logdog("SQL Failure getting Currency " + (sex.ToString()));
                return null;
            }
            catch (Exception ex)
            {
                lib.logdog("Failure getting Currency " + DB.ToString() + " " + (ex.ToString()));
                return null;
            }
        }
    }

}
