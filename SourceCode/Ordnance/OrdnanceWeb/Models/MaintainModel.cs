using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrdnanceWeb.Models
{
	public class MaintainModel
	{
		/// <summary>
		/// 军械ID
		/// </summary>
		public int Maintain_ID { get; set; }

		/// <summary>
		/// 军械名称
		/// </summary>
		public string Maintain_Name { get; set; }

		/// <summary>
		/// 军械批次
		/// </summary>
		public string Maintain_Batch { get; set; }

		/// <summary>
		/// 仓库ID
		/// </summary>
		public string Maintain_WarehouseID { get; set; }

		/// <summary>
		/// 仓库名称
		/// </summary>
		public string Maintain_WarehouseName { get; set; }

		/// <summary>
		/// 军械维修数量
		/// </summary>
		public int Maintain_Num { get; set; }

		/// <summary>
		/// 军械维修时间
		/// </summary>
		public string Maintain_Time { get; set; }
	}
}