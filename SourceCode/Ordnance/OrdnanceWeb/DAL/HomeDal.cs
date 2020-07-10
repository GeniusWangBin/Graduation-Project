using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OrdnanceWeb.DAL
{
    public class HomeDal
    {
        public DataTable GetHomeChartData()
        {

            string sql = @"select Army_Name,SUM(ReportNum) as ReportNum,SUM(BorrowNum)as BorrowNum,SUM(ScrapNum)  as  ScrapNum
                        from (
                        select Army_Name,Sum(isNull(ORT.Report_Num,0)) as ReportNum,0 BorrowNum, 0 ScrapNum  from Ord_ArmyTable OAT left join Ord_ReportTable ORT on OAT.Army_ID=ORT.Report_ArmyID and ORT.Report_Status=3  Group by Army_Name
                        UNION all
                        select Army_Name,0 ReportNum,Sum(isNull(ORT.Borrow_Num,0)) as BorrowNum, 0 ScrapNum  from Ord_ArmyTable OAT left join Ord_BorrowTable ORT on OAT.Army_ID=ORT.Borrow_ArmyID and ORT.Borrow_Status in (2,3) Group by Army_Name
                        UNION all
                        select Army_Name,0 ReportNum, 0 BorrowNum ,Sum(isNull(ORT.Scrap_Num,0)) as ScrapNum from Ord_ArmyTable OAT left join Ord_ScrapTable ORT on OAT.Army_ID=ORT.Scrap_ArmyID  Group by Army_Name

                        ) CC
                        Group by Army_Name";

            DataTable dt = DBHelper.reDs(sql);
            return dt;
        }
        
    }
}