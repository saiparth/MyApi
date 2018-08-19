using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
namespace RestSharpTV
{
	public class ReportGenerator
	{
		public void AddData(string title,List <string>list)
		{

			DataTable dat = new DataTable("HTTPS");
			dat.Columns.Add("Page Title", typeof(String));
			dat.Columns.Add("URL", typeof(String));
			dat.Columns.Add("StatusCode", typeof(String));
			foreach (var item in list)
			{
				dat.Rows.Add(title, item.Split('|')[0], item.Split('|')[1]);
			}
			var d = ConvertDataTableToHtml(dat);
			string filename = @"dream1.html";
			StreamWriter swXLS = new StreamWriter(filename);
			swXLS.Write(d);
			swXLS.Close();


		}
		/// <summary>
		/// Converts dictionary to 2d string array
		/// </summary>
		/// <param name="Dictionary">Dictionary to be converted</param>
		/// <returns>2D string Array</returns>
		private void ConvertDictionaryTo2dStringArray(Dictionary<string, string> Dictionary)
		{

			StringBuilder h = new StringBuilder();
			h.Append("<table> ");
			foreach (KeyValuePair<string, string> item in Dictionary)
			{
				h.Append("<tr><td>" + item.Key + " " + item.Value + "</tr></td>");
			}
			h.Append("</table>");

		}

		public static string ConvertDataTableToHtml(DataTable targetTable)
		{
			string htmlString = "";

			if (targetTable == null)
			{
				throw new System.ArgumentNullException("targetTable");
			}

			StringBuilder htmlBuilder = new StringBuilder();

			//Create Top Portion of HTML Document
			htmlBuilder.Append("<html>");
			htmlBuilder.Append("<head>");
			htmlBuilder.Append("<link rel='stylesheet' href='./Mycss.css'>");
			htmlBuilder.Append("<title>");
			htmlBuilder.Append("Page-");
			htmlBuilder.Append("Dev report");
			htmlBuilder.Append("</title>");
			htmlBuilder.Append("</head>");
			htmlBuilder.Append("<body>");
			htmlBuilder.Append(
	"<table border=\"1px\" cellpadding=\"5\" cellspacing=\"0\" hold=\" / > htmlBuilder.Append(\" style=\"border: solid 1px Black; font - size: small; \">");

			//Create Header Row
			htmlBuilder.Append("<tr align=\"left\" valign=\"top\">");
			int i = 3;
			foreach (DataColumn targetColumn in targetTable.Columns)
			{
				if (i >= 3)
				{
					htmlBuilder.Append("<th align='left' valign='top'>");
					htmlBuilder.Append(targetColumn.ColumnName);
					htmlBuilder.Append("</th>");
				}
				else
				{
					htmlBuilder.Append("<td align='left' valign='top'>");
					htmlBuilder.Append(targetColumn.ColumnName);
					htmlBuilder.Append("</td>");
				}
				i++;
			}

			htmlBuilder.Append("</tr>");

			//Create Data Rows
			foreach (DataRow myRow in targetTable.Rows)
			{
				htmlBuilder.Append("<tr align='left' valign='top'>");

				foreach (DataColumn targetColumn in targetTable.Columns)
				{
					htmlBuilder.Append("<td align='left' valign='top'>");
					htmlBuilder.Append(myRow[targetColumn.ColumnName].ToString());
					htmlBuilder.Append("</td>");
				}

				htmlBuilder.Append("</tr>");
			}

			//Create Bottom Portion of HTML Document
			htmlBuilder.Append("</table>");
			htmlBuilder.Append("</body>");
			htmlBuilder.Append("</html>");

			//Create String to be Returned
			htmlString = htmlBuilder.ToString();

			return htmlString;
		}
	}
}
